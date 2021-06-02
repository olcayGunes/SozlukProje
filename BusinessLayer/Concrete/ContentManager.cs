﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class ContentManager : IContentService
	{

		IContentDal _contentDal;

		public ContentManager(IContentDal contentDal)
		{
			_contentDal = contentDal;
		}

		public void ContentAdd(Content content)
		{
			throw new NotImplementedException();
		}

		public void ContentDelete(Content content)
		{
			throw new NotImplementedException();
		}

		public void ContentUpdate(Content content)
		{
			throw new NotImplementedException();
		}

		public Category GetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<Content> GetList()
		{
			throw new NotImplementedException();
		}

		public List<Content> GetListByHeadingId(int headingId)
		{
			return _contentDal.List(x => x.HeadingId == headingId);
		}
	}
}
