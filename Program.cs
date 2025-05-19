using SchoolGroupsApp.Repositories;

namespace SchoolGroupsApp
{
    internal class Program
    {
        private static StorageManager storageManager;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionString = "";
            storageManager = new StorageManager(connectionString);
        }
    }
}
