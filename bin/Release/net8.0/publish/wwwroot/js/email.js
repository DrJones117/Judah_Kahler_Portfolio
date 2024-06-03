/**
 * Takes the form data and sends it to the SendEmail route in the Email controller
 */
const sendMessage = () => {
    var email = document.getElementById("email").value;
    var subject = document.getElementById("subject").value;
    var body = document.getElementById("body").value;

    console.log("=============" + email + subject + body + "=============")

    var emailData = {
        to: "judah.kahler@gmail.com",
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
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                console.log("Email Sent!")
                alert(data.message);
            }
            else {
                console.error("Message failed to send", error)
                alert(data.message)
            }
        })
        .catch(error => {
            console.error('Message failed to send.', error)
            alert("An unexpected error occurred. Please try again later.")
        });
}