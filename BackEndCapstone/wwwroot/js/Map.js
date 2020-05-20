var map;
var tour = {};
var destinations = []

var stopNumber = 1;

async function getVenues() {
    try {
        const venues = await fetch(`/User/GetVenues`).then(res => res.json())
        return venues
    }
    catch (err) {
        console.log(err)
    }
}

async function getTours() {
    const tours = await fetch(`/Tour/GetTours/`).then(res => res.json())
    return tours
}

async function getTourByName(name) {
    const foundTour = await fetch(`Tour/GetTourByName?name=${name}`).then(res => res.json())
    return foundTour
}

async function editTour(tourId, formData) {
    const dataObj = await fetch(`/Tour/Edit?id=${tourId}`, {
        method: "Post",
        body: formData
    }).then(res => res.json());

    tour.name = dataObj.name
    tour.saved = dataobj.saved
}

async function createTour(formData) {
    const dataObj = await fetch("/Tour/Create", {
        method: "Post",
        body: formData
    }).then(res => res.json());

    tour = {
        name: dataObj.name,
        userId: dataObj.userId,
        saved: dataObj.saved,
        tourId: dataObj.tourId
    };
}

function generateCard(destination) {

    var newLi = document.createElement("li")
    newLi.style = "font-size: 1.5em !important"
    newLi.id = `dateTimeAdded--${destination.DateTimeAdded}`
    document.getElementById("cards").insertAdjacentElement("beforeend", newLi)

    var newSpan = document.createElement("span")
    newSpan.style = "font-size: 0.75em !important"
    newSpan.id = `span--${destination.DateTimeAdded}`
    document.getElementById(`dateTimeAdded--${destination.DateTimeAdded}`).insertAdjacentElement("beforeend", newSpan)

    var newHeader = document.createElement("h3")
    var newContent = document.createTextNode(`${destination.name}`)
    newHeader.appendChild(newContent)
    document.getElementById(`span--${destination.DateTimeAdded}`).insertAdjacentElement("beforeend", newHeader)

    var newDiv = document.createElement("div")

    newContent = document.createTextNode(`${destination.city}, ${destination.state}`)

    newDiv.appendChild(newContent)

    document.getElementById(`span--${destination.DateTimeAdded}`).insertAdjacentElement("beforeend", newDiv)

    var newButton = document.createElement("button")

    newButton.id = `deleteCard--${destination.DateTimeAdded}`

    newContent = document.createTextNode("Delete")

    newButton.appendChild(newContent)

    document.getElementById(`dateTimeAdded--${destination.DateTimeAdded}`).insertAdjacentElement("beforeend", newButton)

    document.getElementById(`deleteCard--${destination.DateTimeAdded}`).addEventListener("click", async () => {
        await deleteDestination(destination)
    })

}

async function deleteDestination(destination) {
    await fetch(`/Destination/Delete/${destination.destinationId}`, {
        method: "Post",
        headers: {
            "Content-Type": "application/json"
        }
    }).then(() => {
        document.getElementById(`dateTimeAdded--${destination.DateTimeAdded}`).outerHTML = ""
    })

    return dataObj
}

async function createDestination(formData) {
    const dataObj = await fetch("/Destination/Create", {
        method: "Post",
        body: formData
    }).then(res => res.json()).then(res => {
        var destination = {
            name: res.name,
            userId: res.userId,
            tourId: res.tourId,
            DateTimeAdded: res.dateTimeAdded,
            destinationId: res.destinationId,
            city: res.city,
            state: res.state,
        };

        destinations.push(destination);

        if (destinations.length > 0) {
            document.getElementById("saveTourButton").classList.remove("hidden")
        }

        document.getElementById("saveTourButton").addEventListener("click", async () => {

            let formData = new FormData();
            formData.append('name', document.getElementById("tourNameInput2").value)
            formData.append('userId', document.getElementById("userIdInput").value)
            formData.append('saved', true)
            formData.append('tourId', tour.tourId)

            await editTour(tour.tourId, formData)
        })

        generateCard(destination)
    })
}

function addDestination(venue) {

    let formData = new FormData();

    formData.append('name', venue.name)
    formData.append('userId', document.getElementById("userIdInput").value)
    formData.append('tourId', tour.tourId)
    formData.append("dateTimeAdded", new Date())
    formData.append("city", venue.city)
    formData.append("state", venue.state)

    var newDestination = createDestination(formData)
}

async function initMap() {
    
    var venues = await getVenues();
        
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

    venues.forEach(venue => {
        if (venue.userType == "venue") {
                
            var venueLat = parseInt(venue.lat);
            var venueLng = parseInt(venue.lng);
            var venueLatLng = [venueLat, venueLng];
            if (!latlng.includes(venueLatLng)) {
                var marker = new google.maps.Marker({
                    map: map,
                    position: { lat: venueLat, lng: venueLng },
                    title: venue.name
                });

                latlng.push([venueLat, venueLng]);

                google.maps.event.addListener(marker, 'click', (function (marker) {
                    return function () {
                        const contentTarget = document.querySelector("#panel")
                        contentTarget.innerHTML = `<div id="mapPane"><h1>${venue.name}</h1> <h3>${venue.city}, ${venue.state}</h3> <h6>Capacity: ${venue.capacity ? venue.capacity : 100}</h6> <div>${venue.blurb ? venue.blurb : 'we are cool'}</div> <button class="addToTourButton">Add to tour</button></div>`
                        document.getElementById("mapPane").addEventListener("click", event => {
                            if (event.target.nodeName == "BUTTON") {
                                if (tour.name) {
                                    addDestination(venue)
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

    try {
        var foundTour = await getTourByName(document.getElementById("tourNameInput").value)
        alert("You already have a tour by that name. Please pick a different one.")
    }
    catch {
        let formData = new FormData();
        formData.append('name', document.getElementById("tourNameInput").value)
        formData.append('userId', document.getElementById("userIdInput").value)
        formData.append('saved', false)

        await createTour(formData)

        document.getElementById("tourName").classList.remove("hidden")
        document.getElementById("tourNameForm").classList.add("hidden")
        document.getElementById("tourName").innerHTML = document.getElementById("tourNameInput").value

        document.getElementById("editTourButton").classList.remove("hidden")
    }
})

window.addEventListener("beforeunload", function(event) {
    if (event.target.activeElement.id != "tourNameButton") {
        event.preventDefault(); 

        event.returnValue = "If you leave the page, you'll lose unsaved changes to your your. Are you want you want to continue?";
    }
});

document.getElementById("editTourButton").addEventListener("click", event => {
    document.getElementById("tourName").classList.add("hidden")
    document.getElementById("tourNameForm2").classList.remove("hidden")
    document.getElementById("editTourButton").classList.add("hidden")
})

document.getElementById("tourNameButton2").addEventListener("click", async event => {

    event.preventDefault();

    tour.name = document.getElementById("tourNameInput2").value
    document.getElementById("tourNameForm2").classList.add("hidden")
    document.getElementById("tourName").innerHTML = document.getElementById("tourNameInput2").value
    document.getElementById("tourName").classList.remove("hidden")
    document.getElementById("editTourButton").classList.remove("hidden")

    let formData = new FormData();
    formData.append('name', document.getElementById("tourNameInput2").value)
    formData.append('userId', document.getElementById("userIdInput").value)
    formData.append('saved', false)
    formData.append('tourId', tour.tourId)

    await editTour(tour.tourId, formData)
})

$('#mdp-demo').multiDatesPicker();