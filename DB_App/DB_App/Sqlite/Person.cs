using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace DB_App.Sqlite
{
    [Table("Person")]
    public class Person
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(int Id, string Fn, string Ln, int Age)
        {
            this.Id = Id;
            FirstName = Fn;
            LastName = Ln;
            this.Age = Age;
        }

        public Person()
        {  }
    }
}
