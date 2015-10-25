String.concat=function(input1,input2,inputN){
    var output=[];
    for(var i=0;i<arguments.length;i++)output.push(arguments[i]||'');
    return output.join('');
}

String.prototype.toCamelCase = function(str) {
    return str
        .replace(/\s(.)/g, function($1) { return $1.toUpperCase(); })
        .replace(/\s/g, '')
        .replace(/^(.)/, function($1) { return $1.toLowerCase(); });
}

String.contains=function(input,pattern,ignoreCase){
    if(arguments.length==0)throw new Error("String.Contains: no argument was passed for 'input'.");
    if(arguments.length==1)throw new Error("String.Contains: no argument was passed for 'pattern'.");
    if(input==undefined||!Object.isType(Function,input.toString))return false;
    if(pattern==undefined||!Object.isType(Function,pattern.toString))return false;
    input=input.toString();
    pattern=pattern.toString();
    if(ignoreCase){
        input=input.toLowerCase();
        pattern=pattern.toLowerCase();
    }
    return input.indexOf(pattern)>-1;
};

String.prototype.capitalize = function () {
    return this.charAt(0).toUpperCase() + this.slice(1);
}

String.format=function(formatString){
    if(!Object.isType(Function,formatString.toString))throw new Error("String.Format: 'formatString' must be convertible to String.");
    var formatArguments=Array.prototype.slice.call(arguments,1);
    return formatString.replace(/\{(\d*)\}/gm,getFormatArgument);
    function getFormatArgument(match,index,position){
        index=parseInt(index);
        if(index>=formatArguments.length)throw new Error(["String.Format: format match index was out of bounds at position [",index,"]."].join(''));
        if(Object.isType(Function,formatArguments[index]&&formatArguments[index].toString))return formatArguments[index].toString();
        return formatArguments[index]+'';
    }
};

String.endsWith=function(input,pattern,ignoreCase){
    if(arguments.length==0)throw new Error("String.EndsWith: no argument was provided for 'input'.");
    if(arguments.length==1)throw new Error("String.EndsWith: no argument was provided for 'pattern'.");
    if(input==undefined||!Object.isType(Function,input.toString))return false;
    if(pattern==undefined||!Object.isType(Function,pattern.toString))return false;
    input=input.toString();
    pattern=pattern.toString();
    if(ignoreCase){
        input=input.toLowerCase();
        pattern=pattern.toLowerCase();
    }
    var index=input.lastIndexOf(pattern);
    return index>=0&&index==input.length-pattern.length;
};

String.equals=function(expected,actual,reason){
    if(!Object.isType(String,expected))throw new Error("String.Equals: 'expected' must contain a valid String.");
    if(actual==undefined)actual=String(actual);
    if(!Object.isType(Function,expected.toString))throw new Error("String.Equals: 'expected' must be convertible to String.");
    if(!Object.isType(Function,actual.toString))throw new Error("String.Equals: 'actual' must be convertible to String.");
    if(expected.toString()!=actual.toString()){
        if(reason)reason.Value=String.Format("String.Equals: Strings did not match. Expected '{0}', found '{1}'.",expected,actual);
        return false;
    }
    return true;
};

String.isEmpty=function(input){
    if(!Object.isType(String,input))throw new Error("String.IsEmpty: 'input' must contain a valid String.");
    return input.length==0;
};

String.pad=function(input,pattern,minimumLength){
    if(!Object.isType(Function,input!=undefined&&input.toString))throw new Error("String.Pad: 'input' must be convertible to String.");
    if(!Object.isType(Function,pattern!=undefined&&pattern.toString))throw new Error("String.Pad: 'pattern' must be convertible to String.");
    if(!Object.isType(Number,minimumLength))throw new Error("String.Pad: 'minimumLength' must be a valid Number.");
    input=input.toString();
    pattern=pattern.toString();
    var difference=minimumLength-input.length;
    if(difference>0&&pattern.length){
        var repeater=(new Array(1+Math.ceil(difference/pattern.length)));
        input=String.Format("{0}{1}",repeater.join(pattern),input);
    }
    return input;
};

String.prototype.interpolate = function(args) {
	var s = '' + this
	for (var i = 0; i < args.length; i++) {
		var reg = new RegExp("\\{" + i + "\\}", "gm")
		s = s.replace(reg, args[i])
	}
	return s
}

String.startsWith=function(input,pattern,ignoreCase){
    if(arguments.length==0)throw new Error("String.StartsWith: no argument was provided for 'input'.");
    if(arguments.length==1)throw new Error("String.StartsWith: no argument was provided for 'pattern'.");
    if(input==undefined||!Object.isType(Function,input.toString))return false;
    if(pattern==undefined||!Object.isType(Function,pattern.toString))return false;
    input=input.toString();
    pattern=pattern.toString();
    if(ignoreCase){
        input=input.toLowerCase();
        pattern=pattern.toLowerCase();
    }
    return input.indexOf(pattern)==0;
};

String.trim=function(input,char1,char2,charN){
    if(input==undefined||!Object.isType(Function,input.toString))throw new Error("String.Trim: 'input' must be convertible to String.");
    input=input.toString();
    var chars=Array.prototype.slice.call(arguments,1);
    if(chars.length){
        for(var i=0;i<chars.length;i++){
            if(chars[i]==undefined||!Object.isType(Function,chars[i].toString))throw new Error(String.Format("String.Trim: char at position [{0}] was not convertible to String.",i));
        }
        input=String.TrimEnd.apply(input,[input].concat(chars));
        input=String.TrimStart.apply(input,[input].concat(chars));
        return input;
    }
    return input.replace(/^\s*|\s*$/g,'');
};

String.trimEnd=function(input,char1,char2,charN){
    if(input==undefined||!Object.isType(Function,input.toString))throw new Error("String.TrimEnd: 'input' must be convertible to String.");
    input=input.toString();
    var chars=Array.prototype.slice.call(arguments,1);
    if(chars.length){
        var found;
        do{
            found=false;
            for(var i=0;i<chars.length;i++){
                if(chars[i]==undefined||!Object.isType(Function,chars[i].toString))throw new Error(String.Format("String.TrimEnd: char at position [{0}] was not convertible to String.",i));
                chars[i]=chars[i].toString();
                if(String.EndsWith(input,chars[i])){
                    input=input.substring(0,input.length-chars[i].length);
                    found=true;
                    break;
                };
            }
        }while(found);
        return input;
    }
    return input.replace(/\s*$/g,'');
};

String.trimStart=function(input,char1,char2,charN){
    if(input==undefined||!Object.isType(Function,input.toString))throw new Error("String.TrimStart: 'input' must be convertible to String.");
    input=input.toString();
    var chars=Array.prototype.slice.call(arguments,1);
    if(chars.length){
        var found;
        do{
            found=false;
            for(var i=0;i<chars.length;i++){
                if(chars[i]==undefined||!Object.isType(Function,chars[i].toString))throw new Error(String.Format("String.TrimStart: char at position [{0}] was not convertible to String.",i));
                chars[i]=chars[i].toString();
                if(String.StartsWith(input,chars[i])){
                    input=input.substring(chars[i].length,input.length);
                    found=true;
                    break;
                };
            }
        }while(found);
        return input;
    }
    return input.replace(/^\s*/g,'');
};