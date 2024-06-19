"use strict";
var Home = function () {

    var getAllOnsiteStatuses = function () {
        var tbl = $('#dailyOnsiteStatusesTable');
        $.ajax({
            url: '/home/GetOnsiteStatuses',
            contentType: 'application/html ; charset:utf-8',
            type: 'GET',
            dataType: 'html'
        }).success(function (result) {
            tbl.empty().append(result);
        }).error(function () {

        });
    };

    var connectToHub = function () {
        // Declare a proxy to reference the hub.
        var notifications = $.connection.dailyOnsiteStatusHub;

        //debugger;
        // Create a function that the hub can call to broadcast messages.
        notifications.client.updateOnsiteStatuses = function () {
            getAllOnsiteStatuses();
        };
        // Start the connection.
        $.connection.hub.start().done(function () {
            //alert("connection started");
            getAllOnsiteStatuses();
        }).fail(function (e) {
            alert(e);
        }); 
    };

    var refreshTime = function () {
        var timeDisplay = document.getElementById("timeDisplay");
        var dateString = new Date().toLocaleString("en-GB", { timeZone: "Pacific/Port_Moresby" });
        var formattedString = dateString.replace(", ", " - ");
        timeDisplay.innerHTML = formattedString;
    };

    setInterval(refreshTime, 1000);

    var downloadExcel = function () {
        $.ajax({
            type: "POST",
            url: "/home/ExportOnsiteStatusesToExcel",
            cache: false,
            success: function (data) {
                window.location = '/home/DownloadOnsiteStatusesExcelFile';
            },
            error: function (data) {
                //Materialize.toast("Something went wrong. ", 3000, 'rounded');
                alert("Something went wrong.");
            }
        });
    };

    return {
        init: function () {
            connectToHub();
            refreshTime();
        },
        downloadOnsiteStatusesToExcel: function () {
            downloadExcel();
        }
    };

}();

jQuery(document).ready(function () {
    
    Home.init();
});


