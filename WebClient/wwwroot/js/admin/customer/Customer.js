getCustomer();

function getCustomer() {
    $.ajax({
        type: "get",
        url: "https://localhost:44344/api/customer",
        data: null,
        //headers: { 'authorization': `Bearer ${token}` },
        dataType: 'json',
        contentType: "application/json",
        error: function (err) {
            alert("Có lỗi xảy ra, vui lòng kiểm tra kết nối");
        },
        success: function (data) {
            //alert(data);
            bindingCustomer(data);
        }
            
    });
}

function bindingCustomer(model) {
    if (model.success) {
        if (model.data) {

            for (var i in model.data) {
                var customer = model.data[i];
                $("#customer").append(`<tr>
                                        <td>`+ customer.customerid + `</td>
                                        <td>`+ customer.namecustomer + `</td>
                                        <td>`+ customer.phonenumber + `</td>
                                        <td>`+ customer.email + `</td>
                                        <td>`+ customer.address + `</td>
                                        <td>`+ customer.picture + `</td>
                                      
                                        
                                        <td>
                                            <button type="button" class="btn btn-warning" style="margin-bottom:5px;">Edit</button></br>
                                          <a><button type="button" class="btn btn-danger" onclick=""><i class="far fa-trash-alt"></i>Delete</button></a>
                                        </td>
                                </tr>`);
            }
        }
    }
}
