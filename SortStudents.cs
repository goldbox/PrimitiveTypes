using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    public enum Discipline { Mathemathics = 1, CSharp, Java, SQL, Literature, Physics, History, Geography, Music, Sport, English, Economics }
    public struct Grades
    {
        public Discipline discipline;
        public int[] grade;
        public Grades (Discipline discipline, int[] grade)
        {
            this.discipline = discipline;
            this.grade = grade;
        }
    }
    
    public struct Classsroom
    {
        public string studentName;
        public Grades[] allGrades;
        public Classsroom (string studentName, Grades[] allGrades)
        {
            this.studentName = studentName;
            this.allGrades = allGrades;
        }
    }

    [TestClass]
    public class SortStudents
    {
        [TestMethod]
        public void TestMethod1()
        {
            Grades[] timoteiDigGrades =
            {
                new Grades (Discipline.Mathemathics,  new int[] { 7, 8, 10 }),
                new Grades (Discipline.CSharp, new int[]{ 10, 9, 10 }),
                new Grades (Discipline.Economics, new int[] {7,8}),
                new Grades (Discipline.English, new int[] {9,8}),
                new Grades (Discipline.Geography, new int[] {})

            };
            Classsroom[] elevenA = {    new Classsroom("TimoteiDig", timoteiDigGrades),
                                        new Classsroom("MihaiRoman", timoteiDigGrades)    
            };
            //double result = elevenA[].studentName.
        }
    }
}
