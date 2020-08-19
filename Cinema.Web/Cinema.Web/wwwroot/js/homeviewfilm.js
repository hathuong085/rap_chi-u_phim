var home = {} || home;
var filmid = 0;
var link= 'https://youtube.com/embed';

home.drawTable = function () {
    $.ajax({
        url: `/Home/Getfilm/${filmid}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#homeviewfilm').empty();
            $('#imagefilm').attr('src', data.film.image);
            $('#bodyfilm').append(
                `<h3>Tên phim: ${data.film.filmName}</h3>
                 <h4>Tiêu đề: ${data.film.title}</h4>
                 <h5>Thông tin: ${data.film.description}</h5>
                 <h5>Đánh giá: ${data.film.averageRate}</h5>
                 <h5 id="categoryname"></h5>`
            );
            home.initCategory(data.film.categoryId);
            $('#linkstrailer').attr('src', `${link}/${data.film.linkTrailer}`);

        }
    });

};
home.initCategory = function (id) {
    $.ajax({
        url: `/Categoryfilm/Get/${id}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#categoryname').empty();
            $('#categoryname').append(`Thể loại: ${data.category.categoryName}`)
        }
    });
}

home.init = function () {
    home.drawTable();
}
$(document).ready(function () {
    filmid = $('#filmid').val();
    home.init();
});