using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_App
{
    public class RealmHandler: IDBHandler
    {

        Realm realm = Realm.GetInstance();

        public object Read(int id)
        {
            return realm.Find<PersonRealm>(id);            
        }
        public void Create(object objToCreate)
        {
            PersonRealm p = objToCreate as PersonRealm;

            if (p != null)
            {
                realm.Write(() =>
                {
                    realm.Add(p);
                });
            }
        }
        public void Update(object objToUpdate)
        {
            PersonRealm p = objToUpdate as PersonRealm;

            if (p != null)
            {
                realm.Write(() =>
                {
                    realm.Add(p, update: true);
                });
            }
        }
        public void Delete(object objToDelete)
        {
            var del = realm.All<PersonRealm>().First(b => b.Id == objToDelete.Id);

            using (var trans = realm.BeginWrite())
            {
                realm.Remove(del);
                trans.Commit();
            }
        }
    }
}
