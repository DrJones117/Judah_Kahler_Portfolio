const sendMessage = () => {
    var email = document.getElementById("email").value;
    var subject = document.getElementById("subject").value;
    var body = document.getElementById("body").value;

    // Basic input validation
    if (!email || !subject || !body) {
        alert("Please fill out all fields.");
        return;
    }

    var emailData = {
        to: "judah.kahler@gmail.com",  // Replace with your actual recipient
        from: email,
        subject: subject,
        body: body
    };

    fetch("/api/Email/send", {
        method: "POST",
        headers: {
            'Accept': "application/json",
            'Content-Type': "application/json"
        },
        body: JSON.stringify(emailData)
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.json();
    })
    .then(data => {
        if (data.success) {
            console.log("Email Sent!");
            alert(data.message);
        } else {
            console.error("Message failed to send", data.error);
            alert(data.message);
        }
    })
    .catch(error => {
        console.log('Error sending message:', error);
        alert("An unexpected error occurred. Please try again later.");
    });
};
