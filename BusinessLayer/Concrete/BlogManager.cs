using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class BlogManager
    {
        Repository<Blog> repoblog = new Repository<Blog>();

        public List<Blog> GetAll()
        {
            return repoblog.List();
        }

        public List<Blog> GetBlogById(int id)
        {
            return repoblog.List(x => x.BlogId == id);
        }

        public List<Blog> GetBlogByAuthor(int id)
        {
            return repoblog.List(x => x.AuthorId == id);
        }
        public List<Blog> GetBlogCategory(int id)
        {
            return repoblog.List(x => x.CategoryId == id);
        }

        public int BlogAddBL(Blog p)
        {
            if(p.BlogTitle=="" ||  p.BlogImage=="" || p.BlogTitle.Length<=5 || p.BlogContent.Length <= 200)
            {
                return -1;
            }

           return repoblog.Insert(p);
        }

        public int DeleteBlogBL(int p)
        {
            Blog blog=repoblog.Find(x=>x.BlogId==p);
            return repoblog.Delete(blog);
        }


    }

}

