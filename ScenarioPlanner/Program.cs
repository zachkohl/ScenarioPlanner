using System;
using ScenarioPlanner;
namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the scenario planner tool");
            Console.WriteLine("Please enter your life roles, seperated by a comma (,)");

            string roleString = Console.ReadLine()!;

            if (roleString == null)
            {
                throw new Exception("must pass in at least one role. Please restart the program and try again");
            }

            Console.WriteLine("Please enter scenarios you see yourself facing. Once again please seperate with a comma (,)");

            string scenarioString = Console.ReadLine()!;

            if (scenarioString == null)
            {
                throw new Exception("must pass in at least one scenario. Please restart the program and try again");
            }

            Console.WriteLine("Please enter the timeframes you would like to organize by. Seperated once again by a comma (,)");




            string timeframeString = Console.ReadLine()!;

            if (timeframeString == null)
            {
                throw new Exception("must pass in at least one timeframe. Please restart the program and try again");
            }

            ScenarioPlannerService myScenarioPlannerService = new ScenarioPlannerService();
            myScenarioPlannerService.addRoles(roleString);
            myScenarioPlannerService.addScenarios(scenarioString);
            myScenarioPlannerService.addTimeFrames(timeframeString);

            string table = myScenarioPlannerService.getTable();

            Console.Write(table);
            while (true)
            {

            }


        }
    }
}