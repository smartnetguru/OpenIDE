Error.equals=function(expected,actual,reason){
    if(!Object.isType(Error,expected))throw new Error("Error.equals: 'expected' must be a valid Error.");
    if(!Object.isType(Error,actual)){
        if(reason)reason.Value="Error.equals: 'actual' was not a valid Error.";
        return false;
    }
    var fields=["name","message","description","number","fileName"];
    for(var i=0;i<fields.length;i++){
        var field=fields[i];
        if(expected.hasOwnProperty(field)&&!Object.equals(expected[field],actual[field])){
            if(reason)reason.Value=String.format("Error.equals: '{0}' did not match. Expected value '{1}', found '{2}'.",field,expected[field],actual[field]);
            return false;
        }
    }
    return true;
};

Error.isEmpty=function(error){
    if(!Object.isType(Error,error))throw new Error("Error.isEmpty: 'error' must be a valid Error.");
    return String.isEmpty(String.trim(error));
};

Error.prototype.toString=function(verbose){
    var message=(this.hasOwnProperty("message")&&!String.isEmpty(this.message)?this.message:this.description);
    if(message==undefined)message='';
    if(!Object.isType(String,message))message=this+'';
    if(verbose){
        if(this.line)message=String.format("{0}\n\t(line: {1})",message,this.line);
        if(this.lineNumber)message=String.format("{0}\n\t(line: {1})",message,this.lineNumber);
        if(this.number)message=String.format("{0}\n\t(number: {1})",message,this.number);
        if(this.stackTrace||this.stack||this.getStack)message=String.format("{0}\n\tStackTrace: {1}",message,this.stackTrace||this.stack||this.getStack());
    }
    return message;
};