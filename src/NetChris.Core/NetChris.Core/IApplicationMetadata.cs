using System;

namespace NetChris.Core
{
    /// <summary>
    /// Defines basic metadata about an application,
    /// as well as some metadata about the specific
    /// execution instance and deployed environment.
    /// </summary>
    /// <see href="https://gitlab.com/NetChris/DotNET-Coding-Standards/wikis/Application-Metadata">Application metadata wiki</see>
    public interface IApplicationMetadata
    {
        /// <summary>
        /// Gets the name of the application.
        /// </summary>
        /// <value>The name of the application.</value>
        string ApplicationName
        {
            get;
        }

        /// <summary>
        /// Gets the application group.
        /// </summary>
        /// <value>The application group.</value>
        string ApplicationGroup
        {
            get;
        }

        /// <summary>
        /// Gets the build identifier.
        /// </summary>
        /// <remarks>
        /// This information is useful in tracking back to the build from which the specific deployment of the application came.
        /// </remarks>
        /// <value>The build identifier.</value>
        string BuildIdentifier
        {
            get;
        }

        /// <summary>
        /// Gets the environment.
        /// </summary>
        /// <value>The environment.</value>
        string Environment
        {
            get;
        }

        /// <summary>
        /// Gets the name of the machine on which the application is running.
        /// </summary>
        /// <value>The name of the machine on which the application is running.</value>
        string MachineName
        {
            get;
        }

        /// <summary>
        /// Gets the application version.
        /// </summary>
        /// <value>The application version.</value>
        string ApplicationVersion
        {
            get;
        }

        /// <summary>
        /// Gets the informational version.
        /// </summary>
        /// <remarks>This value is often a more descriptive representation of <see cref="ApplicationVersion"/></remarks>
        /// <value>The informational version.</value>
        string InformationalVersion
        {
            get;
        }

        /// <summary>
        /// Gets the execution instance identifier.
        /// </summary>
        /// <remarks>
        /// This is a value which uniquely identifies the actual instance of execution of the application.
        /// If the exact same binary is executed, then stopped, then executed again, this value will change.
        /// </remarks>
        /// <value>The execution instance identifier.</value>
        string ExecutionInstanceId
        {
            get;
        }

        /// <summary>
        /// Gets the time at which the currently-running application instance was executed.
        /// </summary>
        /// <value>The time at which the currently-running application instance was executed.</value>
        DateTimeOffset ExecutionInstanceTimestamp
        {
            get;
        }

        /// <summary>
        /// Gets the time zone of the machine running the application.
        /// </summary>
        /// <value>The time zone of the machine running the application.</value>
        string MachineLocalTimeZone
        {
            get;
        }
    }
}
