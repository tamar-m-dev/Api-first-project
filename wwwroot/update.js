const userData = sessionStorage.getItem("logUser");
if (userData) {
    const user = JSON.parse(userData);
    document.getElementById("welcome").textContent = `ברוכים הבאים ${user.name}`
    document.getElementById('up-name').value = user.name;
    document.getElementById('up-email').value = user.email;
    document.getElementById('up-password').value = user.password;
}
else {
    window.location.href('Home.html');
}
const Update = async () => {
    const upUser = {
        name: document.getElementById('up-name').value,
        email: document.getElementById('up-email').value,
        password: document.getElementById('up-password').value,
        id: JSON.parse(userData).id,
    }
    try {
        const response = await fetch('api/Users/' + JSON.parse(userData).id, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(upUser)
        })
        if (response.ok) {
            alert('השינויים נשמרו')
        }
        else {
            alert('השינוים לא נשמרו נסה שוב')
        }
    }
    catch {
        console.log('error!')
    }
}
