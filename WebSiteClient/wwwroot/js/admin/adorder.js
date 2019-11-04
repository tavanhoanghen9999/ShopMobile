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