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
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id); 
        }

        public List<Product> GetList()
        {
            return _productDal.GetList();
        }

        public void Insert(Product entity)
        {
           _productDal.Insert(entity);
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
