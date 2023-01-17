
// 宣告
let monstArray = []
const monstData = [
    {
        id: "",
        type: "A",
        hp: 1,
        armor: 0,
        speed: 1,
        img: "./image/poo-solid.svg"
    },
    {
        id: "",
        type: "B",
        hp: 1,
        armor: 1,
        speed: 2,
        img: "./image/robot-solid.svg"
    },
    {
        id: "",
        type: "C",
        hp: 2,
        armor: 0,
        speed: 3,
        img: "./image/optin-monster.svg"
    },
    {
        id: "",
        type: "D",
        hp: 3,
        armor: 0,
        speed: 4,
        img: "./image/ghost-solid.svg"
    },
]
let steps = 0;
let playerSpeed = 15;
let current = 0;
let level = 1;
let idx = 0;
let intervalArray = [];
let playerInterval = [];
let playerServiseTime = 0;
let mCounter;

//DOM
const player = document.querySelector("#player")
const startBtn = document.querySelector("#startBtn");
let mBornArray = document.querySelectorAll("[monstBorn]");
const moveArray = document.querySelectorAll("[move-id]");
const stateArea = document.querySelector(".state");
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
    right: moveArray[11].getBoundingClientRect()["right"],
    bottom: moveArray[11].getBoundingClientRect()["bottom"],
}


//function
//產生monst物件 ，並打亂其排序
function createMonstOBJ(lv) {
    lv = lv * 2.5;
    console.warn(lv)
    monstArray = [];
    for (let idx = 1; idx <= lv; idx++) {
        let mtype = Math.floor(Math.random() * monstData.length)
        let monst = JSON.parse(JSON.stringify(monstData[mtype]));
        //複製，深淺拷貝問題 sol>JSON轉換
        monst["id"] = idx
        monstArray.push(monst)
    }
    monstArray.sort((a, b) => {
        let random = function () {
            return Math.floor(Math.random() * monstArray.length);
        }

        if (a["id"] - random() > b["id"] - random()) {
            return 1;
        } else if (a["id"] - random() < b["id"] - random()) {
            return -1;
        } else {
            return 0;
        }
    })
    mCounter = monstArray.length
    console.log(monstArray)
}



function playerAction() {
    document.addEventListener("keyup", () => {
        keyOff(event.key)
        checkKey()
    })
    document.addEventListener("keydown", () => {
        player.style.top += 0;
        player.style.right += 0;
        player.style.bottom += 0;
        player.style.left += 0;
        keyOn(event.key)
        checkKey()

    })
    // document.addEventListener("keydown", movePlayer.bind(null, event))
}
let arrowMove = {
    ArrowUp: false,
    ArrowDown: false,
    ArrowLeft: false,
    ArrowRight: false
};
let left, right, up, down
let up_left, up_right
let down_left, down_right

function checkKey() {
    if (arrowMove["ArrowUp"] && arrowMove["ArrowLeft"]) {
        if (up_left != undefined) {
            return
        } else {
            up_left = setInterval(goUpLeft, 100)
        }
    }else {
        clearInterval(up_left)
        up_left=undefined
    }

    if (arrowMove["ArrowUp"] && arrowMove["ArrowRight"]) {
        if (up_right != undefined) {
            return
        } else {
            up_right = setInterval(goUpRight, 100)
        }
    }else {
        clearInterval(up_right)
        up_right=undefined
    }

    if (arrowMove["ArrowDown"] && arrowMove["ArrowLeft"]) {
        if (down_left != undefined) {
            return
        } else {

            down_left = setInterval(goDownLeft, 100)
        }
    }else {
        clearInterval(down_left)
        down_left=undefined
    }
    if (arrowMove["ArrowDown"] && arrowMove["ArrowRight"]) {
        if (down_right != undefined) {
            return
        } else {
            down_right = setInterval(goDownRight, 100)
        }
    } else {
        clearInterval(down_right)
        down_right=undefined
    }



    if (arrowMove["ArrowUp"]&&arrowMove["ArrowRight"]==false&&arrowMove["ArrowLeft"]==false) {
        if (up != undefined) {
            return
        }
        else {
            up = setInterval(goUp, 100)
        }
    } else {
        clearInterval(up)
        up = undefined
    }
    if (arrowMove["ArrowDown"]&&arrowMove["ArrowRight"]==false&&arrowMove["ArrowLeft"]==false) {
        if (down != undefined) {
            return
        } else {
            down = setInterval(goDown, 100)
        }
    } else {
        clearInterval(down)
        down = undefined
    }
    if (arrowMove["ArrowLeft"]&&arrowMove["ArrowUp"]==false&&arrowMove["ArrowDown"]==false) {
        if (left != undefined) {
            return
        } else {
            left = setInterval(goLeft, 100)
        }
    } else {
        clearInterval(left)
        left = undefined

    }
    if (arrowMove["ArrowRight"]&&arrowMove["ArrowUp"]==false&&arrowMove["ArrowDown"]==false) {
        if (right != undefined) {
            return
        } else {
            right = setInterval(goRight, 100)
        }
    } else {
        clearInterval(right)
        right = undefined

    }

}
function keyOn(key) {
    arrowMove[key] = true;
}
function keyOff(key) {
    arrowMove[key] = false
}
function goUp() {
    if (playerCoordinate.top <= moveRange.top) {
        return;
    }
    player.style.top = parseInt(player.style.top) - playerSpeed + "px";
    setPlayerCorrdinate()
}
function goUpLeft() {
    
    if (playerCoordinate.top <= moveRange.top || playerCoordinate.left <= moveRange.left) {
   
        return;
    }
    player.style.top = parseInt(player.style.top) - playerSpeed + "px";
    player.style.left = parseInt(player.style.left) - playerSpeed + "px";
    setPlayerCorrdinate()
}
function goUpRight() {
    if (playerCoordinate.top <= moveRange.top || playerCoordinate.right >= moveRange.right) {
        return;
    }
    player.style.top = parseInt(player.style.top) - playerSpeed + "px";
    player.style.right = parseInt(player.style.right) - playerSpeed + "px";
    setPlayerCorrdinate()
}

