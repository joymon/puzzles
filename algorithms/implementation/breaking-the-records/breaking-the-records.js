exports.breakingRecords = function (scores) {
    let result=scores.reduce(function (context, currentValue) {
        if (currentValue > context.currentMax) {
            context.maxBreaks += 1;
            context.currentMax = currentValue;
        }
        if (currentValue < context.currentMin) {
            context.minBreaks +=1;
            context.currentMin=currentValue;
        }
        return context;
    }, {
        currentMax:scores[0],
        currentMin:scores[0],
        maxBreaks:0,
        minBreaks:0
    });
    return [result.maxBreaks, result.minBreaks];
}