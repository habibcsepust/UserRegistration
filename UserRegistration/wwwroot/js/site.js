// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(function () {
    //var PlaceHolderElement = $('#PlaceHolderHere');
    //$('button[data-toggle="ajax-modal"]').click(function (event) {
    //    var url = $(this).data('url');
    //    var decodeUrl = decodeURIComponent(url);
    //    $.get(decodeUrl).done(function (data) {
    //        //alert(PlaceHolderElement);
    //        PlaceHolderElement.html(data);
    //        PlaceHolderElement.find('.modal').modal('show');
    //    })
    //})

    //PlaceHolderElement.on('click', '[data-save="modal"]', function (event) {
    //    //var form = $(this).parents('modal').find('form');
    //    var form = $('.modal-body .modal-body').find('form');
    //    var actionUrl = form.attr('action');
    //    alert("actionUrl: " + actionUrl);
    //    var url = "/Home/UserList/Create";
    //    //var senddata = form.serialize();
    //    var senddata = $("#addUser .modal-body form").serialize()
    //    alert("senddata: " + senddata);
    //    $.post(url, senddata).done(function (data) {
    //        PlaceHolderElement.find('.modal').modal('hide');
    //    })
    //})


    $(document).on('click', '#saveData', function () {
        //Lirst Name validation
        var fName = $(".fName").val();
        var lName = $(".lName").val();
        var phone = $(".phoneNo").val();
        var email = $(".emailNo").val();
        var password = $(".password").val();
        var dob = $(".dob").val();
        var Gender = $(".Gender").val();

        if (fName == "") {
            $("</br><span id='fError'>First name can not be empty</span></br>").insertBefore(".fName");
            if ($('#fError').length) {
                $("#fError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
                $(".fName").focus();
            } else {
                $('#fError').removeAttr('style');
            }
            return false;
        }
        else
        {
            $("#fError").remove();
        }
        

        //Last Name validation
        if (lName == "") {
            $("</br><span id='lError'>Last name can not be empty</span></br>").insertBefore(".lName");
            if ($('#lError').length) {
                $("#lError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
                $(".lName").focus();
            } else {
                $('#lError').removeAttr('style');
            }
            return false;
        }
        else
        {
            $("#lError").remove();
        }
        

        //Email validation
        if (email == "") {
            $("</br><span id='emailError'>Email address can not be empty</span></br>").insertBefore(".emailNo");
            if ($('#emailError').length) {
                $("#emailError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
                $(".emailNo").focus();
            } else {
                $('#emailError').removeAttr('style');
            }
            return false;
        }
        else {
            $("#emailError").remove();
        }


        //Phone validation
        if (phone == "") {
            $("</br><span id='phoneError'>Phone number can not be empty</span></br>").insertBefore(".phoneNo");
            if ($('#phoneError').length) {
                $("#phoneError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
                $(".phoneNo").focus();
            } else {
                $('#phoneError').removeAttr('style');
            }
            return false;
        }
        else {
            $("#phoneError").remove();
        }


        //password validation
        if (password == "") {
            $("</br><span id='passwordError'>Password field can not be empty</span></br>").insertBefore(".password");
            if ($('#passwordError').length) {
                $("#passwordError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
                $(".password").focus();
            } else {
                $('#passwordError').removeAttr('style');
            }
            return false;
        }
        else {
            $("#passwordError").remove();
        }

        //Birthdate validation
        if (dob == "") {
            $("</br><span id='dobError'>Birthdate can not be empty</span></br>").insertBefore(".dob");
            if ($('#dobError').length) {
                $("#dobError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
                $(".dob").focus();
            } else {
                $('#dobError').removeAttr('style');
            }
            return false;
        }
        else {
            $("#dobError").remove();
        }


        //Gender filed validation
        if (Gender == "") {
            $("</br><span id='genderError'>Gender field can not be empty</span></br>").insertBefore(".Gender");
            if ($('#genderError').length) {
                $("#genderError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
                $(".Gender").focus();
            } else {
                $('#genderError').removeAttr('style');
            }
            return false;
        }
        else {
            $("#genderError").remove();
        }
    });
})

