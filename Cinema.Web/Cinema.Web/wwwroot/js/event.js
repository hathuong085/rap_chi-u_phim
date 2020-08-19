var events = events || {};
events.openmodalevent = function () {
    events.resetmodal();
    $('#addEditEvent').modal('show');
}
events.resetmodal = function () {
    $('#NameEvent').val("");
    $('#TitleEvent').val("");
    $('#ImageEvent').attr('src','/images/liveshow/1.jpg');
    $('#LinkEvent').val("");
}
events.create = function () {
    var saveObj = {};
    saveObj.NameEvent = $('#NameEvent').val();
    saveObj.TitleEvent = $('#TitleEvent').val();
    saveObj.ImageEvent = $('#ImageEvent').attr('src');
    saveObj.LinkEvent = $('#LinkEvent').val();

    
    $.ajax({
        url: `/Event/Create/`,
        method: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(saveObj),
        success: function (data) {
            $('#addEditEvent').modal('hide');
            if (data.result.eventId > 0) {
                $("#desalert").find("#alert").text(data.result.message);
                $('#modalalert').modal('show');
            } else {
                $("#desalert").find("#alert").text(data.result.message);
                $('#modalalert').modal('show');
            }
        }
    });
}
events.delete = function (id) {
    bootbox.confirm({
        message: "Bạn có chắc chắn xóa sự kiện này không?",
        buttons: {
            confirm: {
                label: 'Có',
                className: 'btn-success'
            },
            cancel: {
                label: 'Không',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            $.ajax({
                url: `/Event/Delete/${id}`,
                method: "GET",
                dataType: "json",
                success: function (data) {
                    bootbox.alert(data.result.message);
                    location.reload();
                }
            });
        }
    });
}
events.restore = function (id) {
    bootbox.confirm({
        message: "Bạn có chắc chắn khôi phục sự kiện này không?",
        buttons: {
            confirm: {
                label: 'Có',
                className: 'btn-success'
            },
            cancel: {
                label: 'Không',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            $.ajax({
                url: `/Event/Restore/${id}`,
                method: "GET",
                dataType: "json",
                success: function (data) {
                    bootbox.alert(data.result.message);
                    location.reload();
                }
            });
        }
    });
}

events.update = function (id) {
    var saveObj = {};
    var saveObj = {};
    saveObj.EventId = id;
    saveObj.NameEvent = $('#NameEvent').val();
    saveObj.TitleEvent = $('#TitleEvent').val();
    saveObj.ImageEvent = $('#ImageEvent').attr('src');
    saveObj.LinkEvent = $('#LinkEvent').val();
    $.ajax({
        url: `/Event/Update/`,
        method: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(saveObj),
        success: function (data) {
            $('#addEditEvent').modal('hide');
            if (data.result.eventId > 0) {
                $("#desalert").find("#alert").text(data.result.message);
                $('#modalalert').modal('show');
            } else {
                $("#desalert").find("#alert").text(data.result.message);
                $('#modalalert').modal('show');
            }
        }
    });

}
events.get = function (id) {
    $.ajax({
        url: `/Event/Get/${id}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#NameEvent').val(data.isevent.nameEvent);
            $('#TitleEvent').val(data.isevent.titleEvent);
            $('#ImageEvent').attr('src', data.isevent.imageEvent);
            $('#LinkEvent').val(data.isevent.linkEvent);
            $("#buttoncreateupdate").empty();
            $("#buttoncreateupdate").append(`  <button type="button" class="btn btn-info" data-dismiss="modal">Đóng</button>
                                               <a href="javascript:;" class="btn btn-danger" onclick="events.update(${id})">Lưu</a>`)
            $('#addEditEvent').modal('show')
        }
    });
}
events.uploadImage = function (input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#ImageEvent').attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}
events.reload = function () {
    location.reload();
}

events.init = function () {
};
$(document).ready(function () {
    events.init();
});