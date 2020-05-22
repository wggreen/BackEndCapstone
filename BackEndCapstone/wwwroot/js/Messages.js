document.getElementById("messageReply").addEventListener("click", function (event) {
    event.target.classList.add("hidden")
    var newLabel = document.createElement("label")
    newLabel.id = "textAreaLabel"
    var newContent = document.createTextNode("Reply")
    newLabel.appendChild(newContent)
    document.getElementById(event.target.id).insertAdjacentElement("afterEnd", newLabel)

    var newTextArea = document.createElement("textarea")
    newTextArea.id = "messageReply"
    document.getElementById("textAreaLabel").insertAdjacentElement("afterEnd", newTextArea)
})