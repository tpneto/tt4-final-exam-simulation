using Backend.Data;
using Backend.Models;  // Ajuste se necessário
using Microsoft.EntityFrameworkCore;

public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        // Verifica se a tabela de Tarefas já contém dados, evitando duplicações
        if (!context.Tasks.Any())
        {
            // Adiciona 10 tarefas de exemplo
            var tasks = new List<TaskItem>
            {
                new TaskItem { Title = "Task 1", Description = "First task description", Completed = false },
                new TaskItem { Title = "Task 2", Description = "Second task description", Completed = false },
                new TaskItem { Title = "Task 3", Description = "Third task description", Completed = true },
                new TaskItem { Title = "Task 4", Description = "Fourth task description", Completed = false },
                new TaskItem { Title = "Task 5", Description = "Fifth task description", Completed = false },
                new TaskItem { Title = "Task 6", Description = "Sixth task description", Completed = true },
                new TaskItem { Title = "Task 7", Description = "Seventh task description", Completed = false },
                new TaskItem { Title = "Task 8", Description = "Eighth task description", Completed = true },
                new TaskItem { Title = "Task 9", Description = "Ninth task description", Completed = false },
                new TaskItem { Title = "Task 10", Description = "Tenth task description", Completed = false }
            };

            context.Tasks.AddRange(tasks);
            context.SaveChanges();
        }
    }
}
