using Test.Domain.Entities;

namespace Test.Domain.DTO.User
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public int IdentificationTypeId { get; set; }
        public string IdentificationNumber { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public int MunicipioId { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }


        public static implicit operator UserEntity(UserUpdateDto user) =>
        new() {
            CompanyName = user.CompanyName,
            Address = user.Address,
            Email = user.Email,
            FirstLastName = user.FirstLastName,
            IdentificationTypeId = user.IdentificationTypeId,
            IdentificationNumber = user.IdentificationNumber,
            FirstName = user.FirstName,
            MunicipioId = user.MunicipioId,
            SecondLastName = user.SecondLastName,
            SecondName = user.SecondName,
            CellPhone = user.CellPhone
        };
        

    }
}