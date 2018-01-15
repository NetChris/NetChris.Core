using System;
using System.Reflection;

namespace NetChris.Core
{

    /// <summary>
    /// Provides basic application metadata.
    /// </summary>
    /// <typeparam name="T">A type within your application to use to determine metadata.</typeparam>
    /// <seealso cref="AppMetadata" />
    public class AppMetadata<T> : AppMetadata
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppMetadata{T}" /> class.
        /// </summary>
        /// <param name="applicationName">The application name.</param>
        /// <param name="applicationGroup">The application group.</param>
        public AppMetadata(string applicationName, string applicationGroup) : base(typeof(T))
        {
            ApplicationName = applicationName;
            ApplicationGroup = applicationGroup;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppMetadata{T}"/> class.
        /// </summary>
        /// <remarks>
        /// <para>
        /// In this constructor overload, the <see cref="AppMetadata.ApplicationName"/> is automatically discerned from the
        /// assembly containing <typeparamref name="T"/>.
        /// </para>
        /// </remarks>
        /// <param name="applicationGroupId">The application group identifier.</param>
        public AppMetadata(string applicationGroupId) :
            this(typeof(T).Assembly.GetName().Name, applicationGroupId)
        {
        }
    }

    // TODO 0000 rename to ApplicationMetadata
    /// <summary>
    /// Provides basic application metadata.  Meant to be used as the base type of <see cref="AppMetadata{T}" />.
    /// </summary>
    /// <seealso cref="AppMetadata{T}" />
    public abstract class AppMetadata
    {

        // TODO 0000 IApplicationMetadata - Extract interface from AppMetadata


        private readonly Type _typeInAssembly;

        protected AppMetadata(Type typeInAssembly)
        {
            _typeInAssembly = typeInAssembly;
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

        // TODO 0000 IApplicationMetadata.ApplicationVersion
        // TODO 0000 IApplicationMetadata.InformationalVersion
        // TODO 0000 IApplicationMetadata.ExecutionInstanceId
        // TODO 0000 IApplicationMetadata.ExecutionInstanceTimestamp (DateTimeOffset)
        // TODO 0000 IApplicationMetadata.MachineLocalTimeZoneInfo
        // TODO 0000 IApplicationMetadata.BuildIdentifier
        // TODO 0000 IApplicationMetadata.Environment
        // TODO 0000 IApplicationMetadata.MachineName

        public string ApplicationVersion
        {
            get
            {
                var applicationAssembly = Assembly.GetAssembly(_typeInAssembly);
                var version = applicationAssembly.GetName().Version;
                return $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
            }
        }

        public string InformationalVersion
        {
            get
            {
                var version = _typeInAssembly.Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
                return version?.InformationalVersion;
            }
        }

        private static readonly string _executionInstanceId
            = Guid.NewGuid().ToString();

        public string ExecutionInstanceId
        {
            get
            {
                return _executionInstanceId;
            }
        }

        private static readonly DateTimeOffset _executionInstanceTimestamp
            = DateTimeOffset.Now;

        public DateTimeOffset ExecutionInstanceTimestamp
        {
            get
            {
                return _executionInstanceTimestamp;
            }
        }

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
