async function getUsers() {
    try {
        const users = await fetch(`/User/GetUsers`).then(res => res.json())
        return users
    }
    catch (err) {
        console.log(err)
    }
}

async function getTours() {
    const tours = await fetch(`/Tour/GetTours/`).then(res => res.json())
    return tours
}

var map;
var tour = {};
var destinations = []

async function initMap() {
    
    var users = await getUsers();
        
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 39.5, lng: -98.35 },
        zoom: 3
    });

    google.maps.event.addListener(map, 'click', function () {
        const contentTarget = document.querySelector("#panel")
        contentTarget.classList.add("hidden")
        contentTarget.innerHTML = ""
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

                function generateCard(user) {
                    document.getElementById("cards").innerHTML += `<h1>${user.name}</h1>`
                    addDestination(user);
                }

                async function addDestination(user) {

                    var tours = await getTours();

                    let formData = new FormData();

                    formData.append('name', user.name)
                    formData.append('userId', document.getElementById("userIdInput").value)

                    const dataObj = await fetch("/Destination/Create", {
                        method: "Post",
                        body: formData
                    }).then(res => res.json());

                    var destination = {
                        name: user.name,
                        userId: document.getElementById("userIdInput").value
                    };

                    destinations.add(destination);
                }

                google.maps.event.addListener(marker, 'click', (function (marker) {
                    return function () {
                        const contentTarget = document.querySelector("#panel")
                        contentTarget.innerHTML = `<div id="mapPane"><h1>${user.name}</h1> <h3>${user.city}, ${user.state}</h3> <h6>Capacity: ${user.capacity ? user.capacity : 100}</h6> <div>${user.blurb ? user.blurb : 'we are cool'}</div> <button class="addToTourButton">Add to tour</button></div>`
                        document.getElementById("mapPane").addEventListener("click", event => {
                            if (event.target.nodeName == "BUTTON") {
                                if (tour.name) {
                                    generateCard(user)
                                }
                                else {
                                    alert("You must first enter a tour")
                                }
                            }
                        })
                        contentTarget.classList.remove("hidden")
                    }
                })(marker));
            }
        }
    })        
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

    tour = {
        name: document.getElementById("tourNameInput").value,
        userId: document.getElementById("userIdInput").value,
        saved: false
    };
    
    document.getElementById("tourName").classList.remove("hidden")
    document.getElementById("tourNameForm").classList.add("hidden")
    document.getElementById("tourName").innerHTML = document.getElementById("tourNameInput").value
})

window.addEventListener("beforeunload", function (e) {
    var confirmationMessage = 'It looks like you have been editing something. '
        + 'If you leave before saving, your changes will be lost.';

    (e || window.event).returnValue = confirmationMessage;
    return confirmationMessage;
});