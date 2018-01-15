using System;
using System.Reflection;

namespace NetChris.Core
{
    /// <inheritdoc />
    /// <summary>
    /// Provides basic application metadata.
    /// </summary>
    /// <typeparam name="T">A type within your application to use to determine metadata.</typeparam>
    /// <seealso cref="T:NetChris.Core.ApplicationMetadata" />
    public class ApplicationMetadata<T> : ApplicationMetadata
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationMetadata{T}" /> class.
        /// </summary>
        /// <param name="applicationName">The application name.</param>
        /// <param name="applicationGroup">The application group.</param>
        /// <param name="environmentName">Name of the environment.</param>
        /// <param name="buildIdentifier">The build identifier.</param>
        public ApplicationMetadata(
            string applicationGroup,
            string applicationName,
            string environmentName,
            string buildIdentifier) : base(typeof(T))
        {
            ApplicationName = applicationName;
            ApplicationGroup = applicationGroup;
            BuildIdentifier = buildIdentifier;
            EnvironmentName = environmentName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationMetadata{T}" /> class.
        /// </summary>
        /// <param name="applicationGroup">The application group identifier.</param>
        /// <param name="environmentName">The environment.</param>
        /// <param name="buildIdentifier">The build identifier.</param>
        /// <remarks>In this constructor overload, the <see cref="ApplicationMetadata.ApplicationName" /> is automatically discerned from the
        /// assembly containing <typeparamref name="T" />.</remarks>
        public ApplicationMetadata(
            string applicationGroup,
            string environmentName,
            string buildIdentifier) :
            this(applicationGroup, typeof(T).Assembly.GetName().Name, environmentName, buildIdentifier)
        {
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// Provides basic application metadata.  Meant to be used as the base type of <see cref="ApplicationMetadata{T}" />.
    /// </summary>
    /// <seealso cref="ApplicationMetadata{T}" />
    public abstract class ApplicationMetadata
        : IApplicationMetadata
    {
        private readonly string _applicationVersionString;
        private readonly string _informationalVersion;

        protected ApplicationMetadata(Type typeInAssembly)
        {
            var version = typeInAssembly.Assembly.GetName().Version;
            _applicationVersionString = $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
            var blerg = typeInAssembly.Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            _informationalVersion = blerg?.InformationalVersion;

            #region Environment values

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
                CurrentDirectory = Environment.CurrentDirectory;
            }
            catch (System.IO.IOException)
            {
                // An I/O error occurred.
                // Also will catch System.IO.DirectoryNotFoundException - Attempted to set a local path that cannot be found.
            }
            catch (System.Security.SecurityException)
            {
                // The caller does not have the appropriate permission.
            }

            CurrentManagedThreadId = Environment.CurrentManagedThreadId;
            Is64BitOperatingSystem = Environment.Is64BitOperatingSystem;
            Is64BitProcess = Environment.Is64BitProcess;

            try
            {
                OSPlatform = Environment.OSVersion.Platform.ToString();
                OSServicePack = Environment.OSVersion.ServicePack;
                OSVersion = Environment.OSVersion.VersionString;
            }
            catch (InvalidOperationException)
            {
                // This property was unable to obtain the system version. -or-
                // The obtained platform identifier is not a member of System.PlatformID
            }

            ProcessorCount = Environment.ProcessorCount;
            SystemPageSize = Environment.SystemPageSize;
            MillisecondsElapsedSinceSystemStart = Environment.TickCount;
            UserName = Environment.UserName;
            ClrVersion = Environment.Version.ToString();
            WorkingSet = Environment.WorkingSet;

            #endregion
        }

        public string ApplicationName
        {
            get;
            protected set;
        }

        public string ApplicationGroup
        {
            get;
            protected set;
        }

        public string BuildIdentifier
        {
            get;
            protected set;
        }

        public string EnvironmentName
        {
            get;
            protected set;
        }

        public string MachineName
        {
            get;
        }

        public string CurrentDirectory { get; }
        public int CurrentManagedThreadId { get; }
        public bool Is64BitOperatingSystem { get; }
        public bool Is64BitProcess { get; }
        public string OSPlatform { get; }
        public string OSServicePack { get; }
        public string OSVersion { get; }
        public int ProcessorCount { get; }
        public int SystemPageSize { get; }
        public int MillisecondsElapsedSinceSystemStart { get; }
        public string UserName { get; }
        public string ClrVersion { get; }
        public long WorkingSet { get; }

        public string ApplicationVersion
        {
            get
            {
                return _applicationVersionString;
            }
        }

        public string InformationalVersion
        {
            get
            {
                return _informationalVersion;
            }
        }

        // ReSharper disable once InconsistentNaming
        private static readonly string _executionInstanceId
            = Guid.NewGuid().ToString();

        public string ExecutionInstanceId
        {
            get
            {
                return _executionInstanceId;
            }
        }

        // ReSharper disable once InconsistentNaming
        private static readonly DateTimeOffset _executionInstanceTimestamp
            = DateTimeOffset.Now;

        public DateTimeOffset ExecutionInstanceTimestamp
        {
            get
            {
                return _executionInstanceTimestamp;
            }
        }

        // ReSharper disable once InconsistentNaming
        private static readonly TimeZoneInfo _machineLocalTimeZone =
            TimeZoneInfo.Local;

        public string MachineLocalTimeZone
        {
            get
            {
                return _machineLocalTimeZone.Id;
            }
        }
    }
}
