using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_App
{
    public interface IDBHandler
    {
        void Create(object objToCreate);
        object Read(int id);
        void Update(object objToUpdate);
        void Delete(object objToDelete);
    }
}
