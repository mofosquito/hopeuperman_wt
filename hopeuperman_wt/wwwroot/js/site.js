// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function myFunction() {
    var element = document.getElementById("nav");
    element.classList.toggle("second-nav-ul");
}

function size() {
    var element = document.getElementById("all-nav");
    element.classList.toggle("all-nav");
}

var close = document.getElementsByClassName("right");
var i;

for (i = 0; i < close.length; i++) {
    close[i].onclick = function () {
        var div = this.parentElement;
        div.style.opacity = "0";
        setTimeout(function () { div.style.display = "none"; }, 600);
    }
}