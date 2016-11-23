# StaticDotNet.EntityFrameworkCore.ModelConfiguration

StaticDotNet.EntityFrameworkCore.ModelConfiguration provides a way to configure entities outside of DbContext.OnModelCreating without having to add custom code to your DbContext.

## Supported Platforms
* .NET Core (.NET Standard 1.3 and higher)
* 4.5.1 .NET Framework

## Installation

Installation is done via NuGet:

    Install-Package StaticDotNet.EntityFrameworkCore.ModelConfiguration

## Usage

### Entity Type Configuration Class

Add a class that implements `StaticDotNet.EntityFrameworkCore.ModelConfiguration.EntityTypeConfiguration<TEntity>` to your project where `TEntity` is the entity you want to configure and override the `Configure` method.

```csharp
using StaticDotNet.EntityFrameworkCore.ModelConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ExampleEntityConfiguration
	: EntityTypeConfiguration<ExampleEntity>
{
	public override void Configure( EntityTypeBuilder<ExampleEntity> builder )
	{
		//Add configuration just like you do in DbContext.OnModelCreating
	}
}
```

### Startup Class

Use the extension method provided to let Entity Framework know that you want to configure entities using the Entity Type Configurations.

#### Adding Configurations from Assemblies

```csharp
using StaticDotNet.EntityFrameworkCore.ModelConfiguration;

public void ConfigureServices(IServiceCollection services)
{
	Assembly[] assemblies = new Assembly[]
	{
		// Add your assembiles here.
	};

	services.AddDbContext<ExampleDbContext>( x => x
		.AddEntityTypeConfigurations( assemblies )
	);
}
```

#### Adding Configurations using a Provider

Create a class that implements `StaticDotNet.EntityFrameworkCore.ModelConfiguration.Providers.IEntityTypeConfigurationProvider` and implement the `IEntityTypeConfigurationProvider.GetConfigurations` method to return an `IEnumerable<IEntityTypeConfiguration>`.

```csharp
public void ConfigureServices(IServiceCollection services)
{
	IEntityTypeConfigurationProvider provider = new MyEntityTypeConfigurationProvider();

	services.AddDbContext<ExampleDbContext>( x => x
		.AddEntityTypeConfigurations( provider )
	);
}
```

## How it Works

You don't have to add any custom code to your DbContext. The library replaces the `Microsoft.EntityFrameworkCore.Infrastructure.IModelCustomizer' implementation with it's own.

Here is the order in which configurations are run:
* EntityTypeConfigurations
* DbContext.OnModelCreating

If you would like to control the order in which EntityTypeConfigurations are run, please implement a provider where you can have fine grain control over the order.