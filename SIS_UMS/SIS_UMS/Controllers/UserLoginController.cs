using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SIS_UMS.DatabaseHelper.Interfaces;
using SIS_UMS.Models;

namespace SIS_UMS.Controllers
{
    /// <summary>
    /// Controller responsible for handling user login and related actions.
    /// Also the General idea of this controller it take the username encrypt it and put it in the url to be passed.
    /// After that,the passed username in the url will taken from it then decrypted and passed to the function to check the creditentials.
    /// </summary>
    public class UserLoginController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserLoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Displays the UsernameLogin view.
        /// </summary>
        [HttpGet]
        public IActionResult UsernameLogin()
        {
            return View();
        }

        /// <summary>
        /// Handles the submission of the UsernameLogin form.
        /// </summary>
        /// <param name="username">The user's username.</param>
        [HttpPost]
        public IActionResult UsernameLogin(int username)
        {
            // Check if the username exists using the Check_Username function from the repository.
            bool usernameExists = _userRepository.Check_Username(username);

            if (usernameExists)
            {
                // Encrypt the username using the Encrypt method from the EncryptionHelper class.
                string encryptedUsername = EncryptionHelper.Encrypt(username);
                // Redirect to the PasswordLogin view and pass the encryptedUsername as a parameter in the URL.
                return RedirectToAction("PasswordLogin", new { encryptedUsername });
            }
            else
            {
                // Clear previous errors.
                ModelState.Clear();
                // If the username does not exist, display an error message.
                ModelState.AddModelError("username", "This username does not exist.");
                // Return the UsernameLogin view.
                return View();
            }
        }

        /// <summary>
        /// Displays the PasswordLogin view and passes an encrypted username as a parameter.
        /// </summary>
        /// <param name="encryptedUsername">The encrypted username to be passed as a parameter.</param>
        [HttpGet]
        public IActionResult PasswordLogin(string encryptedUsername)
        {
            // Create a model in the view from the User Model to hold necessary variables.
            User userModel = new User();
            // Add the encryptedUsername to the password_salt field in the model.
            userModel.password_salt = encryptedUsername;
            // Return the view and pass the userModel as the model.
            return View(userModel);
        }

        /// <summary>
        /// Handles the submission of the PasswordLogin form.
        /// </summary>
        /// <param name="userModel">The User model containing encrypted username and password.</param>
        [HttpPost]
        public IActionResult PassLogin([FromBody] User userModel)
        {
            // Retrieve the encrypted username and password from the model.
            string encryptedUsername = userModel.password_salt;
            string password = userModel.user_password;

            // Decrypt the username using the Decrypt method from the EncryptionHelper class.
            int username = EncryptionHelper.Decrypt(encryptedUsername);

            // Use the 'username' parameter for password validation.
            bool isValidPassword = _userRepository.ValidatePassword(username, password);

            if (isValidPassword)
            {
                // Redirect to a new page, dashboard, etc., upon successful login.
                return RedirectToAction("Newpage");
            }

            // Clear previous errors.
            ModelState.Clear();
            // Display an error indicating that the password is incorrect.
            ModelState.AddModelError("password", "Invalid password.");
            // Redirect to the PasswordLogin view and pass the encryptedUsername as a parameter.
            return RedirectToAction("PasswordLogin", new { encryptedUsername });
        }

        /// <summary>
        /// Displays the Newpage view.
        /// </summary>
        public IActionResult Newpage()
        {
            // Return the view for the Newpage.
            return View();
        }
    }
}
