using Microsoft.EntityFrameworkCore;
using NSubstitute;
using StaticDotNet.EntityFrameworkCore.ModelConfiguration.Infrastructure;
using StaticDotNet.EntityFrameworkCore.ModelConfiguration.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.EntityFrameworkCore.ModelConfiguration.UnitTests
{
    public class DbContextOptionsBuilderExtensions_AddEntityTypeConfigurations
    {
		[Fact]
		public void DbContextOptionsBuilderExtensions_AddEntityTypeConfigurationsWithTContext_WithAssembliesReturnsCorrectly()
		{
			Assembly[] assemblies = Array.Empty<Assembly>();

			DbContextOptionsBuilder<DbContext> builder = new DbContextOptionsBuilder<DbContext>();

			builder.AddEntityTypeConfigurations( assemblies );

			EntityTypeConfigurationOptionsExtension optionsExtension = builder.Options.FindExtension<EntityTypeConfigurationOptionsExtension>();

			Assert.NotNull( optionsExtension );

			AssemblyEntityTypeConfigurationProvider provider = optionsExtension.Provider as AssemblyEntityTypeConfigurationProvider;
			Assert.NotNull( provider );
			Assert.Same( assemblies, provider.Assemblies );
		}

		[Fact]
		public void DbContextOptionsBuilderExtensions_AddEntityTypeConfigurationsWithTContext_WithNullAssembliesThrowsArgumentNullException()
		{
			Assembly[] assemblies = null;

			DbContextOptionsBuilder<DbContext> builder = new DbContextOptionsBuilder<DbContext>();

			Assert.Throws<ArgumentNullException>( nameof( assemblies ), () => builder.AddEntityTypeConfigurations( assemblies ) );
		}

		[Fact]
		public void DbContextOptionsBuilderExtensions_AddEntityTypeConfigurationsWithTContext_WithProviderReturnsCorrectly()
		{
			IEntityTypeConfigurationProvider provider = Substitute.For<IEntityTypeConfigurationProvider>();

			DbContextOptionsBuilder<DbContext> builder = new DbContextOptionsBuilder<DbContext>();

			builder.AddEntityTypeConfigurations( provider );

			EntityTypeConfigurationOptionsExtension optionsExtension = builder.Options.FindExtension<EntityTypeConfigurationOptionsExtension>();

			Assert.NotNull( optionsExtension );
			Assert.Same( provider, optionsExtension.Provider );
		}

		[Fact]
		public void DbContextOptionsBuilderExtensions_AddEntityTypeConfigurationsWithTContext_WithNullProviderThrowsArgumentNullException()
		{
			IEntityTypeConfigurationProvider provider = null;

			DbContextOptionsBuilder<DbContext> builder = new DbContextOptionsBuilder<DbContext>();

			Assert.Throws<ArgumentNullException>( nameof( provider ), () => builder.AddEntityTypeConfigurations( provider ) );
		}

		[Fact]
		public void DbContextOptionsBuilderExtensions_AddEntityTypeConfigurations_WithAssembliesReturnsCorrectly()
		{
			Assembly[] assemblies = Array.Empty<Assembly>();

			DbContextOptionsBuilder builder = new DbContextOptionsBuilder();

			builder.AddEntityTypeConfigurations( assemblies );

			EntityTypeConfigurationOptionsExtension optionsExtension = builder.Options.FindExtension<EntityTypeConfigurationOptionsExtension>();

			Assert.NotNull( optionsExtension );

			AssemblyEntityTypeConfigurationProvider provider = optionsExtension.Provider as AssemblyEntityTypeConfigurationProvider;
			Assert.NotNull( provider );
			Assert.Same( assemblies, provider.Assemblies );
		}

		[Fact]
		public void DbContextOptionsBuilderExtensions_AddEntityTypeConfigurations_WithNullAssembliesThrowsArgumentNullException()
		{
			Assembly[] assemblies = null;

			DbContextOptionsBuilder builder = new DbContextOptionsBuilder();

			Assert.Throws<ArgumentNullException>( nameof( assemblies ), () => builder.AddEntityTypeConfigurations( assemblies ) );
		}

		[Fact]
		public void DbContextOptionsBuilderExtensions_AddEntityTypeConfigurations_WithProviderReturnsCorrectly()
		{
			IEntityTypeConfigurationProvider provider = Substitute.For<IEntityTypeConfigurationProvider>();

			DbContextOptionsBuilder builder = new DbContextOptionsBuilder();

			builder.AddEntityTypeConfigurations( provider );

			EntityTypeConfigurationOptionsExtension optionsExtension = builder.Options.FindExtension<EntityTypeConfigurationOptionsExtension>();

			Assert.NotNull( optionsExtension );
			Assert.Same( provider, optionsExtension.Provider );
		}

		[Fact]
		public void DbContextOptionsBuilderExtensions_AddEntityTypeConfigurations_WithNullProviderThrowsArgumentNullException()
		{
			IEntityTypeConfigurationProvider provider = null;

			DbContextOptionsBuilder builder = new DbContextOptionsBuilder();

			Assert.Throws<ArgumentNullException>( nameof( provider ), () => builder.AddEntityTypeConfigurations( provider ) );
		}
	}
}
