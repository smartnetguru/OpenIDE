Object.clone=function(instance){
    if(!arguments.length)throw new Error("Object.Clone: no argument passed for 'instance'.");
    var clone=null;
    if(instance!=undefined){
        switch(Object.getType(instance)){
            case Boolean:
            case Function:
            case Number:
            case String:
                clone=instance;
                break;
            case Array:
                clone=new Array();
                break;
            case Date:
                clone=new Date(instance.getTime());
                break;
            case Error:
                clone=new Error(instance.toString());
                break;
            case Object:
            default:
                clone=new Object();
                break;
        }
        for(var x in instance){
            if(clone[x]!=instance[x])clone[x]=Object.Clone(instance[x]);
        }
        var glitchedProperties=["constructor","toString","valueOf","toLocaleString","prototype","isPrototypeOf","propertyIsEnumerable","hasOwnProperty","length","unique"];
        for(var g=0;g<glitchedProperties.length;g++){
            var prop=glitchedProperties[g];
            if(typeof(clone[prop])!="undefined"&&clone[prop]!=instance[prop])clone[prop]=instance[prop];
        }
    }else{
        clone=instance;
    }
    return clone;
};

Object.contains=function(expected,actual){
    if(expected==undefined)throw new Error("Object.Contains: 'expected' must be a valid Object.");
    if(actual==undefined)return false;
    if(Object.isType(Array,actual))return Array.Contains(actual,expected);
    if(Object.isType(String,actual))return String.Contains(actual,expected);
    for(var x in expected){
        if(Object.isType(Function,expected[x])){
            var context={Cancel:false,Current:x,Instance:actual,Matches:expected};
            if(!expected[x](actual[x],context))return false;
            if(context.Cancel)break;
        }else{
            if(!Object.equals(expected[x],actual[x]))return false;
        }
    }
    return true;
};

Object.copy=function(target,source,subset){
    for(var x in subset||source){
        if(Object.prototype.hasOwnProperty.call(source,x))target[x]=source[x];
    }
    return target;
};

Object.equals=function(expected,actual,reason){
    if(arguments.length==0)throw new Error("Object.equals: 'expected' must be a valid reference.");
    if(arguments.length==1)throw new Error("Object.equals: 'actual' must be a valid reference.");
    if(Object.Same(expected,actual))return true;
    if(expected==undefined){
        if(!Object.Same(expected,actual)){
            if(reason)reason.Value=String.Format("Object.equals: Expected '{0}', found '{1}'.",String(expected),actual);
            return false;
        }
        return true;
    }
    if(Object.isType(Array,expected))return Array.equals(expected,actual,reason);
    if(Object.isType(Boolean,expected))return Boolean.equals(expected,actual,reason);
    if(Object.isType(Error,expected))return Error.equals(expected,actual,reason);
    if(Object.isType(Function,expected))return Function.equals(expected,actual,reason);
    if(Object.isType(Number,expected))return Number.equals(expected,actual,reason);
    if(Object.isType(String,expected))return String.equals(expected,actual,reason);

    if(typeof(expected)!="object"||actual==undefined){
        if(reason)reason.Value=String.Format("Object.equals: Expected '{0}', found '{1}'.",expected,actual);
        return false;
    }
    var x=null;
    var list={};
    for(x in expected){
        if(!Object.equals(expected[x],actual[x],reason)){
            if(reason)reason.Value=String.Format("Object.equals: property '{0}' does not match. Expected value '{1}', found '{2}'.",x,expected[x],actual[x]);
            return false;
        }
        list[x]=true;
    }
    for(x in actual){
        if(!list[x]){
            if(reason)reason.Value=String.Format("Object.equals: found unexpected property '{0}' on actual, with value '{1}'",x,actual[x]);
            return false;
        }
    }
    return true;
};

Object.forEach=function(object,handler,predicate,context){
    if(object==undefined)throw new Error("Object.ForEach: 'object' must be a valid Object.");
    if(!Object.isType(Function,handler))throw new Error("Object.ForEach: argument 'handler' must be a valid Function pointer.");
    if(predicate!=undefined){
        if(!Object.isType(Function,predicate))throw new Error("Object.ForEach: 'predicate' must be a valid Function pointer.");
    }
    if(!context)context={};
    Object.set(context,{
        Cancel:false,
        Current:null,
        Instance:object,
        Name:''
    });
    var blankObject={};
    for(var prop in blankObject)if(!blankObject[prop])blankObject[prop]=true;
    for(var x in object){
        if(blankObject[x])continue;
        context.Current=object[x];
        context.Name=x;
        if(!predicate||predicate(context.Current,context)){
            handler(context.Current,context);
            if(context.Cancel)break;
        }
    }
    return context;
};

