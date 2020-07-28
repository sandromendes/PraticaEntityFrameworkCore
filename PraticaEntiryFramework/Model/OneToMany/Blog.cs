using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PraticaEntiryFramework.Model.OneToMany
{
    public class Blog
    {
        [Key]
        public int Blog_Id { get; set; }
        public string Url { get; set; }
        public List<Post> Posts { get; set; }
    }
}
