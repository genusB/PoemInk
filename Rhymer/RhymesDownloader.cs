using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;

namespace Rhymer
{
    public class RhymesDownloader<T> where T : class
    {
        public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted;
        public IDownloadSettings Settings { get; set; }
        public IParser<T> parser { get; set; }
        HtmlLoader loader;
        public bool IsActive { get; private set; }
        public string DownloadUrl { get; private set; }

        public RhymesDownloader(IParser<T> parser)
        {
            this.parser = parser;
        }

        public RhymesDownloader(IParser<T> parser, IDownloadSettings downloadSettings) : this(parser)
        {
            Settings = downloadSettings;
        }

        public async Task Start()
        {
            IsActive = true;
            await Download();
        }

        public void Abort()
        {
            IsActive = false;
        }

        private async Task Download()
        {
            if (!IsActive)
            {
                OnCompleted?.Invoke(this);
                return;
            }

            loader = new HtmlLoader(Settings);
            var source = await loader.GetSourceByPage();
            var domParser = new HtmlParser();

            var document = await domParser.ParseDocumentAsync(source);

            var result = parser.Parse(document);

            OnNewData?.Invoke(this, result);


            OnCompleted?.Invoke(this);
            IsActive = false;

        }
    }
}
