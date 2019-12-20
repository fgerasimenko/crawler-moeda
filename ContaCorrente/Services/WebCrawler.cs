using System;
using System.Collections.Generic;
using System.Net;
using System.Text;


namespace Services
{
    public class WebCrawler
    {
        public string Page(string link)
        {
            var web = new WebClient();

            string pagina = web.DownloadString(link);

            return pagina;
        }
    }
}
