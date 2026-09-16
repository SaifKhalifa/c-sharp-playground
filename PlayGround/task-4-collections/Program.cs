namespace task_4_collections
{
    internal class Program
    {
        static HashSet<Student> students = new HashSet<Student>();

        static int SearchStudent(Guid studentId)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students.ElementAt(i)._stuID.Equals(studentId))
                {
                    Console.WriteLine($"Student with given ID found at index {i}.\nStudent Name: {students.ElementAt(i).Name}");
                    return i;
                }
            }

            Console.WriteLine("No student found with the given ID");
            return -1;
        }

        static void Test()
        {
        search: Console.Write("Enter student ID to search for: ");
            string guidString = Console.ReadLine();
            Guid value;

            if (Guid.TryParse(guidString, out value)) { SearchStudent(value); }

            else
            {
                Console.WriteLine("Not Valid Student ID!");
                goto search;
            }


        delete: Console.Write("Enter student ID to delete: ");
            guidString = Console.ReadLine();

            if (Guid.TryParse(guidString, out value))
            {
                int index = SearchStudent(value);
                if (index >= 0)
                {
                    Console.WriteLine($"{students.ElementAt(index).Name} is deleted!");
                    students.Remove(students.ElementAt(index));

                    //goto print;
                }
            }

            else
            {
                Console.WriteLine("Not Valid Student ID!");
                goto delete;
            }
        }

        static void Main(string[] args)
        {

            // add new user
            string? studentName = null;

            //Console.Write("Enter Student Name: ");
            //studentName = Console.ReadLine();
            
            Student newStudent = new Student("student name 1");

            students.Add(newStudent);

            newStudent = new Student("student name 2");

            students.Add(newStudent);

        print: for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students.ElementAt(i).Name + ", " + students.ElementAt(i)._stuID);               
            }

            Console.Write("\nenter a new student ID to create: ");
            string guidString = Console.ReadLine();
            Guid value;

            if (Guid.TryParse(guidString, out value))
            {
                int index = SearchStudent(value);
                if (index >= 0)
                {
                    Console.WriteLine($"student with the same guid already exists!");                    
                    goto print;
                }
                else
                {
                    newStudent = new Student("student name 99", value);

                    students.Add(newStudent);
                }
            }

            else
            {
                Console.WriteLine("Not Valid Student ID!");
                goto print;
            }

        }
    }
}
