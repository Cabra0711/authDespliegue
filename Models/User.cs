using PracticaAuth.Enums;

namespace PracticaAuth.Models;

public class User
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Document { get; set; }
    public string Password { get; set; }
    public string Number {get; set;}
    public UserRole Role { get; set; }
}