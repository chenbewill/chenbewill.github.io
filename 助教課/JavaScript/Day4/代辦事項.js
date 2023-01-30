//宣告
let myStorage = window.localStorage;
let localData = [
    // {
    //     state:"",
    //     title: '',
    //     detials: ''
    // }
];
//DOM物件
addTitle = document.querySelector("input");
addBTN = document.querySelector("#button-add");
toDoList = document.querySelector("#todolist");
function addStorage() {
    if (addTitle.value.length == 0) {
        addTitle.value = "無名標題";
    }
    let data = {
        state: false,
        title: addTitle.value,
        detials: "請輸入詳細內容"
    }
    localData.push(data);
    pushLocalData()
    loadStorage();
}
//渲染畫面
function loadStorage() {
    toDoList.innerHTML = "";
    if (myStorage.getItem("data") != null) {
        localData = JSON.parse(myStorage.getItem("data"));
        console.log(localData);
        localData.forEach((item, index) => {
            renderToDoList(null, item, index);
        })
    }
}
function renderToDoList(e, item, idx) {
    let state = item.state;
    let title = item.title;
    let text = item.detials;
    if (text.length == 0) {
        text = "請輸入詳細內容";
    }
    //標題
    let input = document.createElement('input');
    input.classList.add('form-check-input', 'm-0', 'mx-2');
    input.setAttribute('type', 'checkbox');
    input.onclick = tick;
    let divTitle = document.createElement('div');
    divTitle.classList.add("accordion-button", "collapsed");
    divTitle.setAttribute('type', 'button');
    divTitle.setAttribute('data-bs-toggle', 'collapse');
    divTitle.setAttribute('aria-expanded', 'false');
    if (state == true) {
        input.setAttribute("checked", "");
        divTitle.classList.add("bg-body-secondary");
    }
    let p = document.createElement('p');
    p.classList.add('m-0');
    p.innerText = title;
    divTitle.append(input, p);
    let h2 = document.createElement('h2');
    h2.classList.add('accordion-header');
  
    h2.addEventListener('click', openDetail);
    h2.appendChild(divTitle);
    //內容
    let textDetails = document.createElement('textarea');
    textDetails.classList.add('text', 'col-12');
    textDetails.setAttribute("disabled","");
    textDetails.innerText = text;
    //按鈕
    let btnSave = document.createElement('button');
    btnSave.classList.add("btn", "btn-success", "d-none");
    btnSave.addEventListener("click", Save);
    btnSave.innerText = '保存';
    let btnEdit = document.createElement('button');
    btnEdit.classList.add("btn", "btn-warning");
    btnEdit.addEventListener('click', Edit);
    btnEdit.innerText = '編輯';
    let btnDelete = document.createElement('button');
    btnDelete.classList.add("btn", "btn-danger");
    btnDelete.addEventListener('click', Delete);
    btnDelete.innerText = '刪除';
    //按鈕容器
    let divBTN = document.createElement('div');
    divBTN.classList.add('btn-action','text-end');
    divBTN.append(btnSave, btnEdit, btnDelete);
    let divBody = document.createElement('div');
    divBody.classList.add("accordion-collapse", "collapse", "accordion-body","py-1");
    divBody.setAttribute('data-bs-parent', "#todolist");
    divBody.append(textDetails, divBTN);
    let li = document.createElement('li');
    li.setAttribute("data-idx", idx);
    li.classList.add('accordion-item');

    li.append(h2, divBody);
    toDoList.appendChild(li);
    addTitle.value = '';
}
function tick(event) {
    let li = event.target.parentNode.parentNode.parentNode;
    debugger
    let input = event.target;
    let index = li.dataset.idx;
    if(input.checked){
        localData[index].state = true ;
    }else{
        localData[index].state = false;
    }
    pushLocalData()
    loadStorage()
    event.stopPropagation();
}
function Save(event) {
    let parent = event.target.parentNode.parentNode;
    let saveBtn = event.target;
    let editBtn = parent.querySelector(".btn-warning");
    let content = parent.querySelector('.text');
    content.setAttribute("readonly", "");
    content.classList.remove("border","border-secondary","border-2");
    saveBtn.classList.add("d-none");
    editBtn.classList.remove("d-none");
    let label=parent.querySelector("label");
    let input = parent.querySelector("input");
    let li = parent.parentNode;
    let todoTitle = li.querySelector("p");
    todoTitle.innerText = input.value;
    localData[li.dataset.idx].detials = content.value;
    localData[li.dataset.idx].title = input.value;
    pushLocalData();
    label.remove();
    input.remove();
}
function Edit(event) {
    let editBtn = event.target;
    let parent = event.target.parentNode.parentNode;
    let saveBtn = parent.querySelector(".btn-success");
    let content = parent.querySelector('.text');
    let todoTitle = parent.parentNode.querySelector("p");
    content.removeAttribute("readonly");
    content.removeAttribute("disabled");
    content.classList.add("border","border-secondary","border-2");
    saveBtn.classList.remove("d-none");
    editBtn.classList.add("d-none");
    //修改標題
    let label = document.createElement('label');
    label.innerText="標題";
    let input = document.createElement("input");
    input.placeholder = "修改標題";
    input.value = todoTitle.innerText;
    parent.insertBefore(label,content);
    parent.insertBefore(input, content);
}
function Delete(event) {
    let li = event.target.parentNode.parentNode.parentNode;
    let index = li.dataset.idx;
    debugger
    localData.splice(index, 1);
    console.log(localData);
    pushLocalData();
    li.remove();
}
function openDetail(event) {
    let target = event.target.parentNode.parentNode;
    if (event.target.localName != "div") {
        target = target.parentNode;
    }
    let content = target.querySelector('.accordion-body');
    content.classList.toggle('show');
    event.stopPropagation();
}
function pushLocalData() {
    myStorage.setItem("data", JSON.stringify(localData));
}

window.onload = () => {
    loadStorage()
    addBTN.onclick = addStorage;


}

// function cloneAdd() {
//     //怎樣用????
//     let temp = document.querySelector('template');
//     let li = temp.querySelector('li').cloneNode(true);
//     toDoList.appendChild(li);
// }
