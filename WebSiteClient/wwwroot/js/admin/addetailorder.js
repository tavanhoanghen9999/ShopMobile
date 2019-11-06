getdetailorder();


//get loại
function getdetailorder() {
    $.ajax({
        type: "get",
        url: linkserver + "detailorder",
        data: null,
        //headers: { 'authorization': `Bearer ${token}` },
        dataType: 'json',
        contentType: "application/json",
        error: function (err) {
            alert("Có lỗi xảy ra, vui lòng kiểm tra kết nối");
        },
        success: function (data) {
            bindingdetailorder(data);

        }
    });
}
function bindingdetailorder(modle) {
    if (modle.success) {

        $(".table-linepr1").remove();
        if (modle.data) {
            for (var i in modle.data) {
                var item = modle.data[i];
                $('#item-torder').append(` <div class="h body-table table-linepr1">
                    <span class="h item-table">`+ item.detailorderid + `</span>
                    <span class="h item-table">`+ item.total + `</span>
                    <span class="h item-table">`+ item.price + `</span>
                    <span class="h item-table">`+ item.discount + `</span>
                    <span class="h item-table">`+ item.orderid + `</span>
                    <span class="h item-table">`+ item.productid + `</span>
                    <span class="h item-table">`+ (item.activity == 0 ? "Đã xử lý" : "Chưa xử lý") + `</span>
                    <span class="h item-table">
                        <i class="fa fa-pencil-square-o icon-edit bnt-add-linepr" data-toggle="modal" data-target="#linepr-edit" onclick="getLineProductById(`+ item.lineid + `)" aria-hidden="true"></i>
                        <i class="fa fa-trash-o icon-edit" data-toggle="modal" data-target="#table-linepr1" onclick="deletedetailorder(`+ item.detailorderid + `)" aria-hidden="true"></i>
            </span>
        </div>`);
            }
        }
    }
}

//delete order
function deletedetailorder(id) {

    if (true) {
        $.ajax({
            type: "delete",
            url: linkserver + "detailorder?id=" + id,
            data: null,
            //headers: { 'authorization': `Bearer ${token}` },
            dataType: 'json',
            contentType: "application/json",
            error: function (err) {
                bootbox.alert("Có lỗi xảy ra, vui lòng xem trạng thái chi tiết đơn hàng của bạn");
            },
            success: function (data) {
                if (data.success) {
                    bootbox.alert("Xóa thông tin thành công!");
                    getdetailorder(bindingdetailorder);
                }
                else {
                    alert(data.message);
                }
            }
        });

    }
}