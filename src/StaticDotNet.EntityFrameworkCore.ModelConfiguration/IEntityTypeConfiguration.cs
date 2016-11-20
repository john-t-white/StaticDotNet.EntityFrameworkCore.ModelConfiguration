using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaticDotNet.EntityFrameworkCore.ModelConfiguration
{
    public interface IEntityTypeConfiguration
    {
		Type EntityType { get; }

		void Configure( EntityTypeBuilder builder );
    }
}
