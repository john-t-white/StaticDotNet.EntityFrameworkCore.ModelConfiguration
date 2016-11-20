using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaticDotNet.ParameterValidation;
using StaticDotNet.EntityFrameworkCore.ModelConfiguration.Extensions;

namespace StaticDotNet.EntityFrameworkCore.ModelConfiguration
{
	/// <summary>
	/// Class used to configure an entity.
	/// </summary>
	/// <typeparam name="TEntity">The the type of entity to configure.</typeparam>
	public abstract class EntityTypeConfiguration<TEntity>
		: IEntityTypeConfiguration
		where TEntity : class
	{
		/// <summary>
		/// Gets the type of entity to configure.
		/// </summary>
		public Type EntityType => typeof( TEntity );

		void IEntityTypeConfiguration.Configure( EntityTypeBuilder builder )
		{
			EntityTypeBuilder<TEntity> typedBuilder;

			Parameter.Validate( builder, nameof( builder ) )
				.IsNotNull()
				.IsForEntityType<TEntity>( out typedBuilder );

			this.Configure( typedBuilder );
		}

		/// <summary>
		/// Configures the entity.
		/// </summary>
		/// <param name="builder">The builder used to configure the entity.</param>
		public abstract void Configure( EntityTypeBuilder<TEntity> builder );
	}
}
