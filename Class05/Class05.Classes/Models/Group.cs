//alt i enter trga
namespace Class05.Classes.Models
{
    internal class Group
    {
        public string GroupName { get; set; }
        public int NumberOfStudents { get; set; }
        public string CurrentSubjectName { get; set; }

        public Group(string groupName, int numOfStudents,string currentSubjectName)
        {
            //property=parametar;
            
            GroupName = groupName;
            NumberOfStudents = numOfStudents;
            CurrentSubjectName = currentSubjectName;
        }

        public Group()
        {

        }

        public void DisplayGroupInfo()
        {
            Console.WriteLine($"This is hroup {GroupName} with {NumberOfStudents} students.");
        }

    }
}
