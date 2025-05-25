using BuyEasy.Models.ViewModel;
using BuyEasy.Services;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    private readonly IUserService _userService;
    private readonly IEmailService _emailService;

    public static Dictionary<string, string> otpStore = new(); // temp memory store

    public AccountController(IUserService userService, IEmailService emailService)
    {
        _userService = userService;
        _emailService = emailService;
    }

    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(UserViewModel model)
    {
        var user = _userService.Login(model.Email, model.Password);
        if (user != null) return RedirectToAction("Index", "Home");
        ViewBag.Error = "Invalid credentials.";
        return View(model);
    }

    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(UserViewModel user)
    {
        _userService.Register(user);

        string subject = "Welcome to BuyEasy";
        string body = $@"
        <h2>Welcome to BuyEasy!</h2>
        <p>Thank you for registering, {user.Username}!</p>
        <p>We’re glad to have you with us.</p>";

        await _emailService.SendEmailAsync(user.Email, subject, body);

        return View("RegistrationSuccess"); // <-- create this view
    }


    public IActionResult ForgotPassword() => View();

    [HttpPost]
    public IActionResult ForgotPassword(string email)
    {
        string otp = new Random().Next(100000, 999999).ToString();
        otpStore[email] = otp;

        _emailService.SendEmailAsync(email, "OTP for Password Reset", $"Your OTP is: {otp}");
        return View("VerifyOTP", model: email);
    }

    [HttpPost]
    public IActionResult VerifyOTP(string email, string otp)
    {
        if (otpStore.TryGetValue(email, out var expectedOtp) && otp == expectedOtp)
        {
            otpStore.Remove(email); // cleanup
            return View("ResetPassword", model: email); // custom view with new password input
        }

        ViewBag.Error = "Invalid OTP";
        return View("VerifyOTP", model: email);
    }

    [HttpPost]
    public IActionResult ResetPassword(UserViewModel model)
    {
        if (model.Password != model.ConfirmPassword)
        {
            ViewBag.Error = "Passwords do not match";
            return View("ResetPassword", model);
        }

        var user = _userService.GetByEmail(model.Email);
        if (user == null)
        {
            ViewBag.Error = "User not found";
            return View("ResetPassword", model);
        }

        user.Password = model.ConfirmPassword;
        _userService.Update(user);

        return RedirectToAction("Login", "Account");
    }


}
