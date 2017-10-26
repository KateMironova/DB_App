using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using DB_App.Sqlite;

namespace DB_App
{
    public class SqliteHandler: IDBHandler
    {
        SQLiteConnection connection = null;
        public SqliteHandler(string path)
        {
            connection = new SQLiteConnection(path);
            connection.CreateTable<Person>();
        }
        public object Read(int id)
        {
            return connection.Table<Person>().ToList();
        }

        public void Create(object objToCreate)
        {
            connection.Insert(objToCreate);
        }
        
        public void Update(object objToUpdate)
        {
            connection.Update(objToUpdate);
        }

        public void Delete(object objToDelete)
        {
            connection.Delete(objToDelete);
        }

    }
}
