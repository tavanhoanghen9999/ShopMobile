var activity = 0;
getcustomer();
var formData = new FormData();
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
function getcustomer() {
    $.ajax({
        type: "get",
        url: linkserver + "customer",
        data: null,
        //headers: { 'authorization': `Bearer ${token}` },
        dataType: 'json',
        contentType: "application/json",
        error: function (err) {
            alert("Có lỗi xảy ra, vui lòng kiểm tra kết nối");
        },
        success: function (data) {
            bindingcustomer(data);

        }
    });
}
function bindingcustomer(modle) {
    if (modle.success) {

        $(".body-customer").remove();
        if (modle.data) {
            for (var i in modle.data) {
                var item = modle.data[i];
                $('#item-customer').append(` <div class="h body-customer " id="view-customer">
            <span class="h item-table-customer" style="background-image:url(`+ linkcustomer + item.picture + `)"></span>
            <span class="h item-table-customer">`+ item.customerid +`</span>
            <span class="h item-table-customer">`+ item.namecustomer +`</span>
            <span class="h item-table-customer">`+ item.phonenumber +`</span>
            <span class="h item-table-customer">`+ item.email +`</span>
            <span class="h item-table-customer">`+ item.address + `</span>
            <span class="h item-table-customer">`+ (item.active === true ? 'Còn hoạt động' : 'Ngừng hoạt động')+`</span>
            <span class="h item-table-customer">
                <i class="fa fa-pencil-square-o icon-edit bnt-add-linepr" data-toggle="modal" data-target="#linepr-edit" onclick="getLineProductById(`+ item.lineid + `)" aria-hidden="true"></i>
                <i class="fa fa-trash-o icon-edit" data-toggle="modal" data-target="#table-linepr1" onclick="deletelineproduct(`+ item.lineid +`)" aria-hidden="true"></i>
            </span>
        </div>`);
            }
        }
    }
}


$('#sl-activity-cus').on('change', function () {
    active = parseInt(this.value);
});
/// insert customer

function insertcustomer() {
    var bol = true;
    var data = {
        'namecustomer': $("#txtlinename").val(),
        'phonenumber': $("#txtnumberphone").val(),
        'email': $("#txtemail").val(),
        'address': $("#txtaddress").val(),
        'activity': 0
    };
    if (bol) {
        bol = false;

        $.ajax({
            url: linkserver + "lineproduct/insertcustomer",
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
                    $('#insert-customer').modal('toggle');
                    bootbox.alert("Thêm khhách thành công");
                    getcustomer();
                }
                else {
                    alert("Có lỗi xảy ra vui lòng kiểm tra lại thông tin !");
                }
            }
        });
    }
}

        

//    formData.append("namecustomer", $("#txtlinename").val());
//    formData.append("phonenumber", $("#txtnumberphone").val());
//    formData.append("email", $("#txtemail").val());
//    formData.append("address", $("#txtaddress").val());
//    formData.append("activity", $("#txtactivity").val());

//    $.ajax({
//        url: linkserver + "lineproduct/insertcustomer",
//        type: 'post',
//        dataType: 'json',
//        async: false,
//        data: formData,
//        //headers: { 'authorization': `Bearer ${token}` },
//        processData: false,
//        contentType: false,
//        cache: false,
//        error: function (err) {
//            alert("That bai");
//        },
//        success: function (data) {
//            if (data.success) {
//                $('#insert-customer').modal('toggle');
//                bootbox.alert("Thêm thành công");
//                getcustomer();
//            }
//            else {
//                alert("Có lỗi xảy ra vui lòng kiểm tra lại thông tin !");
//            }
//        }
//    });
//}