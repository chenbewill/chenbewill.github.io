//log
function $log(value) {
    console.log(value);
}
//型別判斷
function $typeof(obj) {
    if (Array.isArray(obj)) {
        //if (obj instanceof Arry) {
        console.log(obj + "is Arry")
        return;
    }
    else {
        console.log(typeof (obj));
        return;
    }
}
//多個範圍內不重複數字
function $Random_number(count, range) {
    let result = []
    for (let i = 0; i < count; i++) {
        let num = Math.floor(Math.random() * range);
        console.log(typeof num);
        //檢查數字是否重複
        if (result.includes(num)) {
            i--;
            continue;
        } else {
            result.push(num);
        }
    }
    return result
}
//縣市路段資料
//時間

export { $log, $typeof,$Random_number }