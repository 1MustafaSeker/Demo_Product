using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void Delete(Customer entity)
        {
            _customerDal.Delete(entity);
        }

        public Customer GetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public List<Customer> GetCustomerListWithJob()
        {
            return _customerDal.GetCustomerListWithJob();
        }

        public List<Customer> GetList()
        {
            return _customerDal.GetList();  
        }

        public void Insert(Customer entity)
        {
            _customerDal.Insert(entity);
        }

        public void Update(Customer entity)
        {
           _customerDal.Update(entity);
        }
    }
}
