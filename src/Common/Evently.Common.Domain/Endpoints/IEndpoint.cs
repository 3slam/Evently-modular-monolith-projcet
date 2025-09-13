

using Microsoft.AspNetCore.Routing;

namespace Evently.Common.Domain.Endpoints;

public interface IEndpoint
{
   void Map(IEndpointRouteBuilder app);
}