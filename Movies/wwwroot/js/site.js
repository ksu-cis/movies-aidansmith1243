// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
var movieEntrees = document.getElementsByClassName("movie-entry");

var form = document.getElementById("search-and-filter-form");

form.addEventListener("submit", function (event) {
    event.preventDefault();

    var term = document.getElementById("search").value;

    var mpaa = [];
    var mpaaCheckBox = document.getElementsByClassName("mpaa");
    for (var j = 0; j < mpaaCheckBox.length; j++){
        if (mpaaCheckBox[j].checked) {
            mpaa.push(mpaaCheckBox[j].value);
        }
    }

    var minIMDB = document.getElementById("imdb-min-rating");

    for (var i = 0; i < movieEntrees.length; i++) {
        var entry = movieEntrees[i];

        // Unhide all Entrees
        entry.style.display = "block";

        // Filter by Search Term
        if (term) {
            if (!entry.dataset.title.toLowerCase().includes(term.toLowerCase())) {
                entry.style.display = "none";
            }
        }

        // Filter by mpaa rating
        if (mpaa.length > 0) {
            if (!mpaa.includes(entry.dataset.mpaa)) {
                entry.style.display = "none";
            }
        }

        // Filter by IMDB min rating
        if (minIMDB) {
            if (!entry.dataset.imdb || parseFloat(minIMDB) > parseFloat(entry.dataset.imdb)) {
                entry.style.display = "none";
            }
        }

    }

});