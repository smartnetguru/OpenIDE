Function.equals=function(expected,actual,reason){
    if(!Object.isType(Function,expected))throw new Error("Function.equals: 'expected' must be a valid Function pointer.");
    if(!Object.isType(Function,actual)){
        if(reason)reason.Value="Function.equals: 'actual' must be a valid Function pointer.";
        return false;
    }
    if(expected!=actual&&expected.toString()!=actual.toString()){
        if(reason)reason.Value=String.format("Function.equals: function bodies do not match. Expected '{0}', found '{1}'.",expected,actual);
        return false;
    }
    return true;
};

Function.getBody=function(method){
    if(!Object.isType(Function,method))throw new Error("Function.GetBody: 'method' must be a valid Function pointer.");
    var body=method.toString();
    return String.trim(body.slice(body.indexOf('{')+1,body.lastIndexOf('}')));
};

Function.getDelegate=function(method,instance){
    if(!Object.isType(Function,method))throw new Error("Function.GetDelegate: 'method' must be a valid Function pointer.");
    if(!instance)throw new Error("Function.GetDelegate: 'instance' must be a valid Object.");
    var preArgs=Array.prototype.slice.call(arguments,2);
    return function delegate(){
        var args=preArgs.slice(0).concat(Array.prototype.slice.call(arguments,0));
        if(this.constructor===arguments.callee||this.constructor===delegate){
            var argumentList=[];
            for(var i=0;i<args.length;i++)argumentList.push(String.format("args[{0}]",i));
            return Function("constructor","args",String.format("Object.Copy(constructor.prototype,this.constructor.prototype);return new constructor({0});",argumentList.join(','))).apply(this,[method,args]);
        }else{
            return method.apply(instance,args);
        }
    };
};

Function.getName=function(method){
    if(!Object.isType(Function,method))throw new Error("Function.GetName: 'method' must be a valid Function pointer.");
    var funcStr=String.trim(method.toString());
    var name=null;
    if(funcStr.match(/\bfunction\s?([^(]*)\(/)){
        name=String.trim(RegExp.$1);
    }
    return name||"[anonymous]";
};

Function.getParameters=function(method){
    if(!Object.isType(Function,method))throw new Error("Function.GetParameters: 'method' must be a valid Function pointer.");
    var funcStr=method.toString();
    var parenIndex=funcStr.indexOf('(')+1;
    var paramList=funcStr.substring(parenIndex,funcStr.indexOf(')',parenIndex)).replace(/\s/g,'');
    paramList=String.trimEnd(paramList,"/**/");
    if(paramList)return paramList.split(',');
    return [];
};

Function.getTestable=function(method){
    var testables=[
        "if(!this._GetMember)this._GetMember=function(name){return eval(name);};",
        "if(!this._SetMember)this._SetMember=function(name,value){eval(\"if(typeof(\"+name+\")!=\\\"undefined\\\")\"+name+\"=value;\");};"
    ];
    var testableFunc=(typeof(method)=="object"?method.constructor:method).toString().replace(/(function[^{]*\{)(\s*)/g,"$1$2"+testables.join("$2")+"$2");
    return Function(String.format("return false||({0})",testableFunc))();
};

Function.isEmpty=function(method){
    if(!Object.isType(Function,method))throw new Error("Function.isEmpty: 'method' must be a valid Function pointer.");
    var body=method.toString();
    body=body.replace(/^[^{]*{|}\s*$/g,'');
    body=body.replace(/\/\/[^\n]*/g,'');
    while(/\/\*|\*\//.test(body)){
        var startIndex=body.indexOf("/*");
        body=[body.substring(0,startIndex),body.substring(body.indexOf('*/',startIndex)+2)].join('');
    }
    body=String.trim(body);
    return String.isEmpty(body)||body==";";
}

Function.isNamespace=function(target){
    return target&&target.constructor&&target.constructor.IsNamespace===true||false;
};

Function.registerNamespace=function(path,rootContainer){
    if(!Object.isType(Function,path&&path.toString))throw new Error("Function.RegisterNamespace: 'path' must be convertible to String.");
    var nameSpaces=path.toString().split('.');
    var container=rootContainer||Object.Global();
    for(var i=0;i<nameSpaces.length;i++){
        if(!container[nameSpaces[i]]){
            (container[nameSpaces[i]]={}).constructor={IsNamespace:true};
        }
        container=container[nameSpaces[i]];
    }
};

Function.prototype.inherit=function(type,name){
    if(!Object.isType(Function,type&&type.apply))throw new Error(String.format("{0}.Inherit: 'type' must be a valid Function pointer.",name||Function.GetName(this)));
    if(this.base&&this.prototype&&this.prototype.base)throw new Error(String.format("{0}.Inherit: unable to inherit {1}. {0} already inherits {2}.",name||Function.GetName(this),Function.GetName(type),Function.GetName(this.base)));
    this.base=type;
    this.Name=name||'(anonymous)';
    this.prototype=new function(constructor){
        this.base=getBaseDelegate(constructor,type);
        this.constructor=constructor;
        this.valueOf=function(){return constructor;};
    }(this);
    function getBaseDelegate(constructor,baseType){
        var ancestorBase=baseType&&baseType.base&&baseType.prototype.base||null;
        var delegate=function(){
            var classMembers=getMemberMap(this);
            var result=scopeDelegate.apply(this,[baseType,ancestorBase].concat(Array.prototype.slice.call(arguments,0)));
            var baseMembers=getMemberMap(this,classMembers);
            Object.forEach(baseMembers,addBaseMember,null,{Members:classMembers,Target:this,Base:ancestorBase});
            return result;
        }
        delegate.base=ancestorBase;
        delegate.constructor=baseType;
        delegate.valueOf=function(){return baseType;}
        return delegate;
    }
    function addBaseMember(member,context){
        if(Object.isType(Function,member))member=Function.GetDelegate(scopeDelegate,context.Target,member,context.Base);
        if(context.Members.hasOwnProperty(context.Name))context.Target[context.Name]=context.Members[context.Name];
        context.Target.base[context.Name]=member;
    }
    function scopeDelegate(method,scope){
        var base=this.base;
        this.base=scope||null;
        var result=method.apply(this,Array.prototype.slice.call(arguments,2));
        this.base=base;
        return result;
    }
    function getMemberMap(target,exclusions){
        var map={};
        for(var x in target){
            if(!exclusions||exclusions[x]!==target[x])map[x]=target[x];
        }
        return map;
    }
};

Function.prototype.implement=function(type,name){
    var instance=null;
    for(var x in type){
        if(!Object.isType(Function,type[x]))continue;
        if(!Object.isType(Function,this.prototype[x])&&!Object.isType(Function,getInstance(this)[x]))throw new Error(String.format("{0}.Implement: does not implement interface member '{1}'",name||Function.GetName(this),x));
        var expectedParams=Function.GetParameters(type[x]);
        var actualParams=Function.GetParameters(this.prototype[x]||getInstance(this)[x]);
        if(!Array.equals(expectedParams,actualParams))throw new Error(String.format("{0}.Implement: The signature '{0}.{2}({1})' does not match interface member '{4}.{2}({3})'",name||Function.GetName(this),actualParams,x,expectedParams,Function.GetName(Object.isType(Function,type)?type:type.constructor)));
    }
    function getInstance(target){
        if(instance)return instance;
        try{
            instance={};
            target.apply(instance,[]);
            return instance;
        }catch(e){
            instance=null;
            throw new Error(String.format("{0}.Implement: unable to instantiate constructor. {1}",name||Function.GetName(target),e));
        }
    }
};