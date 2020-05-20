var map;

var tour = {};
tour.saved = false

var destinations = []

var stopNumber = 1

async function getVenues() {
    try {
        const venues = await fetch(`/User/GetVenues`).then(res => res.json())
        return venues
    }
    catch (err) {
        console.log(err)
    }
}

window.addEventListener("beforeunload", function (event) {
    if (event.target.activeElement.id != "tourNameButton" && event.target.activeElement.id != "saveTourButton") {
        event.preventDefault();

        return confirm("Are you sure you want to leave?")
    }
});

function generateCard(venue) {
    var newLi = document.createElement("li")
    newLi.style = "font-size: 1.5em !important"

    var venueName = venue.name
    if (venueName.includes(" ")) {
        venueName = venueName.split(" ")
        venueName = venueName.join("-")
    }

    var venueCity = venue.city
    if (venueCity.includes(" ")) {
        venueCity = venueCity.split(" ")
        venueCity = venueCity.join("-")
    }

    var venueState = venue.state
    if (venueState.includes(" ")) {
        venueState = venueState.split(" ")
        venueState = venueState.join("-")
    }

    newLi.classList.add(`${venueName}`)
    newLi.classList.add(`${stopNumber}`)
    newLi.classList.add(`${venueCity}`)
    newLi.classList.add(`${venueState}`)
    document.getElementById("cards").insertAdjacentElement("beforeEnd", newLi)

    var contentTarget = document.getElementsByClassName(`${venueName} ${stopNumber} ${venueCity} ${venueState}`)[0]

    var newSpan = document.createElement("span")
    newSpan.style = "font-size: 0.75em !important"
    newSpan.classList.add(`span--${venueName}`)
    newSpan.classList.add(`span--${stopNumber}`)
    contentTarget.insertAdjacentElement("beforeEnd", newSpan)

    var spanTarget = document.getElementsByClassName(`span--${venueName} span--${stopNumber}`)[0]

    var newHeader = document.createElement("h3")
    var newContent = document.createTextNode(`${venue.name}`)
    newHeader.appendChild(newContent)
    spanTarget.insertAdjacentElement("beforeEnd", newHeader)

    var newDiv = document.createElement("div")
    newContent = document.createTextNode(`${venue.city}, ${venue.state}`)
    newDiv.appendChild(newContent)
    spanTarget.insertAdjacentElement("beforeEnd", newDiv)

    var newButton = document.createElement("button")
    newButton.classList.add("deleteCard")
    newButton.classList.add(`${venueCity}`)
    newButton.classList.add(`${stopNumber}`)
    newContent = document.createTextNode("Delete")
    newButton.appendChild(newContent)
    newButton.addEventListener("click", event => {
        newButton.parentElement.outerHTML = ""
    })
    contentTarget.insertAdjacentElement("beforeEnd", newButton)

    document.getElementById("saveTourButton").classList.remove("hidden")

    stopNumber++
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

async function getTourByName(name) {
    const foundTour = await fetch(`Tour/GetTourByName?name=${name}`).then(res => res.json())
    return foundTour
}

async function createDestination(formData) {
    const dataObj = await fetch("/Destination/Create", {
        method: "Post",
        body: formData
    }).then(res => res.json())
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
                    var contentTarget = document.querySelector("#panel")

                    if (contentTarget.hasChildNodes()) {
                        contentTarget.innerHTML = ""
                    }

                    var newDiv = document.createElement("div")
                    newDiv.id = "mapPane"
                    contentTarget.insertAdjacentElement("beforeEnd", newDiv)

                    newDivTarget = document.getElementById("mapPane")

                    var newHeader = document.createElement("h1")
                    var newContent = document.createTextNode(`${venue.name}`)
                    newHeader.appendChild(newContent)
                    newDivTarget.insertAdjacentElement("beforeEnd", newHeader)

                    var newHeader2 = document.createElement("h3")
                    newContent = document.createTextNode(`${venue.city}, ${venue.state}`)
                    newHeader2.appendChild(newContent)
                    newDivTarget.insertAdjacentElement("beforeEnd", newHeader2)

                    var newHeader3 = document.createElement("h6")
                    newContent = document.createTextNode(`${venue.capacity}`)
                    newHeader3.appendChild(newContent)
                    newDivTarget.insertAdjacentElement("beforeEnd", newHeader3)

                    var newDiv2 = document.createElement("div")
                    newContent = document.createTextNode(`${venue.blurb}`)
                    newDiv2.appendChild(newContent)
                    newDivTarget.insertAdjacentElement("beforeEnd", newDiv2)

                    var newButton = document.createElement("button")
                    newButton.classList.add("addToTourButton") 
                    newContent = document.createTextNode("Add to tour")
                    newButton.appendChild(newContent)
                    newButton.addEventListener("click", event => {
                        if (tour.name) {
                            generateCard(venue)
                        }
                        else {
                            alert("You must first enter a tour")
                        }
                    })
                    newDivTarget.insertAdjacentElement("beforeEnd", newButton)

                    contentTarget.classList.remove("hidden")

                }
            })(marker));
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
        tour.name = document.getElementById("tourNameInput").value

        document.getElementById("tourName").classList.remove("hidden")
        document.getElementById("tourNameForm").classList.add("hidden")
        document.getElementById("tourName").innerHTML = document.getElementById("tourNameInput").value

        var newButton = document.createElement("button")
        newButton.id = "editTourButton"
        var newContent = document.createTextNode("Edit tour name")
        newButton.appendChild(newContent)
        newButton.addEventListener("click", event => {
            event.preventDefault()
            document.getElementById("tourName").classList.add("hidden")
            document.getElementById("tourNameForm2").classList.remove("hidden")
            document.getElementById("tourNameInput2").value = tour.name
            newButton.classList.add("hidden")
            document.getElementById("saveTourButton").classList.add("hidden")
            var deleteCards = document.getElementsByClassName("deleteCard")
            var deleteCardsArray = Array.from(deleteCards)
            deleteCardsArray.forEach(dc => {
                dc.classList.add("hidden")
            })
        })
        document.getElementById("tourNameForm2").insertAdjacentElement("afterEnd", newButton)

    }
})


