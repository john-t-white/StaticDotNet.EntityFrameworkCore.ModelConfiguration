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
    public class EntityTypeConfigurationModelCustomizer_ctor
    {
		[Fact]
		public void EntityTypeConfigurationModelCustomizer_ctor_InitializesCorrectly()
		{
			IEntityTypeConfigurationProvider provider = Substitute.For<IEntityTypeConfigurationProvider>();

			EntityTypeConfigurationModelCustomizer modelCustomizer = new EntityTypeConfigurationModelCustomizer( provider );

			Assert.Same( provider, modelCustomizer.Provider );
		}

		[Fact]
		public void EntityTypeConfigurationModelCustomizer_ctor_WithNullProviderThrowsArugmentNullException()
		{
			IEntityTypeConfigurationProvider provider = null;

			Assert.Throws<ArgumentNullException>( nameof( provider ), () => new EntityTypeConfigurationModelCustomizer( provider ) );
		}
	}
}
