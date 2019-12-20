using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Repositories;

namespace Services
{
    public class ContaService
    {
        private ContaRepository _repository;

        public ContaService()
        {
            if (_repository == null)
                _repository = new ContaRepository();
        }

        public void Save(Conta conta)
        {
            var model = GetConta(conta.Id);

            if (model.Codigo != 0)
                throw new Exception("Esse ID de conta já existe");

            
                _repository.Save(conta);

        }

        public void Update(Conta conta)
        {
            var model = GetConta(conta.Id);

            if (model.Codigo == 0)
                throw new Exception("Esse ID de conta não existe");

            
            _repository.Update(conta);

        }

        public Conta GetConta(int id)
        {
            return _repository.GetConta(id);
        }

        public void Saque(Saque saque)
        {
            if (saque.Quantia < 0)
                throw new Exception("Valor inválido. Por favor, tente outra quantia");

            var model = GetConta(saque.Conta.Id);

            if(model.Codigo == 0)
                throw new Exception("Esse ID de conta não existe");

            model.Saldo = model.Saldo - saque.Quantia;

            if(model.Saldo < 0)
                throw new Exception("Saldo Insuficiente");

            Update(model);
        }

        public void Deposito(Deposito deposito)
        {
            if(deposito.Quantia < 0)
                throw new Exception("Valor inválido. Por favor, tente outra quantia");

            var model = GetConta(deposito.Conta.Id);

            if (model.Codigo == 0)
                throw new Exception("Esse ID de conta não existe");

            model.Saldo = model.Saldo + deposito.Quantia;

            Update(model);
        }
    }
}
