function addeletelineproduct(id) {

    if (true) {
        $.ajax({
            type: "delete",
            url: " https://localhost:44344/api/LineProduct?id=" + id,
            data: null,
            //headers: { 'authorization': `Bearer ${token}` },
            dataType: 'json',
            contentType: "application/json",
            error: function (err) {
                alert("Có lỗi xảy ra, loại của bạn có trong sản phẩm");
            },
            success: function (data) {
                if (data.success) {
                    alert("Xóa thông tin thành công!");
                    getLineProduct(bindingLineProduct);
                }
                else {
                    alert(data.message);
                }
            }
        });

    }
}
//function addeletelineproduct(id) {
//    bootbox.confirm({
//        message: "This is a confirm with custom button text and color! Do you like it?",
//        buttons: {
//            confirm: {
//                label: 'Xóa',
//                className: 'btn-success'
//            },
//            cancel: {
//                label: 'Hủy',
//                className: 'btn-danger'
//            }
//        }
//    }
//        callback: function (result) {
//            if (result) {
//                if (true) {
//                    $.ajax({
//                        type: "delete",
//                        url: " https://localhost:44344/api/LineProduct?id=" + id,
//                        data: null,
//                        //headers: { 'authorization': `Bearer ${token}` },
//                        dataType: 'json',
//                        contentType: "application/json",
//                        error: function (err) {
//                            alert("Có lỗi xảy ra, loại của bạn có trong sản phẩm");
//                        },
//                        success: function (data) {
//                            if (data.success) {
//                                alert("Xóa thông tin thành công!");
//                                getLineProduct(bindingLineProduct);
//                            }
//                            else {
//                                alert(data.message);
//                            }
//                        }
//                    });

//                }
//            }
//        }
//    });

//function addeletelineproduct(id) {
//bootbox.confirm({
//    message: "This is a confirm with custom button text and color! Do you like it?",
//    buttons: {
//        confirm: {
//            label: 'Yes',
//            className: 'btn-success'
//        },
//        cancel: {
//            label: 'No',
//            className: 'btn-danger'
//        }
//    },
//    callback: function (result) {
//        if (result) {
//            if (true) {
//                $.ajax({
//                    type: "delete",
//                    url: " https://localhost:44344/api/LineProduct?id=" + id,
//                    data: null,
//                    //headers: { 'authorization': `Bearer ${token}` },
//                    dataType: 'json',
//                    contentType: "application/json",
//                    error: function (err) {
//                        alert("Có lỗi xảy ra, loại của bạn có trong sản phẩm");
//                    },
//                    success: function (data) {
//                        if (data.success) {
//                            alert("Xóa thông tin thành công!");
//                            getLineProduct(bindingLineProduct);
//                        }
//                        else {
//                            alert(data.message);
//                        }
//                    }
//                });

//            }
//        }
//    }
//    });
//}