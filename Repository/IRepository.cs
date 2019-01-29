using System.Collections.Generic;

namespace dotnetTest.Repository
{
    public interface IRepository<Entity, ID>
    {
        List<Entity> All();
        Entity One(ID id);
        Entity Save(Entity entity);
        Entity Update(Entity entity, ID id);
        bool Delete(ID id);
    }
}