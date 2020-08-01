using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class TodoContextSeed
    {
        public static async Task SeedAsync(TodoContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Todos.Any())
                {
                    var data = File.ReadAllText("../Infrastructure/Data/SeedData/todos.json");
                    var items = JsonSerializer.Deserialize<List<TodoItem>>(data);
                    foreach (var item in items)
                    {
                        context.Todos.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                //todo : log the exception
                var logger = loggerFactory.CreateLogger<TodoContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}