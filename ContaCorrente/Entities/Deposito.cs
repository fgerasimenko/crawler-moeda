using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Deposito
    {
        public Deposito()
        {
            this.Conta = new Conta();
            this.Quantia = 0;
        }

        public Conta Conta { get; set; }
        public decimal Quantia { get; set; }
    }
}