Object.getKeys=function(target){
    if(!Object.isType(Object,target))throw new Error("Object.GetKeys: 'target' must be a valid Object.");
    if(Object.isType(Function,Object.keys))return Object.keys(target);
    var keys=[];
    for(var key in target){
        if(Object.prototype.hasOwnProperty.call(target,key))keys.push(key);
    }
    return keys;
};

Object.getPredicate=function(expected){
    if(expected==undefined)throw new Error("Object.GetPredicate: 'expected' was undefined.");
    return function(actual){
        return Object.isType(expected,actual);
    };
};

Object.getType=function(instance){
    if(instance==undefined)return instance;
    var type=typeof(instance);
    switch(type){
        case "boolean":
            type=Boolean;
            break;
        case "number":
            type=Number;
            break;
        case "function":
            switch(Function.GetName(instance.constructor)){
                case "RegExp":
                    type=RegExp;
                    break;
                case "Function":
                    type=Function;
                    break;
            }
            break;
        case "object":
            type=instance.constructor;
            break;
        case "string":
            type=String;
            break;
    }
    return type;
};

Object.global=function(){
    return Function("return this;")();
};

Object.inherits=function(type,instance){
    if(!Object.isType(Function,type))throw new Error("Object.Inherits: 'type' must be a valid Function pointer.");
    if(instance==undefined)return false;
    var constructor=(Object.isType(Function,instance)&&instance.base)||instance.base||instance.constructor;
    if(!constructor||constructor==constructor.constructor)return false;
    if(constructor==type)return true;
    return Object.isType(type,constructor);
};

Object.implements=function(type,target){
    if(!Object.isType(Function,type&&type.constructor))throw new Error("Object.Implements: 'type' must be a valid Function pointer.");
    if(target==undefined)return false;
    var instance=null;
    if(Object.isType(Function,target)){
        try{
            instance=new target();
        }catch(e){
            // Not a function? Might be a 2. 0_o
            instance=target;
        }
    }else instance=target;
    for(var x in type){
        if(Object.isType(Function,type[x])){
            if(!Object.isType(Function,instance[x]))return false;
            var expectedParams=Function.GetParameters(type[x]);
            var actualParams=Function.GetParameters(instance[x]);
            if(!Array.equals(expectedParams,actualParams))return false;
        }else{
            if(typeof(instance[x])=='undefined')return false;
        }
    }
    return true;
};

Object.isEmpty=function(instance){
    if(instance==undefined)throw new Error("Object.IsEmpty: 'instance' was undefined.");
    if(Object.isType(Array,instance))return Array.IsEmpty(instance);
    if(Object.isType(Boolean,instance))return false;
    if(Object.isType(Date,instance))return false;
    if(Object.isType(Error,instance))return Error.IsEmpty(instance);
    if(Object.isType(Function,instance))return Function.IsEmpty(instance);
    if(Object.isType(Number,instance))return false;
    if(Object.isType(String,instance))return String.IsEmpty(instance);
    for(var x in instance)return false;
    return true;
};

Object.isType=function(type,instance){
    if(type==undefined||typeof(type)!="function")throw new Error("Object.isType: 'type' must be a valid Function pointer.");
    if(instance==undefined)return false;
    switch(type){
        case Function:
            return typeof(instance)=="function";
        case RegExp:
            return instance && instance.constructor && instance.constructor==RegExp;
        case Object:
            return instance&&typeof(instance)=="object"&&!Array.Contains([Array,Boolean,Date,Error,Function],instance.constructor);
        case Error:
            if(instance.constructor&&instance.constructor.toString().toLowerCase()=="[object error]")return true;
            //fallthrough, test constructor
        default:
            if(instance instanceof type)return true;
            if(instance.constructor==type||instance.constructor+''==type+'')return true;
            return Object.Inherits(type,instance);
    }
};

Object.resolve=function(path,rootContainer){
    if(path==undefined)return null;
    var object=null;
    if(Object.isType(Function,path&&path.toString)){
        path=path.toString().split('.');
        var container=rootContainer||Object.Global();
        for(var i=0;i<path.length;i++){
            if(!(container=container[path[i]]))break;
        }
        object=container;
    }
    return object;
};

Object.same=function(expected,actual){
    return expected===actual;
};

Object.set=function(object,properties){
    if(object==undefined)return;
    for(var x in properties){
        var value=properties[x];
        if(value&&typeof(value)=="object"){
            if(object[x]==undefined)object[x]=value;
            Object.set(object[x],value);
        }else object[x]=value;
    }
    return object;
};

Object.extend = function() {
  if (arguments.length === 0)
    return this;

  for (var i = 0; i < arguments.length; i++) {
    for (var property in arguments[i]) {
      if (arguments[i].hasOwnProperty(property))
        this[property] = arguments[i][property];
    }
  }
  return this;
};