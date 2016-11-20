using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StaticDotNet.EntityFrameworkCore.ModelConfiguration.Resources;
using StaticDotNet.ParameterValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaticDotNet.EntityFrameworkCore.ModelConfiguration.Extensions
{
    public static class ParameterValidatorExtensions
    {
		public static ParameterValidator<EntityTypeBuilder> IsForEntityType<TEntity>( this ParameterValidator<EntityTypeBuilder> validator, out EntityTypeBuilder<TEntity> entityTypeBuilder )
			where TEntity : class
		{
			EntityTypeBuilder parameterValue = validator.Value;
			if( parameterValue != null && parameterValue.Metadata.ClrType != typeof( TEntity ) )
			{
				string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_BE_FOR_ENTITY_TYPE, parameterValue.Metadata.ClrType.FullName );
				throw new ArgumentException( validator.Name, exceptionMessage );
			}

			InternalEntityTypeBuilder internalEntityTypeBuilder = ( ( IInfrastructure<InternalEntityTypeBuilder> )parameterValue ).Instance;

			entityTypeBuilder = new EntityTypeBuilder<TEntity>( internalEntityTypeBuilder );

			return validator;
		}
    }
}
