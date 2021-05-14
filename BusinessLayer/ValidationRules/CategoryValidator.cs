using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class CategoryValidator:AbstractValidator<Category>
	{
		public CategoryValidator()
		{
			RuleFor(c => c.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez.");
			RuleFor(c => c.CategoryName).MinimumLength(2).WithMessage("Kategori Adı En Az 2 Karakter Olmalıdır.");
			RuleFor(c => c.CategoryName).MaximumLength(50).WithMessage("Kategori Adı 50 Karakterden Fazla Olamaz.");
			RuleFor(c => c.CategoryDescription).MinimumLength(2).WithMessage("Kategori Açıklaması En Az 2 Karakter Olmalıdır.");
			RuleFor(c => c.CategoryDescription).MaximumLength(100).WithMessage("Kategori Açıklaması 100 Karakterden Fazla Olamaz.");
		}
	}
}
