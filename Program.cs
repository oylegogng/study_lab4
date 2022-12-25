using System;

namespace lab1
{

    

    enum Education
    {
        Specialist,
        Bachelor,
        SecondEducation
    }

   

    
    class Program
    {
        static void Main(string[] args)
        {
            KeySelector<String> selector = st => st.GetHashCode().ToString();
            StudentCollection<string> stCollection = new StudentCollection<string>(selector);
            stCollection.CollectionName = "Student Collection";

            StudentVol2 s1 = new StudentVol2();
            StudentVol2 s2 = new StudentVol2("oleg", "terehov", new DateTime(2004, 1, 19), Education.Bachelor, 23, new List<Test>(), new List<Exam>());
            StudentVol2 s3 = new StudentVol2("petya", "brakak", new DateTime(2001, 11, 3), Education.Specialist, 11, new List<Test>(), new List<Exam>());

            Journal journal = new Journal();
            // changes in collections
            stCollection.StudentChanged += journal.NewEntryForCollection;

            // changes in properties
            //m1.PropertyChanged += listener.NewEntryForProperty;
            //m2.PropertyChanged += listener.NewEntryForProperty;

            // 1. Add new elements
            stCollection.AddStudent(s1);
            stCollection.AddStudent(s2);

            // 2. Change elements properties
            s1.Name = "OLEG!!";
            s1.Surname = "TEREHOV";

            // 3. Replacing element
            stCollection.Remove(s2);

            // 4. Change properties of excluded element
            s2.Name = "change";

            Console.WriteLine("\n\n             Changes:\n");
            Console.WriteLine(journal);
        }
    }
}
