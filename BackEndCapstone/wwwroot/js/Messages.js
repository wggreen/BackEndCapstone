var messages = document.querySelectorAll(".individualMessage")

var sentMessages = document.querySelectorAll(".individualSentMessage")

async function createMessage(formData) {
    await fetch("/Messages/Create", {
        method: "Post",
        body: formData
    }).then(res => res.json());
}

async function markAsRead(id) {
    await fetch(`/Messages/MarkAsRead?id=${id}`, {
        method: "Post",
        body: formData
    }).then(res => res.json());
}

document.getElementById("messageReply").addEventListener("click", function (event) {
    event.preventDefault()
    event.target.classList.add("hidden")
    var newLabel = document.createElement("label")
    newLabel.id = "textAreaLabel"
    var newContent = document.createTextNode("Reply")
    newLabel.appendChild(newContent)
    document.getElementById(event.target.id).insertAdjacentElement("afterEnd", newLabel)

    var newTextArea = document.createElement("textarea")
    newTextArea.id = "messageReplyText"
    document.getElementById("textAreaLabel").insertAdjacentElement("afterEnd", newTextArea)

    var newButton = document.createElement("button")
    newContent = document.createTextNode("Send reply")
    newButton.appendChild(newContent)
    newButton.id = "sendReply"
    newButton.addEventListener("click", async event => {
        let formData = new FormData();

        formData.append('senderId', document.getElementById("senderId").value)
        formData.append('recipientId', document.getElementById("recipientId").value)
        formData.append('dates', document.getElementById("messageDates").value)
        formData.append('messageText', document.getElementById("messageReplyText").value)
        formData.append('timestamp', new Date())
        formData.append('isRead', false)

        await createMessage(formData)

        document.getElementById("textAreaLabel").classList.add("hidden")
        document.getElementById("messageReplyText").value = ""
        document.getElementById("messageReplyText").classList.add("hidden")
        document.getElementById("sendReply").classList.add("hidden")

        var newText = document.createElement("p")
        var newContent = document.createTextNode("Replied")
        newText.appendChild(newContent)
        document.getElementById("messageReply").insertAdjacentElement("afterEnd", newText)
    })
    document.getElementById("messageReply").parentElement.insertAdjacentElement("beforeEnd", newButton)
})

document.querySelector(".inboxButton").addEventListener("click", event => {
    if (document.querySelector(".receivedMessages").classList.contains("hidden")) {
        document.querySelector(".receivedMessages").classList.remove("hidden")
    }
    if (!document.querySelector(".sentMessages").classList.contains("hidden")) {
        document.querySelector(".sentMessages").classList.add("hidden")
    }
})

document.querySelector(".sentButton").addEventListener("click", event => {
    if (document.querySelector(".sentMessages").classList.contains("hidden")) {
        document.querySelector(".sentMessages").classList.remove("hidden")
    }
    if (!document.querySelector(".receivedMessages").classList.contains("hidden")) {
        document.querySelector(".receivedMessages").classList.add("hidden")
    }
})

messages.forEach(message => {
    message.addEventListener("click", async event => {
        event.preventDefault()
        if (event.target == message) {
            event.target.classList.add("hidden")
            event.target.classList.add("selected")
            var allMessages = document.querySelectorAll(".individualMessage")
            allMessages.forEach(am => {
                if (!am.classList.contains("selected")) {
                    am.classList.add("hidden")
                }
            })
            event.target.previousElementSibling.classList.remove("hidden")
            event.target.previousElementSibling.classList.add("selectedCard")
            var messageId = parseInt(event.target.id)
            await markAsRead(messageId)
        }
    })
})

var closeButtons = document.querySelectorAll(".btn-xs")

closeButtons.forEach(button => {
    button.addEventListener("click", event => {
        if (event.target.parentElement.parentElement.classList.contains("selectedCard")) {
            event.target.parentElement.parentElement.classList.remove("selectedCard")
            event.target.parentElement.parentElement.classList.add("hidden")
            var allMessages = document.querySelectorAll(".individualMessage")
            allMessages.forEach(am => {
                if (!am.classList.contains("selected")) {
                    am.classList.remove("hidden")
                }
            })
            document.querySelector(".selected").classList.remove("hidden")
            document.querySelector(".selected").classList.remove("selected")
        }
    })
})

sentMessages.forEach(message => {
    message.addEventListener("click", event => {
        event.preventDefault()
        if (event.target == message) {
            event.target.classList.add("hidden")
            event.target.classList.add("selected")
            var allMessages = document.querySelectorAll(".individualSentMessage")
            allMessages.forEach(am => {
                if (!am.classList.contains("selected")) {
                    am.classList.add("hidden")
                }
            })
            event.target.previousElementSibling.classList.remove("hidden")
            event.target.previousElementSibling.classList.add("selectedCard")
        }
    })
})

var closeSentButtons = document.querySelectorAll(".closeSent")

closeButtons.forEach(button => {
    button.addEventListener("click", event => {
        if (event.target.parentElement.parentElement.classList.contains("selectedCard")) {
            event.target.parentElement.parentElement.classList.remove("selectedCard")
            event.target.parentElement.parentElement.classList.add("hidden")
            var allMessages = document.querySelectorAll(".individualSentMessage")
            allMessages.forEach(am => {
                if (!am.classList.contains("selected")) {
                    am.classList.remove("hidden")
                }
            })
            document.querySelector(".selected").classList.remove("hidden")
            document.querySelector(".selected").classList.remove("selected")
        }
    })
})