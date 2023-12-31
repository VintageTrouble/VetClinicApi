﻿using FluentValidation;

using VetClinicApi.Contracts.CustomerContracts;

namespace VetClinicApi.API.Common.Validation.CustomerValidation;

public class UpdateCustomerRequestValidator : BaseCustomerRequestValidator<UpdateCustomerRequest>
{
    public UpdateCustomerRequestValidator() : base()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);
        RuleFor(x => x.LastVisitDate)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .When(x => x.LastVisitDate.HasValue);
    }
}
