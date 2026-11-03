const CheckPass = async () => {
    const password = document.getElementById('reg-password').value;
    if (password != 0) {
        const passResponse = await fetch('api/passwords', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(password)
        });
        if (passResponse.ok) {
            const score = await passResponse.json();
            document.getElementById('pass').value = score;
            if (score > 2) {
                document.getElementById('score').innerHTML = 'סיסמא חזקה מספיק';
            }
            else {
                document.getElementById('score').innerHTML = 'חוזק הסיסמא אינו מספק';
            }
        }
        else {
            console.log("the password request was fall");
        }
    }
};
const Register = async () => {
    const user = {
        name: document.getElementById('reg-name').value,
        email: document.getElementById('reg-email').value,
        password: document.getElementById('reg-password').value
    };
    const response = await fetch('api/Users', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(user)
    })
    if (response.ok) {
        alert("נרשמת בהצלחה")
        document.getElementById('reg-name').value = '';
        document.getElementById('reg-email').value = '';
        document.getElementById('reg-password').value = '';
    }
    else {
        alert("ההרשמה לא הצליחה")
    }
}
const Login = async () => {
    const user = {
        email: document.getElementById('log-email').value,
        password: document.getElementById('log-password').value
    };
    try {
        const response = await fetch('api/Users/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(user)
        })
        if (response.ok) {
            alert("נכנסת בהצלחה")
            const logUser = await response.json();
            sessionStorage.setItem("logUser", JSON.stringify(logUser));
            document.getElementById('log-email').value = '';
            document.getElementById('log-password').value = '';
            window.location.href = 'Update.html';
        }
        else {
            alert("שם משתמש או סיסימא שגויים");
        }
    }
    catch {
        console.log("Error!!!!")
    }
}