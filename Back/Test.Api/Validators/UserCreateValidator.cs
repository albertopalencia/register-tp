 
using FluentValidation;
using Test.Domain.DTO.User;

namespace Test.Api.Validators
{
	/// <summary>
	/// Class UserCreateValidator.
	/// Implements the <see>
	///     <cref>FluentValidation.AbstractValidator{Test.Domain.DTO.User.UserCreateDto}</cref>
	/// </see>
	/// </summary>
	/// <seealso>
	///     <cref>FluentValidation.AbstractValidator{Test.Domain.DTO.User.UserCreateDto}</cref>
	/// </seealso>
	public class UserCreateValidator : AbstractValidator<UserCreateDto>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UserCreateValidator" /> class.
		/// </summary>
		public UserCreateValidator()
		{
			RuleFor(x => x.IdentificationNumber).NotEmpty().WithMessage("Numero de identificacion es obligatorio");
			RuleFor(x => x.IdentificationTypeId).NotNull();
			RuleFor(x => x.MunicipioId).NotNull();
		}
	}
}