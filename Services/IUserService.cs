using BuyEasy.Models.ViewModel;

namespace BuyEasy.Services
{
    public interface IUserService
    {
        UserViewModel Login(string email, string password);
        bool Register(UserViewModel user);
        bool SendOtp(string email);
        bool VerifyOtp(string email, string otp);
        UserViewModel GetByEmail(string email);
        void Update(UserViewModel user);
    }
}
