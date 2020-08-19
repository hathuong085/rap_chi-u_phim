search = {} || search;
search.drawSearch = function () {
    var keyObj = {};
    keyObj.Key = $("#keysearch").val();
    if (keyObj.Key != "") {
        $('#homebody').empty()
        $('#homebody').append(`<section style="padding-top:30px">
                                    <h3 style="text-align:center;color:#007bff">Kết quả tìm kiếm :  <span id="countfilm"></span><h3>
                                    <div class="row" id="searchid">
                                    </div>
                                </section>`)
        $.ajax({
            url: "/Film/Searchfilm",
            method: "POST",
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify(keyObj),
            success: function (data) {
                $('#searchid').empty();
                $("#homebody").find("#countfilm").text(data.search.length)
                $.each(data.search, function (i, v) {
                    $('#searchid').append(
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
    } else {
        $('#homebody').remove();
        location.reload();
    }


};