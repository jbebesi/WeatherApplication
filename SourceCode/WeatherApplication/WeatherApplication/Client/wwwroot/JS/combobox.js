﻿/* When the user clicks on the button,
toggle between hiding and showing the dropdown content */
function myFunction() {
    document.getElementById("myDropdown").classList.toggle("show");
}

var list;
function setList(values) {
    list = values;
}


function filterFunction() {

    var input, filter, ul, li, a, i;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    div = document.getElementById("myDropdown");
    for (i = 0; i < list.length && i < 5; )
    {
        if (list[i].toLowerCase().includes(filter)) {
            div.appendChild(`<a>1${list[i]}</a>`);
            i++;
        }
    }

    //a = div.getElementsByTagName("a");
    //for (i = 0; i < a.length; i++) {
    //    txtValue = a[i].textContent || a[i].innerText;
    //    if (txtValue.toUpperCase().indexOf(filter) > -1) {
    //        a[i].style.display = "";
    //    } else {
    //        a[i].style.display = "none";
    //    }
    //}
}
