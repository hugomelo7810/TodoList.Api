using Microsoft.EntityFrameworkCore;
using System;
using TodoList.Api.Models;

namespace TodoList.Api.Data;

public class TodoListContext : DbContext
{
	public TodoListContext(DbContextOptions<TodoListContext> options)
		: base(options)
	{
	}

	public DbSet<ToDoTask> Tasks { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ToDoTask>(entity =>
		{
			entity.ToTable("tasks");

			entity.HasKey(task => task.Id);

			entity.Property(task => task.Id).HasColumnName("id");
			entity.Property(task => task.Title).HasColumnName("title");
			entity.Property(task => task.IsCompleted).HasColumnName("is_completed");
		});
	}
}
