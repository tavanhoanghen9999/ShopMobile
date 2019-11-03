getProduct();

function getProduct() {
    $.ajax({
        type: "get",
        url: "https://localhost:44344/api/product",
        data: null,
        //headers: { 'authorization': `Bearer ${token}` },
        dataType: 'json',
        contentType: "application/json",
        error: function (err) {
            alert("Có lỗi xảy ra, vui lòng kiểm tra kết nối");
        },
        success: function (data) {
            //alert(data);
            bindingProduct(data);

        }
    });
}

function bindingProduct(model) {
    if (model.success) {
        if (model.data) {

            for (var i in model.data) {
                var product = model.data[i];
                $("#product").append(`<tr>
                                        <td>`+ product.productid + `</td>
                                        <td>`+ product.nameproduct + `</td>
                                        <td>`+ product.price + `</td>
                                        <td>`+ product.discount + `</td>    
                                        <td>`+ product.total + `</td>
                                        <td>`+ formatDate(new Date(product.createday)) + `</td>
                                        <td>`+ product.note + `</td>
                                        <td>`+ product.picture + `</td>
                                        <td>`+ product.lineid + `</td>
                                        <td>`+ product.supplierid + `</td>
                                        <td>
                                          <button type="button" class="btn btn-warning" style="margin-bottom:5px;">Edit</button></br>
                                          <a><button type="button" class="btn btn-danger" onclick="addeleteproduct(`+ product.productid + `)"><i class="far fa-trash-alt"></i>Delete</button></a>
                                        </td>
                                </tr>`
                );
            }
        }
    }
}

function addeleteproduct(id) {
    bootbox.confirm({
        message: "This is a confirm with custom button text and color! Do you like it?",
        buttons: {
            confirm: {
                label: 'Xóa',
                className: 'btn-success'
            },
            cancel: {
                label: 'Hủy',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            if (result) {
                if (true) {
                    $.ajax({
                        type: "delete",
                        url: " https://localhost:44344/api/Product?id=" + id,
                        data: null,
                        //headers: { 'authorization': `Bearer ${token}` },
                        dataType: 'json',
                        contentType: "application/json",
                        error: function (err) {
                            alert("Có lỗi xảy ra, vui lòng kiểm tra lại");
                        },
                        success: function (data) {
                            if (data.success) {
                                alert("Xóa thông tin thành công!");
                                getProduct(bindingProduct);
                            }
                            else {
                                alert(data.message);
                            }
                        }
                    });

                }
            }
        }
        });
}


