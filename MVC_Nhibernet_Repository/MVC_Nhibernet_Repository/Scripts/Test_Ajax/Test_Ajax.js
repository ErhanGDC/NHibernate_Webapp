$(function () {
    $("#txtFilter").on('input', function () {
        $.ajax({
            type: "POST",
            url: "/TestAjax/AjaxMethod",
            data: '{id: "' + $("#txtFilter").val() + '" }',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $("#scienceDetail").text ="";
                if (response.length > 0) {
                    var txt = "Hello: " +
                        response[0].FirstName +
                        " " +
                        response[0].LastName +
                        " .\n Woow are you a " +
                        response[0].Title;

                    $("#scienceDetail").html(txt);

                }
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });
});

$(function () {
    $("#btnGetScience").click(function () {
        $.ajax({
            type: "GET",
            url: "/TestAjax/AjaxJsonResult",
            data: '{name: "' + $("#txtName").val() + '" }',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                console.log(response);
                var len = response.length;
                var txt = "";
                if (len > 0) {
                    $("#GetData").empty();
                    for (var i = 0; i < len; i++) {
                        if (response[i].FirstName && response[i].LastName) {
                            txt += response[i].FirstName + " " + response[i].LastName;
                        }
                        $('#GetData').append('<li>' + txt + '</li>');
                        txt = "";
                    }
                }
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });
});

$(function () {
    $('#fillTable').click(function () {
        $.ajax({
            type: "GET",
            url: "/TestAjax/AjaxJsonResult",
            data: '{id:"' + $('#txtFilter').val() + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                console.log(response);
                var len = response.length;
                var txt = "";
                if (len > 0) {
                    $("#GetData").empty();
                    for (var i = 0; i < len; i++) {
                        if (response[i].FirstName && response[i].LastName) {
                            txt += response[i].FirstName + " " + response[i].LastName;
                        }
                        var $row = $('<tr>' +
                            '<td>' + response[i].FirstName + '</td>' +
                            '<td>' + response[i].LastName + '</td>' +
                            '<td>' + response[i].Title + '</td>' +
                            '</tr>');

                        $('#scienceTable').append($row);
                        txt = "";
                    }
                }
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });
});