using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using StaticDotNet.EntityFrameworkCore.ModelConfiguration.Infrastructure;
using StaticDotNet.EntityFrameworkCore.ModelConfiguration.Providers;
using StaticDotNet.ParameterValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace StaticDotNet.EntityFrameworkCore.ModelConfiguration
{
	/// <summary>
	/// Adds methods to <see cref="DbContextOptionsBuilder" /> to add support for <see cref="IEntityTypeConfiguration" />.
	/// </summary>
	public static class DbContextOptionsBuilderExtensions
	{
		/// <summary>
		/// Adds <see cref="IEntityTypeConfiguration" /> from all of the <paramref name="assemblies" /> specified.
		/// </summary>
		/// <param name="builder">The builder.</param>
		/// <param name="assemblies">The assemblies to search for <see cref="IEntityTypeConfiguration" />.</param>
		/// <returns>The builder.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="assemblies" /> is null.</exception>
		public static DbContextOptionsBuilder AddEntityTypeConfigurations( this DbContextOptionsBuilder builder, params Assembly[] assemblies )
		{
			Parameter.Validate( assemblies, nameof( assemblies ) )
				.IsNotNull();

			AssemblyEntityTypeConfigurationProvider provider = new AssemblyEntityTypeConfigurationProvider( assemblies );

			return builder.AddEntityTypeConfigurations( provider );
		}

		/// <summary>
		/// Adds <see cref="IEntityTypeConfiguration" /> base on the <paramref name="provider" />.
		/// </summary>
		/// <param name="builder">The builder.</param>
		/// <param name="provider">The <see cref="IEntityTypeConfigurationProvider" />.</param>
		/// <returns>The builder.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="provider" /> is null.</exception>
		public static DbContextOptionsBuilder AddEntityTypeConfigurations( this DbContextOptionsBuilder builder, IEntityTypeConfigurationProvider provider )
		{
			Parameter.Validate( builder, nameof( builder ) )
				.IsNotNull();

			Parameter.Validate( provider, nameof( provider ) )
				.IsNotNull();

			EntityTypeConfigurationOptionsExtension optionsExtension = new EntityTypeConfigurationOptionsExtension( provider );

			( ( IDbContextOptionsBuilderInfrastructure )builder ).AddOrUpdateExtension( optionsExtension );

			return builder;
		}
	}
}
