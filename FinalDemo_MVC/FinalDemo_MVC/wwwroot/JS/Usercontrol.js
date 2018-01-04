
$(document).ready(function () {

    //Sig Up page start
    $("#registerDone").click(function () {
        $.ajax(
        {
            type: "POST",
            url: "/UserAccount/UserRegistration",
            data: {
                firstName: $("#txtfirstname").val(),
                lastName: $("#txtlastname").val(),
                EmailId: $("#txtregisterId").val(),
                Password: $("#txtPassword").val(),
                Contactno: $("#txtmobileno").val(),
            },
            success: function (data) {
                window.location.href = "/UserAccount/Userlogin";
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(thrownError);
            }
        });

    });

    $('#registerCancel').click(function (e) {
        $('#txtfirstname').val('');
        $("#txtlastname").val('');
        $("#txtregisterId").val('');
        $("#txtPassword").val('');
        $("#txtmobileno").val('');
    });

   
    $('#usersignup').click(function (e) {
        window.location.href = "/UserAccount/UserRegistration"
    });

    //Image flicker
    var myimage = new Image;
    function Preloadimg() {
        for (var i = 0; i < arguments.length; i++) {
            myimage[i] = new Image();
            myimage[i].src = arguments[i];
        }
    }

    var count = 0;
    function myTimer(myimage) {

        count++;
        ///alert(count);
        for (var i = 0 ; i < 4; i++) {
            if (count == 1) {
                $('.flicker').attr("src", "/wwwroot/Images/DL.jpg");
            }
            else if (count == 2) {
                $('.flicker').attr("src", "/wwwroot/Images/Passport.jpg");
            }
            else if (count == 3) {
                $('.flicker').attr("src", "/wwwroot/Images/PanCard.jpg");
            }

        }

        if (count === 3) {

            $('.flicker').attr("src", "/wwwroot/Images/PanCard.jpg");
        }
        if (count > 2) {
            count = 0;
        }
    }


    if ($('#EmailId').length > 0) {
        Preloadimg("Passport.jpg", "PanCard.jpg", "PanCard.jpg");
        setInterval(function () { myTimer(myimage); }, 1000);
    }

    /* Log in  end */


    /*Upload documnet start */

    $('.PlusImg').click(function () {
        $('.PlusImg').hide();
        $('#Document-list').show();
    });




    //var dropdown = document.getElementById("Document-list");
    $("#Document-list").change(function (e) {
        if ($("#Document-list").val() === "NewDocument") {
            $('#Document-list').hide();
            $('.PlusImg').show();
        }
    });


    $("#Document-list").change(function (e) {

        if ($("#Document-list").val() === "PanCard") {
            window.location.href = "../UserAccount/PancardDoc";
        }
    });


    /*Pan Card Document */

    $('#docsubmit').click(function () {
        //alert("hi");
        var data = new FormData();
        var files = $("#ChooseFile").get(0).files;
        if (files.length > 0) {
            data.append("HelpSectionImages", files[0]);
            data.append("Documetname", $("#doclist").val());
            data.append("Cardno", $("#txtdoccardno").val());
            data.append("Createdate", $("#txtstartdate").val());
            data.append("expirydate", $("#txtlastdate").val());
        }

        $.ajax({
            url: "/UserAccount/PancardDoc",
            type: "POST",
            processData: false,
            contentType: false,
            cache: false,
            data: data,
            success: function (data) {
                //alert("Success");
                window.location.href = "../UserAccount/UploadDocument";
            },
            error: function (xhr, ajaxOptions, thrownError) {
                //alert(xhr.status);
                //alert(thrownError);
            }
        });
    });

    function readURL(input) {

        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#myUploadedImg').attr('src', e.target.result);
            }

            reader.readAsDataURL(input.files[0]);
        }
    }

    $("#ChooseFile").change(function () {
        readURL(this);
    });

    //$(".viewdoc").click(function () {
    //    var a = '@Html.Label(userdata.userdocno)'
    //    alert(a);
    //})
    $('.Documentnames').click(function (e) {
        alert("hi");
    })
});

