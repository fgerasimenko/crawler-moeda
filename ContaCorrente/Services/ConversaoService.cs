using System;
using Repositories;

namespace Services
{
    public class ConversaoService
    {
        private CotacaoRepository _repository;

        public ConversaoService()
        {
            if (_repository == null)
                _repository = new CotacaoRepository();
        }

        public decimal Converter(decimal quantia)
        {
            var link = "https://economia.uol.com.br/cotacoes/cambio/dolar-comercial-estados-unidos/";


            var pagina = new WebCrawler().Page(link);
            var conversao = _repository.GetCotacao(pagina);

            var total = quantia / conversao;
            return total;
        }

        public decimal GetCotacao(decimal quantia)
        {
            var link = "https://economia.uol.com.br/cotacoes/cambio/dolar-comercial-estados-unidos/";

            CotacaoRepository repository = new CotacaoRepository();

            var pagina = new WebCrawler().Page(link);
            var cotacao = _repository.GetCotacao(pagina);
            return quantia / cotacao;
        }

    }
}
