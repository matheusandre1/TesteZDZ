using System.ComponentModel.DataAnnotations;

namespace TesteZDZ.Domain.Base
{
    public  abstract class BaseEntity
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; protected set; } 
        public DateTime DateRegister { get; set; } = DateTime.Now;
    }
}
