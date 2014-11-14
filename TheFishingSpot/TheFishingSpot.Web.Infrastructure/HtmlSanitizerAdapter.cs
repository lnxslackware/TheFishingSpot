namespace TheFishingSpot.Web.Infrastructure
{
    using Html;

    public class HtmlSanitizerAdapter : ISanitizer
    {
        private HtmlSanitizer sanitizer;

        public HtmlSanitizerAdapter()
        {
            this.sanitizer = new HtmlSanitizer();
        }
        public string Sanitize(string html)
        {
            return this.sanitizer.Sanitize(html);
        }
    }
}