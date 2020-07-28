using PraticaEntiryFramework.Context;
using PraticaEntiryFramework.Model.OneToMany;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PraticaEntiryFramework.Samples.OneToMany
{
    public class Sample
    {
        public static void Run()
        {
            Console.WriteLine("Exemplo de Criação de Blog...");

            AddBlog();

            AddPost();

            List<Blog> listaBlogs = ListBlogs();

            UpdateBlog(listaBlogs);

            RemoveFirstBlog(listaBlogs);

            RemoveSomeBlog();

            MultipleOperations();
        }

        private static void RemoveSomeBlog()
        {
            using (var context = new BloggingContext())
            {
                Console.WriteLine("Pesquisando um blog");
                Blog blog = context.Blogs.Single(b => b.Blog_Id == 18);

                if(blog != null)
                {
                    Console.WriteLine($"Dados do blog -> Id: {blog.Blog_Id} URL: {blog.Url}");
                    Console.WriteLine("Removendo o blog recuperado na consulta");
                    context.Blogs.Remove(blog);
                    Console.WriteLine("Remoção efetuada com sucesso!");
                }
            }
        }

        private static void MultipleOperations()
        {
            #region MultipleOperations
            using (var context = new BloggingContext())
            {
                Console.WriteLine("Criando dois blogs");
                // seeding database
                context.Blogs.Add(new Blog { Url = "http://example.com/blog" });
                context.Blogs.Add(new Blog { Url = "http://example.com/another_blog" });
                context.SaveChanges();
                Console.WriteLine("Blogs criados com sucesso!");
            }

            using (var context = new BloggingContext())
            {
                Console.WriteLine("Iniciando bloco de operações múltiplas...");

                // add
                Console.WriteLine("Criando dois blogs");
                context.Blogs.Add(new Blog { Url = "http://example.com/blog_one" });
                context.Blogs.Add(new Blog { Url = "http://example.com/blog_two" });
                context.Blogs.Add(new Blog { Url = "http://example.com/blog_three" });
                context.Blogs.Add(new Blog { Url = "http://example.com/blog_four" });

                // update
                Console.WriteLine("Atualizando a primeira ocorrência");
                var firstBlog = context.Blogs.First();
                firstBlog.Url = "";

                // remove
                Console.WriteLine("Removendo a última ocorrência");
                var lastBlog = context.Blogs.ToList().Last();
                context.Blogs.Remove(lastBlog);

                context.SaveChanges();

                Console.WriteLine("Operações finalizadas com sucesso!");
            }
            #endregion
        }

        private static List<Blog> ListBlogs()
        {
            List<Blog> listaBlogs;

            using (var context = new BloggingContext())
            {
                listaBlogs = context.Blogs.ToList();

                foreach (var blog in listaBlogs)
                {
                    Console.WriteLine($"Dados do blog -> Id: {blog.Blog_Id} URL: {blog.Url}");
                }
            };

            return listaBlogs;
        }

        private static void UpdateBlog(List<Blog> listaBlogs)
        {
            #region Update
            using (var context = new BloggingContext())
            {
                Console.WriteLine("Atualizando um blog");
                var blog = listaBlogs.First();

                Console.WriteLine($"Blog -> Id: {blog.Blog_Id} URL: {blog.Url}");
                
                blog.Url = "http://example.com/blog";

                Console.WriteLine($"Alterado para -> Id: {blog.Blog_Id} URL: {blog.Url}");

                context.Entry<Blog>(blog);

                context.SaveChanges();

                Console.WriteLine("Blog atualizado com sucesso!");
            }
            #endregion
        }

        private static void RemoveFirstBlog(List<Blog> listaBlogs)
        {
            #region Remove
            using (var context = new BloggingContext())
            {
                Console.WriteLine("Removendo um blog");
                var blog = listaBlogs.First();
                context.Blogs.Remove(blog);
                context.SaveChanges();
                Console.WriteLine("Blog removido com sucesso!");
            }
            #endregion
        }

        private static void AddPost()
        {
            #region AddPost
            using (var context = new BloggingContext())
            {
                Console.WriteLine("Criarndo um post");
                List<Blog> listaBlogs = context.Blogs.OrderByDescending(blog => blog.Blog_Id)
                    .Where(blog => blog.Blog_Id > 10)
                    .ToList();

                Blog blog = listaBlogs.First();

                Post post = new Post
                {
                    Blog_Id = blog.Blog_Id,
                    Title = "Teste de criação de post",
                    Content = "Conteúdo exclusivo de testes."
                };
                context.Posts.Add(post);
                context.SaveChanges();

                Console.WriteLine("Post criado com sucesso!");
            }
            #endregion
        }

        private static void AddBlog()
        {
            #region Add Blog
            using (var context = new BloggingContext())
            {
                Console.WriteLine("Criando um blog");

                var blog = new Blog { Url = "http://example.com" };
                context.Blogs.Add(blog);
                context.SaveChanges();

                Console.WriteLine("Blog criado com sucesso!");
            }
            #endregion
        }
    }
}
