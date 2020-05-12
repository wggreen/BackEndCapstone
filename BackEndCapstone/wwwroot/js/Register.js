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