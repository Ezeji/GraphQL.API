using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API.GraphqlCore
{
    public class CountryRecordSchema : Schema
    {
        public CountryRecordSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<CountryRecordQuery>();
            Mutation = resolver.Resolve<CountryRecordMutation>();
        }
    }
}
