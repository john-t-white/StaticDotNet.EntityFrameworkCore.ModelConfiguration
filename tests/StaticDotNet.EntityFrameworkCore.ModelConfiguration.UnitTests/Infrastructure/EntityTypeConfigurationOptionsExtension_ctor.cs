using NSubstitute;
using StaticDotNet.EntityFrameworkCore.ModelConfiguration.Infrastructure;
using StaticDotNet.EntityFrameworkCore.ModelConfiguration.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.EntityFrameworkCore.ModelConfiguration.UnitTests.Infrastructure
{
    public class EntityTypeConfigurationOptionsExtension_ctor
    {
		[Fact]
		public void EntityTypeConfigurationOptionsExtension_ctor_InitializesCorrectly()
		{
			IEntityTypeConfigurationProvider provider = Substitute.For<IEntityTypeConfigurationProvider>();

			EntityTypeConfigurationOptionsExtension optionsExtension = new EntityTypeConfigurationOptionsExtension( provider );

			Assert.Same( provider, optionsExtension.Provider );
		}

		[Fact]
		public void EntityTypeConfigurationOptionsExtension_ctor_WithNullProviderThrowsArgumentNullException()
		{
			IEntityTypeConfigurationProvider provider = null;

			Assert.Throws<ArgumentNullException>( nameof( provider ), () => new EntityTypeConfigurationOptionsExtension( provider ) );
		}
	}
}
