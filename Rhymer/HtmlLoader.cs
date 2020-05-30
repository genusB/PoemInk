using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Rhymer
{
    public class HtmlLoader
    {
        readonly HttpClient client;
        readonly string url;

        public HtmlLoader(IDownloadSettings settings)
        {
            client = new HttpClient();
            url = $"{settings.BaseUrl}{settings.RhymeType}/{settings.Word}.html";
        }

        public async Task<string> GetSourceByPage()
        {
            var response = await client.GetAsync(url);
            string source = "";

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
