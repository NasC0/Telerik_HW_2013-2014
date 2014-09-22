namespace StudentClassesTest
{
    using StudentClasses;
    using System;

    class StudentClassesTest
    {
        static void Main()
        {
            Student peshoStudent = new Student("Pesho Peshev Peshevski", 3215, 2, University.NBU, Faculty.Literature, Specialty.Economics);

            Student peshoClone = peshoStudent.Clone() as Student;

            peshoStudent.EMail = "pesho@dont-clone.!!";
            peshoStudent.Address = "Miami";
            peshoStudent.MobilePhone = "1-800-rave-all-night";

            Student fullClone = peshoStudent.Clone() as Student;

            if (peshoClone == peshoStudent)
            {
                Console.WriteLine("Pesho has found out the secret to cloning students!");
            }

            if (peshoClone == fullClone)
            {
                Console.WriteLine("Even the clones are equal");
            }

            Student goshoStudent = new Student("Gosho Goshev Gochev", 3000, 3, University.SU, Faculty.Informatics, Specialty.NetworkTechnologies);

            if (goshoStudent == peshoStudent)
            {
                Console.WriteLine("Gosho equals Pesho");
            }
            else
            {
                Console.WriteLine("Gosho doesn't equal Pesho");
            }

            if (peshoStudent.CompareTo(goshoStudent) == -1)
            {
                Console.WriteLine("Gosho is better than Pesho");
            }
            else if (peshoStudent.CompareTo(goshoStudent) == 0)
            {
                Console.WriteLine("Gosho is comparable to Pesho");
            }
            else
            {
                Console.WriteLine("Pesho is better than Gosho");
            }
        }
    }
}
