using PracticaAuth.Models;
using PracticaAuth.ServiceResponse;

namespace PracticaAuth.Services.Interfaces;

public interface ILogin
{
    public Task<ServiceResponse<User>> CreateUser(User user);
    public Task<ServiceResponse<User>> Login(string document, string password);
}