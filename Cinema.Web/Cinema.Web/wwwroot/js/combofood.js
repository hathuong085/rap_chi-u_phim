var combo = {} || combo;

combo.openmodalcombo = function () {
    combo.reset();
    $('#addEditCombo').modal('show');
}
combo.Save = function () {
    var saveObj = {};
    saveObj.ComboFoodId = parseInt($('#comboid').val());
    saveObj.ComboName = $('#ComboName').val();
    saveObj.Price = parseInt($('#Price').val());
    saveObj.ImageCombo = $('#ImageFood').attr('src');
    if (saveObj.ComboName != '' && saveObj.Price != '') {
        $.ajax({
            url: `/Combofood/Save/`,
            method: "POST",
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify(saveObj),
            success: function (data) {
                $('#addEditCombo').modal('hide');
                $('#modalalert').modal('show');
            }
        });
    } else {
        $(`#validatenamecombo`).removeClass("d-none");
        $(`#validateprice`).removeClass("d-none");
    }
    
}
combo.reload = function () {
    location.reload();
}
  
combo.uploadImage = function (input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#ImageFood').attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}

combo.get = function (id) {
    $.ajax({
        url: `/Combofood/Get/${id}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#ImageFood').attr('src', data.comboFood.imageCombo);
            $('#ComboName').val(data.comboFood.comboName);
            $('#Price').val(data.comboFood.price);
            $('#comboid').val(id);
            $('#addEditCombo').modal('show');
        }
    });
}
combo.delete = function (id) {
    bootbox.confirm({
        message: "Bạn có chắc chắn xóa combo này không?",
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
                url: `/Combofood/Delete/${id}`,
                method: "GET",
                dataType: "json",
                success: function (data) {
                    bootbox.alert('Xóa thành công!');
                    location.reload();
                }
            });
        }
    });
}
combo.restore = function (id) {
    bootbox.confirm({
        message: "Bạn có chắc chắn khôi phục combo này không?",
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
                url: `/Combofood/restore/${id}`,
                method: "GET",
                dataType: "json",
                success: function (data) {
                    bootbox.alert('Khôi phục thành công thành công!');
                    location.reload();
                }
            });
        }
    });
}

combo.reset = function () {
    $('#ImageFood').attr('src', '/images/combofood.jpg');
    $('#ComboName').val('');
    $('#Price').val('');
    $('#comboid').val('0');
}
combo.init = function () {
};

$(document).ready(function () {
    combo.init();
});