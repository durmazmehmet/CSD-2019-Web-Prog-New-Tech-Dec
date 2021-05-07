using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CSD.AppointmentApp.ValidationAttributes
{
    public class MustBeTrueAttribute : Attribute, IModelValidator
    {
        public bool IsRequired => true;

        public string ErrorMessage { get; set; }
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var value = context.Model as bool?;

            if(!value.HasValue || !value.Value)
                return new List<ModelValidationResult>{ new ModelValidationResult ("", ErrorMessage) };

            return Enumerable.Empty<ModelValidationResult>();
        }
    }
}
