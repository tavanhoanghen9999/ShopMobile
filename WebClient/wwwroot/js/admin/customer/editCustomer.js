var formData = new FormData();

// brower picture
function getImage() {
    $("#ip-image").click();
    $("#ip-image").change(function () {
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
    $("#ip-image").val("");
}

