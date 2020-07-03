using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using FluentValidation;

namespace RatingBlazorApp.Validators
{
    public class UserSignUpValidator : AbstractValidator<UserModel>
    {
        public UserSignUpValidator()
        {
            RuleFor(u => u.EmailAddress).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Vous devez entrer une adresse email")
                .EmailAddress().WithMessage("Vous devez entrer une adresse email valide");

            RuleFor(u => u.Nickname).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Vous devez entrer un pseudo")
                .MinimumLength(8).WithMessage("Le pseudo doit comporter au moins 8 caractères")
                .MaximumLength(30).WithMessage("Le pseudo ne peut dépasser 30 caractères");

            RuleFor(u => u.Password).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Vous devez entrer un mot de passe")
                .MinimumLength(6).WithMessage("Le mot de passe doit comporter au moins 6 caractères")
                .MaximumLength(30).WithMessage("Le mot de passe ne peut dépasser 30 caractères");

            RuleFor(u => u.ConfirmPassword).Equal(u => u.Password).WithMessage("Doit correspondre au mot de passe saisie");
        }
    }
}
