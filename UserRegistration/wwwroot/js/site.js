// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.




$(document).ready(function () {
    $(document).on('click', '#saveData', function () {
        var phoneNo = $("#phoneNo").val();
        var emailNo = $("#emailNo").val();
        var countryName = $("#countryName").val();
        var userCity = $("#userCity").val();
        var userImg = $("#userImg").val();
        var userCV = $("#userCV").val();
        //alert("userCity: " + userCity);
        var dob = $("#AddNewRecord .dobInsert").val();


        var fName = $(".fName").val();
        var lName = $(".lName").val();
        var phone = $(".phoneNo").val();
        var email = $(".emailNo").val();
        var password = $(".password").val();
        var Gender = $(".Gender").val();
        var country = $("#AddNewRecord #countrylist").val();
        var city = $("#AddNewRecord .userCity").val();
        var image = $("#AddNewRecord .userImg").val();
        var cv = $("#AddNewRecord .userCV").val();






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
        else {
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
        else {
            $("#lError").remove();
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


        //Country validation
        if (country == "") {
            $("</br><span id='countryError'>Select your country, please.</span></br>").insertBefore("#AddNewRecord #countrylist");
            if ($('#countryError').length) {
                $("#countryError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
                $("#AddNewRecord #countrylist").focus();
            } else {
                $('#countryError').removeAttr('style');
            }
            return false;
        }
        else {
            $("#countryError").remove();
        }

        if (city == "") {
            $("</br><span id='cityError'>Select your city, please!</span></br>").insertBefore("#AddNewRecord .userCity");
            if ($('#cityError').length) {
                $("#cityError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
                $("#AddNewRecord .userCity").focus();
            } else {
                $('#cityError').removeAttr('style');
            }
            return false;
        }
        else {
            $("#cityError").remove();
        }

        if (image == "") {
            $("</br><span id='cityError'>Select image, please!</span></br>").insertBefore("#AddNewRecord .userImg");
            if ($('#cityError').length) {
                $("#cityError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
                $("#AddNewRecord .userImg").focus();
            } else {
                $('#cityError').removeAttr('style');
            }
            return false;
        }
        else {
            $("#cityError").remove();
        }

        if (cv == "") {
            $("</br><span id='cityError'>Select CV, please!</span></br>").insertBefore("#AddNewRecord .userCV");
            if ($('#cityError').length) {
                $("#cityError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
                $("#AddNewRecord .userCV").focus();
            } else {
                $('#cityError').removeAttr('style');
            }
            return false;
        }
        else {
            $("#cityError").remove();
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
            $("</br><span id='dobError'>Birthdate can not be empty</span></br>").insertBefore(".dobInsert");
            if ($('#dobError').length) {
                $("#dobError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
                $(".dobInsert").focus();
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

        var jsonRequestData = { fName: fName, lName: lName, phoneNo: phoneNo, emailNo: emailNo, countryName: countryName, userCity: userCity, userImg: userImg, userImg: userImg, userCV: userCV, password: password, dob: dob, Gender: Gender }

        $.ajax({
            type: 'POST',
            url: 'Reg/Create/',
            data: jsonRequestData,
            success: function (response) {
                //$('#EditRecord #id').val(response.id);
            }
        })
    });
});




function myEditFunction(i) {
    var id = $('#editRecord_' + i).attr('idVal');
    var cityId;
    //alert(id);
    var jsonRequestData = { id: id }


    $.ajax({
        type: 'POST',
        url: 'Edit/',
        data: jsonRequestData,
        success: function (response) {
            $("#hId").val(response.id);
            $("#hCountryName").val(response.countryId);
            $(".fName1").val(response.fName);
            $(".lName1").val(response.lName);
            $(".phoneNo1").val(response.phone);
            $(".emailNo1").val(response.email);
            $(".password1").val(response.password);
            $(".dobEdit").val(response.dob);

            //alert(response.cityId);
            cityId = response.cityId;

            if (response.countryId != undefined) {
                $('select#countrylist').find('option').each(function () {
                    //alert($(this).val());
                    if (parseInt($(this).val()) == parseInt(response.countryId)) {
                        $(this).prop("selected", true);
                        $(this).trigger("change");

                        //$('select#userCity').find('option').each(function () {
                        //    alert("EachVal: "+$(this).val());
                        //    alert("cityId: " + response.cityId);
                        //    if (parseInt($(this).val()) == parseInt(response.cityId)) {
                        //        $(this).prop("selected", true);
                        //    }
                        //});
                    }
                });


            }

            if (response.gender == "male") {
                $(".Gender1").attr("checked", "checked");
            } else if (response.gender == "female") {
                $(".Gender2").attr("checked", "checked");
            } else {
                $(".Gender3").attr("checked", "checked");
            }



            $('#EditRecord').modal('show');
        },

        complete: function (response) {

        }
    });
}



//$(document).ready(function () {
//    $('#updateData').on('click', function () {
//        //alert("PLEASE IGNORE..!! Not done yet database update for update data.");
//        //return false;

//        var fName = $("#fName").val();
//        var lName = $("#lName").val();
//        var phoneNo = $("#phoneNo").val();
//        var emailNo = $("#emailNo").val();
//        var countryName = $("#countryName").val();
//        var userCity = $("#userCity").val();
//        var userImg = $("#userImg").val();
//        var userCV = $("#userCV").val();
//        alert("userCity: " + userCity);
//        var password = $("#password").val();
//        var dob = $("#dob").val();
//        var Gender = $("#Gender").val();

//        var jsonRequestData = { fName: fName, lName: lName, phoneNo: phoneNo, emailNo: emailNo, countryName: countryName, userCity: userCity, userImg: userImg, userImg: userImg, userCV: userCV, password: password, dob: dob, Gender: Gender }

//        $.ajax({
//            type: 'POST',
//            url: 'Reg/Create/',
//            data: jsonRequestData,
//            success: function (response) {
//                //$('#EditRecord #id').val(response.id);
//            }
//        })
//    });
//});







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




    //$(document).on('click', '#saveData', function () {
    //    //Lirst Name validation
    //    var fName = $(".fName").val();
    //    var lName = $(".lName").val();
    //    var phone = $(".phoneNo").val();
    //    var email = $(".emailNo").val();
    //    var password = $(".password").val();
    //    var dob = $("#AddNewRecord .dobInsert").val();
    //    var Gender = $(".Gender").val();
    //    var country = $("#AddNewRecord #countrylist").val();
    //    var city = $("#AddNewRecord .userCity").val();
    //    var image = $("#AddNewRecord .userImg").val();
    //    var cv = $("#AddNewRecord .userCV").val();

        

    //    if (fName == "") {
    //        $("</br><span id='fError'>First name can not be empty</span></br>").insertBefore(".fName");
    //        if ($('#fError').length) {
    //            $("#fError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
    //            $(".fName").focus();
    //        } else {
    //            $('#fError').removeAttr('style');
    //        }
    //        return false;
    //    }
    //    else
    //    {
    //        $("#fError").remove();
    //    }
        

    //    //Last Name validation
    //    if (lName == "") {
    //        $("</br><span id='lError'>Last name can not be empty</span></br>").insertBefore(".lName");
    //        if ($('#lError').length) {
    //            $("#lError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
    //            $(".lName").focus();
    //        } else {
    //            $('#lError').removeAttr('style');
    //        }
    //        return false;
    //    }
    //    else
    //    {
    //        $("#lError").remove();
    //    }
        

    //    //Email validation
    //    if (email == "") {
    //        $("</br><span id='emailError'>Email address can not be empty</span></br>").insertBefore(".emailNo");
    //        if ($('#emailError').length) {
    //            $("#emailError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
    //            $(".emailNo").focus();
    //        } else {
    //            $('#emailError').removeAttr('style');
    //        }
    //        return false;
    //    }
    //    else {
    //        $("#emailError").remove();
    //    }


    //    //Country validation
    //    if (country == "") {
    //        $("</br><span id='countryError'>Select your country, please.</span></br>").insertBefore("#AddNewRecord #countrylist");
    //        if ($('#countryError').length) {
    //            $("#countryError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
    //            $("#AddNewRecord #countrylist").focus();
    //        } else {
    //            $('#countryError').removeAttr('style');
    //        }
    //        return false;
    //    }
    //    else {
    //        $("#countryError").remove();
    //    }

    //    if (city == "") {
    //        $("</br><span id='cityError'>Select your city, please!</span></br>").insertBefore("#AddNewRecord .userCity");
    //        if ($('#cityError').length) {
    //            $("#cityError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
    //            $("#AddNewRecord .userCity").focus();
    //        } else {
    //            $('#cityError').removeAttr('style');
    //        }
    //        return false;
    //    }
    //    else {
    //        $("#cityError").remove();
    //    }

    //    if (image == "") {
    //        $("</br><span id='cityError'>Select image, please!</span></br>").insertBefore("#AddNewRecord .userImg");
    //        if ($('#cityError').length) {
    //            $("#cityError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
    //            $("#AddNewRecord .userImg").focus();
    //        } else {
    //            $('#cityError').removeAttr('style');
    //        }
    //        return false;
    //    }
    //    else {
    //        $("#cityError").remove();
    //    }

    //    if (cv == "") {
    //        $("</br><span id='cityError'>Select CV, please!</span></br>").insertBefore("#AddNewRecord .userCV");
    //        if ($('#cityError').length) {
    //            $("#cityError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
    //            $("#AddNewRecord .userCV").focus();
    //        } else {
    //            $('#cityError').removeAttr('style');
    //        }
    //        return false;
    //    }
    //    else {
    //        $("#cityError").remove();
    //    }


    //    //Phone validation
    //    if (phone == "") {
    //        $("</br><span id='phoneError'>Phone number can not be empty</span></br>").insertBefore(".phoneNo");
    //        if ($('#phoneError').length) {
    //            $("#phoneError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
    //            $(".phoneNo").focus();
    //        } else {
    //            $('#phoneError').removeAttr('style');
    //        }
    //        return false;
    //    }
    //    else {
    //        $("#phoneError").remove();
    //    }


    //    //password validation
    //    if (password == "") {
    //        $("</br><span id='passwordError'>Password field can not be empty</span></br>").insertBefore(".password");
    //        if ($('#passwordError').length) {
    //            $("#passwordError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
    //            $(".password").focus();
    //        } else {
    //            $('#passwordError').removeAttr('style');
    //        }
    //        return false;
    //    }
    //    else {
    //        $("#passwordError").remove();
    //    }

    //    //Birthdate validation
    //    if (dob == "") {
    //        $("</br><span id='dobError'>Birthdate can not be empty</span></br>").insertBefore(".dobInsert");
    //        if ($('#dobError').length) {
    //            $("#dobError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
    //            $(".dobInsert").focus();
    //        } else {
    //            $('#dobError').removeAttr('style');
    //        }
    //        return false;
    //    }
    //    else {
    //        $("#dobError").remove();
    //    }


    //    //Gender filed validation
    //    if (Gender == "") {
    //        $("</br><span id='genderError'>Gender field can not be empty</span></br>").insertBefore(".Gender");
    //        if ($('#genderError').length) {
    //            $("#genderError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
    //            $(".Gender").focus();
    //        } else {
    //            $('#genderError').removeAttr('style');
    //        }
    //        return false;
    //    }
    //    else {
    //        $("#genderError").remove();
    //    }
    //});


    $(document).on('click', '#updateData', function () {
        //Lirst Name validation
        var fName = $(".fName1").val();
        var lName = $(".lName1").val();
        var phone = $(".phoneNo1").val();
        var email = $(".emailNo1").val();
        var password = $(".password1").val();
        var dob = $(".dobEdit").val();
        var Gender = $(".Gender").val();
        var country = $("#EditRecord #countrylist").val();
        var city = $("#EditRecord #userCity").val();
        

        if (fName == "") {
            $("</br><span id='fError'>First name can not be empty</span></br>").insertBefore(".fName1");
            if ($('#fError').length) {
                $("#fError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
                $(".fName1").focus();
            } else {
                $('#fError').removeAttr('style');
            }
            return false;
        }
        else {
            $("#fError").remove();
        }


        //Last Name validation
        if (lName == "") {
            $("</br><span id='lError'>Last name can not be empty</span></br>").insertBefore(".lName1");
            if ($('#lError').length) {
                $("#lError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
                $(".lName1").focus();
            } else {
                $('#lError').removeAttr('style');
            }
            return false;
        }
        else {
            $("#lError").remove();
        }


        //Email validation
        if (email == "") {
            $("</br><span id='emailError'>Email address can not be empty</span></br>").insertBefore(".emailNo1");
            if ($('#emailError').length) {
                $("#emailError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
                $(".emailNo1").focus();
            } else {
                $('#emailError').removeAttr('style');
            }
            return false;
        }
        else {
            $("#emailError").remove();
        }


        //Country validation
        if (country == "") {
            $("</br><span id='countryError'>Select your country, please.</span></br>").insertBefore("#EditRecord #countrylist");
            if ($('#countryError').length) {
                $("#countryError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
                $("#EditRecord #countrylist").focus();
            } else {
                $('#countryError').removeAttr('style');
            }
            return false;
        }
        else {
            $("#countryError").remove();
        }

        if (city == "") {
            $("</br><span id='cityError'>Select your city, please!</span></br>").insertBefore("#EditRecord #userCity");
            if ($('#cityError').length) {
                $("#cityError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
                $("#EditRecord #userCity").focus();
            } else {
                $('#cityError').removeAttr('style');
            }
            return false;
        }
        else {
            $("#cityError").remove();
        }


        //Phone validation
        if (phone == "") {
            $("</br><span id='phoneError'>Phone number can not be empty</span></br>").insertBefore(".phoneNo1");
            if ($('#phoneError').length) {
                $("#phoneError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
                $(".phoneNo1").focus();
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
            $("</br><span id='passwordError'>Password field can not be empty</span></br>").insertBefore(".password1");
            if ($('#passwordError').length) {
                $("#passwordError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
                $(".password1").focus();
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
            $("</br><span id='dobError'>Birthdate can not be empty</span></br>").insertBefore(".dobEdit");
            if ($('#dobError').length) {
                $("#dobError").css({ "font-weight": "600", "font-style": "italic", "color": "red" });
                $(".dobEdit").focus();
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

