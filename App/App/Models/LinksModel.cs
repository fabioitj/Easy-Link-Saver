using System;
using SQLite;

namespace App.Models
{
    public class LinksModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateRegister { get; set; }
    }

    public class CommandParameters
    {
        public LinksModel link { get; set; }
    }
}
