using LINQToObjectsAndQueryOperators;

internal class Program
{
    private static void Main(string[] args)
    {
        UniversityManager universityManager = new UniversityManager();
        universityManager.MaleStudents();
        universityManager.SortedStudentsByAge();
        universityManager.AllStudentsFromSapienza();
        universityManager.AllStudentsFromThatUniversity(2);
  
        
        Console.WriteLine("Insert University Id: ");
        string input = Console.ReadLine();
      
        try 
        { 
        int inputAsInt = Convert.ToInt32(input);

        

        universityManager.AllStudentsFromThatUniversity(inputAsInt);

        }
        catch (Exception)
        {

            Console.WriteLine("Wrong value");

        }

        universityManager.StudentAndUniversityNameCollection();

        Console.ReadKey();

    }
}

