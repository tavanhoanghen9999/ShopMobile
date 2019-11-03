//var formData = new FormData();

//// brower picture
//function getImage() {
//    $("#multi-file").click();
//    $("#multi-file").change(function () {
//        readImageUpload(this);
//    });
//}
////add picture to view
//function readImageUpload(input) {
//    if (input.files && input.files[0]) {
//        if (formData.get("picture") != null) {
//            formData.delete("picture");
//        }
//        formData.append("picture", input.files[0]);
//        var reader = new FileReader();
//        reader.onload = function (e) {

//            $("#image-line-product").css("background-image", "url(" + e.target.result + ")");
//        };
//        reader.readAsDataURL(input.files[0]);
//    }
//    $("#multi-file").val("");
//}
//function getLineProduct(id){
//    $.ajax({
//        type: "get",
//        url: "https://localhost:44344/api/lineproduct?id=" + id,
//        data: null,
//        //headers: { 'authorization': `Bearer ${token}` },
//        dataType: 'json',
//        contentType: "application/json",
//        error: function (err) {
//            alert("Có lỗi xảy ra, vui lòng kiểm tra kết nối");
//        },
//        success: function (data) {
//            //alert(data);
//            bindingLineProduct(data);
//        }
//    });
//}
//function UpdateLineProduct() {
//    var linename = $("#txtlinename").val();
//    var linenote = $("#txtnote").val();
//    //var createday = $("#txtcreateday").val();
//    var chekud = true;
//    if (!checkStr(linename.trim())) {
//        addClass('linename');
//        chekud = false;
//    }
//    else {
//        removeClass('linename');
//    }
//    if (!checkStr(linenote.trim())) {
//        addClass('linenote');
//        chekud = false;
//    }
//    else {
//        removeClass('linenote');
//    }
//    if (!chekud) {
//        $('#formedidlineproduct').show();
//        return;
//    }
//    else {
//        $('#formedidlineproduct').hide();
//        var model = {
//            'lineid': lineid,
//            'linename': linename.trim(),
//            'linenote': linenote.trim(),
//            'createday': $("#txtcreateday").val()
//        }
//        updateLineProduct(model);
//    }
//}
//var Lr = true;
//function updateLineProduct(model) {
//    if (Lr) {
//        Lr = false;
//        $.ajax({
//            url: "https://localhost:44344/api/LineProduct",
//            type: 'PUT',
//            dataType: 'json',
//            data: JSON.stringify(model),
//            //headers: { 'authorization': `Bearer ${token}` },
//            async: false,
//            processData: false,
//            contentType: "application/json",
//            error: function (err) {
//                Lr = true;
//                bootbox.alert({
//                    message: "Error :" + err.message
//                });
//            },
//            success: function (data) {
//                bobnud = true;
//                if (data.success) {
//                    $('#formedidlineproduct').modal('toggle');
//                    bootbox.alert({
//                        message: "Cập nhật thông tin thành công!",
//                        callback: function () {
//                            getBonus(picture, bindingLineProduct);//get bonus
//                        }
//                    })
//                }
//                else {
//                    bootbox.alert(data.message);
//                }
//            }
//        });
//    }
//}

function getLineProductById(id) {
    $.ajax({
        type: "get",
        url: "https://localhost:44344/api/lineproduct/getbyid?id=" + id,
        data: null,
        //headers: { 'authorization': `Bearer ${token}` },
        dataType: 'json',
        contentType: "application/json",
        error: function (err) {
            alert("Có lỗi xảy ra, vui lòng kiểm tra kết nối");
        },
        success: function (data) {
            //alert(data);

            viewlineproduct(data.data);
        }
    });
}
function bindingLineProduct(model) {
    if (model.success) {
        $(".abc").remove();
        if (model.data) {

            for (var i in model.data) {
                var lineProduct = model.data[i];
                $("#lineproduct").append(`<tr class="abc">
                                        <td>`+ lineProduct.lineid + `</td>
                                        <td>`+ lineProduct.linename + `</td>
                                        <td>`+ lineProduct.linenote + `</td>
                                        <td>`+ formatDate(new Date(lineProduct.createday)) + `</td>
                                        <td><div  style="background-image:url(https://localhost:44344/img/lineproduct/`+ lineProduct.picture + `) ;width:50px;height:50px;"></div></td>
                                        <td>
                                            <a  href="EditLineProduct?id=`+ lineProduct.lineid +`" ><button type="button" class="btn btn-danger" ><i class="far fa-trash-alt"></i>Edit</button></a>
                                          <a><button type="button" class="btn btn-danger" onclick="addeletelineproduct(`+ lineProduct.lineid + `)"><i class="far fa-trash-alt"></i>Delete</button></a>
                                        </td>
                                </tr>`
                );
            }
        }
    }
}

//hien thi len form
function viewlineproduct(data) {
    $("#txtlinename-edit").val(data.linename);
    $("#txtnotes").val(data.linenote);
    $("#txtcreateday-edit").val(data.createday);
    $("#txtpicture-edit").val(data.picture);

}
