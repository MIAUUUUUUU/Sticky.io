using MiauCore.IO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MiauCore.IO.Domain.Infra
{
    [Authorize]
    [Area("Admin")]
    public abstract class BaseAdminController<T> : Controller where T : class, IGenericEntity
    {
        private IUnitOfWork _unitOfWork;
        public BaseAdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<IActionResult> Index()
        {
            var repo = _unitOfWork.CreateRepository<T>();
            var entities = await repo.List();
            return View(entities);
        }

        [HttpGet]
        public virtual IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public virtual async Task<IActionResult> Add(T entity)
        {
            var repo = _unitOfWork.CreateRepository<T>();
            repo.Add(entity);

            await _unitOfWork.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public virtual async Task<IActionResult> Update(int id)
        {
            var repo = _unitOfWork.CreateRepository<T>();
            var entity = await repo.GetById(id);

            if (entity == null)
                return RedirectToAction("Index");

            return View(entity);
        }

        [HttpPost]
        public virtual async Task<bool> Update(T entity)
        {
            try
            {
                var repo = _unitOfWork.CreateRepository<T>();
                repo.Update(entity);

                await _unitOfWork.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        public virtual async Task<bool> Delete(int id)
        {
            try
            {
                var repo = _unitOfWork.CreateRepository<T>();
                repo.Delete(id);

                await _unitOfWork.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