function goDown() {
    if (playerCoordinate.bottom >= moveRange.bottom) {
        return;
    }
    player.style.bottom = parseInt(player.style.bottom) - playerSpeed + "px";
    setPlayerCorrdinate()
}
function goDownLeft() {
    if (playerCoordinate.bottom >= moveRange.bottom || playerCoordinate.left <= moveRange.left) {
        return;
    }
    player.style.bottom = parseInt(player.style.bottom) - playerSpeed + "px";
    player.style.left = parseInt(player.style.left) - playerSpeed + "px";
    setPlayerCorrdinate()
}
function goDownRight() {
    if (playerCoordinate.bottom >= moveRange.bottom || playerCoordinate.right >= moveRange.right) {

        return;
    }
    player.style.bottom = parseInt(player.style.bottom) - playerSpeed + "px";
    player.style.right = parseInt(player.style.right) - playerSpeed + "px";
    setPlayerCorrdinate()
}

function goRight() {
    if (playerCoordinate.right >= moveRange.right) {
        return;
    }
    player.style.right = parseInt(player.style.right) - playerSpeed + "px";
    setPlayerCorrdinate()
}
function goLeft() {
    if (playerCoordinate.left <= moveRange.left) {
        return;
    }
    player.style.left = parseInt(player.style.left) - playerSpeed + "px";
    setPlayerCorrdinate()
}
function setPlayerCorrdinate() {
    playerCoordinate["left"] = player.getBoundingClientRect()["left"];
    playerCoordinate["top"] = player.getBoundingClientRect()["top"];
    playerCoordinate["right"] = player.getBoundingClientRect()["right"];
    playerCoordinate["bottom"] = player.getBoundingClientRect()["bottom"];
}

