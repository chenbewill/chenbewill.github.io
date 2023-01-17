//宣告
let dataSouceMRT_Station;
let dataSouceMRT_Exits;
let dataSouceUBike;
let MRT_Data
let markers = L.markerClusterGroup()//marker叢集

//DOM OBJ
let map;
const showArea = document.querySelector("#exit")
// function
function initMap() {
    map = L.map('map', {
        center: [25.04749868923793, 121.51709013556446],
        zoom: 12,
    })
    //設定圖層 openstreetmap圖資來源
    let osmUrl = 'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png'
    let osm = new L.TileLayer(osmUrl, { minZoom: 8, maxZoom: 19 });
    map.addLayer(osm)
}
function initDataSource() {
    let MRT_StationRequest = fetch("https://raw.githubusercontent.com/chenbewill/FileStorage/main/MRT_Station");
    let MRT_ExitRequest = fetch("https://raw.githubusercontent.com/chenbewill/FileStorage/main/MRT_Exit");
    Promise.all([MRT_StationRequest, MRT_ExitRequest])
        .then(res => {
            // 因Promise.all回傳是Promise物件
            return Promise.all(res.map(x => x.json()))
        }
        )
        .then((jsonArray) => {
            [dataSouceMRT_Station, dataSouceMRT_Exits] = jsonArray
            dataSouceMRT_Station.forEach((stat) => {
                stat["ExitInfo"] = []
                //排除重複資料 待修正

                dataSouceMRT_Exits.forEach(exit => {

                    if (exit.StationName.Zh_tw == stat.StationName.Zh_tw) {
                        stat.ExitInfo.push({
                            ExitID: exit.ExitID,
                            ExitName: exit.ExitName,
                            LocationDescription: exit.LocationDescription,
                            ExitPosition: exit.ExitPosition
                        })
                    }
                })
            })
            renderStation()
        })
}

function renderStation() {
    dataSouceMRT_Station.forEach((stat) => {
        let marker = L.marker([stat.StationPosition.PositionLat, stat.StationPosition.PositionLon])
        markers.addLayer(marker)
        marker.bindPopup(
            `
            <h4>捷運站名:${stat.StationName.Zh_tw}</h4>
            <p>地址:${stat.StationAddress}</p>
            <p>捷運出口數量:${stat.ExitInfo.length}</p>
            `
        )
        marker.addEventListener("click", showExit.bind(null,stat))
    })
    map.addLayer(markers)
}
function showExit(stat){
    showArea.innerHTML="";
    const ul = document.createElement("ul")
    stat.ExitInfo.forEach((exit, idx) => {
        console.log(exit)
        const ExNameLi = document.createElement("li")
        const AddressLi = document.createElement("li")
        ExNameLi.innerText=`${exit.ExitName.Zh_tw}`
        ul.appendChild(ExNameLi);
        AddressLi.innerText=`地址:${exit.LocationDescription}`;
        ul.appendChild(AddressLi)
    })
    showArea.appendChild(ul)
}


//window.onload
window.onload = () => {
    initMap()
    initDataSource()



}


