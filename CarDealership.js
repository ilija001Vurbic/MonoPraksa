
function validateEmail(inputText){
    var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if(inputText.value.match(mailformat))
    {
        alert("Valid email address!");
        document.form1.email.focus();
        return true;
    }
    else
    {
        alert("Invalid email address!");
        document.form1.email.focus();
        return false;
    }
}
function add(){
    if(!validateEmail(document.form1.email)){
        alert("Try again!");
    }
    else{
        var name = document.getElementById("name");
        var surname = document.getElementById("surname");
        var email = document.getElementById("email");
        var car = document.getElementById("car");
        var output = document.querySelector("#output tbody");
        output.innerHTML += "<tr><td>"+name.value+"</td><td>"+surname.value+"</td><td>"+email.value+"</td><td>"+car.value+"</td></tr>"
        alert("Thank you, you will be contacted shortly about availability of the requested model.");
    }
}
