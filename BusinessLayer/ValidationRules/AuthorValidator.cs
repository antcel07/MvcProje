using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class AuthorValidator:AbstractValidator<Author>
	{
		public AuthorValidator() {
			RuleFor(x => x.AuthorAbout).NotEmpty().WithMessage("Yazar hakkında  boş geçilemez");
			RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Yazar adı içeriği boş geçilemez");
			RuleFor(x => x.AuthorTitle).NotEmpty().WithMessage("Yazar başlık girişi boş geçilemez");
			RuleFor(x => x.AuthorImage).NotEmpty().WithMessage("Yazar görseli boş geçilemez");
		}
	}
}
