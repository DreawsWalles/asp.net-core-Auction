function ValidMail() {
    let array1 = ['yandex', 'mail', 'rambler', 'outlook'];
    let array2 = ['ru', 'com', 'lr'];
    let re = /^[\w-\.]+@[\w-]+\.[a-z]{2,4}$/i;
    let myMail = document.getElementById('email').value;
    let valid = re.test(myMail);
    if (valid) {
        let tmp = myMail.split('@')[1].split('.');
        let isOk1 = false;
        let isOk2 = false;
        let i = 0;
        while (!isOk1)
            if (array1[i] == tmp[0])
                isOk1 = true;
            else
                i++;
        i = 0;
        while (!isOk2)
            if (array2[i] == tmp[1])
                isOk2 = true;
            else
                i++;
        if (!(isOk1 && isOk2))
            return false;
    }
    return valid;
}
function ValidPhone() {
    let re = /^\d[\d\(\)\ -]{4,14}\d$/;
    let myPhone = document.getElementById('phone').value;
    let valid = re.test(myPhone);
    return valid;
}
function valifateForm(form) {
    debugger
    let errors = document.getElementsByClassName("error");
    let e = document.getElementsByTagName("input");
    if (document.getElementById("Name").nodeValue == undefined) {
        errors[0].innerHTML = "Данное поле не должно быть пустым";
        return
    }
    errors[0].innerHTML = "";
    if (!document.getElementById("Sername").nodeValue) {
        errors[1].innerHTML = "Данное поле не должно быть пустым";
        return;
    }
    errors[1].innerHTML = "";
    if (!document.getElementById("Patronymic").nodeValue) {
        errors[2].innerHTML = "Данное поле не должно быть пустым";
        return false;
    }
    errors[2].innerHTML = "";
    if (!document.getElementById("Email").nodeValue) {
        errors[3].innerHTML = "Данное поле не должно быть пустым";
        return false;
    }
    else if (!ValidMail(document.getElementById("Email").Value)) {
        errors[3].innerHTML = "Некорректный Email";
        return false;
    }
    errors[3].innerHTML = "";
    return true;
}