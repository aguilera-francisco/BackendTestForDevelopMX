using FluentValidation;
using System.Numerics;

namespace BackendTest.Validators
{
    public class PostalCodeValidator: AbstractValidator<string>
    {
        public PostalCodeValidator() {
            string error = "Invalid Postal Code";
            RuleFor(pc => pc)
                .Custom((pc, context) => {
                    if (!Int32.TryParse(pc, out int value)) { 
                        context.AddFailure(error);
                    }
                }); 
            RuleFor(pc => pc).Length(5).WithMessage(error);
        }
    }
}
