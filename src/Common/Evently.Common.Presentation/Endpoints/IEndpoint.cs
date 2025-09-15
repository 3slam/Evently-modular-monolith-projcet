

using Microsoft.AspNetCore.Routing;

namespace Evently.Common.Presentation.Endpoints;

public interface IEndpoint
{
   void Map(IEndpointRouteBuilder app);
}