using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;

namespace AzureDevOpsStateTracker.Functions.Extensions
{
    public static class HttpRequestExtensions
    {
        public static string GetBody(this HttpRequest request)
        {
            string corpo;
            using (StreamReader reader = new StreamReader(request.Body,
                                                         encoding: Encoding.UTF8,
                                                         detectEncodingFromByteOrderMarks: false,
                                                         leaveOpen: true))
            {
                corpo = reader.ReadToEndAsync().Result;
                request.Body.Position = 0;
            }

            return corpo;
        }

    }
}