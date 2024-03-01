function ajaxCalls(method, api, data, successCB, errorCB) {
    $.ajax({
        type: method,
        url: api,
        data: data,
        cache: false,
        contentType: "application/json",
        dataType: "json",
        success: function (response) {
            successCB(response)
        },
        error: errorCB
    });

    

}