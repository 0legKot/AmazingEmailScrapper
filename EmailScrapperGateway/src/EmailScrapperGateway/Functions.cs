using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using System.Net;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace EmailScrapperGateway {
    public class Functions {
        /// <summary>
        /// Default constructor that Lambda will invoke.
        /// </summary>
        public Functions() {
        }


        /// <summary>
        /// A Lambda function to respond to HTTP Get methods from API Gateway
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The API Gateway response.</returns>
        public APIGatewayProxyResponse GetFromCache(APIGatewayProxyRequest request, ILambdaContext context) {
            context.Logger.LogInformation("Get Request\n");
            var myjson = "{\r\n                \"data\": [\r\n                    { \"url\": \"aws.aa\", \"emails\": [\"aaa@aa.aa\", \"bbb@bb.bb\"] },\r\n                    { \"url\": \"aws2.xx\", \"emails\": [\"ddd@aa.dd\", \"mmm@nn.bb\"] }\r\n                ]\r\n            }";
            var response = new APIGatewayProxyResponse {
                StatusCode = (int)HttpStatusCode.OK,
                Body = myjson,
                Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
            };

            return response;
        }
    }
}