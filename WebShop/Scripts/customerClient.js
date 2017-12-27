'use strict'

$(function () {
    $.ajax({
        url: window.location.protocol + "//" + window.location.host + "/api/customer"
    }).then(function (data) {        
        fillCustomerRows(data);
    });
});

// - - - CUSTOMERS - - - 

$(".customers").off('click', 'button.remove-btn').on('click', 'button.remove-btn', function () {
    var id = $(this)[0].id;
    var btn = $(this)[0];
    removeCustomer(id, btn);
});

function fillCustomerRows(data) {
    $(".customers tbody").html('');
    $(data).each(function (index, item) {
        $(".customers tbody").append("<tr><th>" + item.Id + "</th><th>" + item.Name + '</th><th><button class="btn btn-sm glyphicon glyphicon-remove remove-btn" id="' + item.Id + '"></button></th><th><button class="btn btn-sm glyphicon glyphicon-th-list get-orders" id="' + item.Id +'"></button></th></td>');
    });    
}

function removeCustomer(id, btn) {
    $.ajax({
        url: window.location.protocol + "//" + window.location.host + "/api/customer/" + id,
        type: "DELETE",
        success: function () {
            $(btn).parent().parent().fadeOut();
        }
    });
}

// - - - ORDERS - - -

$(".customers").on('click', 'button.get-orders', function(){
    var id = $(this)[0].id;
    var btn = $(this)[0];
    var customerName = $(btn).parent().parent().find("th:eq(1)").html();
    $(".orders > table > caption > h3").html(customerName + " Orders");
    getOrders(id);
});

function getOrders(id) {
    $.ajax({
        url: window.location.protocol + "//" + window.location.host + "/api/order?customerId=" + id,
        type: "GET",
        success: function (data) {
            fillOrderRows(data);
        }
    });
}

function fillOrderRows(data) {
    $(".orders tbody").html('');
    $(data).each(function (index, item) {
        $(".orders tbody").append("<tr><th>" + item.Id + "</th><th>" + item.Date + '</th><th><button class="btn btn-sm glyphicon glyphicon-remove remove-btn" id="' + item.Id + '"></button></th><th><button class="btn btn-sm glyphicon glyphicon-th-list get-products" id="' + item.Id + '"></button></th></td>');
    });
}

// - - - PRODUCTS - - -

$(".orders").on('click', 'button.get-products', function () {
    var id = $(this)[0].id;
    var btn = $(this)[0];
    var orderId = $(btn).parent().parent().find("th:eq(0)").html();
    $(".products > table > caption > h3").html("Order #" + orderId + " Products");
    getProducts(id);
});

function getProducts(id) {
    $.ajax({
        url: window.location.protocol + "//" + window.location.host + "/api/product?orderId=" + id,
        type: "GET",
        success: function (data) {
            fillProductRows(data);
        }
    });
}

function fillProductRows(data) {
    $(".products tbody").html('');
    $(data).each(function (index, item) {
        $(".products tbody").append("<tr><th>" + item.Id + '</th><th>' + item.Name + '</th><th>' + item.Price + '</th><th><button class="btn btn-sm glyphicon glyphicon-remove remove-btn" id="' + item.Id + '"></th></td>');
    });
}