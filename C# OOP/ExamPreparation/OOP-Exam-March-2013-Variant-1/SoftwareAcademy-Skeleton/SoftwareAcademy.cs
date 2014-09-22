using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.IO;

namespace SoftwareAcademy
{
    public class SoftwareAcademyCommandExecutor
    {
        static void Main()
        {
            using (StreamWriter sw = new StreamWriter("../../output.txt"))
            {
                CourseFactory f = new CourseFactory();
                ITeacher joro = f.CreateTeacher("Joro");
                sw.WriteLine(joro);
                joro.Name = "George";
                sw.WriteLine(joro);
                ILocalCourse php = f.CreateLocalCourse("PHP", joro, "Enterprise");
                sw.WriteLine(php);
                php.AddTopic("Intro PHP");
                php.AddTopic("PHP Core");
                php.AddTopic("PHP Advanced Topics");
                php.AddTopic("PHP Exam");
                sw.WriteLine(php);
                IOffsiteCourse cpp = (new CourseFactory()).CreateOffsiteCourse("C++", joro, "Ultimate");
                sw.WriteLine(cpp);
                cpp.AddTopic("Intro C++");
                cpp.AddTopic("C++ Core");
                cpp.AddTopic("C++ Advanced Topics");
                cpp.AddTopic("C++ Exam");
                sw.WriteLine(cpp);
                joro.AddCourse(cpp);
                sw.WriteLine(joro);
                joro.AddCourse(php);
                joro.AddCourse(cpp);
                sw.WriteLine(joro);
                CourseFactory factory = new CourseFactory();
                ITeacher nakov = factory.CreateTeacher("Nakov");
                sw.WriteLine(nakov);
                nakov.Name = "Svetlin Nakov";
                sw.WriteLine(nakov);
                ILocalCourse oop = factory.CreateLocalCourse("OOP", null, "Light");
                sw.WriteLine(oop);
                oop.Teacher = nakov;
                sw.WriteLine(oop);
                oop.AddTopic("Using Classes and Objects");
                oop.AddTopic("Defining Classes");
                oop.AddTopic("OOP Principles");
                oop.AddTopic("Teamwork");
                oop.AddTopic("Exam Preparation");
                sw.WriteLine(oop);
                ICourse html = factory.CreateOffsiteCourse("HTML", nakov, "Plovdiv");
                html.AddTopic("Using Classes and Objects");
                sw.WriteLine(html);
                html.AddTopic("Defining Classes");
                html.AddTopic("OOP Principles");
                sw.WriteLine(html);
                html.AddTopic("Teamwork");
                html.AddTopic("Exam Preparation");
                sw.WriteLine(html);
                nakov.AddCourse(oop);
                nakov.AddCourse(html);
                sw.WriteLine(nakov);
                oop.Name = "Object-Oriented Programming";
                (oop as ILocalCourse).Lab = "Enterprise";
                oop.Teacher = factory.CreateTeacher("George Georgiev");
                oop.AddTopic("Practical Exam");
                sw.WriteLine(oop);
                html.Name = "HTML Basics";
                (html as IOffsiteCourse).Town = "Varna";
                html.Teacher = oop.Teacher;
                html.AddTopic("Practical Exam");
                sw.WriteLine(html);
                ICourse css = factory.CreateLocalCourse("CSS", null, "Ultimate");
                sw.WriteLine(css);
                for (int i = 0; i < 2; i++)
                {
                    joro.AddCourse(oop);
                    joro.AddCourse(oop);
                    joro.AddCourse(css);
                }
                sw.WriteLine(joro);
                php.Name = "PHP Avdanced Course";
                ILocalCourse localPhp = (ILocalCourse)php;
                localPhp.Lab = "The Very Big Lab";
                php.Teacher = nakov;
                php.AddTopic("Final PHP Topic");
                sw.WriteLine(php);
                html.Name = "PHP Avdanced Course";
                IOffsiteCourse offsiteHtml = (IOffsiteCourse)html;
                offsiteHtml.Town = "The Very Big Lab";
                html.Teacher = null;
                html.AddTopic("Final HTML Topic");
                sw.WriteLine(html.ToString());
            }

        }

//        private static string ReadInputCSharpCode()
//        {
//            StringBuilder result = new StringBuilder();
//            string line;
//            while ((line = sw.ReadLine()) != "")
//            {
//                result.AppendLine(line);
//            }
//            return result.ToString();
//        }

//        static void CompileAndRun(string csharpCode)
//        {
//            // Prepare a C# program for compilation
//            string[] csharpClass =
//            {
//                @"using System;
//                  using SoftwareAcademy;
//
//                  public class RuntimeCompiledClass
//                  {
//                     public static void Main()
//                     {"
//                        + csharpCode + @"
//                     }
//                  }"
//            };

//            // Compile the C# program
//            CompilerParameters compilerParams = new CompilerParameters();
//            compilerParams.GenerateInMemory = true;
//            compilerParams.TempFiles = new TempFileCollection(".");
//            compilerParams.ReferencedAssemblies.Add("System.dll");
//            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
//            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
//            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
//                compilerParams, csharpClass);

//            // Check for compilation errors
//            if (compile.Errors.HasErrors)
//            {
//                string errorMsg = "Compilation error: ";
//                foreach (CompilerError ce in compile.Errors)
//                {
//                    errorMsg += "\r\n" + ce.ToString();
//                }
//                throw new Exception(errorMsg);
//            }

//            // Invoke the Main() method of the compiled class
//            Assembly assembly = compile.CompiledAssembly;
//            Module module = assembly.GetModules()[0];
//            Type type = module.GetType("RuntimeCompiledClass");
//            MethodInfo methInfo = type.GetMethod("Main");
//            methInfo.Invoke(null, null);
//        }
    }
}
