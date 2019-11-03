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
function validateInsertLinePeoduct() {
    formData.append("linename", $("#txtlinename").val());
    formData.append("linenote", $("#txtnote").val());
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
