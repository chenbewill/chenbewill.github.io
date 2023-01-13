
// 宣告
let monstArray = []
const monstData = [
    {
        type: "A",
        hp: 10,
        armor: 0,
        speed: 1000
    },
    {
        type: "B",
        hp: 9,
        armor: 1,
        speed: 800
    },
    {
        type: "C",
        hp: 1,
        armor: 0,
        speed: 400
    },
    {
        type: "D",
        hp: 1,
        armor: 0,
        speed: 400
    },
    {
        type: "E",
        hp: 1,
        armor: 0,
        speed: 400
    },
]
let steps = 0;
let allSteps = 0;
let current = 0;
let level = 0;
let intervalArray = [];
//DOM
const player = document.querySelector("#player")
const startBtn = document.querySelector("#startBtn");
let mBornArray = document.querySelectorAll("[monstBorn]");
let moveArray = document.querySelectorAll("[move-id]");
mBornArray = Array.from(mBornArray).sort((a, b) => {
    return a.getAttribute("monstBorn") - b.getAttribute("monstBorn")
})
let playerCoordinate = {
    left: player.getBoundingClientRect()["left"],
    top: player.getBoundingClientRect()["top"],
    right: player.getBoundingClientRect()["right"],
    bottom: player.getBoundingClientRect()["bottom"],
    center: function () {
        return calCoordinate(this)
    }
}
let moveRange = {
    left: moveArray[0].getBoundingClientRect()["left"],
    top: moveArray[0].getBoundingClientRect()["top"],
    right: moveArray[8].getBoundingClientRect()["right"],
    bottom: moveArray[8].getBoundingClientRect()["bottom"],
}
let id = 1;

//function
//產生monst物件 
function createMonstOBJ(count) {
    for (let idx = 1; idx <= count; idx++) {
        let mtype = Math.floor(Math.random() * monstData.length)
        let monst = JSON.parse(JSON.stringify(monstData[mtype]));
        //複製，深淺拷貝問題 sol>JSON轉換
        monst["id"] = idx
        monstArray.push(monst)
    }
}

function playerAction() {
    document.addEventListener("keydown", function move(event) {
        //不設定會不能動=_=
        player.style.top += 0;
        player.style.right += 0;
        player.style.bottom += 0;
        player.style.left += 0;
        switch (event.key) {
            case "ArrowLeft":
                if (playerCoordinate.left <= moveRange.left) {
                    return;
                }
                player.style.left = parseInt(player.style.left) - 10 + "px";
                break;
            case "ArrowUp":
                if (playerCoordinate.top <= moveRange.top) {
                    return;
                }
                player.style.top = parseInt(player.style.top) - 10 + "px";
                break;
            case "ArrowRight":
                if (playerCoordinate.right >= moveRange.right) {

                    return;
                }
                player.style.right = parseInt(player.style.right) - 10 + "px";

                break;
            case "ArrowDown":
                if (playerCoordinate.bottom >= moveRange.bottom) {
                    return;
                }
                player.style.bottom = parseInt(player.style.bottom) - 10 + "px";
                break;
        }
        playerCoordinate["left"] = player.getBoundingClientRect()["left"];
        playerCoordinate["top"] = player.getBoundingClientRect()["top"];
        playerCoordinate["right"] = player.getBoundingClientRect()["right"];
        playerCoordinate["bottom"] = player.getBoundingClientRect()["bottom"];

    })
}

function start() {
    let random = Math.floor(Math.random() * mBornArray.length)
    steps = random + (level * mBornArray.length);
    turnAround()
}

function turnAround() {
    mBornArray[current].classList.remove("born")
    current++;
    while (current >= mBornArray.length) {
        current = 0
        break;
    }
    //先不要用隨機這件事情
    if (monstArray.length <= steps) {
        let mdiv = document.createElement("div")
        mdiv.classList.add("monst");
        mdiv.setAttribute("data-monstid", id)
        id++;
        mBornArray[current].classList.add("born")
        mBornArray[current].appendChild(mdiv);
    }
    steps--;
    if (steps > 0) {
        // 遞迴
        setTimeout(turnAround, 100);
    } else {
        startBtn.disabled = false;
        initMonst()
    }
}

function initMonst() {
    let monsts = document.querySelectorAll("[data-monstid]")
    monsts.forEach((item, idx) => {
        intervalArray.push(setInterval(monstMove.bind(null, item), 40))
    })
}
function monstMove(event) {
    event.style.left += 0;
    event.style.top += 0;
    event.style.right += 0;
    event.style.bottom += 0;
    let monstCoordinate = {
        left: event.getBoundingClientRect()["left"],
        top: event.getBoundingClientRect()["top"],
        right: event.getBoundingClientRect()["right"],
        bottom: event.getBoundingClientRect()["bottom"],
        center: function () {
            return calCoordinate(this)
        }
    }
    let mCenter = monstCoordinate.center();
    let pCenter = playerCoordinate["center"]();

    // 判斷水平 
    if (mCenter.x - pCenter.x > 0) {
        event.style.left = parseInt(event.style.left) - 1 + "px";
    } else if (mCenter.x - pCenter.x < 0) {
        event.style.left = parseInt(event.style.left) + 1 + "px";
    } else {

    }
    // 判斷垂直
    if (mCenter.y - pCenter.y > 0) {
        event.style.top = parseInt(event.style.top) - 1 + "px";
    } else if (mCenter.y - pCenter.y < 0) {
        event.style.top = parseInt(event.style.top) + 1 + "px";
    } else {

    }
    //勝敗 (兩點距離)
    // 左上重疊
    let dx = Math.abs(mCenter["x"] - pCenter["x"]);
    let dy = Math.abs(mCenter["y"] - pCenter["y"]);
    let dis = Math.sqrt(Math.pow(dx, 2) + Math.pow(dy, 2));
    // 左下重疊
    while (dis < 10){
        intervalArray.forEach(intval => {
            clearInterval(intval)
        })
        console.log("4")

        alert("死掉囉")
        break;
    }
    
    debugger

    //右上重疊
    // 右下重疊
    // Ml-Pl<0 && Mt-Pb<0
    // while (monstCoordinate["left"] - playerCoordinate["left"] < 0 && monstCoordinate["top"] - playerCoordinate["bottom"] > 0) {
    //     intervalArray.forEach(intval => {
    //         clearInterval(intval)
    //     })
    //     console.log("4")

    //     alert("死掉囉")
    //     break;
    // }





}


window.onload = function () {
    createMonstOBJ(20)
    startBtn.addEventListener("click", function () {
        mBornArray.forEach(element => {
            element.innerHTML = "";
        })
        level++;
        start();
        startBtn.disabled = true;
    });
    playerAction()
}
// left: player.getBoundingClientRect()["left"],
// top: player.getBoundingClientRect()["top"],
// right: player.getBoundingClientRect()["right"],
// bottom: player.getBoundingClientRect()["bottom"],
function calCoordinate(position) {
    let item = {
        x: (position.right + position.left) / 2,
        y: (position.top + position.bottom) / 2
    }
    console.log(item)
    return item
}