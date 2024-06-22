﻿using FluentValidation;

namespace MaterialsExchangeAPI.Features.Seller.Commands.UpdateSellerCommand
{
    public class UpdateSellerCommandValidator : AbstractValidator<UpdateSeller>
    {
        public UpdateSellerCommandValidator()
        {
            RuleFor(m => m.Id).NotNull();
            RuleFor(m => m.Name).NotEmpty();
        }
    }
}