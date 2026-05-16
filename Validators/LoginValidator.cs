using FluentValidation;
using PracticaAuth.Models;

namespace PracticaAuth.Validators;

public class LoginValidator : AbstractValidator<User>
{
    public LoginValidator()
    {
        RuleFor(login => login.Email)
            .NotEmpty().WithMessage("El Email es requerido").
            EmailAddress().WithMessage("El Email debe tener un formato valido");

        RuleFor(login => login.Password)
            .NotEmpty().WithMessage("La Password es requerida");
        
        RuleFor(login => login.UserName)
            .NotEmpty().WithMessage("El código de operador (Username) no puede estar vacío.")
            .MinimumLength(3).WithMessage("El nombre de usuario es demasiado corto para los estándares de Estelar.");
        
        RuleFor(login => login.Document)
            .MaximumLength(16).WithMessage("El documento no puede pasar de los 16 caracteres")
            .MinimumLength(8).WithMessage("El documento debe de contar con minimo 8 caracteres");
        
    }
}