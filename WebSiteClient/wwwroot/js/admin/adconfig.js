var linkserver = 'https://localhost:44344/api/';
var linklineproduct = 'https://localhost:44344/img/lineproduct/';
var linkproduct = 'https://localhost:44344/img/product/';
var linkcustomer = 'https://localhost:44344/img/customer/';
var linkcustomer = 'https://localhost:44344/img/supplier/';


function formatDate(date) {
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var ampm = hours >= 12 ? 'pm' : 'am';
    hours = hours % 12;
    hours = hours ? hours : 12; // the hour '0' should be '12'
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var strTime = hours + ':' + minutes + ' ' + ampm;
    var month = (date.getMonth() + 1) < 10 ? '0' + (date.getMonth() + 1) : (date.getMonth() + 1);
    var day = date.getDate() < 10 ? '0' + date.getDate() : date.getDate();
    return day + "/" + month + "/" + date.getFullYear();
}