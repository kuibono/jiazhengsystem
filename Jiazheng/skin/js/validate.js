jQuery.fn.extend({
    err: function(msg) {
        if ($("#err_" + this.attr("id")).size() != 0) {
            $("#err_" + this.attr("id")).remove();
        }
        this.after("<span style='color:red' id='err_" + $(this).attr("id") + "' class='error'>" + msg + "</span>");
    },
    clearerr: function() {
        $("#err_" + this.attr("id")).remove();
    },
    cannotnull: function() {
//        $(this).blur(function() {
//            var values = $(this).val();
//            if (values == "") {
//                $(this).err("必填项！");
//            }
//            else {
//                $(this).clearerr();
//            }
//        });

    },
    isTel: function() {
        $(this).blur(function() {
            var values = $(this).val();
            reg = new RegExp(/^((\d{3,4}-)|\d{3.4}-)?\d{7,8}$/);
            if (!reg.test(values) && values!="") {
                $(this).err("格式不正确！");
            }
            else {
                $(this).clearerr();
            }
        })
    },
    isMobile: function() {
        $(this).blur(function() {
            var values = $(this).val();
            reg = new RegExp(/^1[358]\d{9}$/);
            if (!reg.test(values) && values != "") {
                $(this).err("格式不正确！");
            }
            else {
                $(this).clearerr();
            }
        })
    },
    isMobileOrTel: function() {
        $(this).blur(function() {
            var values = $(this).val();
            reg = new RegExp(/^1[358]\d{9}$/);
            reg2 = new RegExp(/^((\d{3,4}-)|\d{3.4}-)?\d{7,8}$/);
            if (!reg.test(values) && !reg2.test(values) && values != "") {
                $(this).err("格式不正确！");
            }
            else {
                $(this).clearerr();
            }
        })
    },
    
    isInt: function() {
        $(this).blur(function() {
            var values = $(this).val();
            if (isNaN(values) && values != "") {
                $(this).err("格式不正确！");
            }
            else {
                $(this).clearerr();
            }
        })
    },
    isDouble: function() {
        $(this).blur(function() {
            var values = $(this).val();
            reg = new RegExp(/^[-]?\d+[.]?\d*$/);
            if (!reg.test(values) && values != "") {
                $(this).err("格式不正确！");
            }
            else {
                $(this).clearerr();
            }
        })
    },
    len: function(min, max) {
        var values = $(this).val();
        if ((values.length > max || values.length < min) && values!="") {
            $(this).err("长度必须在" + min + "-" + max + "之间！");
        }
        else {
            $(this).clearerr();
        }
    },
    same: function(id) {
        var values = $(this).val();
        if (values != $("#" + id).val()) {
            $(this).err("两次输入不一致！");
        }
        else {
            $(this).clearerr();
        }
    },
    ismail: function() {
        $(this).blur(function() {
            var values = $(this).val();
            reg = new RegExp(/^[a-zA-Z0-9]+@[a-zA-Z0-9]+.[a-z][a-z.]{2,8}$/);
            if (!reg.test(values) && values != "") {
                $(this).err("格式不正确！");
            }
            else {
                $(this).clearerr();
            }
        })
    },
    checkForm: function() {
        $(this).submit(function() {
            $(this).find("input").each(function() {
                $(this).blur();
            });
            if ($(".error").size() > 0) {
                return false;
            }
        })
    }
})