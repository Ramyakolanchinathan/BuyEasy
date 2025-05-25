using BuyEasy.Models.DataModel;
using BuyEasy.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;

    public UserRepository(AppDbContext db)
    {
        _db = db;
    }

    public User GetByEmail(string email)
    {
        return _db.Users.FirstOrDefault(u => u.Email == email);
    }

    public void Update(User user)
    {
        _db.Users.Update(user);
        _db.SaveChanges();
    }
    public User GetById(int id) => _db.Users.Find(id);
    public void Add(User user) => _db.Users.Add(user);
    public void Save() => _db.SaveChanges();
}
