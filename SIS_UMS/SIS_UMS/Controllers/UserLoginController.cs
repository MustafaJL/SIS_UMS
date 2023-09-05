using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SIS_UMS.DatabaseHelper.Interfaces;
using SIS_UMS.Models;

namespace SIS_UMS.Controllers
{
    public class UserLoginController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserLoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
       

        [HttpGet]
        public IActionResult UsernameLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UsernameLogin(int username)
        {
            bool usernameExists = _userRepository.Check_Username(username);

            if (usernameExists)
            {
                // Encrypt the username and pass it as a string in the URL
                string encryptedUsername = EncryptionHelper.Encrypt(username);
                return RedirectToAction("PasswordLogin", new { encryptedUsername });
            }
            else
            {
                ModelState.Clear(); // Clear previous errors
                ModelState.AddModelError("username", $"The username '{username}' does not exist.");
                return View();
            }
        }



        [HttpGet]
        public IActionResult PasswordLogin( string encryptedUsername)
        {
            User userModle = new User();
            userModle.password_salt= encryptedUsername;
            return View(userModle);
        }


        //[HttpPost]
        //public IActionResult PasswordLogin(User userModel , string encryptedUsername)
        //{
        //    var password = userModel.user_password;
        //  return RedirectToAction("PassLogin", new { encryptedUsername, password });
        //}

        //[HttpPost]
        //public IActionResult PassLogin( string encryptedUsername, string password)
        //{

        //    int username = EncryptionHelper.Decrypt(encryptedUsername);
        //    // Use the 'username' parameter for password validation
        //    bool isValidPassword = _userRepository.ValidatePassword(username, password);


        //    if (isValidPassword)
        //    {
        //        ViewBag.IsValid = true;
        //        // Password is valid, redirect to the dashboard page or perform other actions
        //        //return RedirectToAction("Newpage");
        //        return RedirectToAction("Index","Home");
        //    }

        //    ModelState.Clear(); // Clear previous errors
        //    ModelState.AddModelError("password", "Invalid password.");
        //    ViewBag.IsValid = false;
        //    return RedirectToAction("PasswordLogin", new { encryptedUsername });
        //}


        [HttpPost]
        public IActionResult PassLogin([FromBody] User userModel)
        {

            // You can access properties of the JSON object like this:
            string encryptedUsername = userModel.password_salt;

            string password = userModel.user_password;

            // Check if the expected properties are present
            if (encryptedUsername == null)
            {
                // Handle the case where expected properties are missing
                return BadRequest("Missing username properties in JSON data.");
            }


            int username = EncryptionHelper.Decrypt(encryptedUsername);
            // Use the 'username' parameter for password validation
            bool isValidPassword = _userRepository.ValidatePassword(username, password);


            if (isValidPassword)
            {
                ViewBag.IsValid = true;
                // Password is valid, redirect to the dashboard page or perform other actions
                //return RedirectToAction("Newpage");
                return RedirectToAction("Index", "Home");
            }

            ModelState.Clear(); // Clear previous errors
            ModelState.AddModelError("password", "Invalid password.");
            ViewBag.IsValid = false;
            return RedirectToAction("PasswordLogin", new { encryptedUsername });
        }



        public IActionResult Newpage()
        {
            return View();
        }
    }
}
