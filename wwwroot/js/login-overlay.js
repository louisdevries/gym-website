// Get the overlay and button elements
const loginOverlay = document.getElementById('loginOverlay');
const closeLoginOverlay = document.getElementById('closeLoginOverlay');
const loginLink = document.querySelector('a[href="#login"]');  // Assuming the link is properly set to "#login"

// Open the login overlay when the login link is clicked
loginLink.addEventListener('click', function(e) {
    e.preventDefault();
    loginOverlay.style.display = 'block';
});

// Close the overlay when the close button is clicked
closeLoginOverlay.addEventListener('click', function() {
    loginOverlay.style.display = 'none';
});

// Optionally close the overlay when clicking outside of the content area
window.addEventListener('click', function(e) {
    if (e.target === loginOverlay) {
        loginOverlay.style.display = 'none';
    }
});

// Handle form submission (optional: submit via AJAX or traditional POST)
document.getElementById('loginForm').addEventListener('submit', function(e) {
    e.preventDefault();
    
    const username = document.getElementById('username').value;
    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;

    // Send the login data to the server (using AJAX or traditional form submission)
    // Example with AJAX (fetch or jQuery)
    fetch('/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ username, email, password }),
    })
    .then(response => response.json())
    .then(data => {
        if (data.success) {
            // Handle successful login (redirect or update UI)
            window.location.reload();  // Example: reload page after successful login
        } else {
            // Show error message if login fails
            alert('Login failed. Please check your credentials.');
        }
    })
    .catch(error => {
        console.error('Error:', error);
    });
})