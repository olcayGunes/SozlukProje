using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IContentService
	{
		List<Content> GetList();
		List<Content> GetListByHeadingId(int headingId);
		void ContentAdd(Content content);
		Category GetById(int id);
		void ContentDelete(Content content);
		void ContentUpdate(Content content);
	}
}
