using Euroval.Entity.Entity;
using Euroval.Entity.Repository;
using Euroval.Entity.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Euroval.Domain.Domain;
using System.Linq.Expressions;

namespace Euroval.Domain.Service
{
    public abstract class GenericServiceAsync<Tv, Te> : IServiceAsync<Tv, Te> where Tv : BaseDomain where Te : BaseEntity
    {
        protected IRepositoryAsync<Te> _repository;

        internal readonly IUnitOfWork _unitOfWork;

        protected GenericServiceAsync(IRepositoryAsync<Te> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<IEnumerable<Tv>> GetAll()
        {
            var entityResult = await _repository.GetAll();
            return Mapper.Map<IEnumerable<Tv>>(source: entityResult);
        }

        public async Task<Tv> GetOne(int id)
        {
            var entityResult = await _repository.GetOne(predicate: x => x.Id == id);
            return Mapper.Map<Tv>(source: entityResult);
        }

        public async Task<IEnumerable<Tv>> Get(Expression<Func<Te, bool>> predicate)
        {
            var entityResult = await _repository.Get(predicate);
            return Mapper.Map<IEnumerable<Tv>>(source: entityResult);
        }
        public async Task<int> Add(Tv obj)
        {
            var entityResult = Mapper.Map<Te>(source: obj);
            await _repository.Insert(entityResult);
            await _unitOfWork.SaveAsync();

            return entityResult.Id;
        }
        public async Task<int> Update(Tv obj)
        {
            var entityResult = Mapper.Map<Te>(source: obj);
            await _repository.Update(obj.Id, entityResult);

            return await _unitOfWork.SaveAsync();
        }
        public async Task<int> Remove(int id)
        {
            var entityResult = await _repository.GetOne(predicate: x => x.Id == id);
            _repository.Delete(entityResult);

            return await _unitOfWork.SaveAsync();
        }
    }
}
