const firstNameInput = document.getElementById('firstName-input');
const firstNameError = document.getElementById('firstName-validation-error');

firstNameInput.addEventListener('blur', function () {
    const firstName = firstNameInput.value.trim();
    if (firstName === '') {
        firstNameError.textContent = 'Du måste ange ett förnamn.';
    } else if (firstName.length < 2) {
        firstNameError.textContent = 'Förnamn måste ha minst 2 bokstäver.';
    } else if (!/^[a-zA-Z\u00C0-\u017F]+([\s\-'][a-zA-Z\u00C0-\u017F]+)*$/.test(firstName)) {
        firstNameError.textContent = 'Förnamn får bara innehålla bokstäver, mellanslag, apostrofer eller bindestreck.';
    } else {
        firstNameError.textContent = '';
    }
});

const lastNameInput = document.getElementById('lastName-input');
const lastNameError = document.getElementById('lastName-validation-error');

lastNameInput.addEventListener('blur', function () {
    const lastName = lastNameInput.value.trim();
    if (lastName === '') {
        lastNameError.textContent = 'Du måste ange ett efternamn.';
    } else if (lastName.length < 2) {
        lastNameError.textContent = 'Efternamn måste ha minst 2 bokstäver.';
    } else if (!/^[a-zA-Z\u00C0-\u017F]+([\s\-'][a-zA-Z\u00C0-\u017F]+)*([\s][a-zA-Z\u00C0-\u017F]+)*$/.test(lastName)) {
        lastNameError.textContent = 'Efternamn får bara innehålla bokstäver, mellanslag, apostrofer eller bindestreck. Minst två ord krävs.';
    } else {
        lastNameError.textContent = '';
    }
});


const emailInput = document.getElementById('email-input');
const emailError = document.getElementById('email-validation-error');

emailInput.addEventListener('blur', function () {
    const email = emailInput.value.trim();
    if (email === '') {
        emailError.textContent = 'Du måste ange en e-postadress.';
    } else if (!isValidEmail(email)) {
        emailError.textContent = 'E-postadressen är ogiltig.';
    } else {
        emailError.textContent = '';
    }
});

function isValidEmail(email) {
    // Use a regular expression to validate email format
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}
const passwordInput = document.getElementById('password-input');
const confirmPasswordInput = document.getElementById('confirm-password-input');
const passwordError = document.getElementById('password-validation-error');
const confirmPasswordError = document.getElementById('confirm-password-validation-error');

passwordInput.addEventListener('blur', function () {
    const password = passwordInput.value;
    if (password === '') {
        passwordError.textContent = 'Du måste ange ett lösenord.';
    } else if (!/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/.test(password)) {
        passwordError.textContent = 'Lösenordet måste innehålla minst en stor bokstav, en liten bokstav och en siffra.';
    } else {
        passwordError.textContent = '';
    }
    confirmPasswordInput.dispatchEvent(new Event('blur')); // Trigger blur event on confirm password input
});

confirmPasswordInput.addEventListener('blur', function () {
    const confirmPassword = confirmPasswordInput.value;
    if (confirmPassword === '') {
        confirmPasswordError.textContent = 'Du måste bekräfta lösenordet.';
    } else if (passwordInput.value !== confirmPassword) {
        confirmPasswordError.textContent = 'Lösenorden matchar inte.';
    } else {
        confirmPasswordError.textContent = '';
    }
});
