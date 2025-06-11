using FluentValidation;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public class CreateReviewDtoValidator : AbstractValidator<CreateReviewDto>
    {
        public CreateReviewDtoValidator()
        {
            RuleFor(x => x.ProductId).GreaterThan(0);
            RuleFor(x => x.Comment)
                .NotEmpty()
                .MaximumLength(500);
            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5)
                .WithMessage("Rating must be between 1 and 5.");
        }
    }
}
