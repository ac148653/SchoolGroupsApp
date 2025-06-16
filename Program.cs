using System.Threading.Tasks.Dataflow;
using System.Transactions;
using Azure.Core;
using SchoolGroupsApp.Model;
using SchoolGroupsApp.Repositories;
using SchoolGroupsApp.View;

namespace SchoolGroupsApp
{
    internal class Program
    {
        private static StorageManager storageManager;
        private static ConsoleView view;

        static void Main(string[] args)
        {
            string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=SchoolGroupsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            storageManager = new StorageManager(connectionString);

            int loginChoice = view.LoginMenu();
            switch (loginChoice)
            {
                case 1:
                    {
                        
                    }
                case 2:
                    {

                    }
                case 3:
                    {

                    }
                case 4:
                    {
                        
                    }
            }

    
            view = new ConsoleView();
            string choice = view.DisplayMenu();

            switch (choice)
            {
                case "1":
                    {
                        List<Groups> groups = storageManager.GetAllGroups();
                        view.DisplayGroups(groups);
                    }
                    break;
                case "2":
                    UpdateGroupName();
                    break;
                case "3":
                   InsertNewGroup();
                    break;
                case "4":
                   DeleteGroupByName();
                    break;
                /*case "5":
                    exit = true;
                    break;*/
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            storageManager.CloseConnection();

        } 
        private static void UpdateGroupName()
        {
            view.DisplayMessage("Enter the groupId to update: ");
            int groupId = view.GetIntInput();
            view.DisplayMessage("Enter the new group name: ");
            string groupName = view.GetInput();
            int rowsAffected = storageManager.UpdateGroupName(groupId, groupName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }
        /*private static void InsertNewGroup()
        {
            view.DisplayMessage("Enter the new group name: ");
            string groupName = view.GetInput();
            int generateId = storageManager.InsertGroup(groupName);
            view.DisplayMessage($"New group inserted with ID: {generateId}");
        }*/
        private static void InsertNewGroup()
        {
            view.DisplayMessage("Enter the new group name: ");
            string groupName = view.GetInput();
            int groupID = 0;
            Groups group1 = new Groups(groupID, groupName);
            int generateId = storageManager.InsertGroup(group1);
            view.DisplayMessage($"New group inserted with ID: {generateId}");
            
        }

        private static void DeleteGroupByName()
        {
            view.DisplayMessage("Enter the group name to delete: ");
            string groupName = view.GetInput();
            int rowsAffected = storageManager.DeleteGroupByName(groupName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }
    }
}
