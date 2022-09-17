using Application.Entities.Base;

namespace Application.DAL.Contract
{
    public interface IDataAccess<TEntity, in TPk> where TEntity : Entity
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TPk id);
        TEntity Create(TEntity entity);
        TEntity Update(TPk id, TEntity entity);
        TEntity Delete(TPk id);

    }
}