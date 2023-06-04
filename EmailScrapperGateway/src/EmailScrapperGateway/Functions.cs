using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using System.Net;
using System.Reflection.PortableExecutable;

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
                Headers = new Dictionary<string, string> { 
                    { "Content-Type", "application/json" },
                    { "Access-Control-Allow-Origin", "*" },
                    { "Access-Control-Allow-Methods", "*" },
                    { "Access-Control-Allow-Headers", "*" },
                    { "Access-Control-Expose-Headers", "*" },
                }
            };

            return response;
        }

        /// <summary>
        /// A Lambda function to respond to HTTP Get methods from API Gateway
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The API Gateway response.</returns>
        public APIGatewayProxyResponse AddToQueue(APIGatewayProxyRequest request, ILambdaContext context) {
            var myjson = request.Body;
            var response = new APIGatewayProxyResponse {
                StatusCode = (int)HttpStatusCode.OK,
                Body = myjson,
                Headers = new Dictionary<string, string> {
                    { "Content-Type", "application/json" },
                    { "Access-Control-Allow-Origin", "*" },
                    { "Access-Control-Allow-Methods", "*" },
                    { "Access-Control-Allow-Headers", "*" },
                    { "Access-Control-Expose-Headers", "*" },
                }
            };

            return response;
        }
    }
}