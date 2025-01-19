﻿using FluentValidation;
using MediatR;
using OnlineShop.Purchase.Core.ApplicationServices.Framework.Commands;

namespace OnlineShop.Purchase.Core.ApplicationServices.Extensions.Behaviors.Validations;
public class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    public async Task<TResponse> Handle(TRequest request,
                                  RequestHandlerDelegate<TResponse> next,
                                  CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var validationErrors = _validators
            .Select(validator => validator.Validate(context))
            .Where(validationResult => validationResult.Errors.Any())
            .SelectMany(validationResult => validationResult.Errors)
            .Select(validationFailure => new ValidationError(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage))
            .ToList();

        validationErrors.ThrowIfIsInvalid();
        return await next();
    }
}
