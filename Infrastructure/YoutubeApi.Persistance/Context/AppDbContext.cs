﻿using Microsoft.EntityFrameworkCore;
using System.Reflection;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Persistance.Context
{
	public class AppDbContext : DbContext
	{
		public AppDbContext() { }

		public AppDbContext(DbContextOptions options) : base(options) { }

		public DbSet<Brand> Brands { get; set; }
		public DbSet<Detail> Details { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  //oluşturduğumuz data seedlerin
																							//konfügrasyonunu burda bu şekilde
																							//veri tabanına belirtiyoruz
		}
	}
}
