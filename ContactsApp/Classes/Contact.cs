using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsApp.Classes
{
    [Table("Contacts")]
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
