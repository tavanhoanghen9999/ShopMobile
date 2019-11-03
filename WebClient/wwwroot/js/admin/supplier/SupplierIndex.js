getSupplier();

function getSupplier() {
    $.ajax({
        type: "get",
        url: "https://localhost:44344/api/supplier",
        data: null,
        //headers: { 'authorization': `Bearer ${token}` },
        dataType: 'json',
        contentType: "application/json",
        error: function (err) {
            alert("Có lỗi xảy ra, vui lòng kiểm tra kết nối");
        },
        success: function (data) {
            //alert(data);
            bindingSupplier(data);
        }

    });
}

function bindingSupplier(model) {
    if (model.success) {
        if (model.data) {

            for (var i in model.data) {
                var supplier = model.data[i];
                $("#supplier").append(`<tr>
                                        <td>`+ supplier.supplierid + `</td>
                                        <td>`+ supplier.suppliername + `</td>
                                        <td>`+ supplier.phonenumber + `</td>
                                        <td>`+ supplier.email + `</td>
                                        <td>`+ supplier.address + `</td>
                                        <td>`+ supplier.picture + `</td>
                                        <td>`+ supplier.createday + `</td>
                                        <td>`+ supplier.activity + `</td>
                                        <td>
                                            <button type="button" class="btn btn-warning" style="margin-bottom:5px;">Edit</button></br>
                                          <a><button type="button" class="btn btn-danger" onclick=""><i class="far fa-trash-alt"></i>Delete</button></a>
                                        </td>
                                </tr>`);
            }
        }
    }
}

//add supplier
var formData = new FormData();

// brower picture
function getImage() {
    $("#multi-file").click();
    $("#multi-file").change(function () {
        readImageUpload(this);
    });
}
//add picture to view
function readImageUpload(input) {
    if (input.files && input.files[0]) {
        if (formData.get("picture") != null) {
            formData.delete("picture");
        }
        formData.append("picture", input.files[0]);
        var reader = new FileReader();
        reader.onload = function (e) {

            $("#image-line-product").css("background-image", "url(" + e.target.result + ")");
        };
        reader.readAsDataURL(input.files[0]);
    }
    $("#multi-file").val("");
}


///add
function validateSupplier() {
    formData.append("linename", $("#txtlinename").val());
    formData.append("linenote", $("#txtnote ").val());
    formData.append("createday", $("#txtcreateday").val());

    $.ajax({
        url: " https://localhost:44344/api/LineProduct/postLine",
        type: 'post',
        dataType: 'json',
        async: false,
        data: formData,
        //headers: { 'authorization': `Bearer ${token}` },
        processData: false,
        contentType: false,
        cache: false,
        error: function (err) {
            alert("That bai1");
        },
        success: function (data) {
            if (data.success) {
                alert("thanh cong");
            }
            else {
                alert("Có lỗi xảy ra vui lòng kiểm tra lại thông tin  !");
            }
        }
    });
}
// insert supplier
var formData = new FormData();

// brower picture
function getImage() {
    $("#multi-file").click();
    $("#multi-file").change(function () {
        readImageUpload(this);
    });
}
//add picture to view
function readImageUpload(input) {
    if (input.files && input.files[0]) {
        if (formData.get("picture") != null) {
            formData.delete("picture");
        }
        formData.append("picture", input.files[0]);
        var reader = new FileReader();
        reader.onload = function (e) {

            $("#image-line-product").css("background-image", "url(" + e.target.result + ")");
        };
        reader.readAsDataURL(input.files[0]);
    }
    $("#multi-file").val("");
}


///add
function InsertSupplier() {
    formData.append("suppliername", $("#txtsuppliername").val());
    formData.append("phonenumber", $("#txtnumberphone ").val());
    formData.append("email", $("#txtemail").val());
    formData.append("address", $("#txtadress").val());
    formData.append("createday", $("#txtcreateday").val());
    formData.append("activity", $("#txtactivity").val());

    $.ajax({
        url: " https://localhost:44344/api/Supplier",
        type: 'post',
        dataType: 'json',
        async: false,
        data: formData,
        //headers: { 'authorization': `Bearer ${token}` },
        processData: false,
        contentType: false,
        cache: false,
        error: function (err) {
            alert("That bai1");
        },
        success: function (data) {
            if (data.success) {
                alert("thanh cong");
            }
            else {
                alert("Có lỗi xảy ra vui lòng kiểm tra lại thông tin  !");
            }
        }
    });
}
