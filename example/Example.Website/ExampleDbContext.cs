using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Website
{
    public class ExampleDbContext
		: DbContext
    {
		public ExampleDbContext( DbContextOptions<ExampleDbContext> options )
			: base( options )
		{ }
    }
}
