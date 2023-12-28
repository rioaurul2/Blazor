function saveMessage(fullName) {
    /*alert(fullName + ' has been saved successfully!');*/

    document.getElementById('divServerValidations').innerText = fullName + ' has been saved successfully!';
}

function setFocusOnElement(element) {
    element.focus()
}