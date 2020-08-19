var management = {} || management;
management.drawListCategoryfilm = function () {
    $.ajax({
        url: `/Categoryfilm/Gets`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#listcategoryfilm1').empty();
            $('#listcategoryfilm2').empty();
            $.each(data.categories, function (i, v) {
                $("#listcategoryfilm1").append(`<li><a href="/Film/FilmOfCategory/${v.categoryId}">${v.categoryName}</a></li>`)
                $("#listcategoryfilm2").append(`<li><a href="/Film/FilmOfCategory/${v.categoryId}">${v.categoryName}</a></li>`)
            });
        }
    });
}
    
management.drawroomshowingnow = function () {
    $.ajax({
        url: `/Room/ShowingNow`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#chartroom').empty();
            $.each(data.rooms, function (i, v) {
                $('#chartroom').append(
                ` <div class="col-lg-4">
                    <div class="au-card chart-percent-card" style="margin:5px 20px">
                        <div class="au-card-inner">
                            <h3 class="title-2 mb-1 tm-b-5 text-center"><b>${v.roomName}</b></h3>
                            <p class="text-center mb-3"><b>Trạng thái: </b>  ${v.status}</p>
                            <p><b>Phim :</b> <i>${v.filmName}</i></p>
                            <p><b>Thời gian chiếu :</b>  <i>${v.timeName}</i></p>
                            <p><b>Số lượng ghế :</b> </p>
                            <div class="no-gutters">
                                <div>
                                    <div class="chart-note-wrap">
                                        <div class="chart-note mr-0 d-block">
                                            <span class="dot dot--blue"></span>
                                            <span>Ghế đang sử dụng</span>
                                        </div>
                                        <div class="chart-note mr-0 d-block">
                                            <span class="dot dot--red"></span>
                                            <span>Ghế trống</span>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <div class="percent-chart_${v.roomId}">
                                        <canvas id="percent-chart_${v.roomId}" style="height:150px"></canvas>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                 `
                )
                management.drawchartshowingroom(v.roomId, v.totalSeat, v.numberChairOn);
            });
        }
    });
}
management.drawchartshowingroom = function (roomid, totalseat, chairon) {
    try {
    var ctx = document.getElementById(`percent-chart_${roomid}`);
    if (ctx) {
        ctx.height = 280;
        var myChart = new Chart(ctx, {
            type: 'doughnut',
            data: {
                datasets: [
                    {
                        label: "My First dataset",
                        data: [chairon, totalseat - chairon],
                        backgroundColor: [
                            '#00b5e9',
                            '#fa4251'
                        ],
                        hoverBackgroundColor: [
                            '#00b5e9',
                            '#fa4251'
                        ],
                        borderWidth: [
                            0, 0
                        ],
                        hoverBorderColor: [
                            'transparent',
                            'transparent'
                        ]
                    }
                ],
                labels: [
                    'Ghế đang sử dụng',
                    'Ghế trống'
                ]
            },
            options: {
                maintainAspectRatio: false,
                responsive: true,
                cutoutPercentage: 55,
                animation: {
                    animateScale: true,
                    animateRotate: true
                },
                legend: {
                    display: false
                },
                tooltips: {
                    titleFontFamily: "Poppins",
                    xPadding: 15,
                    yPadding: 10,
                    caretPadding: 0,
                    bodyFontSize: 16
                }
            }
        });
    }

} catch (error) {
    console.log(error);
}
}
management.init = function () {
    management.drawListCategoryfilm();
    management.drawroomshowingnow();
};

$(document).ready(function () {
    management.init();
});
