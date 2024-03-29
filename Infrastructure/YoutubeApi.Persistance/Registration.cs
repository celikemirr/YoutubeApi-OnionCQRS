﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YoutubeApi.Application.Interfaces.IRepositories;
using YoutubeApi.Application.Interfaces.Repositories;
using YoutubeApi.Persistance.Context;
using YoutubeApi.Persistance.Repositories;

namespace YoutubeApi.Persistance
{
	public static class Registration
	{
		public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>(opt =>
			opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
			services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
		}
	}
}
