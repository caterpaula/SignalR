using System;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Internal.Protocol;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class JsonProtocolDependencyInjectionExtensions
    {
        /// <summary>
        /// Enables the JSON protocol for SignalR.
        /// </summary>
        /// <remarks>
        /// This has no effect if the JSON protocol has already been enabled.
        /// </remarks>
        /// <param name="builder">The <see cref="ISignalRBuilder"/> representing the SignalR server to add JSON protocol support to.</param>
        /// <returns>The value of <paramref name="builder"/></returns>
        public static ISignalRBuilder AddJsonProtocol(this ISignalRBuilder builder) => AddJsonProtocol(builder, _ => { });

        /// <summary>
        /// Enables the JSON protocol for SignalR and allows options for the JSON protocol to be configured.
        /// </summary>
        /// <remarks>
        /// Any options configured here will be applied, even if the JSON protocol has already been registered with the server.
        /// </remarks>
        /// <param name="builder">The <see cref="ISignalRBuilder"/> representing the SignalR server to add JSON protocol support to.</param>
        /// <param name="configure">A delegate that can be used to configure the <see cref="JsonHubProtocolOptions"/></param>
        /// <returns>The value of <paramref name="builder"/></returns>
        public static ISignalRBuilder AddJsonProtocol(this ISignalRBuilder builder, Action<JsonHubProtocolOptions> configure)
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IHubProtocol, JsonHubProtocol>());
            builder.Services.Configure(configure);
            return builder;
        }
    }
}
