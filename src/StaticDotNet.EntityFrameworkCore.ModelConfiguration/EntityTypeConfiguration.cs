using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaticDotNet.ParameterValidation;
using StaticDotNet.EntityFrameworkCore.ModelConfiguration.Extensions;

namespace StaticDotNet.EntityFrameworkCore.ModelConfiguration
{
	public abstract class EntityTypeConfiguration<TEntity>
		: IEntityTypeConfiguration
		where TEntity : class
	{
		public Type EntityType => typeof( TEntity );

		void IEntityTypeConfiguration.Configure( EntityTypeBuilder builder )
		{
			EntityTypeBuilder<TEntity> typedBuilder;

			Parameter.Validate( builder, nameof( builder ) )
				.IsNotNull()
				.IsForEntityType<TEntity>( out typedBuilder );

			this.Configure( typedBuilder );
		}

		public abstract void Configure( EntityTypeBuilder<TEntity> builder );
	}
}
