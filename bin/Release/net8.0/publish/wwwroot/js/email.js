const sendMessage = () => {
    const emailData = {
        From: document.querySelector('[name="email"]').value,
        Subject: document.querySelector('[name="subject"]').value,
        Body: document.querySelector('[name="message"]').value,
        ConfirmEmail: document.querySelector('[name="confirmEmail"]').value
    };

    // Validate ConfirmEmail matches email
    if (emailData.From !== emailData.ConfirmEmail) {
        alert("Email and Confirm Email do not match.");
        return;
    }

    fetch('/api/Email/send', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(emailData)
    })
    .then(response => {
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        return response.json();
    })
    .then(data => {
        console.log('Success:', data.message);

        displaySuccessMessage(data.message);

        // Reset the form
        document.getElementById("emailForm").reset();
    })
    .catch(error => {
        console.error('Error:', error);
        alert("An unexpected error occurred. Please try again later.");
    });
};

function displaySuccessMessage(success) {
    const successContainer = document.getElementById("successMessage");

    // Clear any existing messages
    successContainer.innerHTML = "";

    // Create a new success message element
    const successItem = document.createElement("p");
    successItem.textContent = success;  // Use the success message passed into the function
    successItem.style.color = "green";  // Style it as green for success

    // Add custom styles for the success message
    successItem.style.border = "1px solid green";      // Green border
    successItem.style.backgroundColor = "#f9f9f9";     // Off-white background
    successItem.style.padding = "10px";                // Padding for spacing
    successItem.style.borderRadius = "5px";            // Rounded corners
    successItem.style.opacity = "0";                   // Start with opacity 0 for fade-in effect
    successItem.style.transition = "opacity 2s ease";  // Transition for fade-in effect

    // Append the message to the container
    successContainer.appendChild(successItem);

    // Trigger fade-in after a brief delay
    setTimeout(() => {
        successItem.style.opacity = "1";  // Set opacity to 1 for fade-in effect
    }, 100);  // Delay of 100ms to trigger the transition

    // Trigger fade-out after a few seconds
    setTimeout(() => {
        successItem.style.opacity = "0";  // Set opacity to 0 for fade-out effect
    }, 4000);  // Delay of 4 seconds before fading out
}


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