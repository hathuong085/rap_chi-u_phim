var film = {} || film;
var filmId = 0;
var link = `https://www.youtube.com/embed`;
var rowseat = ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J"]
var arrSeat = [];
var listNameSeat = [];
var numberChairOn = 0;
var dayshow = "";
var starttime = "";
var roomname = "";
var priceticket = 0;
var arrOrder = [];
var arrNumberOrder = [];
var saveshowingId = 0;
var totalpriceTicket = 0;
var totalpriceOrder = 0;
var namecus = "";
var phone = "";
var email = "";
var IsPartSaveSeat = 0;


film.drawDatesShow = function () {
    $.ajax({
        url: `/Showing/Top7DatesShow`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#filmofdate').empty();
            $.each(data.days, function (i, v) {
                var daycut = v.day.slice(0, 10);
                $('#filmofdate').append(
                    ` <div>
                         <h3 style="border-bottom:2px solid white;padding-left:30px;color:white;margin-top:50px">
                                       Ngày: ${daycut}</h3>
                          <hr />
                           <div class="row" id="day_${daycut}">
                              
                         </div>
                     </div>`);
                var dayObj = {};
                dayObj.Day = daycut;
                $.ajax({
                    url: `/Home/GetFilmsOfDay`,
                    method: "POST",
                    dataType: "json",
                    contentType: "application/json",
                    data: JSON.stringify(dayObj),
                    success: function (data) {
                        $(`#day_${daycut}`).empty();
                        $.each(data.films, function (i, p) {
                            $(`#day_${daycut}`).append(` <div class="col-sm-6 p-5">
                                 <div class="row border" style="margin-left:25px">
                                     <div class="col-sm-8 text-center">
                                         <img src="${p.image}" style="width:250px;height:300px;margin-top:10px" />
                                         <h5 style="margin-top:10px;color:white">${p.filmName}</h5>
                                     </div>
                                    <div class="col-sm-4 text-center border-left border-top">
                                        <div>
                                             <p style="margin-top:30px;color:white"><u><i><b>Giờ chiếu</b></i></u></p>
                                             <div style="margin-top:10px" id="day_${daycut}_${p.filmId}">
                                             </div>
                                        </div>
                                     </div>
                                 </div>
                             </div>
                            `)
                            var reqObj = {};
                            reqObj.FilmId = p.filmId;
                            reqObj.DayShow = daycut;
                            $.ajax({
                                url: `/Home/ScreeningFilmOfDate`,
                                method: "POST",
                                dataType: "json",
                                contentType: "application/json",
                                data: JSON.stringify(reqObj),
                                success: function (data) {
                                    $(`#day_${daycut}_${p.filmId}`).empty();
                                    $.each(data.timeshows, function (i,v) {
                                        $(`#day_${daycut}_${p.filmId}`).append(`
                                             <p><a href="javascript:;" onclick="film.openmodalbookfilm(${v.showingId})" class="btn btn-outline-primary" title="Đặt vé">${v.startTime}</a></p>
                                        `)
                                    })
                                }
                            });
                        })
                    }
                });
            })
        }
    });
}
film.searchbyday = function () {
    keyObj = {};
    keyObj.ToDate = $("#todate").val();
    keyObj.FromDate = $("#fromdate").val();
    $.ajax({
        url: `/Showing/SearchDayshowByPeriod`,
        method: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(keyObj),
        success: function (data) {
            $('#filmofdate').empty();
            $.each(data.days, function (i, v) {
                var daycut = v.day.slice(0, 10);
                $('#filmofdate').append(
                    ` <div>
                         <h3 style="border-bottom:2px solid white;padding-left:30px;color:white;margin-top:50px">
                                       Ngày: ${daycut}</h3>
                          <hr />
                           <div class="row" id="day_${daycut}">
                              
                         </div>
                     </div>`);
                var dayObj = {};
                dayObj.Day = daycut;
                $.ajax({
                    url: `/Home/GetFilmsOfDay`,
                    method: "POST",
                    dataType: "json",
                    contentType: "application/json",
                    data: JSON.stringify(dayObj),
                    success: function (data) {
                        $(`#day_${daycut}`).empty();
                        $.each(data.films, function (i, p) {
                            $(`#day_${daycut}`).append(` <div class="col-sm-6 p-5">
                                 <div class="row border" style="margin-left:25px">
                                     <div class="col-sm-8 text-center">
                                         <img src="${p.image}" style="width:250px;height:300px;margin-top:10px" />
                                         <h5 style="margin-top:10px;color:white">${p.filmName}</h5>
                                     </div>
                                    <div class="col-sm-4 text-center border-left border-top">
                                        <div>
                                             <p style="margin-top:30px;color:white"><u><i><b>Giờ chiếu</b></i></u></p>
                                             <div style="margin-top:10px" id="day_${daycut}_${p.filmId}">
                                             </div>
                                        </div>
                                     </div>
                                 </div>
                             </div>
                            `)
                            var reqObj = {};
                            reqObj.FilmId = p.filmId;
                            reqObj.DayShow = daycut;
                            $.ajax({
                                url: `/Home/ScreeningFilmOfDate`,
                                method: "POST",
                                dataType: "json",
                                contentType: "application/json",
                                data: JSON.stringify(reqObj),
                                success: function (data) {
                                    $(`#day_${daycut}_${p.filmId}`).empty();
                                    if (data.timeshows.length > 0) {
                                        $.each(data.timeshows, function (i, v) {
                                            $(`#day_${daycut}_${p.filmId}`).append(`
                                             <p><a href="javascript:;" onclick="film.openmodalbookfilm(${v.showingId})" class="btn btn-outline-primary" title="Đặt vé">${v.startTime}</a></p>
                                        `)
                                        })
                                    } else {
                                        $(`#day_${daycut}_${p.filmId}`).append(`<p style="color:red"> Đã chiếu</p>`)
                                    }
                                  
                                }
                            });
                        })
                    }
                });
            })
        }
    });
}
//film.searchbyday = function () {
//    keyObj = {};
//    keyObj.ToDate = $("#todate").val();
//    keyObj.FromDate = $("#fromdate").val();
//    $.ajax({
//        url: `/Film/SearchfilmByDay`,
//        method: "POST",
//        dataType: "json",
//        contentType: "application/json",
//        data: JSON.stringify(keyObj),
//        success: function (data) {
//            $("#countfilm").empty();
//            $("#countfilm").append(`<span style="font-size:30px;color:white">Tìm kiếm :  ${data.films.length}</span>`);
//            $('#filmofdate').empty();
//            $.each(data.films, function (i, p) {
//                $(`#filmofdate`).append(` <div class="col-sm-6 p-5">
//                                 <div class="row border" style="margin-left:25px">
//                                     <div class="col-sm-8 text-center">
//                                         <img src="${p.image}" style="width:250px;height:300px;margin-top:10px" />
//                                         <h5 style="margin-top:10px;color:white">${p.filmName}</h5>
//                                     </div>
//                                    <div class="col-sm-4 text-center border-left border-top">
//                                        <div>
//                                             <p style="margin-top:30px;color:white"><u><i><b>Giờ chiếu</b></i></u></p>
//                                             <div style="margin-top:10px" id="day_${p.filmId}">
//                                             </div>
//                                        </div>
//                                     </div>
//                                 </div>
//                             </div>
//                            `)
//                var reqObj = {};
//                reqObj.FilmId = p.filmId;
//                reqObj.DayShow = keyObj.Day;
//                $.ajax({
//                    url: `/Home/ScreeningFilmOfDate`,
//                    method: "POST",
//                    dataType: "json",
//                    contentType: "application/json",
//                    data: JSON.stringify(reqObj),
//                    success: function (data) {
//                        $(`#day_${p.filmId}`).empty();
//                        $.each(data.timeshows, function (i, v) {
//                            $(`#day_${p.filmId}`).append(`
//                                             <p><a href="javascript:;" onclick="film.openmodalbookfilm(${v.showingId})" class="btn btn-outline-primary" title="Đặt vé">${v.startTime}</a></p>
//                                        `)
//                        })
//                    }
//                });
//            })
//        }
//    });
//}

