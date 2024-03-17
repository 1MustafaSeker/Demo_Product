using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Ürün adını boş geçemezsiniz");
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("Ürün adı en az 3 karakterli olmalıdır");
            RuleFor(p => p.Stock).NotEmpty().WithMessage("Ürün stok boş geçilemez");
            RuleFor(p => p.Price).NotEmpty().WithMessage("Ürün fiyat boş geçilemez");
        }
    }
}
