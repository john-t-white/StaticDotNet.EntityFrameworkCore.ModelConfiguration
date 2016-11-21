using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using NSubstitute;
using StaticDotNet.EntityFrameworkCore.ModelConfiguration.Infrastructure;
using StaticDotNet.EntityFrameworkCore.ModelConfiguration.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StaticDotNet.EntityFrameworkCore.ModelConfiguration.UnitTests.Infrastructure
{
    public class EntityTypeConfigurationModelCustomizer_Customize
    {
		[Fact]
		public void EntityTypeConfigurationModelCustomizer_Customize_InvokesCorrectly()
		{
			ModelBuilder modelBuilder = new ModelBuilder( new ConventionSet() );
			DbContext dbContext = Substitute.For<DbContext>();

			IEntityTypeConfigurationProvider provider = Substitute.For<IEntityTypeConfigurationProvider>();

			StringEntityTypeConfiguration stringEntityTypeConfiguration = new StringEntityTypeConfiguration();
			ObjectEntityTypeConfiguration objectEntityTypeConfiguration = new ObjectEntityTypeConfiguration();

			IEntityTypeConfiguration[] configurations = new IEntityTypeConfiguration[]
			{
				stringEntityTypeConfiguration,
				objectEntityTypeConfiguration
			};

			provider.GetConfigurations()
				.Returns( configurations );

			EntityTypeConfigurationModelCustomizer modelCustomizer = new EntityTypeConfigurationModelCustomizer( provider );

			modelCustomizer.Customize( modelBuilder, dbContext );

			Assert.True( stringEntityTypeConfiguration.ConfigureExecuted );
			Assert.True( objectEntityTypeConfiguration.ConfigureExecuted );
		}
	}

	#region Test Classes

	public class StringEntityTypeConfiguration
		: EntityTypeConfiguration<string>
	{
		public bool ConfigureExecuted { get; private set; }

		public override void Configure( EntityTypeBuilder<string> builder )
		{
			this.ConfigureExecuted = true;
		}
	}

	public class ObjectEntityTypeConfiguration
		: EntityTypeConfiguration<object>
	{
		public bool ConfigureExecuted { get; private set; }

		public override void Configure( EntityTypeBuilder<object> builder )
		{
			this.ConfigureExecuted = true;
		}
	}

	#endregion
}
