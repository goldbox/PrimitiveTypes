using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    public enum Discipline { Mathemathics = 1, CSharp, Java, SQL, Literature, Physics, History, Geography, Music, Sport, English, Economics }
    public struct Student
    {
        public Discipline discipline;
        public int[] grade;
        public Student (Discipline discipline, int[] grade)
        {
            this.discipline = discipline;
            this.grade = grade;
        }
    }
    
    public struct Classsroom
    {
        public string studentName;
        public Student[] allGrades;
        public double averageGrade;
        public Classsroom (string studentName, Student[] allGrades)
        {
            this.studentName = studentName;
            this.allGrades = allGrades;
            this.averageGrade = 0;
        }
    }

    [TestClass]
    public class SortStudents
    {
        [TestMethod]
        public void TestMethod1()
        {
            Classsroom[] elevenA =
            {
                new Classsroom("Timotei Dig", GiveRandomGradesToAllDisciplines(1)),
                new Classsroom("Mihai Blaga", GiveRandomGradesToAllDisciplines(2)),
                new Classsroom("Mihai Eminescu", GiveRandomGradesToAllDisciplines(3)),
                new Classsroom("Mircea Eliade", GiveRandomGradesToAllDisciplines(4)),
                new Classsroom("Elena Basescu", GiveRandomGradesToAllDisciplines(5)),
                new Classsroom("Mihaela Cosma", GiveRandomGradesToAllDisciplines(6)),
                new Classsroom("Vlad Tepes", GiveRandomGradesToAllDisciplines(7)),
                new Classsroom("Ion Creanga", GiveRandomGradesToAllDisciplines(8)),
                new Classsroom("Alin Pop", GiveRandomGradesToAllDisciplines(9)),
                new Classsroom("Iuliana Crisan", GiveRandomGradesToAllDisciplines(10)),
                new Classsroom("Marcel Pavel", GiveRandomGradesToAllDisciplines(11)),
                new Classsroom("Cristina Belea", GiveRandomGradesToAllDisciplines(12)),
                new Classsroom("Liviu Guta", GiveRandomGradesToAllDisciplines(13)),
                new Classsroom("Albert Einstein", GiveRandomGradesToAllDisciplines(14)),
                new Classsroom("Avram Iancu", GiveRandomGradesToAllDisciplines(15)),
                new Classsroom("Ion Marica", GiveRandomGradesToAllDisciplines(16)),
                new Classsroom("Maria Fat", GiveRandomGradesToAllDisciplines(17)),
                new Classsroom("Vasile Vas", GiveRandomGradesToAllDisciplines(18)),
                new Classsroom("Mihai Leu", GiveRandomGradesToAllDisciplines(19)),
                new Classsroom("Mirela Mihaescu", GiveRandomGradesToAllDisciplines(20)),
                new Classsroom("Dumitru Cristea", GiveRandomGradesToAllDisciplines(21)),
                new Classsroom("Monica Suteu", GiveRandomGradesToAllDisciplines(22)),

            };

            ComputeAverageGradeAndSortStudents(ref elevenA);





        }

        private void ComputeAverageGradeAndSortStudents(ref Classsroom[] elevenA)
        {
            int i = 0;
            foreach(Classsroom student in elevenA)
            {
                elevenA[i].averageGrade = CalculateAverageGrades(student);
                i++;
            }
            SortUsingAverageGrade(ref elevenA);
        }

        private void SortUsingAverageGrade(ref Classsroom[] classroom)
        {
            for (int i = 1; i < classroom.Length; i++)
                for (int j = i; j > 0 && (classroom[j].averageGrade > classroom[j - 1].averageGrade); j--)
                    Swap(ref classroom, j, j - 1);
        }

        private void Swap(ref Classsroom[] classroom, int a, int b)
        {
            var temp = classroom[a];
            classroom[a] = classroom[b];
            classroom[b] = temp;
        }

        private double CalculateAverageGrades (Classsroom student)
        {
            double result = 0.0;
            for (int i = 0; i< 12; i++)
                result += CalculateAverageForOneScience(student.allGrades[i].grade);
            return result / 12;
        } 

        private double CalculateAverageForOneScience(int[] scienceGrades)
        {
            int numberOfGrades = scienceGrades.Length;
            double result = 0.0;
            for (int i = 0; i < numberOfGrades; i++)
                result += scienceGrades[i];
            return result / numberOfGrades;

        }

        private Student[] GiveRandomGradesToAllDisciplines(int stud)
        {
            Student[] thisStudent =
            {
               new Student (Discipline.Mathemathics, GiveMeRandomGrade(stud + 50)),
                new Student (Discipline.CSharp, GiveMeRandomGrade(stud + 51)),
                new Student (Discipline.Economics, GiveMeRandomGrade(stud + 52)),
                new Student (Discipline.English, GiveMeRandomGrade(stud + 53)),
                new Student (Discipline.Geography, GiveMeRandomGrade(stud + 54)),
                new Student (Discipline.History, GiveMeRandomGrade(stud + 55)),
                new Student (Discipline.Java, GiveMeRandomGrade(stud + 56)),
                new Student (Discipline.Literature, GiveMeRandomGrade(stud + 57)),
                new Student (Discipline.Music, GiveMeRandomGrade(stud + 58)),
                new Student (Discipline.Physics, GiveMeRandomGrade(stud + 59)),
                new Student (Discipline.Sport, GiveMeRandomGrade(stud + 60)),
                new Student (Discipline.SQL, GiveMeRandomGrade(stud + 61))

            };
            return thisStudent;
        }

        private int[] GiveMeRandomGrade (int seed)
        {
            Random random = new Random(seed);
            int n = random.Next(1, 5);
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (i == 2)
                {
                    result[i] = random.Next(1, 10);
                    continue;
                }
                result[i] = (i == 0) ? random.Next(9, 10) : random.Next(7, 10);
            }
            return result;
        }
    }
}
