using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;

namespace MatchingAlgorithm.Tests
{
    [TestFixture]
    public class MatchingTest
    {
        [Test, Description("Rank Students By Score")]
        public static void Students_ranked_by_score()
        {
            var RankedStudentData = "[{\"StudentName\":\"Alan Summer\",\"Score\":24,\"Age\":20,\"Preferences\":[{\"University\":\"Bristol\",\"Rank\":1},{\"University\":\"York\",\"Rank\":2},{\"University\":\"Cambridge\",\"Rank\":3},{\"University\":\"Oxford\",\"Rank\":4},{\"University\":\"Newcastle\",\"Rank\":5}]},{\"StudentName\":\"Freddie True\",\"Score\":21,\"Age\":49,\"Preferences\":[{\"University\":\"Newcastle\",\"Rank\":1},{\"University\":\"York\",\"Rank\":2},{\"University\":\"Cambridge\",\"Rank\":3},{\"University\":\"Oxford\",\"Rank\":4},{\"University\":\"Bristol\",\"Rank\":5}]},{\"StudentName\":\"Fred Bloggs\",\"Score\":13,\"Age\":35,\"Preferences\":[{\"University\":\"York\",\"Rank\":1},{\"University\":\"Bristol\",\"Rank\":2},{\"University\":\"Oxford\",\"Rank\":3},{\"University\":\"Cambridge\",\"Rank\":4},{\"University\":\"Newcastle\",\"Rank\":5}]},{\"StudentName\":\"Bot Trotter\",\"Score\":12,\"Age\":55,\"Preferences\":[{\"University\":\"Cambridge\",\"Rank\":1},{\"University\":\"York\",\"Rank\":2},{\"University\":\"Bristol\",\"Rank\":3},{\"University\":\"Oxford\",\"Rank\":4},{\"University\":\"Newcastle\",\"Rank\":5}]},{\"StudentName\":\"Boaty Boatface\",\"Score\":12,\"Age\":34,\"Preferences\":[{\"University\":\"Cambridge\",\"Rank\":1},{\"University\":\"York\",\"Rank\":2},{\"University\":\"Bristol\",\"Rank\":3},{\"University\":\"Oxford\",\"Rank\":4},{\"University\":\"Newcastle\",\"Rank\":5}]},{\"StudentName\":\"Mick Roberts\",\"Score\":11,\"Age\":33,\"Preferences\":[{\"University\":\"Newcastle\",\"Rank\":1},{\"University\":\"York\",\"Rank\":2},{\"University\":\"Cambridge\",\"Rank\":3},{\"University\":\"Oxford\",\"Rank\":4},{\"University\":\"Bristol\",\"Rank\":5}]},{\"StudentName\":\"Chris Cole\",\"Score\":10,\"Age\":18,\"Preferences\":[{\"University\":\"York\",\"Rank\":1},{\"University\":\"Oxford\",\"Rank\":2},{\"University\":\"Bristol\",\"Rank\":3},{\"University\":\"Newcastle\",\"Rank\":4},{\"University\":\"Cambridge\",\"Rank\":5}]},{\"StudentName\":\"Bernard Henry\",\"Score\":9,\"Age\":21,\"Preferences\":[{\"University\":\"Newcastle\",\"Rank\":1},{\"University\":\"York\",\"Rank\":2},{\"University\":\"Cambridge\",\"Rank\":3},{\"University\":\"Oxford\",\"Rank\":4},{\"University\":\"Bristol\",\"Rank\":5}]},{\"StudentName\":\"John Smith\",\"Score\":8,\"Age\":18,\"Preferences\":[{\"University\":\"Bristol\",\"Rank\":1},{\"University\":\"Oxford\",\"Rank\":2},{\"University\":\"York\",\"Rank\":3},{\"University\":\"Newcastle\",\"Rank\":4},{\"University\":\"Cambridge\",\"Rank\":5}]},{\"StudentName\":\"Jane Dowie\",\"Score\":7,\"Age\":44,\"Preferences\":[{\"University\":\"Bristol\",\"Rank\":1},{\"University\":\"Oxford\",\"Rank\":2},{\"University\":\"York\",\"Rank\":3},{\"University\":\"Newcastle\",\"Rank\":4},{\"University\":\"Cambridge\",\"Rank\":5}]},{\"StudentName\":\"Cocco Bobmin\",\"Score\":7,\"Age\":33,\"Preferences\":[{\"University\":\"Bristol\",\"Rank\":1},{\"University\":\"Oxford\",\"Rank\":2},{\"University\":\"York\",\"Rank\":3},{\"University\":\"Newcastle\",\"Rank\":4},{\"University\":\"Cambridge\",\"Rank\":5}]},{\"StudentName\":\"Nikki Jobs\",\"Score\":6,\"Age\":45,\"Preferences\":[{\"University\":\"York\",\"Rank\":1},{\"University\":\"Oxford\",\"Rank\":2},{\"University\":\"Bristol\",\"Rank\":3},{\"University\":\"Newcastle\",\"Rank\":4},{\"University\":\"Cambridge\",\"Rank\":5}]},{\"StudentName\":\"Seb Cole\",\"Score\":6,\"Age\":39,\"Preferences\":[{\"University\":\"York\",\"Rank\":1},{\"University\":\"Oxford\",\"Rank\":2},{\"University\":\"Bristol\",\"Rank\":3},{\"University\":\"Newcastle\",\"Rank\":4},{\"University\":\"Cambridge\",\"Rank\":5}]},{\"StudentName\":\"Chris Brown\",\"Score\":5,\"Age\":31,\"Preferences\":[{\"University\":\"Bristol\",\"Rank\":1},{\"University\":\"York\",\"Rank\":2},{\"University\":\"Cambridge\",\"Rank\":3},{\"University\":\"Oxford\",\"Rank\":4},{\"University\":\"Newcastle\",\"Rank\":5}]},{\"StudentName\":\"Mike Jones\",\"Score\":4,\"Age\":21,\"Preferences\":[{\"University\":\"Bristol\",\"Rank\":1},{\"University\":\"York\",\"Rank\":2},{\"University\":\"Cambridge\",\"Rank\":3},{\"University\":\"Oxford\",\"Rank\":4},{\"University\":\"Newcastle\",\"Rank\":5}]},{\"StudentName\":\"Herbert Herbert\",\"Score\":3,\"Age\":24,\"Preferences\":[{\"University\":\"York\",\"Rank\":1},{\"University\":\"Bristol\",\"Rank\":2},{\"University\":\"Oxford\",\"Rank\":3},{\"University\":\"Cambridge\",\"Rank\":4},{\"University\":\"Newcastle\",\"Rank\":5}]},{\"StudentName\":\"Jonny McVie\",\"Score\":2,\"Age\":21,\"Preferences\":[{\"University\":\"Cambridge\",\"Rank\":1},{\"University\":\"York\",\"Rank\":2},{\"University\":\"Bristol\",\"Rank\":3},{\"University\":\"Oxford\",\"Rank\":4},{\"University\":\"Newcastle\",\"Rank\":5}]},{\"StudentName\":\"Bob Fleming\",\"Score\":1,\"Age\":30,\"Preferences\":[{\"University\":\"York\",\"Rank\":1},{\"University\":\"Bristol\",\"Rank\":2},{\"University\":\"Oxford\",\"Rank\":3},{\"University\":\"Cambridge\",\"Rank\":4},{\"University\":\"Newcastle\",\"Rank\":5}]}]";
            var RankedStudents = JsonConvert.DeserializeObject<List<Student>>(RankedStudentData);

            Matching.PopulateData(out List<University> Universities, out List<Student> Students);
            var TestRankedStudents = Matching.RankStudentsByScore(Students);

            Assert.AreEqual(TestRankedStudents.Count, RankedStudents.Count, "Counts not equal");

            for (int i = 0; i < RankedStudents.Count; i++)
            {
                Assert.AreEqual(TestRankedStudents[i].StudentName, RankedStudents[i].StudentName, "Student name not equal");
                Assert.AreEqual(TestRankedStudents[i].Score, RankedStudents[i].Score, "Score not equal");
                Assert.AreEqual(TestRankedStudents[i].Age, RankedStudents[i].Age, "Age not equal");
            }
        }


