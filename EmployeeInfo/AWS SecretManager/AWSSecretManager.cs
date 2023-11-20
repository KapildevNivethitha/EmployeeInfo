using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Amazon.SecretsManager.Model.Internal.MarshallTransformations;

namespace EmployeeInfo.AWS_SecretManager
{
    public  class AWSSecretManager
    {
        public async Task<string> GetSecret()
        {
            string secretName = "DatabaseSecret";
            string region = "us-east-1";

            IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

            GetSecretValueRequest request = new GetSecretValueRequest
            {
                SecretId = secretName,
                VersionStage = "AWSCURRENT", // VersionStage defaults to AWSCURRENT if unspecified.
            };

            GetSecretValueResponse response;

            try
            {
                response =  await client.GetSecretValueAsync(request);
            }
            catch (Exception e)
            {
                // For a list of the exceptions thrown, see
                // https://docs.aws.amazon.com/secretsmanager/latest/apireference/API_GetSecretValue.html
                throw e;
            }

            return response.SecretString;

            // Your code goes here
        }

        //public async Task<string> createconnectionstring()
        //{
        //    var SecretManagerSettings=await GetSecret();
        //    string host= SecretManagerSettings.
        //}
    }
}
