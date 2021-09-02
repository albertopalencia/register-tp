using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Test.Application.Abstract;
using Test.Common.Resources;
using Test.Common.Utilities;
using Test.Domain.DTO;
using Test.Domain.DTO.User;
using Test.Domain.Entities;
using Test.Infrastructure.Interfaces.Repositories;

namespace Test.Application.Implements
{
	/// <summary>
	/// Class UserService.
	/// Implements the <see cref="Test.Application.Abstract.IUserService" />
	/// </summary>
	/// <seealso cref="Test.Application.Abstract.IUserService" />
	public class UserService : IUserService
	{
		/// <summary>
		/// The repository
		/// </summary>
		private readonly IUserRepository _repository;

		/// <summary>
		/// Initializes a new instance of the <see cref="UserService" /> class.
		/// </summary>
		/// <param name="repository">The repository.</param>
		public UserService(IUserRepository repository)
		{
			_repository = repository;
		}

		/// <summary>
		/// Validates the user.
		/// </summary>
		/// <param name="identificationNumber">The user.</param>
		/// <exception cref="ArgumentNullException">user not found {identificationNumber}</exception>
		/// <exception cref="Exception">el usuario {identificationNumber no esta habilitado</exception>
		public async Task<ResponseGenericDto<UserResponseDto>> Validate(string identificationNumber)
		{
			var userEntity = await FirstUserOrDefaultAsync(u => u.IdentificationNumber == identificationNumber);
			var response = new ResponseGenericDto<UserResponseDto> { Success = true };
			if (userEntity is null)
			{
				var randon = RandomNumberGeneratorUtil.Create();
				response.Message = UserMessageResource.Tramite + "(" + randon  + ") " +  UserMessageResource.NoExiste;
			}
			else
			{
				response.Result = userEntity;
				response.Message = UserMessageResource.Existe;
			}

			return response;
		}

		public async Task<ResponseGenericDto<List<UserListDto>>> UserList()
		{
			var getAll = await _repository.GetAllAsync();
			var list = getAll.Select<UserEntity, UserListDto>(u => u).ToList();
			return new ResponseGenericDto<List<UserListDto>> { Success = true, Result = list };
		}

		/// <summary>
		/// Creates the specified user.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns>Task&lt;UserResponseDto&gt;.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public async Task<ResponseGenericDto<bool>> Create(UserCreateDto user)
		{
			var userCreate = await FirstUserOrDefaultAsync(u => u.IdentificationNumber == user.IdentificationNumber);
			var response = new ResponseGenericDto<bool> { Success = false };
			if (userCreate is null)
			{
				response.Message = UserMessageResource.Existe;
			}
			else
			{
				UserEntity userEntity = user;
				await _repository.AddAsync(userEntity);
				response.Message = UserMessageResource.Creado;
				response.Success = true;
			}

			return response;
		}

		/// <summary>
		/// Gets the name of the by user.
		/// </summary>
		/// <param name="userFunc">The user function.</param>
		/// <returns>Task&lt;UserEntity&gt;.</returns>
		internal async Task<UserEntity> FirstUserOrDefaultAsync(Expression<Func<UserEntity, bool>> userFunc)
		{
			return await _repository.FirstOrDefaultAsync(userFunc);
		}

		/// <summary>
		/// Generates the exception.
		/// </summary>
		/// <param name="error">The error.</param>
		/// <exception cref="Exception"></exception>
		/// <exception cref="ArgumentNullException"></exception>
		internal static void GenerateException(string error) => throw new Exception(error);
	}
}