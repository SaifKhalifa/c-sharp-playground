using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_4_collections
{
    public class Student
    {
        public Guid _stuID { get; private set; }      
        public string Name { get; private set; }

        public Student(string name)
        {
            if (name == null || name == " ") throw new ArgumentNullException("Name must not be empty");

            Name = name;
            _stuID = Guid.NewGuid();
        }

        public Student(string name, Guid studentID)
        {
            if (name == null || name == " ") throw new ArgumentNullException("Name must not be empty");

            Name = name;
            _stuID = studentID;
        }
    }
}
