using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ResourceManagement.Data.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ResourceManagement.Data.Infrastructure
{
    public class DatabaseFactory : IDesignTimeDbContextFactory<ResourceManagementContext>
    {
        public ResourceManagementContext CreateDbContext(string[] args)
        {
            var connectionString = GetDefaultSolutionConnectionString(Directory.GetCurrentDirectory());

            var optionsBuilder = new DbContextOptionsBuilder<ResourceManagementContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ResourceManagementContext(optionsBuilder.Options);
        }

        private string GetDefaultSolutionConnectionString(string currentPath)
        {
            var solutionPath = GetSolutionPath(Directory.GetCurrentDirectory());
            var settingsPaths = GetSettingsPaths(solutionPath);
            var distinctConnectionStrings = new List<string>();
            foreach (var settingsPath in settingsPaths)
            {
                var connectionStrings = GetConnectionStringFromConfig(settingsPath);
                if (connectionStrings != null)
                    distinctConnectionStrings.AddRange(connectionStrings);
            }
            distinctConnectionStrings = distinctConnectionStrings.Where(x => !string.IsNullOrEmpty(x)).Distinct().ToList();
            switch (distinctConnectionStrings.Count())
            {
                case 0:
                    Console.WriteLine("No connection string found, insert one:");
                    return Console.ReadLine();
                case 1: return distinctConnectionStrings[0];
                default:
                    return GetUserInput(distinctConnectionStrings);
            }
        }

        private string GetUserInput(List<string> connectionStrings)
        {
            Console.WriteLine("Connection strings found:");
            for (int i = 0; i < connectionStrings.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {connectionStrings[i]}");
            }

            Console.WriteLine("Chose a connection string by inserting the number or enter a connection string");
            var userInput = Console.ReadLine();
            if (int.TryParse(userInput, out var option) && option > 0 && option <= connectionStrings.Count)
            {
                return connectionStrings[option];
            }

            return userInput;
        }

        private string GetSolutionPath(string startPath)
        {
            var paths = Directory.GetFiles(startPath, "*.sln", SearchOption.TopDirectoryOnly);
            if (paths.Length > 0)
                return startPath;
            return GetSolutionPath(Path.GetDirectoryName(startPath));
        }

        private string[] GetSettingsPaths(string solutionPath)
        {
            return Directory.GetFiles(solutionPath, "appsettings*.json", SearchOption.AllDirectories);
        }

        private List<string> GetConnectionStringFromConfig(string configPath)
        {
            var configuration = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(configPath));

            if (configuration["ConnectionStrings"] == null)
                return null;

            return configuration["ConnectionStrings"].Select(ax => (string)((JProperty)ax).Value).ToList();
        }
    }
}