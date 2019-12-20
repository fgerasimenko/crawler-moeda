using System;

namespace Entities
{
    public class Conta
    {
        public Conta()
        {
            this.Codigo = 0;
            this.Id = 0;
            this.Saldo = 0;
        }
        public int Codigo { get; set; }
        public int Id { get; set; }
        public decimal Saldo { get; set; }
    }
}
