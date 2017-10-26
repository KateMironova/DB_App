using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_App
{
    public class PersonRealm: RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Fn { get; set; }
        public string Ln { get; set; }
        public int Age { get; set; }

        public PersonRealm()
        {

        }
        public PersonRealm(int Id, string Fn, string Ln, int Age)
        {
            this.Id = Id;
            this.Fn = Fn;
            this.Ln = Ln;
            this.Age = Age;
        }

    }
}
