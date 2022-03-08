using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRiskManagement.Validators
{

    public class FileTypeValidator: ValidationAttribute
    {
        private readonly string[] _validTypes;

        public FileTypeValidator(string[] validTypes)
        {
            this._validTypes = validTypes;
        }
        public FileTypeValidator(FileTypeGroup fileTypeGroup)
        {
            if (fileTypeGroup == FileTypeGroup.Image)
            {
                _validTypes = new string[] { "image/jpeg", "image/png", "image/gif" };
            }

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

            if (!_validTypes.Contains(formFile.ContentType)){
                return new ValidationResult($"El typo de archivo deve ser uno de los siguientes: {string.Join(", ", _validTypes)}");
            }
            return ValidationResult.Success;
        }
    }
    public enum FileTypeGroup
    {
        Image
    }
}
