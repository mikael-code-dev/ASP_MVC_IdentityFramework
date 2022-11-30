var toggleAddLanguageBtn = document.querySelector("#toggle-add-language-button");


function toggleLanguagePanel(id) {
    var toggleElement = document.getElementById(`${id}`);
    var elementInside = toggleElement.parentElement.querySelector("div");

    var theButton = toggleElement.parentElement.querySelector("input");
    theButton.value = theButton.value === "-" ? "+" : "-";

    elementInside.classList.toggle("show-language-panel");
}

const addLanguageButton = (id) => {

    var thePanel = document.getElementById(`${id}`);
    var input = thePanel.querySelector("input");
    var fixedInput = capitalize(input.value);

    $.ajax({
        type: "POST",
        url: `People/AddLanguage?id=${id}&lang=${fixedInput}`,
        success: function (response) {

            // Add the languate -> FrontEnd.
            var theUl = thePanel.parentElement.parentElement.querySelector("ul");
            var liElem = document.createElement("li");
            liElem.appendChild(document.createTextNode(`${fixedInput}`));
            theUl.appendChild(liElem);

            // Empty input and close (toggle) the language Panel.
            input.value = "";
            var panel = document.getElementById(`${id}`);
            var theButton = panel.parentElement.querySelector("input");
            panel.classList.toggle("show-language-panel");
            theButton.value = theButton.value === "-" ? "+" : "-";
        }
    })
}

function capitalize(input) {
    return input.charAt(0).toUpperCase() + input.slice(1);
}

function deletePerson(id) {

    $.ajax({
        type: "DELETE",
        url: "People/Delete?id=" + id,
        success: function (response) {
            var ele = document.querySelectorAll('tr');

            ele.forEach(elem => {
                if (elem.getAttribute('data-modelid') == id) {
                    elem.remove();
                }
            })
        }
    })
}

var errorMess = document.querySelectorAll(".error-message");

errorMess.forEach((element) => {
    if (element.innerHTML === "") {
        element.classList.add("no-show");
    }
});