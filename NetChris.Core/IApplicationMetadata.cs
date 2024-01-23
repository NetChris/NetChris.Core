using System;

namespace NetChris.Core
{
    /// <summary>
    /// Defines basic metadata about an application,
    /// as well as some metadata about the specific
    /// execution instance and deployed environment.
    /// </summary>
    public interface IApplicationMetadata
    {
        /// <summary>
        /// Gets the name of the application.
        /// </summary>
        /// <value>The name of the application.</value>
        string ApplicationName { get; }

        /// <summary>
        /// Gets application's <see cref="CanonicalApplicationName"/>.
        /// </summary>
        CanonicalApplicationName CanonicalApplicationName { get; }

        /// <summary>
        /// Gets the application version.
        /// </summary>
        /// <value>The application version.</value>
        Version ApplicationVersion { get; }

        /// <summary>
        /// Gets the build identifier.
        /// </summary>
        /// <value>The build identifier.</value>
        string BuildIdentifier { get; }

        /// <summary>
        /// Gets the name of the environment.
        /// </summary>
        /// <value>The name of the environment.</value>
        string EnvironmentName { get; }

        /// <summary>
        /// Gets the name of the machine on which the application is running.
        /// </summary>
        /// <value>The name of the machine on which the application is running.</value>
        string MachineName { get; }

        /// <summary>
        /// Gets the informational version.
        /// </summary>
        /// <remarks>This value is often a more descriptive representation of <see cref="ApplicationVersion"/></remarks>
        /// <value>The informational version.</value>
        string? InformationalVersion { get; }

        /// <summary>
        /// Gets the time at which the currently-running application instance was started.
        /// </summary>
        /// <value>The time at which the currently-running application instance was started.</value>
        DateTimeOffset StartTimestamp { get; }

        /// <summary>
        /// Gets the operating system/platform.
        /// </summary>
        /// <value>The operating system/platform.</value>
        // ReSharper disable once InconsistentNaming
        string OSPlatform { get; }

        /// <summary>
        /// Gets the concatenated string representation of the platform identifier, version, and service pack that are currently installed on the operating system.
        /// </summary>
        /// <value>The string representation of the values returned by the
        /// System.OperatingSystem.Platform,
        /// System.OperatingSystem.Version,
        /// and System.OperatingSystem.ServicePack properties..</value>
        // ReSharper disable once InconsistentNaming
        string OSVersion { get; }

        /// <summary>
        /// Gets the user name currently logged on to the Windows operating system.
        /// </summary>
        /// <value>The user name of the person who is logged on to Windows.</value>
        string UserName { get; }

        /// <summary>
        /// Gets the version of the common language runtime.
        /// </summary>
        /// <value>The version of the common language runtime.</value>
        string ClrVersion { get; }
    }
}