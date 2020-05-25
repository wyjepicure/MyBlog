namespace Wyj.Blog.Web.Models.Blogs
{
    public class Article
    {
        public Article()
        {
        }

        public string Context { get; internal set; }
        public int Id { get; internal set; }
        public string Title { get; internal set; }
    }
}