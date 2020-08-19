var film = {} || film;
var filmId = 0;
var link = `https://www.youtube.com/embed`;

film.drawFilm = function () {
    $.ajax({
        url: `/Film/Get/${filmId}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#Image').attr('src', data.film.image);
            $('#FilmName').empty()
            $('#FilmName').append(`<p>${data.film.filmName} </p>`);
            $('#namefilmcus').empty()
            $('#namefilmcus').append(`<p>${data.film.filmName} </p>`);
            $('#Title').empty()
            $('#Title').append(`<p>${data.film.title} </p>`);
            $('#Description').empty()
            $('#Description').append(`<p>${data.film.description} </p>`)
            $('#action2').empty();
            $('#action2').append(`<h3>${data.film.filmName}</h3>`)
            $('#trailer').attr('src', `${link}/${data.film.linkTrailer}`);
            film.initCategory(data.film.categoryId);

        }
    });
}
film.get = function () {
    $.ajax({
        url: `/Film/Get/${filmId}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#ImageUd').attr('src', data.film.image);
            $('#FilmNameUd').val(data.film.filmName);
            $('#TitleUd').val(data.film.title);
            $('#DescriptionUd').val(data.film.description);
            $('#LinktrailerUd').val(data.film.linkTrailer);
            film.categories(data.film.categoryId)
            $('#EditFilm').appendTo("body").modal('show');

        }
    });
}
film.initCategory = function (id) {
    $.ajax({
        url: `/Categoryfilm/Get/${id}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#menucategory').empty();
            $('#menucategory').append(`<a href="/Film/FilmNowShowing/${data.category.categoryId}">${data.category.categoryName}</a>`)

            $('#CategoryFilm').empty();
            $('#CategoryFilm').append(`<p>${data.category.categoryName} </p>`)
        }
    });
}

film.drawListCategoryfilm = function () {
    $.ajax({
        url: `/Categoryfilm/Gets`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#listcategoryfilm').empty();
            $.each(data.categories, function (i, v) {
                $("#listcategoryfilm").append(`<li><a href="/Film/FilmNowShowing/${v.categoryId}">${v.categoryName}</a></li>`)
            });
        }
    });
}

film.categories = function (cateId) {
    $.ajax({
        url: `/Categoryfilm/Gets`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#CategoryUd').empty();
            $.each(data.categories, function (i, v) {
                var selected = (v.categoryId == cateId)? "selected" : ""
                $("#CategoryUd").append(`<option value="${v.categoryId}" ${selected}>${v.categoryName}</option>`)
            });
        }
    });
}
film.update = function () {
    var saveObj = {};
    saveObj.FilmId = parseInt(filmId);
    saveObj.FilmName = $('#FilmNameUd').val();
    saveObj.Title = $('#TitleUd').val();
    saveObj.Description = $('#DescriptionUd').val();
    saveObj.LinkTrailer = $('#LinktrailerUd').val();
    saveObj.Image = $('#ImageUd').attr('src');
    saveObj.CategoryId = parseInt($('#CategoryUd').val());

    $.ajax({
        url: `/Film/Update/`,
        method: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(saveObj),
        success: function (data) {
            $('#EditFilm').modal('hide');
            film.drawFilm();
            bootbox.alert(data.result.message);
            
        }
    });

}
film.uploadImage = function (input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#ImageUd').attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}
film.drawmenucus = function () {
    $("#menucus").empty();
    $("#menucus").append(` <li class="list-inline-item">
                                <a href="/Categoryfilm/categoryfilm">Thể loại</a>
                           </li>                
                            <li class="list-inline-item seprate">
                                 <span>/</span>
                            </li>
                            <li class="list-inline-item" id="menucategory"></li>
                            <li class="list-inline-item seprate">
                                      <span>/</span>
                            </li>
                            <li class="list-inline-item" id="namefilmcus"></li>`)
}
film.init = function () {
    film.drawmenucus();
    film.drawFilm();
    film.drawListCategoryfilm();
};

$(document).ready(function () {
    filmId = $('#FilmId').val();
    film.init();
});