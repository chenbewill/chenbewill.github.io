
//宣告
const today = new Date();
let year = today.getFullYear();
let month = today.getMonth();

//目標DOM物件
const monthTitleArea = document.querySelector("#monthDisplay");
const calendarArea = document.querySelector("#calendar");
const nextBtn = document.querySelector("#nextButton");
const backBtn = document.querySelector("#backButton");
const addModalBtn = document.querySelector("#addModalsubmit")
const editModalBtn = document.querySelector("#editModalsubmit")
const addArea = document.querySelector("#addModal");
const todoTitle = addArea.querySelector("#addModaltitle");
const todoContent = addArea.querySelector("#addModalcontent")
const todoDate = document.querySelector("#addModalDate")
const editArea = document.querySelector("#editModal");
const editTodoTitle = editArea.querySelector("#editModaltitle");
const editTodoContent = editArea.querySelector("#editModalcontent")
const editTodoDate = document.querySelector("#editModalDate")


//function
function renderDate() {
    monthTitleArea.innerText = `${year}年，${month + 1}月`;
    calendarArea.innerHTML = "";
    //該月第一天是星期幾
    let dayOfMonth = new Date(year, month, 1).getDay();
    //該月份幾天
    let dateOfMonth = new Date(year, month + 1, 0).getDate();
    //日期計算
    let dateCount = 1;
    //填充日期
    for (let d = 1; d <= dateOfMonth + dayOfMonth; d++) {
        let dayDiv = document.createElement("div");
        dayDiv.classList.add("day");
        if (d <= dayOfMonth) {
            dayDiv.classList.add("padding");
        }
        else {
            dayDiv.innerText = dateCount;
            let forDay = dateCount;
            dayDiv.addEventListener("click", function () {
                bootstrap.Modal.getOrCreateInstance(addModal).show()
                todoDate.value = `${year}-${(month + 1).toString().padStart(2, "0")}-${(forDay).toString().padStart(2, "0")}`;
                todoTitle.value = "";
                todoContent.value = ""
            })
            //讀取Storage取得符合資料
            if (localStorage.getItem(`${year}-${month + 1}-${dateCount}`) != null) {
                let data = JSON.parse(localStorage.getItem(`${year}-${month + 1}-${dateCount}`));
                let ol = document.createElement("ol")
                let li = document.createElement("li")
                li.innerText = data.title;
                li.addEventListener("click", function (event) {
                    let data = JSON.parse(localStorage.getItem(`${year}-${month + 1}-${forDay}`));
                    bootstrap.Modal.getOrCreateInstance(editModal).show()                  
                    editTodoDate.value = `${year}-${(month + 1).toString().padStart(2, "0")}-${forDay.toString().padStart(2, "0")}`;                  
                    editTodoTitle.value=data["title"];
                    editTodoContent.value=data["content"];
                    event.stopPropagation();
                })
                ol.appendChild(li)
                dayDiv.appendChild(ol);
            }
            dateCount++;
        }
        calendarArea.appendChild(dayDiv);
    }
}
function changeMonth(event) {
    if (event.target.id == "backButton") {
        month--;
        if (month == -1) {
            year--;
            month = 11
        }
    } else {
        month++;
        if (month == 12) {
            year++;
            month = 0
        }
    }
    renderDate()
}
function addEvent() {
    nextBtn.addEventListener("click", changeMonth)
    backBtn.addEventListener("click", changeMonth)
    addModalBtn.addEventListener("click", addTodoList)
    editModalBtn.addEventListener("click", editTodoList)
}
function addTodoList(event) {
    const date = new Date(addArea.querySelector("#addModalDate").value)
    let todoItem = {
        title: todoTitle.value,
        content: todoContent.value
    }
    localStorage.setItem(`${year}-${month + 1}-${date.getDate()}`, `${JSON.stringify(todoItem)}`);
    bootstrap.Modal.getOrCreateInstance(addModal).hide()
    renderDate()
}

function editTodoList() {
    const date = new Date(editTodoDate.value)
    let editItem={
        title:editTodoTitle.value,
        content:editTodoContent.value
    }
    localStorage.setItem(`${date.getFullYear()}-${date.getMonth()+1}-${date.getDate()}`,`${JSON.stringify(editItem)}`);
    bootstrap.Modal.getOrCreateInstance(editModal).hide()
    renderDate()
}

window.onload = function () {
    renderDate()
    addEvent()

}