using System.Collections.Generic;

namespace MatchingAlgorithm
{
    /// <summary>
    /// Student class to hold information of a student and their university preferences
    /// </summary>
    public class Student
    {
        public string StudentName;
        public int Score;
        public int Age;
        public List<StudentPreference> Preferences;
    }
}
