using Haber.Data;
using Haber.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Service
{
    public interface ILogService
    {
        void Insert(LogLama entity);
        void Update(LogLama entity);
        void Delete(LogLama entity);
        void Delete(Guid id);
        LogLama Find(Guid id);

        LogLama Find(String slug);
        IEnumerable<LogLama> GetAll();
        IEnumerable<LogLama> GetAllByTitle(string title);
        IEnumerable<LogLama> Search(string title);
    }


    public class LogService : ILogService
    {
        private readonly IRepository<LogLama> haberRepository;
        private readonly IUnitOfWork unitOfWork;
        public LogService(IUnitOfWork unitOfWork, IRepository<LogLama> haberRepository)
        {
            this.unitOfWork = unitOfWork;
            this.haberRepository = haberRepository;
        }

        public void Delete(LogLama entity)
        {
            haberRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var galery = haberRepository.Find(id);
            if (galery != null)
            {
                this.Delete(galery);
            }
        }
        public LogLama Find(String slug)
        {
            return haberRepository.Find(slug);
        }

        public LogLama Find(Guid id)
        {
            return haberRepository.Find(id);
        }

        public IEnumerable<LogLama> GetAll()
        {
            return haberRepository.GetAll();
        }

        public IEnumerable<LogLama> GetAllByTitle(string title)
        {
            return haberRepository.GetAll(w => w.Message.Contains(title));
        }

        public void Insert(LogLama entity)
        {
            haberRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<LogLama> Search(string title)
        {
            return haberRepository.GetAll(e => e.Message.Contains(title));
        }

        public void Update(LogLama entity)
        {
            var galery = haberRepository.Find(entity.Id);
            haberRepository.Update(galery);
            unitOfWork.SaveChanges();
        }
    }
}
