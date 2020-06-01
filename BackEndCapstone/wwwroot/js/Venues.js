async function getVenues() {
    const venues = await fetch(`/User/GetVenues`).then(res => res.json())
    return venues
}

async function buildList() {
    var states = ["All", "Alaska", "Alabama", "Arkansas", "Arizona", "California", "Colorado", "Connecticut", "District of Columbia", "Delaware", "Florida", "Georgia", "Guam", "Hawaii", "Iowa", "Idaho", "Illinois", "Indiana", "Kansas", "Kentucky", "Louisiana", "Massachusetts", "Maryland", "Maine", "Michigan", "Minnesota", "Missouri", "Mississippi", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Puerto Rico", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Virginia", "Vermont", "Washington", "Wisconsin", "West Virginia", "Wyoming"]

    var selectList = document.createElement("select");
    selectList.id = "statesList";

    document.querySelector(".statesDropdown").insertAdjacentElement("afterbegin", selectList)

    //Create and append the options
    for (var i = 0; i < states.length; i++) {
        var option = document.createElement("option");
        option.value = states[i];
        option.text = states[i];
        selectList.appendChild(option);
    }

    document.getElementById("statesList").value = "All"

    var venues = await getVenues();

    venues.forEach(venue => {
        var venueState = venue.state
        if (venueState.includes(" ")) {
            venueState = venueState.split(" ")
            venueState = venueState.join("")
        }
        var venueName = venue.name.split(" ")
        venueName = venueName.join("")
        if (!document.querySelector(`.state--${venueState}`)) {
            var newState = document.createElement("ul")
            newState.classList.add(`state--${venueState}`)
            document.querySelector(".statesList").insertAdjacentElement("beforeend", newState)

            var newHeader = document.createElement("h4")
            var newContent = document.createTextNode(`${venue.state}`)
            newHeader.appendChild(newContent)
            document.querySelector(`.state--${venueState}`).insertAdjacentElement("beforeend", newHeader)

            var newListItem = document.createElement("li")
            newListItem.classList.add("card")
            newListItem.classList.add("border-primary")
            newListItem.classList.add("mb-3")
            newListItem.id = `${venueName}`
            document.querySelector(`.state--${venueState}`).insertAdjacentElement("beforeend", newListItem)

            var newDiv = document.createElement("div")
            newDiv.classList.add("card-body")
            newDiv.id = `cardBody--${venueName}`
            document.querySelector(`#${venueName}`).insertAdjacentElement("beforeend", newDiv)

            newHeader = document.createElement("h5")
            newHeader.classList.add("card-title")
            newContent = document.createTextNode(`${venue.name}`)
            newHeader.appendChild(newContent)
            document.getElementById(`cardBody--${venueName}`).insertAdjacentElement("beforeend", newHeader)

            newDiv = document.createElement("div")
            newDiv.classList.add("card-subtitle")
            newContent = document.createTextNode(`${venue.city}`)
            newDiv.appendChild(newContent)
            document.getElementById(`cardBody--${venueName}`).insertAdjacentElement("beforeend", newDiv)
        }
        else {
            var newListItem = document.createElement("li")
            newListItem.classList.add("card")
            newListItem.classList.add("border-primary")
            newListItem.classList.add("mb-3")
            newListItem.id = `${venueName}`
            document.querySelector(`.state--${venueState}`).insertAdjacentElement("beforeend", newListItem)

            var newDiv = document.createElement("div")
            newDiv.classList.add("card-body")
            newDiv.id = `cardBody--${venueName}`
            document.querySelector(`#${venueName}`).insertAdjacentElement("beforeend", newDiv)

            newHeader = document.createElement("h5")
            newHeader.classList.add("card-title")
            newContent = document.createTextNode(`${venue.name}`)
            newHeader.appendChild(newContent)
            document.getElementById(`cardBody--${venueName}`).insertAdjacentElement("beforeend", newHeader)

            newDiv = document.createElement("div")
            newDiv.classList.add("card-subtitle")
            newContent = document.createTextNode(`${venue.city}`)
            newDiv.appendChild(newContent)
            document.getElementById(`cardBody--${venueName}`).insertAdjacentElement("beforeend", newDiv)
        }
    })
}

buildList()

document.getElementById("filterButton").addEventListener("click", event => {
    var selectedState = document.getElementById("statesList").value
    if (selectedState != "All") {
        if (selectedState.includes(" ")) {
            selectedState = selectedState.split(" ")
            selectedState = selectedState.join("")
        }
        var states = Array.from(document.querySelector(".statesList").children)
        states.forEach(state => {
            if (!state.classList.contains(`state--${selectedState}`)) {
                state.classList.add("hidden")
            }
        })
    }
    else {
        var states = Array.from(document.querySelector(".statesList").children)
        states.forEach(state => {
            if (state.classList.contains("hidden")) {
                state.classList.remove("hidden")
            }
        })
    }
})