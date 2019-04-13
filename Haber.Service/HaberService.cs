using Haber.Data;
using Haber.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Service
{
    public interface IHaberService
    {
        void Insert(Haberler entity);
        void Update(Haberler entity);
        void Delete(Haberler entity);
        void Delete(Guid id);
        Haberler Find(Guid id);
        IEnumerable<Haberler> GetAll();
        IEnumerable<Haberler> GetAllByTitle(string title);
        IEnumerable<Haberler> Search(string title);
    }


    public class HaberService:IHaberService
    {
        private readonly IRepository<Haberler> haberRepository;
        private readonly IUnitOfWork unitOfWork;
        public HaberService(IUnitOfWork unitOfWork, IRepository<Haberler> haberRepository)
        {
            this.unitOfWork = unitOfWork;
            this.haberRepository = haberRepository;
        }

        public void Delete(Haberler entity)
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

        public Haberler Find(Guid id)
        {
            return haberRepository.Find(id);
        }

        public IEnumerable<Haberler> GetAll()
        {
            return haberRepository.GetAll();
        }

        public IEnumerable<Haberler> GetAllByTitle(string title)
        {
            return haberRepository.GetAll(w => w.HaberBaslik.Contains(title));
        }

        public void Insert(Haberler entity)
        {
            haberRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Haberler> Search(string title)
        {
            return haberRepository.GetAll(e => e.HaberBaslik.Contains(title));
        }

        public void Update(Haberler entity)
        {
            var galery = haberRepository.Find(entity.Id);
            galery.HaberBaslik = entity.HaberBaslik;
            galery.HaberPhoto = entity.HaberPhoto;
            galery.HaberDetay = entity.HaberDetay;
            galery.HaberSirano = entity.HaberSirano;
            galery.IsActive = entity.IsActive;
            haberRepository.Update(galery);
            unitOfWork.SaveChanges();
        }
    }
}
