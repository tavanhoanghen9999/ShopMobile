getsupplier();

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
            <span class="h item-table " style="background-image:url(`+ linklineproduct + item.picture + `)"></span>
            <span class="h item-table">`+ item.supplierid + `</span>
            <span class="h item-table">`+ item.suppliername + `</span>
            <span class="h item-table">`+ item.address + `</span>
            <span class="h item-table">`+ item.phonenumber + `</span>
            <span class="h item-table">`+ item.email + `</span>
            <span class="h item-table">`+ formatDate(new Date(item.createday)) + `</span>
            <span class="h item-table">`+ (item.active == true ? 'Còn hoạt động' : 'Ngừng hoạt động')  + `</span>
            <span class="h item-table">
                <i class="fa fa-pencil-square-o icon-edit bnt-add-linepr" data-toggle="modal" data-target="#linepr-edit" onclick="getLineProductById(`+ item.lineid + `)" aria-hidden="true"></i>
                <i class="fa fa-trash-o icon-edit" data-toggle="modal" data-target="#table-linepr1" onclick="deletelineproduct(`+ item.lineid + `)" aria-hidden="true"></i>
            </span>
        </div>`);
            }
        }
    }
}


//insert suuplier

function insertLineProduct() {
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
            if (data.success) {
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

