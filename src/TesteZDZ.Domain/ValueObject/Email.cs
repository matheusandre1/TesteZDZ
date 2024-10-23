namespace TesteZDZ.Domain.ValueObject
{
    public  class Email
    {
        public string Value { get; set; }

        public Email() { }

        public Email(string value) 
        {
            Value = value; 
        }
    }
}