        [Test, Description("Final Match results")]
        public static void Final_match_results()
        {
            var MatchResultsData = "[{\"StudentName\":\"Alan Summer\",\"UniversityName\":\"Bristol\",\"Rank\":1},{\"StudentName\":\"Freddie True\",\"UniversityName\":\"Newcastle\",\"Rank\":1},{\"StudentName\":\"Fred Bloggs\",\"UniversityName\":\"York\",\"Rank\":1},{\"StudentName\":\"Bot Trotter\",\"UniversityName\":\"Cambridge\",\"Rank\":1},{\"StudentName\":\"Boaty Boatface\",\"UniversityName\":\"Cambridge\",\"Rank\":1},{\"StudentName\":\"Mick Roberts\",\"UniversityName\":\"Newcastle\",\"Rank\":1},{\"StudentName\":\"Chris Cole\",\"UniversityName\":\"York\",\"Rank\":1},{\"StudentName\":\"Bernard Henry\",\"UniversityName\":\"Newcastle\",\"Rank\":1},{\"StudentName\":\"John Smith\",\"UniversityName\":\"Oxford\",\"Rank\":2},{\"StudentName\":\"Jane Dowie\",\"UniversityName\":\"York\",\"Rank\":3},{\"StudentName\":\"Cocco Bobmin\",\"UniversityName\":\"Newcastle\",\"Rank\":4},{\"StudentName\":\"Nikki Jobs\",\"UniversityName\":\"Newcastle\",\"Rank\":4},{\"StudentName\":\"Seb Cole\",\"UniversityName\":\"Cambridge\",\"Rank\":5},{\"StudentName\":\"Chris Brown\",\"UniversityName\":\"Cambridge\",\"Rank\":3},{\"StudentName\":\"Mike Jones\",\"UniversityName\":\"NotMatched\",\"Rank\":0},{\"StudentName\":\"Herbert Herbert\",\"UniversityName\":\"NotMatched\",\"Rank\":0},{\"StudentName\":\"Jonny McVie\",\"UniversityName\":\"NotMatched\",\"Rank\":0},{\"StudentName\":\"Bob Fleming\",\"UniversityName\":\"NotMatched\",\"Rank\":0}]";
            var SolutionMatchResults = JsonConvert.DeserializeObject<List<MatchResult>>(MatchResultsData);


            Matching.PopulateData(out List<University> Universities, out List<Student> Students);
            var FinalMatchResults = Matching.FinalMatchResults(Universities, Students);

            Assert.AreEqual(FinalMatchResults.Count, SolutionMatchResults.Count, "Counts not equal");

            for (int i = 0; i < SolutionMatchResults.Count; i++)
            {
                Assert.AreEqual(FinalMatchResults[i].StudentName, SolutionMatchResults[i].StudentName, "Student name not equal");
                Assert.AreEqual(FinalMatchResults[i].UniversityName, SolutionMatchResults[i].UniversityName, "University name not equal");
                Assert.AreEqual(FinalMatchResults[i].Rank, SolutionMatchResults[i].Rank, "Rank not equal");
            }
        }
    }
}
