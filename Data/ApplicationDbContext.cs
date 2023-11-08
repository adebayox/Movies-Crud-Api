﻿using System;
using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
		{

		}

		public DbSet<Movie> Movies { get; set; }

	}
}

