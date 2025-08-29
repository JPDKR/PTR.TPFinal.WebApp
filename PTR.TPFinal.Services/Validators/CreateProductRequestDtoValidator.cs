using FluentValidation;
using PTR.TPFinal.Services.DTOs.Requests;

namespace PTR.TPFinal.Services.Validators
{
    public class CreateProductRequestDtoValidator : AbstractValidator<CreateProductRequestDto>
    {
        public CreateProductRequestDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MaximumLength(100).WithMessage("Máximo 100 caracteres");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("El precio debe ser mayor a 0")
                .LessThanOrEqualTo(1_000_000).WithMessage("El precio no puede superar 1.000.000");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("La descripción no puede superar 500 caracteres")
                .When(x => !string.IsNullOrWhiteSpace(x.Description));

            RuleFor(x => x.AreaId)
                .GreaterThan(0).WithMessage("El Area debe ser válido")
                .When(x => x.AreaId == 0);
        }
    }
}
