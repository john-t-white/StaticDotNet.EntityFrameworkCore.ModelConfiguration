using Microsoft.EntityFrameworkCore.Infrastructure;
using StaticDotNet.EntityFrameworkCore.ModelConfiguration.Providers;
using StaticDotNet.ParameterValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StaticDotNet.EntityFrameworkCore.ModelConfiguration.Infrastructure
{
	/// <summary>
	/// Configures the entities by first getting the collection of <see cref="IEntityTypeConfiguration" /> from the <see cref="Provider" />.
	/// Then proceeds with the default implementation of <see cref="ModelCustomizer" />.
	/// </summary>
	public class EntityTypeConfigurationModelCustomizer
		: ModelCustomizer
    {
		/// <summary>
		/// Instantiates an instance of <see cref="EntityTypeConfigurationModelCustomizer" />.
		/// </summary>
		/// <param name="provider">The provider used to get the collection of <see cref="IEntityTypeConfiguration" />.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="provider" /> is null.</exception>
		public EntityTypeConfigurationModelCustomizer( IEntityTypeConfigurationProvider provider )
			: base()
		{
			Parameter.Validate( provider, nameof( provider ) )
				.IsNotNull();

			this.Provider = provider;
		}

		/// <summary>
		/// Returns the <see cref="IEntityTypeConfigurationProvider" />.
		/// </summary>
		public IEntityTypeConfigurationProvider Provider { get; }

		/// <summary>
		/// Configures the entities by first getting the collection of <see cref="IEntityTypeConfiguration" /> from the <see cref="Provider" />.
		/// Then proceeds with the default implementation of <see cref="ModelCustomizer" />.
		/// </summary>
		/// <param name="modelBuilder">The builder being used to construct the model.</param>
		/// <param name="dbContext">The context instance that the model is being created for.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="modelBuilder" /> or <paramref name="dbContext" /> is null.</exception>
		public override void Customize( ModelBuilder modelBuilder, DbContext dbContext )
		{
			Parameter.Validate( modelBuilder, nameof( modelBuilder ) )
				.IsNotNull();

			foreach( IEntityTypeConfiguration currentEntityTypeConfiguration in this.Provider.GetConfigurations() )
			{
				EntityTypeBuilder currentEntityTypeBuilder = modelBuilder.Entity( currentEntityTypeConfiguration.EntityType );
				currentEntityTypeConfiguration.Configure( currentEntityTypeBuilder );
			}

			base.Customize( modelBuilder, dbContext );
		}
	}
}
