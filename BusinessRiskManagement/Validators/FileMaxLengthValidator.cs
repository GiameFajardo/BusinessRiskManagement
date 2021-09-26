using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRiskManagement.Validators
{
    public class FileMaxLengthValidator: ValidationAttribute
    {
        private readonly int _maxLength;

        public FileMaxLengthValidator(int maxLength)
        {
            this._maxLength = maxLength;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            IFormFile formFile = value as IFormFile;

            if (formFile == null)
            {
                return ValidationResult.Success;
            }

            if (formFile.Length > _maxLength * 1024* 1024)
            {
                return new ValidationResult($"El peso del archivo no debe de acceder a {_maxLength}mb");
            }
            return ValidationResult.Success;
        }
    }
}
