using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchingAlgorithm
{
    public partial class Matching
    {
        public static void Main(string[] args)
        {
            // Call PopulateData to get a list of Universities and Students along with thier prefered choices and scores
            PopulateData(out List<University> Universities, out List<Student> Students);

            // Perform the actual match routine and return the results
            var MatchResults = FinalMatchResults(Universities, Students);

            // Optionally display the formatted results
            MatchResults.ForEach(r => Console.WriteLine($"{r.StudentName}:Matched:{r.UniversityName}:Rank {r.Rank}"));
        }

        /// <summary>
        /// Return a List<MatchResult> which represents the final matches of students to universites and the preference rank.
        /// Make use of RankStudentsByScore and RankStudentPreferenceByRank methods in the implementation of this method.
        /// </summary>
        public static List<MatchResult> FinalMatchResults(List<University> universities, List<Student> students)
        {
            List<MatchResult> result = new List<MatchResult>();

            foreach (var university in universities)
            {
                for (int i = 1; i <= 5; i++)
                {
                    List<Student> matchedStudents = students.Where(s => s.Preferences
                                                                    .Where(p => p.University.Equals(university.UniversityName) && p.Rank.Equals(i)).Any()
                                                                  )
                                                            .OrderByDescending(s => s.Age)
                                                            .ToList();
                    foreach (var matchedStudent in matchedStudents)
                    {
                        if (university.RemainingPlaces > 0)
                        {
                            result.Add(new MatchResult()
                            {
                                StudentName = matchedStudent.StudentName,
                                UniversityName = university.UniversityName,
                                Rank = i
                            });

                            university.RemainingPlaces -= 1;
                        }
                    }
                }

            }

            return result.OrderBy(mr => mr.StudentName)
                    .ThenBy(mr => mr.UniversityName)
                    .ThenBy(mr => mr.Rank).ToList();
        }

        /// <summary>
        /// Return a List<Student> which represents the students ordered by score (high to low).
        /// If there are students with equal Scores, then the oldest student should be given precedence.
        /// </summary>
        public static List<Student> RankStudentsByScore(List<Student> students)
        {
            var result = students.OrderByDescending(s => s.Score).ToList();
            result.ForEach(s => s.Preferences = RankStudentPreferenceByRank(s.Preferences));
            return result;
        }

        /// <summary>
        /// Return a List<StudentPreference> which represents a student's university preferences ordered by Rank (1 to 5)
        /// </summary>
        public static List<StudentPreference> RankStudentPreferenceByRank(List<StudentPreference> preferences)
        {
            return preferences.OrderBy(p => p.Rank).ToList();
        }
    }
}
