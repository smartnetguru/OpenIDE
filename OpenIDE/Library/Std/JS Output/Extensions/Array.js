Array.clear=function(array){
    if(!Object.IsType(Array,array))throw new Error("Array.Clear: 'array' must be a valid Array.");
    for(var i=0;i<array.length;i++)array[i]=null;
    array.length=0;
};

Array.prototype.clear = function () {
    this.splice(0, this.length);
};

Array.contains=function(array,expected,predicate){
    if(!Object.IsType(Array,array))throw new Error("Array.Contains: 'array' must be a valid Array.");
    return Array.IndexOf(array,expected,0,predicate)>-1;
};

Array.copy=function(sourceArray,sourceIndex,destinationArray,destinationIndex,length){
    if(!Object.IsType(Array,sourceArray)&&!sourceArray.hasOwnProperty("length"))throw new Error("Array.Copy: 'sourceArray' must be a valid Array.");
    if(sourceIndex==undefined)sourceIndex=0;
    if(!Object.IsType(Number,sourceIndex))throw new Error("Array.Copy: 'sourceIndex' must be a valid Number.");
    if(sourceIndex<0)throw new Error("Array.Copy: 'sourceIndex' may not be negative.");
    if(destinationArray==undefined)destinationArray=[];
    if(!Object.IsType(Array,destinationArray))throw new Error("Array.Copy: 'destinationArray' must be a valid Array.");
    if(destinationIndex==undefined)destinationIndex=0;
    if(!Object.IsType(Number,destinationIndex))throw new Error("Array.Copy: 'destinationIndex' must be a valid Number.");
    if(destinationIndex<0)throw new Error("Array.Copy: 'destinationIndex' may not be negative.");
    if(arguments.length<5){
        length=sourceArray.length-sourceIndex;
    }else{
        if(!Object.IsType(Number,length))throw new Error("Array.Copy: 'length' must be a valid Number.");
        if(length<0)length=sourceArray.length-sourceIndex;
    }
    Array.prototype.splice.apply(destinationArray,[destinationIndex,0].concat(Array.prototype.slice.apply(sourceArray,[sourceIndex,length])));
    return destinationArray;
};

Array.equals=function(expected,actual,reason){
    if(!Object.IsType(Array,expected))throw new Error("Array.Equals: 'expected' must be a valid Array.");
    if(!Object.IsType(Array,actual)){
        if(reason)reason.Value="Array.Equals: 'actual' was not a valid Array.";
        return false;
    }
    if(expected.length!=actual.length){
        if(reason)reason.Value=String.Format("Array.Equals: Expected array of length '{0}', found array of length '{1}'.",expected.length,actual.length);
        return false;
    }
    for(var i=0;i<expected.length;i++){
        if(!Object.Equals(expected[i],actual[i])){
            if(reason)reason.Value=String.Format("Array.Equals: Unexpected value found at position [{0}]. Expected '{1}', found '{2}'.",i,expected[i],actual[i]);
            return false;
        }
    }
    return true;
};

Array.find=function(array,expected,predicate){
    if(!Object.IsType(Array,array))throw new Error("Array.Contains: 'array' must be a valid Array.");
    var index=Array.IndexOf(array,expected,0,predicate);
    if(index>-1)return array[index];
    return null;
};

Array.isEmpty=function(array){
    if(!Object.IsType(Array,array))throw new Error("Array.IsEmpty: 'array' must be a valid Array.");
    return array.length==0;
};

Array.remove=function(array,expected,predicate){
    if(!Object.IsType(Array,array))throw new Error("Array.Remove: 'array' must be a valid Array.");
    var index=Array.IndexOf(array,expected,0,predicate);
    if(index>-1)return array.splice(index,1);
    return null;
};

Array.shuffle=function(array){
    if(!Object.IsType(Array,array))throw new Error("Array.Shuffle: 'array' must be a valid Array.");
    var result=[];
    var target=array.slice(0);
    while(target.length)result.push(target.splice(Math.floor(Math.random()*target.length),1)[0]);
    return result;
};