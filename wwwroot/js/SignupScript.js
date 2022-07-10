function submitform() {
    if (document.reg_form.onsubmit()) {

        var name = document.reg_form.name;
        var mobile = document.reg_form.number;
        var passwrd = document.reg_form.pass;
        var re_passwrd = document.reg_form.re_pass;

        if (name.value.length <= 0) {
            alert("Name is required");
            name.focus();
            return false;
        }

        if (mobile.value.length <= 0) {
            alert("Contact is required");
            mobile.focus();
            return false;
        }
        if (passwrd.value.length <= 0) {
            alert("Password is required");
            passwrd.focus();
            return false;
        }
        if (re_passwrd.value.length <= 0) {
            alert("Confirm your password");
            re_passwrd.focus();
            return false;
        }

        if (passwrd.length < 8) {
            document.getElementById("message").innerHTML = "**Password length must be atleast 8 characters";
            return false;
        }

        //maximum length of password validation  
        if (passwrd.length > 15) {
            document.getElementById("message").innerHTML = "**Password length must not exceed 15 characters";
            return false;
        } else {
            alert("Password is correct");
        }  

        if (passwrd != re_passwrd) {
            alert("Passwords did not match");
        } else {
            alert("Password created successfully");
        } 



        document.reg_form.submit();
    }
}





