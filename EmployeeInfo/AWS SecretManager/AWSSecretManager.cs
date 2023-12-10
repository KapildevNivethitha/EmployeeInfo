using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Amazon.SecretsManager.Model.Internal.MarshallTransformations;
using EmployeeInfo.Models;
using Microsoft.AspNetCore.DataProtection;
using Newtonsoft.Json;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace EmployeeInfo.AWS_SecretManager
{
    public static class AWSSecretManager
    {
        public static  string GetSecret()
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
                response = client.GetSecretValueAsync(request).Result;
            }
            catch (Exception e)
            {
                // For a list of the exceptions thrown, see
                // https://docs.aws.amazon.com/secretsmanager/latest/apireference/API_GetSecretValue.html
                throw e;
            }
            string secret = "";
            if (response.SecretString != null)
            {
                return secret = response.SecretString;

                // Your code goes here
            }
            return secret = response.SecretString;
           
        }
        public static  string createconnectionstring()
        {
            var SecretManagerSettings =  GetSecret();
            var secretManagerValues = JsonConvert.DeserializeObject<SecretManagerValues>(SecretManagerSettings);

            string username = secretManagerValues.username;
            string password = Encryption.DecryptString("b14ca5898a4e4133bbce2ea2315a1916",secretManagerValues.password);
            string host = secretManagerValues.host;
            string port = secretManagerValues.port;
            return $"Host = {host}; Port = {port}; Username = {username}; Password = {password}; Database = EmployeeDetailsInfo";
        }

    }
}
