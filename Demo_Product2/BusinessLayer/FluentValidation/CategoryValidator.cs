﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator() 
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Kategori adı boş geçilemez");
        }
    }
}
