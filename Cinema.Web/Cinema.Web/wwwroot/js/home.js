var home = {} || home;

home.drawFilmTop = function () {
    $.ajax({
        url: "/Film/GetsFilmTop",
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#filmsbyrate').empty();
            $.each(data.films, function (i, v) {
                $('#filmsbyrate').append(
                    `
                  <div class="col-md-4">
                          <div>
                               <a href="/Home/Film/${v.filmId}" style="width:100%;height:400px" class="d-inline-block mb-4">
                                    <img src="${v.image}" style="width:100%;height:400px;padding:10px 15px;border-radius:20px" alt="${v.filmName}" class="rangoliPic">
                                </a>
                            </div>
                            <div class="ftco-media-details">
                                            <h3 style="text-align:center;color:white">${v.filmName}</h3>
                                            <p style="text-align:center;color:#007bff">${v.title}</p>
                              </div>

                                  
                    </div>`
                );
            });
        }
    });

};

home.deleteshowingbytime = function () {
    $.ajax({
        url: `/Showing/DeleteByTime`,
        method: "GET",
        dataType: "json",
        success: function (data) {
        }
    });
}
home.init = function () {
    home.deleteshowingbytime();
    home.drawFilmTop();
};

$(document).ready(function () {
    home.init();
});