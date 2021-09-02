 namespace Test.Domain.Entities
{
     
    public class UserEntity : Entity
    {
         
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


        public MunicipioEntity Municipio { get; set; }

        public IdentificationTypeEntity IdentificationType { get; set; }

    }
}