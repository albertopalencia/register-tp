using System.Collections.Generic;
using Test.Domain.DTO.User;
using System.Threading.Tasks;
using Test.Domain.DTO;


namespace Test.Application.Abstract
{
	/// <summary>
	/// Class IUserService.
	/// </summary>
	public interface IUserService
	{
		/// <summary>
		/// Validates the user.
		/// </summary>
		/// <param name="identificationNumber">The user.</param>
		/// <returns>Task&lt;UserResponseDto&gt;.</returns>
		Task<ResponseGenericDto<UserResponseDto>> Validate(string identificationNumber);
 
		Task<ResponseGenericDto<bool>> Create(UserCreateDto user);

		Task<ResponseGenericDto<List<UserListDto>>> UserList();
	}
}