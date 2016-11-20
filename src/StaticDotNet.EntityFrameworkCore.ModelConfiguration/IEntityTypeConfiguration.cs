using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaticDotNet.EntityFrameworkCore.ModelConfiguration
{
	/// <summary>
	/// Responsible for configuring an entity.
	/// </summary>
	public interface IEntityTypeConfiguration
    {
		/// <summary>
		/// Gets the type of entity to configure.
		/// </summary>
		Type EntityType { get; }

		/// <summary>
		/// Configures the entity.
		/// </summary>
		/// <param name="builder">The builder used to configure the entity.</param>
		void Configure( EntityTypeBuilder builder );
    }
}
