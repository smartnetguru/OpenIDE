Boolean.equals=function(expected,actual,reason){
    if(!Object.IsType(Boolean,expected))throw new Error("Boolean.Equals: 'expected' must be a valid Boolean.");
    if(!Object.IsType(Boolean,actual)){
        actual=!!actual;
    }
    if(expected!=actual){
        if(reason)reason.Value=String.Format("Boolean.Equals: Booleans did not match. Expected '{0}', found '{1}'.",expected,actual);
        return false;
    }
    return true;
};