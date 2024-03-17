using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class JobValidator:AbstractValidator<Job>
    {
        public JobValidator() 
        {
            RuleFor(j => j.Name).NotEmpty().WithMessage("Meslek adı boş geçilemez");
            RuleFor(j => j.Name).MinimumLength(2).WithMessage("Meslek adı minimum 2 karakter içermelidir");
        }
    }
}
