Date.equals=function(expected,actual,reason){
    if(!Object.isType(Date,expected))throw new Error("Date.Equals: 'expected' must be a valid Date.");
    if(!Object.isType(Date,actual)){
        if(reason)reason.Value="Date.Equals: 'actual' was not a valid Date.";
        return false;
    }
    if(expected.getTime()!=actual.getTime()){
        if(reason)reason.Value=String.Format("Date.Equals: Dates did not match. Expected '{0}', found '{1}'.",expected,actual);
        return false;
    }
    return true;
};

Date.prototype.toMidnight = function () {
    this.setMinutes(0);
    this.setSeconds(0);
    this.setHours(0)
}

Date.format=function(date,formatString){
    if(!Object.isType(Date,date))throw new Error("Date.Format: 'date' must be a valid Date.");
    if(!Object.isType(Function,formatString&&formatString.toString)) throw new Error("Date.Format: 'formatString' must implement toString().");
    switch(formatString){
        case 'd':
            return String.format("{0}/{1}/{2}",date.getMonth()+1,date.getDate(),date.getFullYear());
        default:
            // Freeform format
            var format=formatString
                .replace(/yyyy/gm,'{0}')
                .replace(/yy/gm,'{1}')
                .replace(/MM/gm,'{2}')
                .replace(/M/gm,'{3}')
                .replace(/dd/gm,'{4}')
                .replace(/d/gm,'{5}')
                .replace(/hh/gm,'{6}')
                .replace(/h/gm,'{7}')
                .replace(/HH/gm,'{8}')
                .replace(/H/gm,'{9}')
                .replace(/mm/gm,'{10}')
                .replace(/m/gm,'{11}')
                .replace(/ss/gm,'{12}')
                .replace(/s/gm,'{13}')
                .replace(/tt/gm,'{14}')
                .replace(/ii/gm,'{15}')
                .replace(/i/gm,'{16}');
            var hours=date.getHours();
            var meridianHours=hours>0?hours>12?hours-12:hours:12;
            return String.format(
                format,
                date.getFullYear(),
                String.pad(date.getYear(),0,2),
                String.pad(date.getMonth()+1,0,2),
                date.getMonth()+1,
                String.pad(date.getDate(),0,2),
                date.getDate(),
                String.pad(hours,0,2),
                hours,
                String.pad(meridianHours,0,2),
                meridianHours,
                String.pad(date.getMinutes(),0,2),
                date.getMinutes(),
                String.pad(date.getSeconds(),0,2),
                date.getSeconds(),
                hours<12?'AM':'PM',
                String.pad(date.getMilliseconds(),0,2),
                date.getMilliseconds()
            );
    }
};