function movePlayer() {

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
            player.style.left = parseInt(player.style.left) - playerSpeed + "px";
            break;
        case "ArrowUp":
            if (playerCoordinate.top <= moveRange.top) {
                return;
            }
            player.style.top = parseInt(player.style.top) - playerSpeed + "px";
            break;
        case "ArrowRight":
            if (playerCoordinate.right >= moveRange.right) {
                return;
            }
            player.style.right = parseInt(player.style.right) - playerSpeed + "px";
            break;
        case "ArrowDown":
            if (playerCoordinate.bottom >= moveRange.bottom) {
                return;
            }
            player.style.bottom = parseInt(player.style.bottom) - playerSpeed + "px";
            break;
    }
    playerCoordinate["left"] = player.getBoundingClientRect()["left"];
    playerCoordinate["top"] = player.getBoundingClientRect()["top"];
    playerCoordinate["right"] = player.getBoundingClientRect()["right"];
    playerCoordinate["bottom"] = player.getBoundingClientRect()["bottom"];
}
function moveMonst(event) {
    //不設定會不能動 !?
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
    //下面兩個寫法一樣，都是啟動屬性內的function
    let mCenter = monstCoordinate.center();
    let pCenter = playerCoordinate["center"]();
    let monstData = JSON.parse(event.dataset.monstobj);
    //此處寫大寫會烙賽...dataset.限制自訂屬性都要小寫
    // 判斷水平 
    if (mCenter.x - pCenter.x > 0) {
        event.style.left = parseInt(event.style.left) - monstData.speed + "px";
    } else if (mCenter.x - pCenter.x < 0) {
        event.style.left = parseInt(event.style.left) + monstData.speed + "px";
    } else {

    }
    // 判斷垂直
    if (mCenter.y - pCenter.y > 0) {
        event.style.top = parseInt(event.style.top) - monstData.speed + "px";
    } else if (mCenter.y - pCenter.y < 0) {
        event.style.top = parseInt(event.style.top) + monstData.speed + "px";
    } else {

    }
    //勝敗 (兩點距離)
    let dx = Math.abs(mCenter["x"] - pCenter["x"]);
    let dy = Math.abs(mCenter["y"] - pCenter["y"]);
    let dis = Math.sqrt(Math.pow(dx, 2) + Math.pow(dy, 2))
    while (dis < player.offsetWidth) {
        intervalArray.forEach(intval => {
            clearInterval(intval)
        })
        arrowMove.ArrowUp = false
        arrowMove.ArrowDown = false
        arrowMove.ArrowLeft = false
        arrowMove.ArrowRight = false
        checkKey()
        alert("死掉囉")
        break;
    }
}
function start() {
    let random = Math.floor(Math.random() * mBornArray.length)
    steps = random + mBornArray.length;
    idx = 0;
    turnAround()
}
function turnAround() {
    current++;
    while (current >= mBornArray.length) {
        current = 0
        break;
    }
    // let id = 1;
    // monstArray[max]
    // 放入monst
    if (idx < monstArray.length) {
        let mdiv = document.createElement("div")
        mdiv.classList.add("monst");
        //此處寫大寫會烙賽...dataset.限制自訂屬性都要小寫
        mdiv.setAttribute("data-monstid", monstArray[idx].id)
        mdiv.setAttribute("data-monsthp", (monstArray[idx].hp + monstArray[idx].armor))
        mdiv.style.backgroundImage = `url(${monstArray[idx].img})`;
        //搞事~
        mdiv.setAttribute("data-monstobj", JSON.stringify(monstArray[idx]))
        //set monst click event
        mdiv.addEventListener("click", attackMonst.bind(event, this))

        idx++;
        mBornArray[current].appendChild(mdiv);
    }
    steps--;
    if (steps > 0) {
        // 遞迴
        setTimeout(turnAround, 100);
    } else {

        startUpMonst()
    }
}
function startUpMonst() {
    let monsts = document.querySelectorAll("[data-monstid]")
    monsts.forEach((item) => {
        intervalArray.push(setInterval(moveMonst.bind(null, item), 100))
    })
}

function calCoordinate(item) {
    return {
        x: (item.right + item.left) / 2,
        y: (item.top + item.bottom) / 2
    }
}
function attackMonst() {
    const monst = event.target;
    let mhp = monst.dataset.monsthp;
    mhp--;
    monst.setAttribute("data-monsthp", mhp);
    if (mhp <= 0) {
        document.querySelector(`[data-monstid="${monst.dataset.monstid}"]`).parentNode.innerHTML = "";
        mCounter--;
        while (mCounter == 0) {
            gameFinish()
            playerRecord();
            break;
        }
    }
}

function gameFinish() {
    alert(`恭喜LV${level}，過關囉`)
    startBtn.disabled = false;
    level++;
    mCounter = 0;
    arrowMove.ArrowUp = false
    arrowMove.ArrowDown = false
    arrowMove.ArrowLeft = false
    arrowMove.ArrowRight = false
    checkKey()
    renderPage()
}
function playerRecord() {
    let record = {
        lv: level
    }
    localStorage.setItem("gameRecord", JSON.stringify(record))
}
function loadRecord() {
    if (localStorage.getItem("gameRecord") == null) {
        level = 1;
    } else {
        let data = JSON.parse(localStorage.getItem("gameRecord"))
        level = data.lv;
    }
}
function renderPage() {
    stateArea.innerText = `Level${level}，怪物數量${monstArray.length}`;
}

window.onload = function () {
    loadRecord()
    startBtn.addEventListener("click", function clearPreviousMonst() {
        console.log(level);
        createMonstOBJ(`${level + 4}`);
        start();
        startBtn.disabled = true;
        renderPage()
    });
    playerAction()
    stateArea.innerText = `Level${level}，怪物數量${monstArray.length}`;
}



