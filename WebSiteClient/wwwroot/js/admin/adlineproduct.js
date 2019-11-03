getLineProduct();

var lineid = -1;

var formData = new FormData();
var formData1 = new FormData();

// brower picture
$("#txtpicture").change(function () {
    readImageUpload(this);
});
//add picture to view
function readImageUpload(input) {
    if (input.files && input.files[0]) {
        if (formData.get("picture") != null) {
            formData.delete("picture");
        }
        formData.append("picture", input.files[0]);
        //var reader = new FileReader();
        //reader.onload = function (e) {

        //    $("#image-line-product").css("background-image", "url(" + e.target.result + ")");
        //};
        //reader.readAsDataURL(input.files[0]);
    }
    //$("#txtpicture").val("");
}
//get loại
function getLineProduct() {
    $.ajax({
        type: "get",
        url: linkserver +"lineproduct",
        data: null,
        //headers: { 'authorization': `Bearer ${token}` },
        dataType: 'json',
        contentType: "application/json",
        error: function (err) {
            alert("Có lỗi xảy ra, vui lòng kiểm tra kết nối");
        },
        success: function (data) {
            bindingLineProduct(data);
            
        }
    });
}
function bindingLineProduct(modle) {
    if (modle.success) {

        $(".table-linepr1").remove();
        if (modle.data) {
            for (var i in modle.data) {
                var item = modle.data[i];
                $('#item-linnepr').append(` <div class="h body-table table-linepr1">
            <span class="h item-table " style="background-image:url(`+ linklineproduct + item.picture +`)"></span>
            <span class="h item-table">`+ item.lineid+`</span>
            <span class="h item-table">`+ item.linename +`</span>
            <span class="h item-table">`+ item.linenote+`</span>
            <span class="h item-table">`+ formatDate(new Date(item.createday)) + `</span>
            <span class="h item-table">
                <i class="fa fa-pencil-square-o icon-edit bnt-add-linepr" data-toggle="modal" data-target="#linepr-edit" onclick="getLineProductById(`+ item.lineid +`)" aria-hidden="true"></i>
                <i class="fa fa-trash-o icon-edit" data-toggle="modal" data-target="#table-linepr1" onclick="deletelineproduct(`+ item.lineid +`)" aria-hidden="true"></i>
            </span>
        </div>`);
            }    
        }
    }
}
//them loại
function insertLineProduct(){
    formData.append("linename", $("#txtlinename").val());
    formData.append("linenote", $("#txtnote").val());
    formData.append("createday", $("#txtcreateday").val());

$.ajax({
    url: linkserver + "lineproduct/insertlineproduct",
    type: 'post',
    dataType: 'json',
    async: false,
    data: formData,
    //headers: { 'authorization': `Bearer ${token}` },
    processData: false,
    contentType: false,
    cache: false,
    error: function (err) {
        alert("That bai");
    },
    success: function (data) {
        if (data.success)
        {
            $('#insert-linepr').modal('toggle');
            bootbox.alert("Thêm thành công");
            getLineProduct();
        }
        else {
            alert("Có lỗi xảy ra vui lòng kiểm tra lại thông tin !");
        }
    }
});
}

//cap nhật loiaj
function getLineProductById(id) {
    $.ajax({
        type: "get",
        url: linkserver + "lineproduct/getbyid?id=" + id,
        data: null,
        //headers: { 'authorization': `Bearer ${token}` },
        dataType: 'json',
        contentType: "application/json",
        error: function (err) {
            alert("Có lỗi xảy ra, vui lòng kiểm tra kết nối");
        },
        success: function (data) {
            if (data.success && data.data) {
                var item = data.data;
                lineid = item.lineid;
                $("#txtlinename-edit").val(item.linename);
                $("#txtnote-edit").val(item.linenote);
                $("#txtcreateday-edit").val(formatDate(new Date(item.createday)));
            }
        }
    });
}
function updateLineProduct() {
    formData1.append("linename", $("#txtlinename-edit").val());
    formData1.append("linenote", $("#txtnote-edit").val());
    formData1.append("createday", $("#txtcreateday-edit").val());
    formData1.append("lineid", lineid);
  
    $.ajax({
        url: linkserver + "lineproduct",
        type: 'put',
        dataType: 'json',
        async: false,
        data: formData1,
        //headers: { 'authorization': `Bearer ${token}` },
        processData: false,
        contentType: false,
        cache: false,
        error: function (err) {
            alert("That bai");
        },
        success: function (data) {
            if (data.success) {
                $('#linepr-edit').modal('toggle');
                bootbox.alert("Cập nhật thành công");
                getLineProduct();
            }
            else {
                alert("Có lỗi xảy ra vui lòng kiểm tra lại thông tin !");
            }
        }
    });
}
///delete Lineproduct
function deletelineproduct(id) {

    if (true) {
        $.ajax({
            type: "delete",
            url: linkserver + "lineproduct?id="+id,
            data: null,
            //headers: { 'authorization': `Bearer ${token}` },
            dataType: 'json',
            contentType: "application/json",
            error: function (err) {
                alert("Có lỗi xảy ra, loại của bạn có trong sản phẩm");
            },
            success: function (data) {
                if (data.success) {
                    bootbox.alert("Xóa thông tin thành công!");
                    getLineProduct(bindingLineProduct);
                }
                else {
                    alert(data.message);
                }
            }
        });

    }
}



//datetime picker
$(document).ready(function () {
    $('#datepicker-linecrday ,#datepicker-lineupdate').datetimepicker({
        format: 'DD/MM/YYYY',
        extraFormats: false,
        stepping: 1,
        minDate: false,
        maxDate: false,
        useCurrent: true,
        collapse: true,
        defaultDate: false,
        disabledDates: false,
        enabledDates: false,
        icons: {
            time: 'glyphicon glyphicon-time',
            date: 'glyphicon glyphicon-calendar',
            up: 'glyphicon glyphicon-chevron-up',
            down: 'glyphicon glyphicon-chevron-down',
            previous: 'glyphicon glyphicon-chevron-left',
            next: 'glyphicon glyphicon-chevron-right',
            today: 'glyphicon glyphicon-screenshot',
            clear: 'glyphicon glyphicon-trash'
        },
        useStrict: false,
        sideBySide: false,
        daysOfWeekDisabled: [],
        calendarWeeks: false,
        viewMode: 'years',
        toolbarPlacement: 'default',
        showTodayButton: false,
        showClear: false,
        widgetPositioning: {
            horizontal: 'auto',
            vertical: 'auto'
        }
    });
});
// brower picture
$("#txtpicture-edit").change(function () {
    readImageUpload1(this);
});
//add picture to view
function readImageUpload1(input) {
    if (input.files && input.files[0]) {
        if (formData1.get("picture") != null) {
            formData1.delete("picture");
        }
        formData1.append("picture", input.files[0]);
    }
    //$("#txtpicture-edit").val("");
}