// const sendMessage = () => {
//     var email = document.getElementById("email").value;
//     var subject = document.getElementById("subject").value;
//     var body = document.getElementById("body").value;

//     // Basic input validation
//     if (!email || !subject || !body) {
//         alert("Please fill out all fields.");
//         return;
//     }

//     var emailData = {
//         to: "judah.kahler@gmail.com",
//         from: email,
//         subject: subject,
//         body: body
//     };

//     fetch("/api/Email/send", {
//         method: "POST",
//         headers: {
//             'Accept': "application/json",
//             'Content-Type': "application/json"
//         },
//         body: JSON.stringify(emailData)
//     })
//     .then(response => {
//         if (!response.ok) {
//             throw new Error('Network response was not ok');
//         }
//         return response.json();
//     })
//     .then(data => {
//         if (data.success) {
//             console.log("Email Sent!");
//             alert(data.message);
//         } else {
//             console.error("Message failed to send", data.error);
//             alert(data.message);
//         }
//     })
//     .catch(error => {
//         console.log('Error sending message:', error);
//         alert("An unexpected error occurred. Please try again later.");
//     });
// };

const sendMessage = () => {
    const emailData = {
        From: document.querySelector('[name="email"]').value,
        Subject: document.querySelector('[name="subject"]').value,
        Body: document.querySelector('[name="message"]').value,
        ConfirmEmail: document.querySelector('[name="confirmEmail"]').value
    };

    fetch('/api/Email/send', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(emailData)
    })
    .then(response => response.json().then(data => ({ status: response.status, body: data })))
    .then(({ status, body }) => {
        if (status === 200) {
            console.log('Success:', body.message);

            successMessage(body.message);

            // Clear form after success
            document.querySelector('[name="email"]').value = "";
            document.querySelector('[name="subject"]').value = "";
            document.querySelector('[name="message"]').value = "";
            document.querySelector('[name="confirmEmail"]').value = "";

        } else if (status === 400) {
            // Handle validation errors
            console.error('Validation failed:', body.errors);
            displayValidationErrors(body.errors); // Call a function to display validation messages
        } else {
            console.error('Error:', body.Message || 'Failed to send email');
        }
    })
    .catch(error => {
        console.log("Debug Message: ", error)
        console.error('Error:', error)
    });
};

// Send validation errors back
function displayValidationErrors(errors) {
    const errorContainer = document.getElementById("errorContainer");
    
    // Clear any existing errors
    errorContainer.innerHTML = "";

    // Loop through each field's errors and display them
    for (let field in errors) {
        if (errors.hasOwnProperty(field)) {
            // For each field, loop through its associated errors
            errors[field].forEach(errorMessage => {
                const errorItem = document.createElement('p');
                errorItem.textContent = errorMessage;
                errorItem.style.color = "red"; // Style error text as red
                errorContainer.appendChild(errorItem);
            });
        }
    }
}
