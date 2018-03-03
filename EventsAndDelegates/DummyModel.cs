using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class DummyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Grade Grade { get; set; }

        public DummyModel(int id, string name, Grade grade)
        {
            this.Id = id;
            this.Name = name;
            this.Grade = grade;
        }
    }
}
