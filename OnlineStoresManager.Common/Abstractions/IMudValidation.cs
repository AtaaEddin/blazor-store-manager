using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FluentValidation;

namespace OnlineStoresManager.Abstractions
{
    public interface IMudValidation : IValidator
    {
        Func<object, string, Task<IEnumerable<string>>> ValidateValue { get; }
    }
}
