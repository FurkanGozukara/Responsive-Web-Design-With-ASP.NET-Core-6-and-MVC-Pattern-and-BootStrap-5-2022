// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

 
    jQuery.extend({
        getValues: function(url, target='main') {
        var result = null;
    $.ajax({
        url: url,
    type: 'get',
    async: true,
    success: function(data) {
        result = data;
        $(target).append(result);
            }
        });
    return result;
    }
    });

