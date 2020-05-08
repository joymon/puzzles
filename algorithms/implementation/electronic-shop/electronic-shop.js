exports.electronicShop = function (keyboards,drives,b) {
    let sums=[];
    keyboards.forEach(element => {
        drives.forEach(drivePrice=>{
            sums.push(element+drivePrice);
        });
    });
    sums = sums.filter(s=>s<=b);
    if(sums.length === 0) return -1;
    let max= Math.max(...sums);
    return max;
}