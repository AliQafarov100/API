using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Back_End_API.DTOs.ProductDtos
{
    public class ProductPostDto
    {
        public decimal SoldPrice { get; set; }
        public decimal CostPrice { get; set; }
        public string Name { get; set; }
        public bool DisplayStatus { get; set; }
    }

    public class ProductPostValidator : AbstractValidator<ProductPostDto>
    {
        public ProductPostValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Not empty").MaximumLength(20).
                WithMessage("Length name mustn't more tha 20");
            RuleFor(x => x.SoldPrice).GreaterThanOrEqualTo(0).WithMessage("Entre definition price more than 0")
                .LessThanOrEqualTo(9999.99m).WithMessage("Zehmet olmasa 10,000 - den kicik bir eded daxil edin");

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.CostPrice > x.SoldPrice)
                {
                    context.AddFailure("CostPrice", "Cost price not than more sold price");
                }
            });
        }
    }
}
