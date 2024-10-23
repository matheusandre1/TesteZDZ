namespace TesteZDZ.Domain.Base
{
    public  class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DateRegister { get; set; } = DateTime.Now;
    }
}
