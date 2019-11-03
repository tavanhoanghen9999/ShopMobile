getsupplier();

var supplierid = -1;

var formData = new FormData();
var formDataedit = new FormData();

// brower picture
$("#txtpicture").change(function () {
    readImageUpload(this);
});

var active = 0;
$('#sl-ativity').on('change', function () {
    active = parseInt(this.value);
})
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

//add picture to view//readImageUpload1
function readImageUploadedit(input) {
    if (input.files && input.files[0]) {
        if (formDataedit.get("picture") != null) {
            formDataedit.delete("picture");
        }
        formDataedit.append("picture", input.files[0]);
    }
    //$("#txtpicture-edit").val("");
}

//get loại
function getsupplier() {
    $.ajax({
        type: "get",
        url: linkserver + "supplier",
        data: null,
        //headers: { 'authorization': `Bearer ${token}` },
        dataType: 'json',
        contentType: "application/json",
        error: function (err) {
            alert("Có lỗi xảy ra, vui lòng kiểm tra kết nối");
        },
        success: function (data) {
            bindingsupplier(data);

        }
    });
}


function bindingsupplier(modle) {
    if (modle.success) {

        $(".table-suppler1").remove();
        if (modle.data) {
            for (var i in modle.data) {
                var item = modle.data[i];
                $('#item-supplier').append(` <div class="h body-table table-suppler1">
            <span class="h item-table " style="background-image:url(`+ linksupplier + item.picture + `)"></span>
            <span class="h item-table">`+ item.supplierid + `</span>
            <span class="h item-table">`+ item.suppliername + `</span>
            <span class="h item-table">`+ item.address + `</span>
            <span class="h item-table">`+ item.phonenumber + `</span>
            <span class="h item-table">`+ item.email + `</span>
            <span class="h item-table">`+ formatDate(new Date(item.createday)) + `</span>
            <span class="h item-table">`+ (item.active == true ? 'Còn hoạt động' : 'Ngừng hoạt động')  + `</span>
            <span class="h item-table">
                <i class="fa fa-pencil-square-o icon-edit bnt-add-linepr" data-toggle="modal" data-target="#linepr-edit" onclick="getSupplierById(`+ item.supplierid + `)" aria-hidden="true"></i>
                <i class="fa fa-trash-o icon-edit" data-toggle="modal" data-target="#table-linepr1" onclick="deletesupplier(`+ item.supplierid + `)" aria-hidden="true"></i>
            </span>
        </div>`);
            }
        }
    }
}

//insert suuplier

function insertsupplier() {
    formData.append("suppliername", $("#txtsuppliername").val());
    formData.append("address", $("#txtaddress").val());
    formData.append("phonenumber", $("#txtnumberphone").val());
    formData.append("email", $("#txtemail").val());
    formData.append("createday", $("#txtcreateday").val());
   
    $.ajax({
        url: linkserver + "supplier/insertsupplier",
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
            if (data.success) {
                $('#insert-supplier').modal('toggle');
                bootbox.alert("Thêm thành công");
                getsupplier();
            }
            else {
                alert("Có lỗi xảy ra vui lòng kiểm tra lại thông tin !");
            }
        }
    });
}


///cap nhat supplier

function getSupplierById(id) {
    $.ajax({
        type: "get",
        url: linkserver + "supplier/getbyid?id=" + id,
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
                supplierid = item.supplierid;
                $("#txtsuppliername-edit").val(item.suppliername);
                $("#txtaddress-edit").val(item.address);
                $("#txtnumberphone-edit").val(item.phonenumber);
                $("#txtemail-edit").val(item.email);
                $("#txtcreateday-edit").val(formatDate(new Date(item.createday)));
                $("#sl-ativity-edit option[value='" + (data.data.active === true ? 0 : 1) + "']").prop("selected", true);
            }
        }
    });
}
function updatesupplier() {
    formDataedit.append("suppliername", $("#txtsuppliername-edit").val());
    formDataedit.append("address", $("#txtaddress-edit").val());
    formDataedit.append("phonenumber", $("#txtnumberphone-edit").val());
    formDataedit.append("email", $("#txtemail-edit").val());
    formDataedit.append("createday", $("#txtcreateday-edit").val());
    formDataedit.append("supplierid", supplierid);
    formDataedit.append("ativity", active);

    $.ajax({
        url: linkserver + "supplier",
        type: 'put',
        dataType: 'json',
        async: false,
        data: formDataedit,
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
                getsupplier();
            }
            else {
                alert("Có lỗi xảy ra vui lòng kiểm tra lại thông tin !");
            }
        }
    });
}

///delete supplier
function deletesupplier(id) {

    if (true) {
        $.ajax({
            type: "delete",
            url: linkserver + "supplier?id=" + id,
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
                    getsupplier(bindingsupplier);
                }
                else {
                    alert(data.message);
                }
            }
        });

    }
}


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
