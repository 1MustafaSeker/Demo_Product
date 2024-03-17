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
    public class JobManager : IJobService
    {
        IJobDal _jobDal;

        public JobManager(IJobDal jobDal)
        {
            _jobDal = jobDal;
        }

        public void Delete(Job entity)
        {
           _jobDal.Delete(entity);
        }

        public Job GetById(int id)
        {
            return _jobDal.GetById(id);
        }

        public List<Job> GetList()
        {
            return _jobDal.GetList();
        }

        public void Insert(Job entity)
        {
            _jobDal.Insert(entity);
        }

        public void Update(Job entity)
        {
            _jobDal.Update(entity);
        }
    }
}
