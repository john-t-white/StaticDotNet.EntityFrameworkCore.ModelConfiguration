using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using StaticDotNet.EntityFrameworkCore.ModelConfiguration.Providers;
using StaticDotNet.ParameterValidation;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace StaticDotNet.EntityFrameworkCore.ModelConfiguration.Infrastructure
{
	/// <summary>
	/// The <see cref="IDbContextOptionsExtension" /> which configures the services neccessary to support configuring entities with <see cref="IEntityTypeConfiguration" />.
	/// </summary>
	public class EntityTypeConfigurationOptionsExtension
		: IDbContextOptionsExtension
	{
		/// <summary>
		/// Instantiates an instance of <see cref="EntityTypeConfigurationOptionsExtension" />.
		/// </summary>
		/// <param name="provider">The <see cref="IEntityTypeConfigurationProvider" />.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="provider" /> is null.</exception>
		public EntityTypeConfigurationOptionsExtension( IEntityTypeConfigurationProvider provider )
		{
			Parameter.Validate( provider, nameof( provider ) )
				.IsNotNull();

			this.Provider = provider;
		}

		/// <summary>
		/// Gets the <see cref="IEntityTypeConfigurationProvider" />.
		/// </summary>
		public IEntityTypeConfigurationProvider Provider { get; }

		/// <summary>
		/// Replaces the <see cref="IModelCustomizer" /> implementation with <see cref="EntityTypeConfigurationModelCustomizer" />
		/// and adds the <see cref="IEntityTypeConfigurationProvider" /> to the <paramref name="services" />.
		/// </summary>
		/// <param name="services">The collection to add services to.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="services" /> is null.</exception>
		public void ApplyServices( IServiceCollection services )
		{
			Parameter.Validate( services, nameof( services ) )
				.IsNotNull();

			ServiceDescriptor modelCustomizerServiceDescriptor = ServiceDescriptor.Singleton<IModelCustomizer, EntityTypeConfigurationModelCustomizer>();
			services.Replace( modelCustomizerServiceDescriptor );

			services.AddSingleton<IEntityTypeConfigurationProvider>( this.Provider );
		}
	}
}
