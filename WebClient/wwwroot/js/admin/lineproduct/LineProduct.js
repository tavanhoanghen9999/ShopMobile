getLineProduct();   

function getLineProduct(){
    $.ajax({
        type: "get",
        url: "https://localhost:44344/api/lineproduct",
        data: null,
        //headers: { 'authorization': `Bearer ${token}` },
        dataType: 'json',
        contentType: "application/json",
        error: function (err) {
            alert("Có lỗi xảy ra, vui lòng kiểm tra kết nối");
        },
        success: function (data) {
            //alert(data);
            bindingLineProduct(data);
        }
    });
}
//var x = '2019-12-12';
//var y = formatDate(new Date(x));
//alert(y);
function bindingLineProduct(model) {
    if (model.success) {
        $(".abc").remove();
        if (model.data) {
            
            for (var i in model.data) {
                var lineProduct = model.data[i];
                $("#lineproduct").append(`<tr class="abc">
                                        <td>`+ lineProduct.lineid +`</td>
                                        <td>`+ lineProduct.linename +`</td>
                                        <td>`+ lineProduct.linenote + `</td>
                                        <td>`+ formatDate(new Date(lineProduct.createday)) + `</td>
                                        <td >`+ lineProduct.picture +`</td>
                                        <td>
                                            <a  href="EditLineProduct" ><button type="button" class="btn btn-danger" ><i class="far fa-trash-alt"></i>Edit</button></a>
                                          <a><button type="button" class="btn btn-danger" onclick="addeletelineproduct(`+ lineProduct.lineid +`)"><i class="far fa-trash-alt"></i>Delete</button></a>
                                        </td>
                                </tr>`
                );
            }
        }
    }
}
