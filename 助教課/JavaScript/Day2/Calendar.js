const calendarArea = document.querySelector(".section_Calendar .calendar");

//想用Template!!

//建立日曆
// 7*5 大小 
CreateCalendar()
function CreateCalendar() {
    //表頭
    const thead = document.createElement("thead");
    thead.classList.add("d-flex", "flex-wrap");
    const week = ["SunDay", "MonDay", "TuesDay", "WednesDay", "ThursDay", "FriDay", "SaturDay"]
    const thtr = document.createElement("tr");
    thtr.classList.add("col-12", "d-flex", "flex-wrap", "justify-content-center");
    for (let i = 0; i < week.length; i++) {
        const thtd = document.createElement("td");
        thtd.classList.add("week", "border", "border-2", "border-dark", "p-2");
        thtd.innerText=week[i];
        thtr.appendChild(thtd);
    }
    thead.appendChild(thtr);
    calendarArea.appendChild(thead);

    // 表身
    const tbody = document.createElement("tbody");
    tbody.classList.add("d-flex", "flex-wrap");
    let num = 1;
    for (let i = 0; i < 5; i++) {
        const tr = document.createElement("tr");
        tr.classList.add("col-12", "d-flex", "flex-wrap", "justify-content-center");
        for (let i2 = 0; i2 < 7; i2++) {
            const td = document.createElement("td");
            td.innerText = num;
            td.classList.add("day", "border", "border-2", "border-dark", "p-2");
            num++;
            tr.appendChild(td);
        }
        tbody.appendChild(tr);
    }
    calendarArea.appendChild(tbody);
    num = 1;
}
// 年分
function GetYear(sender) {

}
// 月份
function GetMounth() { }
// 日期
function GetDay() { }

