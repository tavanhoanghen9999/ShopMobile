getorder();


//get loại
function getorder() {
    $.ajax({
        type: "get",
        url: linkserver + "order",
        data: null,
        //headers: { 'authorization': `Bearer ${token}` },
        dataType: 'json',
        contentType: "application/json",
        error: function (err) {
            alert("Có lỗi xảy ra, vui lòng kiểm tra kết nối");
        },
        success: function (data) {
            bindingorder(data);

        }
    });
}
function bindingorder(modle) {
    if (modle.success) {

        $(".table-linepr1").remove();
        if (modle.data) {
            for (var i in modle.data) {
                var item = modle.data[i];
                $('#item-order').append(` <div class="h body-table table-linepr1">
           
            <span class="h item-table">`+ item.orderid + `</span>
            <span class="h item-table">`+ item.nameorder + `</span>
            <span class="h item-table">`+ formatDate(new Date(item.createday)) + `</span>
            <span class="h item-table">`+ formatDate(new Date(item.daydelivery)) + `</span>
            <span class="h item-table">`+ item.address+ `</span>
            <span class="h item-table">`+ item.phonenumber+ `</span>
            <span class="h item-table">`+ item.email+ `</span>
            <span class="h item-table">`+ item.sumprice+ `</span>
            <span class="h item-table">`+ item.customerid+ `</span>
            <span class="h item-table">`+ (item.activity == 0 ? "Mới tạo" : item.activity == 1 ? "Đang giao" : "Hủy đơn hàng")+ `</span>
            <span class="h item-table">
                <i class="fa fa-pencil-square-o icon-edit bnt-add-linepr" data-toggle="modal" data-target="#linepr-edit" onclick="getLineProductById(`+ item.lineid + `)" aria-hidden="true"></i>
                <i class="fa fa-trash-o icon-edit" data-toggle="modal" data-target="#table-linepr1" onclick="deleteorder(`+ item.orderid + `)" aria-hidden="true"></i>
            </span>
        </div>`);
            }
        }
    }
}

//inser order
function insertLineProduct() {
    formData.append("nameorder", $("#txtlinename").val());
    formData.append("linenote", $("#txtnote").val());
    formData.append("address", $("#txtnote").val());
    formData.append("phonenumber", $("#txtnote").val());
    formData.append("sumprice", $("#txtnote").val());
    formData.append("customerid", $("#txtnote").val());
    formData.append("email", $("#txtnote").val());
    formData.append("createday", $("#txtcreateday").val());
    formData.append("daydelivery", $("#txtcreateday").val());

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

//delete order
function deleteorder(id) {

    if (true) {
        $.ajax({
            type: "delete",
            url: linkserver + "order?id=" + id,
            data: null,
            //headers: { 'authorization': `Bearer ${token}` },
            dataType: 'json',
            contentType: "application/json",
            error: function (err) {
                bootbox.alert("Có lỗi xảy ra, vui lòng xem trạng thái đơn hàng của bạn");
            },
            success: function (data) {
                if (data.success) {
                    bootbox.alert("Xóa thông tin thành công!");
                    getorder(bindingorder);
                }
                else {
                    alert(data.message);
                }
            }
        });

    }
}