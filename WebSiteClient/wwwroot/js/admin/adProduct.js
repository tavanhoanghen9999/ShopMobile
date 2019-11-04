getProduct();
getLineProduct();
getsupplier();
active = 0;
lineid = 0;
supplierid = 0;
var formData = new FormData();

// add activity
$('#sl-activity-pr').on('change', function () {
    active = parseInt(this.value);
});
// id loai
$('#select-lineproduct').on('change', function () {
    lineid = parseInt(this.value);
});
// id supplier
$('#select-supplierid').on('change', function () {
    supplierid = parseInt(this.value);
});
//ở đây copy cái hàm lấy loại 
getLineProduct();
function getLineProduct() {
    $.ajax({
        type: "get",
        url: linkserver + "lineproduct",
        data: null,
        //headers: { 'authorization': `Bearer ${token}` },
        dataType: 'json',
        contentType: "application/json",
        error: function (err) {
            alert("Có lỗi xảy ra, vui lòng kiểm tra kết nối");
        },
        success: function (data) {
            if (data.success) {
                for (var i in data.data) {
                    var item = data.data[i];
                    $("#select-lineproduct").append('<option value="' + item.lineid + '">' + item.linename + '</option>');
                }
            }
        }
    });
}
//lây hãng 
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
            if (data.success) {
                for (var i in data.data) {
                    var item = data.data[i];
                    $("#select-supplierid").append('<option value="' + item.supplierid + '">' + item.suppliername + '</option>');
                }
            }
        }
    });
}




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
function getProduct() {
    $.ajax({
        type: "get",
        url: linkserver + "product",
        data: null,
        //headers: { 'authorization': `Bearer ${token}` },
        dataType: 'json',
        contentType: "application/json",
        error: function (err) {
            alert("Có lỗi xảy ra, vui lòng kiểm tra kết nối");
        },
        success: function (data) {
            bindingProduct(data);

        }
    });
}
// show product
function bindingProduct(modle) {
    if (modle.success) {

        $(".body-table").remove();
        if (modle.data) {
            for (var i in modle.data) {
                var item = modle.data[i];

                $('#item-product').append(`<div class="h body-table" id="item-product">
        <span class="h item-table-product" style="background-image:url(`+ linkproduct + item.picture + `)"></span>
        <span class="h item-table-product">`+ item.productid +`</span>
        <span class="h item-table-product">`+ item.nameproduct +`</span>
        <span class="h item-table-product">`+ item.note + `</span>
        <span class="h item-table-product">`+ formatDate(new Date(item.createday)) + `</span>
        <span class="h item-table-product">`+ item.total +`</span>
        <span class="h item-table-product">`+ item.discount +`</span>
        <span class="h item-table-product">`+ item.lineid +`</span>
        <span class="h item-table-product">`+ item.supplierid + `</span>
        <span class="h item-table-product">`+ (item.activity == 0 ? "Còn hàng" : item.activity == 1 ? "Hết hàng" :"Hàng mới") +`</span>
            
        <span class="h item-table-product">
            <i class="fa fa-pencil-square-o icon-table bnt-add-product" data-toggle="modal" data-target="#linepr-edit" onclick="getLineProductById(`+ item.lineid + `)" aria-hidden="true"></i>
                <i class="fa fa-trash-o icon-table" data-toggle="modal" data-target="#table-linepr1" onclick="deleteproduct(`+ item.productid +`)" aria-hidden="true"></i>
        </span>
    </div>`);
            }
        }
    }
}

//insert product

function insertproduct() {
    formData.append("nameproduct", $("#txtproduct").val());
    formData.append("note", $("#txtnote").val());
    formData.append("total", $("#txttotal").val());
    formData.append("price", $("#txtprice").val());
    formData.append("createday", $("#txtcreateday").val());
    formData.append("discount", $("#txtdiscount").val());
    var x = $("#txtlineid").children("option:selected").val();
    var y = $("#txtlineid").children("option:selected").val();
   


    $.ajax({
        url: linkserver + "product/insertproduct",
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
                $('#insert-product').modal('toggle');
                bootbox.alert("Thêm thành công");
                getProduct();
            }
            else {
                alert("Có lỗi xảy ra vui lòng kiểm tra lại thông tin !");
            }
        }
    });
}

//delete product
function deleteproduct(id) {
    if (true) {
        $.ajax({
            type: "delete",
            url: linkserver + "product?id=" + id,
            data: null,
            //headers: { 'authorization': `Bearer ${token}` },
            dataType: 'json',
            contentType: "application/json",
            error: function (err) {
                bootbox.alert("Có lỗi xảy ra, vui lòng kiểm tra lại khóa ngoại sản phẩm của bạn");
            },
            success: function (data) {
                if (data.success) {
                    bootbox.alert("Xóa thông tin sản phẩm thành công!");
                    getproduct(bindingproduct);
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

