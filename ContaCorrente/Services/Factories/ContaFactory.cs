using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Factories
{
    public class ContaFactory
    {
        private static volatile ContaFactory contaFactory;
        private static volatile ContaService contaService;

        public static ContaFactory GetInstance()
        {
            if (contaFactory == null)
                contaFactory = new ContaFactory();

            return contaFactory;
        }

        public ContaService GetContaService()
        {
            if (contaService == null)
                contaService = new ContaService();

            return contaService;
        }
    }
}
