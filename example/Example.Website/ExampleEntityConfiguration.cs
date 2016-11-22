using StaticDotNet.EntityFrameworkCore.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Website
{
	public class ExampleEntityConfiguration
		: EntityTypeConfiguration<ExampleEntity>
	{
		public override void Configure( EntityTypeBuilder<ExampleEntity> builder )
		{
			builder.HasKey( x => x.Id );

			builder.Property( x => x.Id )
				.ValueGeneratedOnAdd();

			builder.Property( x => x.Name )
				.HasMaxLength( 10 );
		}
	}
}
