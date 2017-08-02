using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

using Swashbuckle.Examples;
using Swashbuckle.Swagger.Annotations;

using SwashbuckleAspNetTipsSample.ApiApp.Examples;
using SwashbuckleAspNetTipsSample.ApiApp.Models;
using SwashbuckleAspNetTipsSample.ApiApp.OperationFilters;

namespace SwashbuckleAspNetTipsSample.ApiApp.Controllers
{
    /// <summary>
    /// This represents the controller entity for values.
    /// </summary>
    [RoutePrefix("api")]
    public class ValuesController : ApiController
    {
        /// <summary>
        /// Creates value details.
        /// </summary>
        /// <param name="model">Payload that contains request details.</param>
        [Route("values")]
        [HttpPost]
        [SwaggerConsumes("application/json", "application/yaml")]
        [SwaggerProduces("application/json")]
        [SwaggerRequestExample(typeof(ValueRequestModel), typeof(RequestModelExample<ValueRequestModel>))]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.Created, "Resource created", typeof(ValueResponseModel))]
        [SwaggerResponseExample(HttpStatusCode.Created, typeof(ResponseModelExample<ValueResponseModel>))]
        public async Task<IHttpActionResult> CreateValue([FromBody] ValueRequestModel model)
        {
            var response = new ValueResponseModel() { Value = new ValueReference() { Id = model.Id } };

            return this.Ok(response);
        }
    }
}