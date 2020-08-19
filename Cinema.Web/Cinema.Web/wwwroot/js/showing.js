showing = {} || showing;
idfilm = 0;
showing.openmodaladdeditshowing = function (id) {
    showing.updateDay();
    showing.drawfilmbyid(id);
    idfilm = id;
    $("#addeditshowing").modal("show");
}
showing.comfirmday = function () {
    saveObj = {};
    saveObj.RoomId = parseInt($('#roomid').val());
    saveObj.DayShow = $('#day').val();
    $.ajax({
        url: `/Showing/TimeEmptyByRoomDay`,
        method: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(saveObj),
        success: function (data) {
            $('#time').empty();
            if (data.results.length > 0) {
                $.each(data.results, function (i, v) {
                    $("#time").append(`<option value="${v.timeId}">${v.timeName}</option>`)
                });
            } else {
                $("#time").append(`<option value="">Hết xuất</option>`)
            }
        }
    });
}
showing.drawfilmbyid = function (id) {
    $.ajax({
        url: `/Film/Get/${id}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#Image').attr('src', data.film.image);
            $('#FilmName').empty();
            $('#FilmName').append(`<p>${data.film.filmName}</p>`);
        }
    });
}
showing.save = function () {
    saveObj = {};
    saveObj.FilmId = idfilm;
    saveObj.TimeId = parseInt($("#time").val());
    saveObj.RoomId = parseInt($("#roomid").val())
    saveObj.DayShow = $("#day").val();
    $.ajax({
        url: `/Showing/Create/`,
        method: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(saveObj),
        success: function (data) {
            $('#addeditshowing').modal('hide');
            $('#modalalert').modal('show');
        }
    });
}
showing.updateDay = function () {
    var day = new Date();
    var today = `${day.getFullYear()}-${day.getMonth() + 2}-${day.getDate()}`;
    $("#day").val(convert(today));
}
function convert(str) {
    var date = new Date(str),
        mnth = ("0" + (date.getMonth() + 1)).slice(-2),
        day = ("0" + date.getDate()).slice(-2);
    return [date.getFullYear(), mnth, day].join("-");
}