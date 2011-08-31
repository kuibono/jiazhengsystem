$(function() {
    $(".list tr:even").css("background-color", "#E7E7E7").mouseover(function() {
        $(this).css("background-color", "#FCFDEE");
    }).mouseout(function() {
        $(this).css("background-color", "#E7E7E7");
    });

    $(".list tr:odd").css("background-color", "#FFFFFF").mouseover(function() {
        $(this).css("background-color", "#FCFDEE");
    }).mouseout(function() {
        $(this).css("background-color", "#FFFFFF");
    }); ;
})

function selAll() {
    $(".list input:checkbox").each(function() {
        $(this).attr("checked", true);
    });
}
function noSelAll() {
    $(".list input:checkbox").each(function() {
        $(this).attr("checked", !$(this).attr("checked"));
    });
}
var Request = new function() {
    this.search = window.location.search;

    this.QueryString = new Array();

    var tmparray = this.search.substr(1, this.search.length).split("&")
    for (var i = 0; i < tmparray.length; i++) {
        var tmpStr2 = tmparray[i].split("=");
        this.QueryString[tmpStr2[0]] = tmpStr2[1];
    }
}

jQuery.fn.extend({
    exist: function(table, column) {
        $(this).blur(function() {
            $.getJSON("/Tools/Exist.ashx?tableName=" + table + "&columnName=" + column + "&q=" + $(this).val() + "&id=" + Request.QueryString["id"] + "&jsoncallback=?", function(j) {
            if (j.data == "true") {
                    $(this).adderr("已经存在，请重新输入");
                }
                else {
                    $(this).removeerr();
                }
            })
        })

    },
    adderr: function(msg) {
        if ($("#err_" + this.attr("id")).size() != 0) {
            $("#err_" + this.attr("id")).remove();
        }
        this.after("<span style='color:red' id='err_" + $(this).attr("id") + "' class='error'>" + msg + "</span>");
    },
    removeerr: function() {
        $("#err_" + this.attr("id")).remove();
    }


})