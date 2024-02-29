using System;
using System.Reflection;

namespace NetChris.Core
{
    /// <inheritdoc />
    /// <remarks>
    /// This is the primary default implementation of <see cref="IApplicationMetadata" />
    /// </remarks>
    public class ApplicationMetadata : IApplicationMetadata
    {
        /// <summary>
        /// Gets a new instance of the <see cref="ApplicationMetadata" /> class, using
        /// <see cref="Assembly.GetEntryAssembly"/> for the assembly on which to base its data.
        /// </summary>
        /// <param name="applicationAggregate">The application aggregate</param>
        /// <param name="applicationAggregateShort">The short-form application aggregate</param>
        /// <param name="applicationComponent">The application component</param>
        /// <param name="applicationComponentShort">The short-form application component</param>
        /// <param name="environmentName">The environment in which the application is running.</param>
        /// <remarks>In this factory, <see cref="ApplicationMetadata.ApplicationName" /> is automatically discerned
        /// from <see cref="Assembly.GetEntryAssembly"/> using its <see cref="AssemblyName.Name"/>.</remarks>
        public static ApplicationMetadata GetApplicationMetadataFromEntryAssembly(
            string applicationAggregate,
            string applicationAggregateShort,
            string applicationComponent,
            string applicationComponentShort,
            string environmentName)
        {
            var entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly == null)
            {
                throw new InvalidOperationException(
                    "There was no assembly available from System.Reflection.Assembly.GetEntryAssembly()");
            }

            var applicationName = entryAssembly.GetName().Name;
            var result = new ApplicationMetadata(entryAssembly,
                applicationAggregate, applicationAggregateShort,
                applicationComponent, applicationComponentShort,
                applicationName, environmentName);
            return result;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationMetadata" /> class.
        /// </summary>
        /// <param name="applicationAggregate">The application aggregate</param>
        /// <param name="applicationAggregateShort">The short-form application aggregate</param>
        /// <param name="applicationComponent">The application component</param>
        /// <param name="applicationComponentShort">The short-form application component</param>
        /// <param name="applicationName">The application name.</param>
        /// <param name="assembly">The assembly from which to pull the <see cref="IApplicationMetadata.ApplicationName"/></param>
        /// <param name="environmentName">The environment in which the application is running.</param>
        /// <remarks>In this constructor overload, the <see cref="ApplicationMetadata.ApplicationName" /> is automatically discerned
        /// from <paramref name="assembly"/>
        /// </remarks>
        public ApplicationMetadata(
            Assembly assembly,
            string applicationAggregate,
            string applicationAggregateShort,
            string applicationComponent,
            string applicationComponentShort,
            string applicationName,
            string environmentName)
        {
            CanonicalApplicationName = new CanonicalApplicationName(applicationAggregate, applicationAggregateShort,
                applicationComponent, applicationComponentShort);
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
            }
            catch (InvalidOperationException)
            {
                // This property was unable to obtain the system version. -or-
                // The obtained platform identifier is not a member of System.PlatformID
                OSPlatform = string.Empty;
            }

            try
            {
                OSVersion = Environment.OSVersion.VersionString;
            }
            catch (InvalidOperationException)
            {
                OSVersion = string.Empty;
            }

            UserName = Environment.UserName;
            ClrVersion = Environment.Version.ToString();
        }

        /// <inheritdoc />
        public string ApplicationName { get; }

        /// <inheritdoc />
        public CanonicalApplicationName CanonicalApplicationName { get; }

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
        public string? InformationalVersion { get; }

        // ReSharper disable once InconsistentNaming
        private static readonly DateTimeOffset _startTimestamp
            = DateTimeOffset.Now;

        /// <inheritdoc />
        public DateTimeOffset StartTimestamp => _startTimestamp;
    }
}