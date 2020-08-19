var film = {} || film;
var catId = 0;
//film.drawTable = function () {
//    $.ajax({
//        url: `/Film/Gets/${catId}`,
//        method: "GET",
//        dataType: "json",
//        success: function (data) {
//            $('#tbFilmOfCategory tbody').empty();
//            $.each(data.films, function (i, v) {
//                $('#tbFilmOfCategory tbody').append(
//                    `<tr>
//                        <td>${v.filmId}</td>
//                        <td><a href="/Film/FilmShow/${v.filmId}" class="item">${v.filmName}</a></td>
//                        <td>${v.title}</td>
//                        <td>${v.averageRate}</td>
//                    </tr>`
//                );
//            });
//        }
//    });

//};

//<a href="javascript:;" onclick="film.get(${v.filmId})" class="item"><i class="zmdi zmdi-edit"></i></a>
//    <a href="javascript:;" onclick="film.delete(${v.filmId})" class="item"><i class="zmdi zmdi-delete"></i></a>


film.openAddEditfilm = function () {
    film.reset();
    $('#addEditFilm').find('.modal-title').text('Thêm phim');
    film.initCategory();
    $('#addEditFilm').appendTo("body").modal('show');
};




film.uploadImage = function (input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#Image').attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}


film.create = function () {
    var saveObj = {};
    saveObj.FilmName = $('#FilmName').val();
    saveObj.Title = $('#Title').val();
    saveObj.Description = $('#Description').val();
    saveObj.LinkTrailer = $('#Linktrailer').val();
    saveObj.Image = $('#Image').attr('src');
    saveObj.CategoryId = catId;

    $.ajax({
        url: `/Film/Create/`,
        method: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(saveObj),
        success: function (data) {
            $('#addEditFilm').modal('hide');
            bootbox.alert(data.result.message);
            location.reload();
        }
    });
}


film.initCategory = function () {
    $.ajax({
        url: `/Categoryfilm/Get/${catId}`,
        method: "GET",
        dataType: "json",
         success: function (data) {
             $('#Category').empty();
             $('#menucategory').empty();
             $('#menucategory').append(`<a href="/Film/FilmNowShowing/${data.category.categoryId}">${data.category.categoryName} <span style="color:black">( Phim đang chiếu)</span></a>`)
             $('#Category').append(`<p value="${data.category.categoryId}">${data.category.categoryName}</p>`)
        }
    });
}
film.initCategories = function () {
    $.ajax({
        url: `/Categoryfilm/Gets`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#Category').empty();
            $.each(data.categories, function (i, v) {
                $("#Category").append(`<option value=${v.categoryId}>${v.categoryName}</option>`)
            });
        }
    });
}

film.addbutoncreate = function () {
    $('#buttoncreate').append(`
        <a href="javascript:void(0);" class="au-btn au-btn-icon au-btn--green au-btn--small" onclick="film.openAddEditfilm()">
            <i class="zmdi zmdi-plus"></i>Thêm phim
        </a>`)
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
film.reset = function () {
    $('#FilmName').val("");
    $('#filmId').val("0");
    $('#Title').val("");
    $('#Description').val("");
    $('#Linktrailer').val("");
    $('#Image').attr('src', '/images/noimage.jpg');
    $('#FileUpload').val('');
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
                            <li class="list-inline-item" id="buttoncreate"></li>`)
}
film.init = function () {
    film.drawListCategoryfilm();
    film.initCategory();
    film.drawmenucus();
    film.addbutoncreate();
};

$(document).ready(function () {
    catId = parseInt($('#CategoryId').val());
    film.init();
});