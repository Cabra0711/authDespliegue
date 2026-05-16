using Microsoft.EntityFrameworkCore;
using PracticaAuth.Data;
using PracticaAuth.Enums;
using PracticaAuth.Models;
using PracticaAuth.ServiceResponse;
using PracticaAuth.Services.Interfaces;
using BCrypt.Net;
using FluentValidation;

namespace PracticaAuth.Services;

public class LoginService : ILogin
{
    private readonly MySqlDbContext _context;
    private readonly IValidator<User> _userValidator;
    
    public LoginService(MySqlDbContext context,  IValidator<User> userValidator)
    {
        _userValidator = userValidator;
        _context = context;
    }

    public async Task<ServiceResponse<User>> CreateUser(User user)
    {
        var response = new ServiceResponse<User>();
        var userExist = await _context.Users.FirstOrDefaultAsync(u => u.Document == user.Document);

        if (userExist != null)
        {
            response.Message = "El usuario que ingresaste ya existe";
            response.Success = false;
            return response;
        }
        else
        {
            response.Success = true;
            response.Data = user;
            response.Message = "Se ha guardado el registro correctamente";
            
            user.Role = UserRole.User;
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            await _context.Users.AddAsync(user);
            return response;
        }
    }

    public async Task<ServiceResponse<User>> Login(string document, string password)
    {
        var response = new ServiceResponse<User>();
        var userExist = await _context.Users.SingleOrDefaultAsync(u => u.Document == document);

        if (userExist != null && BCrypt.Net.BCrypt.Verify(password, userExist.Password))
        {
            response.Data = userExist;
            response.Success = true;
            response.Message = "Accediendo al sistema...";
            return response;
        }
        else
        {
            response.Success = false;
            response.Message = "Credenciales Invalidas o Incorrectas...";
            return response;
        }
    }
}