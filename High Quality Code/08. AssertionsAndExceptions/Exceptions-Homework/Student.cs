using System;
using System.Linq;
using System.Collections.Generic;

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    private IList<Exam> exams;

    public Student(string firstName, string lastName, IList<Exam> exams)
    {
        if (firstName == null)
        {
            throw new ArgumentNullException("Student first name must be initialized.");
        }
        
        if (firstName.Length <= 1)
        {
            throw new ArgumentException("Student first name must be longer than 1 synbol.");
        }

        if (lastName == null)
        {
            throw new ArgumentNullException("Student last name must be initialized.");
        }

        if(lastName.Length <= 1)
        {
            throw new ArgumentException("Student last name must be longer than 1 symbol.");
        }

        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public IList<Exam> Exams
    {
        get
        {
            return this.exams;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Student exams collection must be initialized.");
            }

            this.exams = value;
        }
    }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams.Count <= 0)
        {
            throw new ArgumentException("Student exam list must contain at least 1 element.");
        }

        IList<ExamResult> results = new List<ExamResult>();

        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams.Count == 0)
        {
            throw new ArgumentException("Student exam list must containt at least 1 element.");
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
