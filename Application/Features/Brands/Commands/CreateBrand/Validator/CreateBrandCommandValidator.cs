using FluentValidation;

namespace Application.Features.Brands.Commands.CreateBrand.Validator
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommandRequest>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(2);
        }
    }
}
