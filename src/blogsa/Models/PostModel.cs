using System;

namespace blogsa
{
    public class PostModel
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public string Image { get; set; }
        public string Author { get; set; }
        public string AuthorUrl { get; set; }
        public string Template { get; set; }
        public string Url { get; set; }
    }
}