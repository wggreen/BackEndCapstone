async function getUsers() {
    try {
        const users = await fetch(`/User/GetUsers`).then(res => res.json())
        return users
    }
    catch (err) {
        console.log(err)
    }
}

var map;

var isDone = false;

var markers = []

async function initMap() {

    var infoWindowOpen = null;
    
    var users = await getUsers();
        
    if (!isDone) {
        
        map = new google.maps.Map(document.getElementById('map'), {
            center: { lat: 39.5, lng: -98.35 },
            zoom: 3
        });
        
        var latlng = []

        users.forEach(user => {
            if (user.userType == "venue") {
                
                var userLat = parseInt(user.lat);
                var userLng = parseInt(user.lng);
                var userLatLng = [userLat, userLng];
                if (!latlng.includes(userLatLng)) {
                    var marker = new google.maps.Marker({
                        map: map,
                        position: { lat: userLat, lng: userLng },
                        title: user.name
                    });

                    latlng.push([userLat, userLng]);

                    google.maps.event.addListener(marker, 'click', (function (marker) {
                        return function () {
                            const contentTarget = document.querySelector(".panel")
                            contentTarget.innerHTML = `<h1>${user.Name}</h1>`
                        }
                    })(marker));

                }
            }
        })        
    }
}

document.getElementById("tourNameButton").addEventListener("click", async event => {
    event.preventDefault();

    let formData = new FormData();
    formData.append('name', document.getElementById("tourNameInput").value)
    formData.append('userId', document.getElementById("userIdInput").value)
    formData.append('saved', false)
    const dataObj = await fetch("/Tour/Create", {
        method: "Post",
        body: formData
    }).then(res => res.json());

    document.getElementById("tourName").classList.remove("hidden")
    document.getElementById("tourNameForm").classList.add("hidden")
    document.getElementById("tourName").innerHTML = document.getElementById("tourNameInput").value
})