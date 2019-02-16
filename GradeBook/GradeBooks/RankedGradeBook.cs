using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base (name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students");
            }
            else
            {
                //treshold and get list of average grades by descending order,
                var treshold = (int)Math.Ceiling(Students.Count * 0.2);
                List<double> grades = new List<double>();

                foreach (Student student in Students)
                {
                        grades.Add(student.AverageGrade);
                }

                grades.OrderByDescending(i => i);

                //Final step


                if (grades[treshold - 1] <= averageGrade)
                {
                    return 'A';
                }
                else if (grades[(treshold * 2) - 1] <= averageGrade)
                {
                    return 'B';
                }
                else if (grades[(treshold * 3) - 1] <= averageGrade)
                {
                    return 'C';
                }
                else if (grades[(treshold * 4) - 1] <= averageGrade)
                {
                    return 'D';
                }
                else
                {
                    return 'F';
                }

            }

            return base.GetLetterGrade(averageGrade);
        }
    }
}
