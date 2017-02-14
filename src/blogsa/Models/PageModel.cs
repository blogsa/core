using System;

namespace blogsa
{
    public class PageModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Template { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Summary { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
    }
}