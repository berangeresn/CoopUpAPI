using FluentValidation;

namespace Application.Validators
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MinimumLength(6).WithMessage("Le mot de passe doit contenir au moins 6 caractères")
                .Matches("[A-Z]").WithMessage("Le mot de passe doit contenir au moins une majuscule")
                .Matches("[a-z]").WithMessage("Le mot de passe doit contenir au moins une minuscule")
                .Matches("[0-9]").WithMessage("Le mot de passe doit contenir au moins un chiffre")
                .Matches("[^a-zA-Z0-9]").WithMessage("Le mot de passe doit contenir au moins un caractère non alpha-numérique : ? ! $");
            
            return options;
        }
    }
}