using System;
using Html = HtmlAgilityPack;

namespace Repositories
{
    public class CotacaoRepository
    {
        public decimal GetCotacao(string pagina)
        {
            var cotacao = "R$ 0,00";
            var html = new Html.HtmlDocument();

            html.LoadHtml(pagina);
            //var teste = html.DocumentNode.SelectNodes("//html[1]//body[1]//div[5]//article[1]//div[2]//div[1]//div[1]//div[1]//div[1]//div[1]//div[3]//div[1]//div[1]//div[1]//div[2]//div[4]//div[4]//div[1]//div[1]//div[1]//div[1]//div[1]//div[1]//div[1]//ul[1]//li[1]//span[2]");
            var xpath = html.DocumentNode.SelectNodes("/html/body/div[5]/article/div[2]/div/div[1]/div/div/div[3]/section/div/div/div[2]/div/input");

            var divs = html.DocumentNode.SelectNodes("/html/body/div[5]/article/div[2]/div/div[1]/div/div/div[3]/section/div/div/div[2]/div/input");

            foreach (Html.HtmlNode div in divs)
            {
                cotacao = div.GetAttributeValue("value", "");
            }

            cotacao.Replace("R$", "");
            cotacao.Replace(",", ".");
            return Decimal.Parse(cotacao);
        }
    }
}
