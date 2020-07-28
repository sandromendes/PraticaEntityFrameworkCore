using System.ComponentModel.DataAnnotations;

namespace PraticaEntiryFramework.Model.OneToMany
{
    public class Post
    {
        [Key]
        public int Post_Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Blog_Id { get; set; }
        public Blog Blog { get; set; }
    }
}
