var categoryfilm = {} || categoryfilm;

categoryfilm.drawTable = function () {
    $.ajax({
        url: "/CategoryFilm/Gets",
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#tbCategoryFilm tbody').empty();
            $.each(data.categories, function (i, v) {
                $('#tbCategoryFilm tbody').append(
                    `<tr>
                        <td>${v.categoryId}</td>
                        <td>${v.categoryName}</td>
                        <td class="text-center"><a href="/Film/FilmNowShowing/${v.categoryId}" >${v.countNowShowing}</a></td>
                         <td class="text-center"><a href="/Film/FilmUpComing/${v.categoryId}" >${v.countUpcoming}</a></td>
                         <td class="text-center"><a href="/Film/FilmScreened/${v.categoryId}" >${v.countScreened}</a></td>
                    </tr>`
                );
            });
        }
    });

}; 
categoryfilm.drawListCategoryfilm = function () {
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
categoryfilm.drawmenucus = function () {
    $("#menucus").empty();
    $("#menucus").append(` <li class="list-inline-item">
                                                <a href="/Categoryfilm/categoryfilm">Thể loại</a>
                                            </li>
                                            <li class="list-inline-item seprate">
                                                <span>/</span>
                                            </li>`)
}
categoryfilm.init = function () {
    categoryfilm.drawListCategoryfilm();
    categoryfilm.drawTable();
    categoryfilm.drawmenucus();
};

$(document).ready(function () {
    categoryfilm.init();
});