//物件圖片資料
window.onload = () => {
    //初始化設定
    const iPhoneArea = document.querySelector(".section_iPhone");
    // const iPadArea = document.querySelector(".section_iPad");
    // const MackBook = document.querySelector(".section_MackBook");
    let viewSPU = "iPhone";
    let viewSKU = "iPhone 13mini";
    let productType;
    let porductSKU;
    SetSPU(viewSPU);
    SetSKU(viewSKU);
    //更換商品種類SPU
    function SetSPU(SPU) {
        productType = productTypeArray.filter((item) => item[SPU]);
    }
    //更換商品SKU
    function SetSKU(SKU) {
        porductSKU = productType[0][viewSPU].filter((item) => item["SKU"] == SKU)
    }
    //添加事件
    const productType_Control = document.querySelectorAll(".productType_Control");
    productType_Control.forEach((btn) => {
        btn.addEventListener("click", GetSPU);
    });
    //切換商品
    function GetSPU(event) {
        //SPU更換
        viewSPU = event.target.innerText;
        SetSPU(viewSPU);
        //SKU更換
        viewSKU = productType[0][viewSPU][0]["SKU"];
        SetSKU(viewSKU);
        if (productType.length !== 0) {
            GetSKU();
            GetSKUInfo()
        } else {
            alert("查無商品資料");
        }

    }
    //功能區-載入機型
    function GetSKU() {
        const typeArea = document.querySelector(".type");
        typeArea.innerHTML = "";
        let h2 = document.createElement("h2");
        h2.classList.add("col-12");
        h2.innerText = "機型。 哪一款最適合你？";
        typeArea.appendChild(h2);
        productType.forEach((product) => {
            if (product[viewSPU] !== undefined) {
                product[viewSPU].forEach((pdSKU) => {
                    let button = document.createElement("button")
                    button.classList.add("btn", "btn-outline-primary");
                    button.setAttribute("data-sku", `${pdSKU["SKU"]}`)
                    button.innerText = pdSKU["裝置"];
                    typeArea.appendChild(button);
                })
            }
        })
    }
    //載入SKU資訊-合併
    function GetSKUInfo() {
        GetAppearance()
        GetStorage()
        GetPic()
        GetPrice()
        afterGetSKUInfo()
    }
    //#region 載入商品SKU資訊
    //SKU資訊-載入外觀
    function GetAppearance() {
        const appearanceArea = document.querySelector(".appearance");
        appearanceArea.innerHTML = "";
        let h2 = document.createElement("h2");
        h2.classList.add("col-12");
        h2.innerText = "外觀。 挑選你喜愛的外觀。";
        appearanceArea.appendChild(h2);
        console.log(porductSKU);
        porductSKU.filter((item, index) => {
            item["圖片"].forEach((color) => {
                let div = document.createElement("div");
                div.classList.add("col-1", "p-2", "color-btn", "rounded");
                let img = document.createElement("img");
                img.classList.add("col-12", "rounded-circle");
                img.setAttribute("data-btn-color", `${color["顏色"]}`);
                img.setAttribute("src", `${color["顏色圖片"]}`);
                div.appendChild(img);
                appearanceArea.appendChild(div);
            })

        })

    }
    //SKU資訊-載入儲存裝置
    function GetStorage() {
        const storageArea = document.querySelector(".storage");
        storageArea.innerHTML = "";
        let h2 = document.createElement("h2");
        h2.classList.add("col-12");
        h2.innerText = "儲存裝置。 選擇需要的儲存空間大小。。";
        storageArea.appendChild(h2);
        porductSKU.filter((item) => {
            item["儲存裝置"].forEach((stroage) => {
                let div = document.createElement("div");
                div.classList.add("col-12", "col-md-5", "p-2", "btn", "btn-outline-secondary", "m-2");
                div.innerText = stroage["大小"];
                div.setAttribute("data-price", `${stroage["價格"]}`);
                div.setAttribute("data-stroage", `${stroage["大小"]}`);
                storageArea.appendChild(div);


            })
        })
    }
    //SKU資訊-載入圖片
    function GetPic(color) {
        const picArea = document.querySelector(".pic");
        picArea.innerText = "";
        porductSKU.filter((item) => {
            item["圖片"].forEach((imgCollection, index) => {
                let div = document.createElement("div");
                div.classList.add("col-12","d-none");
                div.classList.add("carousel", "slide", "carousel-inner","carousel-dark")
                div.setAttribute("id", `carousel${index}`)//輪播
                div.setAttribute("data-color", `${imgCollection["顏色"]}`);
                imgCollection["裝置圖片"].forEach((pic, picIndex) => {
                    //#region 輪播
                    let divitem = document.createElement("div");
                    divitem.classList.add("carousel-item");
                    while (picIndex == 0) {
                        divitem.classList.add("active")
                        break;
                    }
                    //#endregion
                    let img = document.createElement("img");
                    img.classList.add("col-12", "item");
                    img.setAttribute("src", `${pic}`);
                    divitem.appendChild(img)
                    div.appendChild(divitem);
                    picArea.appendChild(div);
                })
                //#region 輪播                 
                while(imgCollection["裝置圖片"].length>1){
                    //prev按鈕
                    let button = document.createElement("button");
                    let span = document.createElement("span");
                    span.classList.add("carousel-control-prev-icon");
                    span.setAttribute("aria-hidden", "true");
                    button.appendChild(span.cloneNode(true));
                    span.innerHTML="";
                    button.classList.add("carousel-control-prev");
                    button.setAttribute("data-bs-target", `#carousel${index}`);
                    button.setAttribute("data-bs-slide", `prev`);
                    div.appendChild(button.cloneNode(true));
                    button.innerHTML="";
                    //next按鈕
                    button.classList.remove("carousel-control-prev");
                    span.classList.remove("carousel-control-prev-icon");
                    console.log(span);
                    console.log(button);
                    span.classList.add("carousel-control-next-icon");
                    span.setAttribute("aria-hidden", "true");     
                    button.appendChild(span);
                    button.classList.add("carousel-control-next");
                    button.setAttribute("data-bs-target", `#carousel${index}`)
                    button.setAttribute("data-bs-slide", `next`)
                    div.appendChild(button);
                    break;
                }
                //#endregion
            })

        })
        ChangeAppearance(porductSKU[0]["圖片"][0]["顏色"]);
    };
    //SKU資訊-載入優惠方案???做來要幹嘛阿沒用到阿87878787877878787787
    function GetTradeIn() {
        const tradeInArea = document.querySelector(".tradeIn");
        tradeInArea.innerHTML = "";
        const h2 = document.createElement("h2");
        h2.innerText = "Apple Trade In 換購方案。"
        tradeInArea.appendChild(h2)
        const button = document.createElement("button");
        button.innerText = "選取一款智慧型手機，折抵優惠";
        tradeInArea.appendChild(button.cloneNode(true));
        button.innerText = "無換購"
        tradeInArea.appendChild(button);
    }
    //SKU資訊-獲得價格;
    function GetPrice() {
        const finalPriceArea = document.querySelector(".finalPrice");
        finalPriceArea.innerHTML = "";
        porductSKU.filter((item) => {
            finalPriceArea.innerText += `NT:${parseInt(item["價格"])}`;
        });
    }
    //#endregion

    //#region 生成後互動Function
    function afterGetSKUInfo() {
        const skuBTNCollection = document.querySelectorAll(`[data-sku]`);
        const colorBTNCollation = document.querySelectorAll("[data-btn-color]")
        const stroageBTNCollation = document.querySelectorAll("[data-stroage]")
        skuBTNCollection.forEach((btn) => {
            btn.addEventListener("click", ChangeType);
        })
        colorBTNCollation.forEach((btn) => {
            btn.addEventListener("click", (event) => {
                let color = event.target.getAttribute("data-btn-color")
                ChangeAppearance(color);
            });
        })
        stroageBTNCollation.forEach((btn) => {
            btn.addEventListener("click", ChangeStorage);
        })
    }
    //更換機型 
    function ChangeType(event) {
        viewSKU = event.target.dataset.sku;
        SetSKU(viewSKU);
        GetSKUInfo();
    }
    //更換顯示外觀圖片
    function ChangeAppearance(color) {
        const colorPicCollation = document.querySelectorAll("[data-color]");
        [...colorPicCollation].filter((colorPic) => {
            if (colorPic.dataset.color === color) {
                colorPic.classList.remove("d-none");
            } else {
                colorPic.classList.add("d-none");
            }

        })

    }
    // 更換儲存裝置
    function ChangeStorage(event) {
        const finalPriceArea = document.querySelector(".finalPrice");
        finalPriceArea.innerHTML = "";
        let add = parseInt(event.target.dataset.price);
        let price = parseInt(porductSKU[0]["價格"])
        finalPriceArea.innerHTML = `NT:${price + add}`;

    }
    //#endregion


}

