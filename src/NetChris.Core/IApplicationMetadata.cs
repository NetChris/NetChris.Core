using System;

namespace NetChris.Core
{
    // TODO 1000 - Consider re-organizing environment-specific information into an Environment property of type IEnvironment (to be defined)
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
        /// Gets the name of the environment.
        /// </summary>
        /// <value>The name of the environment.</value>
        string EnvironmentName
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

        /// <summary>
        /// Gets the fully qualified path of the current working directory.
        /// </summary>
        /// <value>The fully qualified path of the current working directory.</value>
        string CurrentDirectory
        {
            get;
        }

        // TODO 1000 - Remove this.  This will change over the course of execution.
        /// <summary>
        /// Gets a unique identifier for the current managed thread.
        /// </summary>
        /// <value>A unique identifier for the current managed thread.</value>
        int CurrentManagedThreadId
        {
            get;
        }

        /// <summary>
        /// Gets whether the current operating system is a 64-bit operating system.
        /// </summary>
        /// <value><c>true</c> if the operating system is 64-bit; otherwise, <c>false</c>.</value>
        bool Is64BitOperatingSystem
        {
            get;
        }

        /// <summary>
        /// Gets whether the current process is a 64-bit process.
        /// </summary>
        /// <value><c>true</c> if the process is 64-bit; otherwise, <c>false</c>.</value>
        bool Is64BitProcess
        {
            get;
        }

        /// <summary>
        /// Gets the operating system/platform.
        /// </summary>
        /// <value>The operating system/platform.</value>
        string OSPlatform
        {
            get;
        }

        /// <summary>
        /// Gets the operating system service pack.
        /// </summary>
        /// <value>The operating system service pack.</value>
        string OSServicePack
        {
            get;
        }

        /// <summary>
        /// Gets the concatenated string representation of the platform identifier, version, and service pack that are currently installed on the operating system.
        /// </summary>
        /// <value>The string representation of the values returned by the
        /// System.OperatingSystem.Platform,
        /// System.OperatingSystem.Version,
        /// and System.OperatingSystem.ServicePack properties..</value>
        string OSVersion
        {
            get;
        }

        /// <summary>
        /// Gets the number of processors on the current machine.
        /// </summary>
        /// <value>
        /// The 32-bit signed integer that specifies the number of processors on the current machine.
        /// There is no default. If the current machine contains multiple processor groups, this
        /// property returns the number of logical processors that are available for use by the
        /// common language runtime (CLR).
        /// </value>
        int ProcessorCount
        {
            get;
        }

        // TODO 1000 - Remove this.  This will change over the course of execution.
        /// <summary>
        /// Gets the number of bytes in the operating system's memory page.
        /// </summary>
        /// <value>The number of bytes in the system memory page.</value>
        int SystemPageSize
        {
            get;
        }

        /// <summary>
        /// Gets the number of milliseconds elapsed since the system started.
        /// </summary>
        /// <value>
        /// A 32-bit signed integer containing the amount of time in milliseconds
        /// that has passed since the last time the computer was started.
        /// </value>
        int MillisecondsElapsedSinceSystemStart
        {
            get;
        }

        /// <summary>
        /// Gets the user name currently logged on to the Windows operating system.
        /// </summary>
        /// <value>The user name of the person who is logged on to Windows.</value>
        string UserName
        {
            get;
        }

        /// <summary>
        /// Gets the version of the common language runtime.
        /// </summary>
        /// <value>The version of the common language runtime.</value>
        string ClrVersion
        {
            get;
        }

        // TODO 1000 - Remove this.  This will change over the course of execution.
        /// <summary>
        /// Gets the amount of physical memory mapped to the process context.
        /// </summary>
        /// <value>
        /// A 64-bit signed integer containing the number of bytes of
        /// physical memory mapped to the process context.
        /// </value>
        long WorkingSet
        {
            get;
        }

        // TODO 1000 - Add a property that indicates the time at which the IApplicationMetadata was instantiated, a good indicator of when the application started.
    }
}
