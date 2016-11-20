using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaticDotNet.EntityFrameworkCore.ModelConfiguration.Providers
{
	/// <summary>
	/// Responsible for getting a collection of <see cref="IEntityTypeConfiguration" />.
	/// </summary>
	public interface IEntityTypeConfigurationProvider
    {
		/// <summary>
		/// Returns a collection of <see cref="IEntityTypeConfiguration" />.
		/// </summary>
		/// <returns>A collection of <see cref="IEntityTypeConfiguration" />.</returns>
		IEnumerable<IEntityTypeConfiguration> GetConfigurations();
    }
}
