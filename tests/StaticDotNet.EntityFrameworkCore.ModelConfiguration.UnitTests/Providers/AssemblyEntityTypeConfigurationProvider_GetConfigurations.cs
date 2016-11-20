using NSubstitute;
using StaticDotNet.EntityFrameworkCore.ModelConfiguration.Internal;
using StaticDotNet.EntityFrameworkCore.ModelConfiguration.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.EntityFrameworkCore.ModelConfiguration.UnitTests.Providers
{
    public class AssemblyEntityTypeConfigurationProvider_GetConfigurations
    {
		[Fact]
		public void AssemblyEntityTypeConfigurationProvider_GetConfigurations_ReturnsCorrectly()
		{
			IEntityTypeConfiguration configuration = Substitute.For<IEntityTypeConfiguration>();

			Assembly[] assemblies =
			{
				configuration.GetType().GetTypeInfo().Assembly
			};

			IActivator activator = Substitute.For<IActivator>();

			activator.CreateInstance( configuration.GetType() )
				.Returns( configuration );

			AssemblyEntityTypeConfigurationProvider provider = new AssemblyEntityTypeConfigurationProvider( assemblies, activator );

			IEnumerable<IEntityTypeConfiguration> result = provider.GetConfigurations();

			Assert.Contains( result, x => x.GetType() == configuration.GetType() );
		}
    }
}
