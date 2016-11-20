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
    public class AssemblyEntityTypeConfigurationProvider_ctor
    {
		[Fact]
		public void AssemblyEntityTypeConfigurationProvider_ctor_InitializesCorrectly()
		{
			Assembly[] assemblies = Array.Empty<Assembly>();

			AssemblyEntityTypeConfigurationProvider provider = new AssemblyEntityTypeConfigurationProvider( assemblies );

			Assert.Same( assemblies, provider.Assemblies );
			Assert.IsType<ActivatorWrapper>( provider.Activator );
		}

		[Fact]
		public void AssemblyEntityTypeConfigurationProvider_ctor_WithNullAssembliesThrowsArgumentNullException()
		{
			Assembly[] assemblies = null;

			Assert.Throws<ArgumentNullException>( nameof( assemblies ), () => new AssemblyEntityTypeConfigurationProvider( assemblies ) );
		}
	}
}
