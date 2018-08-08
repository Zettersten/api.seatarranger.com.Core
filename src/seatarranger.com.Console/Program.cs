using Newtonsoft.Json;
using seatarranger.com.Core.Configurations;
using seatarranger.com.Core.Extensions;
using seatarranger.com.Core.Models;
using seatarranger.com.Core.Services.ArrangerService;
using System;
using System.IO;

namespace seatarranger.com.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("\n\n" +
                $"======================================\n" +
                $"= ByteCode Wedding Planner Challenge =\n" +
                $"======================================\n");

            System.Console.Write("Provide your input file (.json): ");
            var filePath = System.Console.ReadLine();

            System.Console.Write("Searching for file " + filePath);

            if (!File.Exists(filePath))
            {
                System.Console.Write("\nFile not found. Try again? (hit any key)");
                System.Console.ReadKey();
                System.Console.Clear();
                Main(args);
                return;
            }

            ArrangementInput inputModel; 

            try
            {
                inputModel = JsonConvert.DeserializeObject<ArrangementInput>(File.ReadAllText(filePath));
            }
            catch
            {
                System.Console.Write("\nCould not parse file. Was it the correct format? (hit any key to try again)");
                System.Console.Write("\n { 'tables': [{ 'capacity': 2, 'id': 'A' }], 'parties': [{ 'size': 2, 'name': 'Erik' }] }");
                System.Console.ReadKey();
                System.Console.Clear();
                Main(args);
                return;
            }

            var arrangmentService = new ArrangerService();
            var resultingJson = string.Empty;

            try
            {
                var result = arrangmentService
                    .ArrangeParties(inputModel.Parties, inputModel.Tables);

                resultingJson = JsonConvert.SerializeObject(result.ToJson(), Formatting.Indented, JsonConfiguration.GetSerializerSettings());
            }
            catch (Exception ex)
            {
                System.Console.Write("\n" + ex.Message + " (press any key to try again)");
                System.Console.ReadKey();
                System.Console.Clear();
                Main(args);
                return;
            }

            System.Console.Write("\n" + "Result: \n" + resultingJson);
            System.Console.Write("\nTry again (press any key)?");
            System.Console.ReadKey();
            System.Console.Clear();
            Main(args);
            return;
        }
    }
}
