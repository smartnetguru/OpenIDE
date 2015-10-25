Number.equals=function(expected,actual,reason){
    if(!Object.isType(Number,expected)){
        expected=parseFloat(expected);
        if(isNaN(expected))throw new Error("Number.Equals: 'expected' must be a valid Number.");
    }
    if(!Object.isType(Number,actual)){
        actual=parseFloat(actual);
        if(isNaN(actual)){
            if(reason)reason.Value="Number.Equals: 'actual' was not convertible to Number.";
            return false;
        }
    }
    if(expected!=actual){
        if(reason)reason.Value=String.Format("Number.Equals: Numbers do not match. Expected '{0}', found '{1}'.",expected,actual);
        return false;
    }
    return true;
};

Number.trim=function(number,decimalPlaces){
    if(!decimalPlaces)decimalPlaces=0;
    var factor=Math.pow(10,decimalPlaces);
    return Math.round(number*factor)/factor;
};

Number.isInteger = function (str) {
    return (/^-?\d+$/.test(str));
}