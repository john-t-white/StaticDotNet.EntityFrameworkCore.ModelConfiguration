using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Website.Controllers
{
	[Route( "Example" )]
    public class ExampleController
		: Controller
    {
		public ExampleController( ExampleDbContext dbContext )
		{
			this.DbContext = dbContext;
		}

		public ExampleDbContext DbContext { get; }

		public IActionResult Index()
		{
			IEntityType exampleEntityType = this.DbContext.Model.FindEntityType( typeof( ExampleEntity ) );

			IProperty exampleNameProperty = exampleEntityType.FindProperty( "Name" );

			return this.View( exampleNameProperty );
		}
    }
}
