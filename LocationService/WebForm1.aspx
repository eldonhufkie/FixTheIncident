<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="LocationService.Views.Home.WebForm1" %>

<!DOCTYPE html>
<html>
<head>
    <title></title>
    <meta charset="utf-8" />
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: "http://localhost:28511/api/Location/",
                dataType: 'json',
                success: function (Data) {
                    $.each(Data, function (key, val) {
                        var str = val.FaultLatitude + ',' + val.FaultLongitude;
                        $('<li/>', { text: str })
                        .appendTo($('#items'));
                    });
                }
            });
        });

        function show() {
            var Id = $('#itId').val();
            $.getJSON("http://localhost:28511/api/Location/" + Id,
                function (Data) {
                    var str = Data.FaultLatitude + ': $' + Data.FaultLongitude;
                    $('#items').text(str);
                })
            .fail(
                function (jqXHR, textStatus, err) {
                    $('#items').text('Error: ' + err);
                });
        }
    </script>

</head>
<body id="body">
    <div class="main-content">
        <div>
            <h1>Showing All Items </h1>
            <ul id="items" />
        </div>
        <div>
            <label for="itId">ID:</label>
            <input type="text" id="itId" size="5" />
            <input type="button" value="Search" onclick="show();" />
            <p id="item" />
        </div>
    </div>
</body>
</html>
