using System;
using System.Reflection;

namespace NetChris.Core
{
    /// <inheritdoc />
    /// <remarks>
    /// This is the primary default implementation of <see cref="IApplicationMetadata" />
    /// </remarks>
    public class ApplicationMetadata
        : IApplicationMetadata
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationMetadata" /> class, using
        /// <see cref="Assembly.GetExecutingAssembly"/> for the assembly on which to base its data.
        /// </summary>
        /// <param name="applicationAggregate">The application aggregate.</param>
        /// <param name="applicationName">The application name.</param>
        /// <param name="environmentName">The environment in which the application is running.</param>
        /// <see href="https://gitlab.com/cssl/reference/-/wikis/canonical-application-name">Canonical Application Name</see>
        public ApplicationMetadata(
            string applicationAggregate,
            string applicationName,
            string environmentName) :
            this(applicationAggregate, applicationName, Assembly.Load(applicationName), environmentName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationMetadata" /> class, using
        /// <see cref="Assembly.GetEntryAssembly"/> for the assembly on which to base its data.
        /// </summary>
        /// <param name="applicationAggregate">The application aggregate.</param>
        /// <param name="environmentName">The environment in which the application is running.</param>
        /// <remarks>In this constructor overload, the <see cref="ApplicationMetadata.ApplicationName" /> is automatically discerned
        /// from <see cref="Assembly.GetExecutingAssembly"/>.</remarks>
        /// <see href="https://gitlab.com/cssl/reference/-/wikis/canonical-application-name">Canonical Application Name</see>
        public ApplicationMetadata(
            string applicationAggregate,
            string environmentName) :
            this(applicationAggregate, Assembly.GetEntryAssembly(), environmentName)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationMetadata" /> class.
        /// </summary>
        /// <param name="applicationAggregate">The application aggregate.</param>
        /// <param name="assembly">The assembly from which to pull the <see cref="IApplicationMetadata.ApplicationName"/></param>
        /// <param name="environmentName">The environment in which the application is running.</param>
        /// <remarks>In this constructor overload, the <see cref="ApplicationMetadata.ApplicationName" /> is automatically discerned
        /// from <paramref name="assembly"/></remarks>
        /// <see href="https://gitlab.com/cssl/reference/-/wikis/canonical-application-name">Canonical Application Name</see>
        public ApplicationMetadata(
            string applicationAggregate,
            Assembly assembly,
            string environmentName) :
            this(applicationAggregate, assembly.GetName().Name, assembly, environmentName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationMetadata" /> class.
        /// </summary>
        /// <param name="applicationAggregate">The application aggregate.</param>
        /// <param name="applicationName">The application name.</param>
        /// <param name="assembly">The assembly from which to pull the <see cref="IApplicationMetadata.ApplicationName"/></param>
        /// <param name="environmentName">The environment in which the application is running.</param>
        /// <remarks>In this constructor overload, the <see cref="ApplicationMetadata.ApplicationName" /> is automatically discerned
        /// from <paramref name="assembly"/></remarks>
        /// <see href="https://gitlab.com/cssl/reference/-/wikis/canonical-application-name">Canonical Application Name</see>
        public ApplicationMetadata(
            string applicationAggregate,
            string applicationName,
            Assembly assembly,
            string environmentName)
        {
            ApplicationAggregate = applicationAggregate;
            ApplicationName = applicationName;
            EnvironmentName = environmentName;

            ApplicationVersion = assembly.GetName().Version;
            var assemblyInformationalVersionAttribute =
                assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            InformationalVersion = assemblyInformationalVersionAttribute?.InformationalVersion;

            try
            {
                MachineName = Environment.MachineName;
            }
            catch (InvalidOperationException)
            {
                // The name of this computer cannot be obtained.
                MachineName = string.Empty;
            }

            try
            {
                OSPlatform = Environment.OSVersion.Platform.ToString();
                OSVersion = Environment.OSVersion.VersionString;
            }
            catch (InvalidOperationException)
            {
                // This property was unable to obtain the system version. -or-
                // The obtained platform identifier is not a member of System.PlatformID
            }

            UserName = Environment.UserName;
            ClrVersion = Environment.Version.ToString();
        }

        /// <inheritdoc />
        public string ApplicationName { get; }

        /// <inheritdoc />
        public string ApplicationAggregate { get; }

        /// <inheritdoc />
        public string EnvironmentName { get; }

        /// <inheritdoc />
        public string MachineName { get; }

        /// <inheritdoc />
        public string OSPlatform { get; }

        /// <inheritdoc />
        public string OSVersion { get; }

        /// <inheritdoc />
        public string UserName { get; }

        /// <inheritdoc />
        public string ClrVersion { get; }

        /// <inheritdoc />
        public Version ApplicationVersion { get; }

        /// <inheritdoc />
        public string InformationalVersion { get; }

        // ReSharper disable once InconsistentNaming
        private static readonly DateTimeOffset _startTimestamp
            = DateTimeOffset.Now;

        /// <inheritdoc />
        public DateTimeOffset StartTimestamp => _startTimestamp;
    }
}