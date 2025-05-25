using AutoMapper;
using BuyEasy.Models.DataModel;
using BuyEasy.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace BuyEasy.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepo,IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public UserViewModel Login(string email, string password)
        {
            var user = _userRepo.GetByEmail(email);
            var userModel = _mapper.Map<UserViewModel>(user);
            if (user != null && user.PasswordHash == Hash(password))
            {
                return userModel;
            }
            else
            {
                return null;
            }
        }

        public bool Register(UserViewModel user)
        {
            if (_userRepo.GetByEmail(user.Email) != null) return false;

            var userEntity = new User
            {
                Email = user.Email,
                PasswordHash = Hash(user.Password)
                // Map other fields as needed
            };

            _userRepo.Add(userEntity);
            _userRepo.Save();
            return true;
        }

        public bool SendOtp(string email)
        {
            var user = _userRepo.GetByEmail(email);
            if (user == null) return false;

            user.OTP = new Random().Next(100000, 999999).ToString();
            user.OTPExpiry = DateTime.Now.AddMinutes(10);
            _userRepo.Update(user);
            _userRepo.Save();

            // Simulate email sending
            Console.WriteLine($"OTP sent to {email}: {user.OTP}");

            return true;
        }

        public bool VerifyOtp(string email, string otp)
        {
            var user = _userRepo.GetByEmail(email);
            if (user == null || user.OTP != otp || user.OTPExpiry < DateTime.Now)
                return false;
            return true;
        }

        private string Hash(string input)
        {
            using var sha = SHA256.Create();
            return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(input)));
        }
        public UserViewModel GetByEmail(string email)
        {
            var user = _userRepo.GetByEmail(email);

            if (user == null)
                return null;

            return new UserViewModel
            {
                Email = user.Email
            };
        }

        public void Update(UserViewModel user)
        {
            var userViewModel = _mapper.Map<User>(user);
            _userRepo.Update(userViewModel);
        }
    }
}

