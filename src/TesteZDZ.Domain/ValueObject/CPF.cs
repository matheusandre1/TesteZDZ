using System.ComponentModel.DataAnnotations;

namespace TesteZDZ.Domain.ValueObject
{
    public  class CPF
    {
        public string? Value { get; set; }

        public CPF()
        {

        }

        public CPF(string value)
        {
            Value = value;
        }
    }
}
