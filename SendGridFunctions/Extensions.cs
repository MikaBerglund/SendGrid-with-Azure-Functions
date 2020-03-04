using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SendGridFunctions
{
    /// <summary>
    /// Extension methods for the function app.
    /// </summary>
    public static class Extensions
    {

        private static RetryOptions DefaultRetryOptions = new RetryOptions(TimeSpan.FromSeconds(10), 10) { BackoffCoefficient = 1.1 };

        /// <summary>
        /// Calls an activity function with the default retry options.
        /// </summary>
        /// <param name="functionName">The name of the function to call.</param>
        /// <param name="input">An optional input object to send to the function.</param>
        public static async Task CallActivityWithDefaultRetryAsync(this IDurableOrchestrationContext context, string functionName, object input = null)
        {
            await context.CallActivityWithRetryAsync(functionName, DefaultRetryOptions, input);
        }

        /// <summary>
        /// Calls an activity function with the default retry options.
        /// </summary>
        /// <typeparam name="TResult">The type for the result returned by the activity function.</typeparam>
        /// <param name="functionName">The name of the function to call.</param>
        /// <param name="input">An optional input object to send to the function.</param>
        /// <returns>Returns the object returned by the activity function.</returns>
        public static async Task<TResult> CallActivityWithDefaultRetryAsync<TResult>(this IDurableOrchestrationContext context, string functionName, object input = null)
        {
            return await context.CallActivityWithRetryAsync<TResult>(functionName, DefaultRetryOptions, input);
        }

    }
}
