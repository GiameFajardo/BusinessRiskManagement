using BusinessRiskManagement.Validators;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRiskManagement.Requests
{
    public class UpdateOrganizationRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Address { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        [FileMaxLengthValidator(maxLength: 4)]
        [FileTypeValidator(fileTypeGroup:FileTypeGroup.Image)]
        public IFormFile Photo { get; set; }
    }
}