document.getElementById("tourNameButton2").addEventListener("click", event => {

    event.preventDefault();

    tour.name = document.getElementById("tourNameInput2").value
    document.getElementById("tourNameForm2").classList.add("hidden")
    document.getElementById("tourName").innerHTML = document.getElementById("tourNameInput2").value
    document.getElementById("tourName").classList.remove("hidden")
    document.getElementById("editTourButton").classList.remove("hidden")
    document.getElementById("saveTourButton").classList.remove("hidden")
    var deleteCards = document.getElementsByClassName("deleteCard")
    var deleteCardsArray = Array.from(deleteCards)
    deleteCardsArray.forEach(dc => {
        dc.classList.remove("hidden")
    })
})

document.getElementById("saveTourButton").addEventListener("click", async event => {
    var stopList = document.getElementById("cards")
    if (stopList.hasChildNodes()) {

        let formData = new FormData();
        formData.append('name', tour.name)
        formData.append('userId', document.getElementById("userIdInput").value)
        formData.append('saved', true)

        await createTour(formData)

        var stops = stopList.childNodes
        var stopsArray = Array.from(stops)
        stopsArray.forEach(stop => {
            var destination = {
                name: stop.classList[0],
                userId: document.getElementById("userIdInput").value,
                tourId: tour.tourId,
                city: stop.classList[2],
                state: stop.classList[3]
            }
            destinations.push(destination)
        })

        var index = 0
        formData = new FormData();
        destinations.forEach(destination => {
            formData.append("[" + index + "].name", destination.name)
            formData.append("[" + index + "].userId", destination.userId)
            formData.append("[" + index + "].tourId", tour.tourId)
            formData.append("[" + index + "].city", destination.city)
            formData.append("[" + index + "].state", destination.state)

            index++
        })
        await createDestination(formData)

        window.location.href = '/Tour'

    }
    else {
        alert("You can't save an empty tour. Please add some stops")
    }
})

$('#mdp-demo').multiDatesPicker();