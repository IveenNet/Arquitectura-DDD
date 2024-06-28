﻿using Microsoft.EntityFrameworkCore;
using Pacagroup.Ecommerce.Domain.Entities;
using Pacagroup.Ecommerce.Persistence.Interceptors;
using System.Reflection;

namespace Pacagroup.Ecommerce.Persistence.Contexts
{
	public class ApplicationDbContext : DbContext
	{

		public readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options) 
		{
			
			_auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;

		}

		public DbSet<Discount> Discounts { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Discount>().ToTable("Discount");

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{

			optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
			optionsBuilder.EnableSensitiveDataLogging();
			
		}

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			return await base.SaveChangesAsync(cancellationToken);
		}
	}
}
