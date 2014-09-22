using System;

public class ExamResult
{
    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentException("Exam grade must be positive.");
        }
        if (minGrade < 0)
        {
            throw new ArgumentException("Exam minimal grade must be positive.");
        }
        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("Exam maximal grade must be bigger than the minimal grade.");
        }
        if (comments == null || comments == "")
        {
            throw new ArgumentNullException("Exam comments must be initialized and not empty.");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
