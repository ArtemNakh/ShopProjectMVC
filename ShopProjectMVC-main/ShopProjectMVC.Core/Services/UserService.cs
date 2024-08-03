using Microsoft.AspNetCore.Mvc;
using ShopProjectMVC.Core.Interfaces;
using ShopProjectMVC.Core.Models;

namespace ShopProjectMVC.Core.Services;

public class UserService : IUserService
{
    private readonly IRepository _repository;

    public UserService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<User> Login(string email, string password)
    {
        var user = _repository.GetAll<User>()
            .Where(u => u.Email == email && u.Password == password)
            .SingleOrDefault();

        return user;
    }

    public Task<User> Register(User user)
    {

        int NumUser = _repository.GetAll<User>()
             .Where(u => u.Email == user.Email)
             .Count();

        if (NumUser <= 0)
            return _repository.Add(user);
        else
            return Task.FromResult(new User { Email = "Error" }); 
    }
}
