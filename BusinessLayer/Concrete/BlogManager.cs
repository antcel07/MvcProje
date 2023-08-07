using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogdal;

        Repository<Blog> repoblog = new Repository<Blog>();

		public BlogManager(IBlogDal blogdal)
		{
			_blogdal = blogdal;
		}

	
        public List<Blog> GetBlogById(int id)
        {
            return _blogdal.List(x => x.BlogId == id);
        }

        public List<Blog> GetBlogByAuthor(int id)
        {
            return _blogdal.List(x => x.AuthorId == id);
        }
        public List<Blog> GetBlogCategory(int id)
        {
            return _blogdal.List(x => x.CategoryId == id);
        }

    

     
		public List<Blog> GetList()
		{
			return _blogdal.List();
		}

		

		public Blog GetById(int id)
		{
		return	_blogdal.GetById(id);
		}

	
		public void TAdd(Blog t)
		{
			_blogdal.Insert(t);
		}

		public void TDelete(Blog t)
		{
			_blogdal.Delete(t);
		}

		public void TUpdate(Blog t)
		{
			_blogdal.Update(t);
		}
	}

}

