// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

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
