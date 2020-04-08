$(document).ready(function () {

    $(document).on("click", ".loadquickview", function (event) {

        var id = $(this).attr("productid");

        //var roleid = $("#hdRoleID").val();

        event.preventDefault();
        event.stopPropagation();

        $.ajax({
            url: '/product/GetQuickView',
            contentType: 'application/html; charset=utf-8',
            data: { id: id },
            type: 'GET',
            dataType: 'html'
            , success: function (data) {

                $("#viewquick").html(data);

                //$('.cloud-zoom, .cloud-zoom-gallery').CloudZoom();

                

            },
            error: function (xhr, status) {
                alert("Fail connect to system server. Please try again or check internet connection.");

            },
            complete: function (xhr, status) {

                //$.loadScript('../js/cloudzoom.js');
                //$.loadScript('../js/cloud-zoom.js');

                $('#QuickViewModal').modal({ backdrop: 'static', keyboard: false });
            }
        });

    });



});