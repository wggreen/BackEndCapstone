async function deleteDestination(id) {
    const dataObj = await fetch(`/Destination/Delete?id=${id}`, {
        method: "Post",
    }).then(res => res.json())
}

async function deleteSingleDestination(id) {
    const dataObj = await fetch(`/Destination/DeleteSingle?id=${id}`, {
        method: "Post",
    }).then(res => res.json())
}

async function deleteTour(id) {
    const dataObj = await fetch(`/Tour/Delete?id=${id}`, {
        method: "Post",
    }).then(res => res.json())
}

var deleteButtons = document.querySelectorAll("#deleteTour")
deleteButtons.forEach(db => {
    db.addEventListener("click", async event => {
        var tourId = parseInt(event.target.classList[0])
        await deleteDestination(tourId)
        await deleteTour(tourId)
        location.reload();
    })
})

var deleteDestinationButtons = document.querySelectorAll(".deleteDestination")
deleteDestinationButtons.forEach(ddb => {
    ddb.addEventListener("click", async event => {
        if (event.target.parentElement.parentElement.childElementCount > 1) {
            var destinationId = parseInt(event.target.id)
            await deleteSingleDestination(destinationId)
            event.target.parentElement.outerHTML = ""
        }
        if (event.target.parentElement.parentElement.childElementCount == 1) {
            if (confirm("Are you sure you want to delete your only stop?") == true) {
                var destinationId = parseInt(event.target.id)
                await deleteSingleDestination(destinationId)
                event.target.parentElement.outerHTML = ""
            }
        }
    })
})