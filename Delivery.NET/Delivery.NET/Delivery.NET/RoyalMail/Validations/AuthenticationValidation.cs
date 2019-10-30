using Delivery.NET.RoyalMail.Values.Requests;
using FluentValidation;

namespace Delivery.NET.RoyalMail.Validations
{
    public class AuthenticationValidation : AbstractValidator<TokenRequest>
    {
        public AuthenticationValidation()
        {
            RuleFor(x => x.ClientId).NotEmpty().WithMessage(RoyalConstants.EmptyClientId);
            RuleFor(x => x.ClientSecret).NotEmpty().WithMessage(RoyalConstants.EmptyClientSecret);
            RuleFor(x => x.Password).NotEmpty().WithMessage(RoyalConstants.EmptyPassword);
            RuleFor(x => x.Username).NotEmpty().WithMessage(RoyalConstants.EmptyUsername);

            RuleFor(x => x.Username).EmailAddress().WithMessage(RoyalConstants.InvalidUsername);
            RuleFor(x => x.ClientId).Must(x => x.Contains("-")).WithMessage(RoyalConstants.InvalidClientId);
        }
    }
}
