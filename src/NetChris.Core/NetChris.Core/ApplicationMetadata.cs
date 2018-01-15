using System;
using System.Reflection;

namespace NetChris.Core
{
    /// <summary>
    /// Provides basic application metadata.
    /// </summary>
    /// <typeparam name="T">A type within your application to use to determine metadata.</typeparam>
    /// <seealso cref="ApplicationMetadata" />
    public class ApplicationMetadata<T> : ApplicationMetadata
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationMetadata{T}" /> class.
        /// </summary>
        /// <param name="applicationName">The application name.</param>
        /// <param name="applicationGroup">The application group.</param>
        public ApplicationMetadata(string applicationName, string applicationGroup) : base(typeof(T))
        {
            ApplicationName = applicationName;
            ApplicationGroup = applicationGroup;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationMetadata{T}"/> class.
        /// </summary>
        /// <remarks>
        /// <para>
        /// In this constructor overload, the <see cref="ApplicationMetadata.ApplicationName"/> is automatically discerned from the
        /// assembly containing <typeparamref name="T"/>.
        /// </para>
        /// </remarks>
        /// <param name="applicationGroupId">The application group identifier.</param>
        public ApplicationMetadata(string applicationGroupId) :
            this(typeof(T).Assembly.GetName().Name, applicationGroupId)
        {
        }
    }

    /// <summary>
    /// Provides basic application metadata.  Meant to be used as the base type of <see cref="ApplicationMetadata{T}" />.
    /// </summary>
    /// <seealso cref="ApplicationMetadata{T}" />
    public abstract class ApplicationMetadata
        : IApplicationMetadata
    {
        private readonly Type _typeInAssembly;

        protected ApplicationMetadata(Type typeInAssembly)
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

        public string BuildIdentifier
        {
            get;
            protected set;
        }

        public string Environment
        {
            get;
            protected set;
        }

        public string MachineName
        {
            get;
            protected set;
        }

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
