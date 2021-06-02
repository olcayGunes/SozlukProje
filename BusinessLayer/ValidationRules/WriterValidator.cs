using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class WriterValidator:AbstractValidator<Writer>
	{
		public WriterValidator()
		{
			RuleFor(c => c.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Geçilemez.");
			RuleFor(c => c.WriterSurName).NotEmpty().WithMessage("Yazar Soyadı Boş Geçilemez.");
			RuleFor(c => c.WriterAbout).Must(isContainA).WithMessage("Hakkında Bölümünde Mutlaka 'a' Harfi Bulunmalıdır.");
			RuleFor(c => c.WriterName).MinimumLength(2).WithMessage("Yazar Adı En Az 2 Karakter Olmalıdır.");
			RuleFor(c => c.WriterSurName).MinimumLength(2).WithMessage("Yazar Soyadı En Az 2 Karakter Olmalıdır.");
			RuleFor(c => c.WriterMail).Must(mailContainer).WithMessage("E-Mail Formatına Uygun Giriş Yapınız.");
		}

		private bool mailContainer(string adress)
		{
			bool result;
			if (adress==null)
			{
				result = false;
				return result;
			}
			result = adress.Contains("@");
			return result;
		}

		public bool isContainA(string name)
		{
			bool result;
			if (name==null)
			{
				result = false;
				return result;
			}
			result = name.Contains("a");
			return result;
		}
	}
}
