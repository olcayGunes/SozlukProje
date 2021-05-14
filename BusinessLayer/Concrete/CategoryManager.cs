using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class CategoryManager : ICategoryService
	{
		ICategoryDal _categoryDal;
		Category _category;

		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

		public CategoryManager(Category category)
		{
			_category = category;
		}

		public void CategoryAdd(Category catergory)
		{
			_categoryDal.Insert(catergory);
		}

		public void CategoryDelete(Category category)
		{
			_categoryDal.Delete(category);
		}

		public void CategoryUpdate(Category category)
		{
			_categoryDal.Update(category);
		}

		public Category GetById(int id)
		{
			return _categoryDal.Get(x => x.CategoryId == id);
		}

		public List<Category> GetList()
		{
			return _categoryDal.List();
		}
	}
}
