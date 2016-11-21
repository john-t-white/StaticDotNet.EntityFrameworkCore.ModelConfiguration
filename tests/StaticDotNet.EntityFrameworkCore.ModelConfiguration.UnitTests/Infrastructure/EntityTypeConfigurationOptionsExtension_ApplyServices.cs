using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
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
    public class EntityTypeConfigurationOptionsExtension_ApplyServices
    {
		[Fact]
		public void EntityTypeConfigurationOptionsExtension_ApplyServices_InvokesCorrectly()
		{
			IServiceCollection services = new ServiceCollection();

			services.AddSingleton<IModelCustomizer>( Substitute.For<IModelCustomizer>() );

			EntityTypeConfigurationOptionsExtension optionsExtension = new EntityTypeConfigurationOptionsExtension( Substitute.For<IEntityTypeConfigurationProvider>() );

			optionsExtension.ApplyServices( services );

			ServiceDescriptor modelCustomerizerServiceDescriptor = services.First( x => x.ServiceType == typeof( IModelCustomizer ) );
			Assert.Equal( typeof( EntityTypeConfigurationModelCustomizer ), modelCustomerizerServiceDescriptor.ImplementationType );
			Assert.Equal( ServiceLifetime.Singleton, modelCustomerizerServiceDescriptor.Lifetime );

			ServiceDescriptor providerServiceDescriptor = services.First( x => x.ServiceType == typeof( IEntityTypeConfigurationProvider ) );
			Assert.Equal( optionsExtension.Provider, providerServiceDescriptor.ImplementationInstance );
			Assert.Equal( ServiceLifetime.Singleton, providerServiceDescriptor.Lifetime );
		}
    }
}
