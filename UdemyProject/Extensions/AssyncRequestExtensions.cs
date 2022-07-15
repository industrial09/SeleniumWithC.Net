using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UdemyProject.Extensions
{
    public static class AssyncRequestExtensions
    {
		public static async Task<IRestResponse<T>> ExecuteAsyncRequest<T>(this RestClient client, IRestRequest request) where T : class, new()
		{
			var taskcompletionsource = new TaskCompletionSource<IRestResponse<T>>();

			client.ExecuteAsync<T>(request, restResponse =>
			{
				if (restResponse.ErrorException != null)
				{
					String message = "Error retrieving response";
					throw new ApplicationException(message, restResponse.ErrorException);
				}
				taskcompletionsource.SetResult(restResponse);
			});
			return await taskcompletionsource.Task;
		}
	}
	
}
