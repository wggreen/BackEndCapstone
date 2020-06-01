function bandListener() {
    document.querySelector("#radioBand").addEventListener(
        "click",
        theClickEvent => {
            let contentTarget = document.querySelector("#bandForm")
            if (contentTarget.classList.contains("hidden")) {
                contentTarget.classList.remove("hidden")
                contentTarget = document.querySelector("#venueForm")
                if (!contentTarget.classList.contains("hidden")) {
                    contentTarget.classList.add("hidden")
                }
            }
        }
    )
}

function venueListener() {
    document.querySelector("#radioVenue").addEventListener(
        "click",
        theClickEvent => {
            let contentTarget = document.querySelector("#venueForm")
            if (contentTarget.classList.contains("hidden")) {
                contentTarget.classList.remove("hidden")
                contentTarget = document.querySelector("#bandForm")
                if (!contentTarget.classList.contains("hidden")) {
                    contentTarget.classList.add("hidden")
                }
            }
        }
    )
}

bandListener()
venueListener()

var states = ["Alaska", "Alabama", "Arkansas", "Arizona", "California", "Colorado", "Connecticut", "District of Columbia", "Delaware", "Florida", "Georgia", "Guam", "Hawaii", "Iowa", "Idaho", "Illinois", "Indiana", "Kansas", "Kentucky", "Louisiana", "Massachusetts", "Maryland", "Maine", "Michigan", "Minnesota", "Missouri", "Mississippi", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Puerto Rico", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Virginia", "Vermont", "Washington", "Wisconsin", "West Virginia", "Wyoming"]

var dropdowns = document.querySelectorAll(".statesDropdown");

dropdowns.forEach(dropdown => {
    for (var i = 0; i < states.length; i++) {
        var option = document.createElement("option");
        option.value = states[i];
        option.text = states[i];
        dropdown.appendChild(option);
    }
})