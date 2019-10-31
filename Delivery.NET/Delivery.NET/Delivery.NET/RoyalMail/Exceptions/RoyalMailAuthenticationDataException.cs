using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Delivery.NET.RoyalMail.Exceptions
{
    public class RoyalMailAuthenticationDataException : Exception
    {
        public IList<ValidationFailure> Errors { get; set; }
        public RoyalMailAuthenticationDataException(string message, IList<ValidationFailure> errors) : base(message)
        {
            Errors = errors;
        }
    }
}