film.pay = function () {
    film.saveSeat();
}
film.saveSeat = function () {
    var saveObj = {};
    saveObj.listseat = arrSeat;
    saveObj.ListNameSeat = listNameSeat.toString();
    saveObj.ShowingId = saveshowingId;
    saveObj.Name = namecus;
    saveObj.Mail = email;
    saveObj.PhoneNumber = phone;
    saveObj.PriceTiket = priceticket;
    saveObj.listComboId = arrOrder;
    saveObj.ListCountCombo = arrNumberOrder;
    saveObj.TotalPriceTiket = totalpriceTicket;
    saveObj.TotalPriceOrder = totalpriceOrder;
    $.ajax({
        url: `/BookFilm/Create/`,
        method: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(saveObj),
        success: function (data) {
            bootbox.alert(data.result.message);
            film.openmodalbookfilm(saveshowingId);
        }
    });
}
film.deleteSeat = function (seatid, showingid) {
    var saveObj = {};
    saveObj.SeatId = seatid;
    saveObj.ShowingId = showingid;
    $.ajax({
        url: `/ChairOn/DeleteSeat`,
        method: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(saveObj)
    });
}
film.drawFilm = function () {
    $.ajax({
        url: `/Film/Get/${filmId}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#Image').attr('src', data.film.image);
            $('#FilmName').empty()
            $('#FilmName').append(`<p class="textcolorwhite">${data.film.filmName} </p>`);
            $('#FilmNameBK').empty()
            $('#FilmNameBK').append(`<p class="textcolorwhite">${data.film.filmName} </p>`);
            $('#Title').empty()
            $('#Title').append(`<p class="textcolorwhite">${data.film.title} </p>`);
            $('#Description').empty();
            $('#Description').append(`<p class="textcolorwhite">${data.film.description} </p>`);
            $('#trailer').attr('src', `${link}/${data.film.linkTrailer}`);
            film.initCategory(data.film.categoryId);

        }
    });
}
film.drawshowing = function () {
    $.ajax({
        url: `/Home/DayShowOfFilm/${filmId}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            var i = 0;
            for (i; i < data.dayshows.length; i++) {
                film.showing(data.dayshows[i].day, i);
            }
        }
    });
}
film.showing = function (day, id) {
    var saveObj = {};
    saveObj.FilmId = parseInt(filmId);
    saveObj.DayShow = convert(day);

    $.ajax({
        url: `/Home/ScreeningFilmOfDate`,
        method: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(saveObj),
        success: function (data) {
            var i = 0;
            $(`#timeshow_${id}`).empty();
            for (i; i < data.timeshows.length; i++) {


                $(`#timeshow_${id}`).append(`<a href="javascript:;" 
                                onclick="film.openmodalbookfilm(${data.timeshows[i].showingId})" 
                                class="btn btn-outline-primary ml-5"> ${data.timeshows[i].startTime}</a>`)

            }
        }
    });
}
function convert(str) {
    var date = new Date(str),
        mnth = ("0" + (date.getMonth() + 1)).slice(-2),
        day = ("0" + date.getDate()).slice(-2);
    return [date.getFullYear(), mnth, day].join("-");
}
film.initCategory = function (id) {
    $.ajax({
        url: `/Categoryfilm/Get/${id}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#CategoryFilm').empty();
            $('#CategoryFilm').append(`<p class="textcolorwhite">${data.category.categoryName} </p>`)
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
                var selected = (v.categoryId == cateId) ? "selected" : ""
                $("#CategoryUd").append(`<option value="${v.categoryId}" ${selected}>${v.categoryName}</option>`)
            });
        }
    });
}

film.resetallvalue = function () {
    arrSeat = [];
    arrOrder = [];
    arrOrder = [];
    arrNumberOrder = [];
    totalpriceTicket = 0;
    totalpriceOrder = 0;
    listNameSeat = [];
    $("#totalprice").empty();
    $("#desBookTicket").empty();
    $("#totalPrice").empty();
    $("#desBookOrder").empty();
    $(`#nextFood`).removeClass("textCustom");
    $("#buttonNext").empty();
    $(`#nextXN`).removeClass("textCustom");
    $(`#nextTT`).removeClass("textCustom");
}

film.openmodalbookfilm = function (showingid) {
    film.resetallvalue();
    film.descriptionshowing(showingid);
    $.ajax({
        url: `/showing/seats/${showingid}`,
        method: "get",
        datatype: "json",
        success: function (data) {
            saveshowingId = showingid;
            $('#addbookbody').empty();
            $("#addbookbody").append(
                `
                     <table id="bookseat">
                        <tr>
                            <th colspan="1"></th>
                            <th colspan="10" style="border:2px solid;text-align:center;"><h3 style="color:black">Màn hình</h3></th>
                        </tr>
                        <tr id="numberseat">
                            <th width = "50" height = "30" ></th >
                        </tr>
                      
                   </table >
                `
            )
            for (var i = 0; i < 10; i++) {
                $("#numberseat").append(`<th width = "50" height = "30" style="text-align:center">${i}</th >`)
                $("#bookseat tbody").append(`
                         <tr id="rowseat${i}">
                            <th width = "50" height = "30" style="text-align:center">${rowseat[i]}</th>
                        </tr>
                `)
                for (var j = 0; j <= 9; j++) {
                    var index = i * 10 + j;
                    if (data.seats[index].status == 'false') {
                        $(`#rowseat${i}`).append(`<td width = "50" height = "30" style="text-align:center">
                                 <input hidden id='val_seat${data.seats[index].seatId}' value="0" />
                                <input hidden id='name_seat${data.seats[index].seatId}' value="${data.seats[index].seatName}" />
                               <input class=""style="width:30px;height:30px" type='button' id='seat${data.seats[index].seatId}' 
                                        onclick='film.bookchair(${data.seats[index].seatId})'>
                            </td>`)
                    } else {
                        $(`#rowseat${i}`).append(`<td width = "50" height = "30" style="text-align:center">
                                <input type='button' style="width:30px;height:30px;background-color:red" value=''>
                            </td>`)
                    }
                }
            }
        }
    });

    $('#bookfilm').modal("show");
}

film.descriptionshowing = function (id) {
    $.ajax({
        url: `/Showing/DescriptionShowing/${id}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            filmId = data.descriptionShowing.filmId;
            starttime = data.descriptionShowing.startTime;
            dayshow = data.descriptionShowing.dayshow;
            roomname = data.descriptionShowing.roomName;
            numberChairOn = data.descriptionShowing.numberChairOn;
            priceticket = data.descriptionShowing.priceTicket;
            $('#FilmNameBK').empty()
            $('#FilmNameBK').append(`<p class="textcolorwhite" style="color:black"><i>${data.descriptionShowing.filmName}</i> </p>`);
            $('#timeshowoffilm').empty()
            $('#timeshowoffilm').append(`<p>${starttime}  ${dayshow}</p>`);
            $('#roomname').empty()
            $('#roomname').append(`<p>${roomname}</p>`);
            $('#priceticket').empty()
            $('#priceticket').append(`<p>${priceticket} VNĐ</p>`);
        }
    });
}

film.bookchair = function (seatid) {
    var seat = `seat${seatid}`;
    var nameseat = $(`#name_seat${seatid}`).val();
    var seathidden = parseInt($(`#val_seat${seatid}`).val());
    if (seathidden % 2 == 0) {
        document.getElementById(seat).classList.add("custonbutton");
        arrSeat.push(seatid);
        listNameSeat.push(nameseat);
        console.log(listNameSeat);
    } else {
        $(`#${seat}`).removeClass("custonbutton");
        arrSeat.remove(seatid);
        listNameSeat.remove(nameseat);
        console.log(listNameSeat);
    }
    $(`#val_seat${seatid}`).val(seathidden + 1);
    if (arrSeat.length > 0) {
        film.addButtonNextCheckSeat();
    } else {
        $("#buttonNext").empty();
    }
    totalpriceTicket = arrSeat.length * priceticket;
    $("#seatname").empty();
    $("#seatname").append(`<p>  ${listNameSeat.toString()}</p>`)
    $("#totalPrice").empty();
    $("#totalPrice").append(`<p>Tổng tiền:  ${totalpriceTicket + totalpriceOrder} VNĐ</p>`)
    $("#desBookTicket").empty();
    $("#desBookTicket").append(`
         <div class="col-7">
                <h6>Vé xem phim </h6>
         </div>
        <div class="col-2 text-center">
            <h6>${arrSeat.length}</h6>
        </div>
        <div class="col-3 text-center">
            <h6 style="float:right">${arrSeat.length * priceticket}</h6>
        </div>
    `);

}

film.bookSeat = function () {
    $("#addbookbody").empty();
    document.getElementById("nextFood").classList.add("textCustom");
    film.addButtonNextCheckFood();
    $.ajax({
        url: `/ComboFood/Gets`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $.each(data.comboFoods, function (i, v) {
                $("#addbookbody").append(
                    `   <div class="col-4 p-2 border-2">
                        
                        <img style="width:100%;height:100px" src="${v.imageCombo}" />
                           <div> <h6>${v.comboName}</h6> </div>
                                    <div class="row">
                                        <div class="col-6">
                                            <h6>${v.price} </h6>
                                        </div>
                                        <div class="col-6 text-rigth">
                                            <input min=0 type="number" value=0 id="countcb${v.comboFoodId}"
                                                    style="width:50px" oninput="film.addOrder(${v.comboFoodId})" />
                                        </div>
                                    </div>
                            </div>               
                                   
                `
                )
            });

        }
    });
}

film.bookOrder = function () {
    $("#addbookbody").empty();
    $("#addbookbody").append(`
           <div class="row col-12">
                   <h4 style="margin-left:35%">Xác nhận thông tin</h4>
             </div>
          <div class="col-4">Họ Tên</div>
          <div class="col-8">
                <input type="text" style="width:100%" id="namecus" placeholder="Nhập họ tên" />
                <p class="d-none" id="validatename" style="color:red">Vui lòng nhập họ tên!</p>
           </div>
         <div class="col-4">Điện thoại</div>
         <div class="col-8">    
                <input type="number" style="width:100%" id="phonecus" placeholder="Nhập số điện thoại" />
                 <p class="d-none" id="validatephone" style="color:red">Vui lòng nhập số điện thoại!</p>
          </div>
         <div class="col-4">Email</div>
        <div class="col-8">
                <input type="email" style="width:100%" id="emailcus" placeholder="Nhập email" />
                  <p class="d-none" id="validateemail" style="color:red">Vui lòng nhập email!</p>
        </div>
        
    `)
    document.getElementById("nextXN").classList.add("textCustom");
    film.addButtonNextComfirm();
    $('#bookfilm').modal('show');
}

film.addOrder = function (id) {
    var count = parseInt($(`#countcb${id}`).val());
    var index = arrOrder.indexOf(id);
    if (count > 0) {
        if (index != -1) {
            arrNumberOrder[index] = count;
        } else {
            arrNumberOrder.push(count);
            arrOrder.push(id);
        }
    }
    else {
        if (index != -1) {
            arrOrder.remove(id);
            arrNumberOrder.remove(arrNumberOrder[index]);
        }
    }

    totalpriceOrder = 0;
    $("#desBookOrder").empty();
    if (arrOrder.length > 0) {
        for (var j = 0; j < arrOrder.length; j++) {
            film.drawComboOrder(j);
        }
    }
}
film.totalprice = function () {
    console.log(totalpriceOrder + totalpriceTicket)
}
film.drawComboOrder = function (j) {
    var cbId = arrOrder[j];
    $.ajax({
        url: `/ComboFood/Get/${cbId}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            var sl = arrNumberOrder[j];
            var gia = data.comboFood.price;
            var tong = sl * gia;
            totalpriceOrder = totalpriceOrder + tong;
            $("#totalPrice").empty();
            $("#totalPrice").append(`<p>Tổng tiền:  ${totalpriceTicket + totalpriceOrder} VNĐ</p>`)
            $("#desBookOrder").append(`
                          <div class="col-7">
                                <h6>${data.comboFood.comboName}</h6>
                         </div>
                        <div class="col-2 text-center">
                            <h6>${sl}</h6>
                        </div>
                        <div class="col-3 text-center">
                             <input hidden value="${sl * gia}" id="price${j}"/>
                            <h6 style="float:right">${sl * gia}</h6>
                        </div>
             `);
        }
    });
}
film.comfirm = function () {
    namecus = $("#namecus").val();
    email = $("#emailcus").val();
    phone = $("#phonecus").val();
    if (namecus == "") {
        $(`#validatename`).removeClass("d-none");
    }
    if (email == "") {
        $(`#validateemail`).removeClass("d-none");
    }
    if (phone == "") {
        $(`#validatephone`).removeClass("d-none");
    }
    if (namecus != "" && phone != "" && email != "") {
        document.getElementById("nextTT").classList.add("textCustom");
        $("#addbookbody").empty();
        $("#addbookbody").append(`
           <div class="row col-12">
                   <h4 style="margin-left:35%">Hình thức thanh toán</h4>
             </div>
          <div class="col-4">
                     <img src="/images/momo-logo-300x300.jpg" style="width:100%;height:100%"/>
           </div>
          <div class="col-8">
                <p>Ví điện tử MOMO</p>
           </div>
         <div class="col-4">
                  <img src="/images/agiletechvietnam-zalopay.png"  style="width:100%;height:100%"/>
        </div>
         <div class="col-8">   
                <p>Ví điện tử ZALO pay</p>
          </div>
        
    `)
        document.getElementB
        $("#buttonNext").empty();
        $("#buttonNext").append(`<input class="btn btn-success" style="width:100px;height:30px" 
                type='button' value="Thanh toán" onclick='film.pay()'>`)
    }
}
film.addButtonNextCheckSeat = function () {
    $("#buttonNext").empty();
    $("#buttonNext").append(`<input class="btn btn-success" style="width:100px;height:30px" 
                type='button' value="Tiếp theo" onclick='film.bookSeat()'>`)
}
film.addButtonNextCheckFood = function () {
    $("#buttonNext").empty();
    $("#buttonNext").append(`<input class="btn btn-success" style="width:100px;height:30px" 
                type='button' value="Tiếp theo" onclick='film.bookOrder()'>`)
}
film.addButtonNextComfirm = function () {
    $("#buttonNext").empty();
    $("#buttonNext").append(`<input class="btn btn-success" style="width:100px;height:30px" 
                type='button' value="Tiếp theo" onclick='film.comfirm()'>`)
}
Array.prototype.remove = function () {
    var what, a = arguments, L = a.length, ax;
    while (L && this.length) {
        what = a[--L];
        while ((ax = this.indexOf(what)) !== -1) {
            this.splice(ax, 1);
        }
    }
    return this;
};
film.updateDay = function () {
    var day = new Date();
    var today = `${day.getFullYear()}-${day.getMonth()+1}-${day.getDate()}`;
    $("#todate").val(convert(today));
    var fromday = `${day.getFullYear()}-${day.getMonth() + 2}-${day.getDate()}`;
    $("#fromdate").val(convert(fromday));
}
film.init = function () {
    film.drawDatesShow();
    film.updateDay();
};

$(document).ready(function () {
    film.init();
});