
getcustomer();


var formData = new FormData();
var formDataedit = new FormData();
var customer = -1;


// add activity
$('#sl-activity-cus').on('change', function () {
    active = parseInt(this.value);
});
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

// get picture update

function readImageUpload(input) {
    if (input.files && input.files[0]) {
        if (formDataedit.get("picture") != null) {
            formDataedit.delete("picture");
        }
        formDataedit.append("picture", input.files[0]);
    }
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
            <span class="h item-table-customer">`+ (item.activity === true ? 'Còn hoạt động' : 'Ngừng hoạt động') +`</span>
            <span class="h item-table-customer">
                <i class="fa fa-pencil-square-o icon-edit bnt-add-linepr" data-toggle="modal" data-target="#update-customer" onclick="getCustomerById(`+ item.customerid + `)" aria-hidden="true"></i>
                <i class="fa fa-trash-o icon-edit" data-toggle="modal" data-target="#table-customer" onclick="deletecustomer(`+ item.customerid +`)" aria-hidden="true"></i>
            </span>
        </div>`);
            }
        }
    }
}

/// insert customer
function insertcustomer() {
    formData.append("namecustomer", $("#txtnamecustomer").val());
    formData.append("phonenumber", $("#txtnumberphone").val());
    formData.append("email", $("#txtemail").val());
    formData.append("address", $("#txtaddress").val());
    formData.append("createday", $("#txtcreateday").val());

    $.ajax({
        url: linkserver + "customer/insertcustomer",
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
                bootbox.alert("Thêm thành công");
                getcustomer();
            }
            else {
                alert("Có lỗi xảy ra vui lòng kiểm tra lại thông tin !");
            }
        }
    });
}

//update customer
function getCustomerById(id) {
    $.ajax({
        type: "get",
        url: linkserver + "customer/getbyid?id=" + id,
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
                customerid = item.customerid;
                $("#txtnamecustomer-edit").val(item.namecustomer);
                $("#txtnumberphone-edit").val(item.phonenumber);
                $("#txtemail-edit").val(item.email);
                $("#txtaddress-edit").val(item.address);
                $("#txtcreateday-edit").val(formatDate(new Date(item.createday)));
                $("#sl-activity-cus option[value='" + (data.data.active === true ? 0 : 1) + "']").prop("selected", true);
            }
        }
    });
}
function updatecustomer() {
    formDataedit.append("namecustomer", $("#txtnamecustomer-edit").val());
    formDataedit.append("phonenumber", $("#txtnumberphone-edit").val());
    formDataedit.append("email", $("#txtemail-edit").val());
    formDataedit.append("address", $("#txtaddress-edit").val());
    formDataedit.append("createday", $("#txtcreateday-edit").val());
    formDataedit.append("customerid", customerid);
    /*debugger*///sl-activity-cus-edit
    var s = parseInt($("#sl-activity-cus-edit").children("option:selected").val());
    formDataedit.append("activity",s);

    $.ajax({
        url: linkserver + "customer",
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
                $('#update-customer').modal('toggle');
                bootbox.alert("Cập nhật thành công");
                getcustomer();
            }
            else {
                alert("Có lỗi xảy ra vui lòng kiểm tra lại thông tin !");
            }
        }
    });
}

///delete supplier
function deletecustomer(id) {

    if (true) {
        $.ajax({
            type: "delete",
            url: linkserver + "customer?id=" + id,
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
                    getcustomer(bindingcustomer);
                }
                else {
                    alert(data.message);
                }
            }
        });

    }
}

