namespace NetChris.Core.Values
{
    /// <summary>
    /// Lightweight object with an code and message.
    /// A glorified key/value pair.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Ideal use is in systems and APIs that, for example, return messages
    /// or throw errors with unique-ish codes and an explanatory message.
    /// </para>
    /// </remarks>
    public class SimpleResult
    {
        /// <summary>
        /// Gets the code
        /// </summary>
        /// <value>The result code</value>
        public string ResultCode
        {
            get;
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>The message</value>
        public string Message
        {
            get;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleResult" /> class.
        /// </summary>
        /// <param name="resultCode">The result code</param>
        /// <param name="message">The message</param>
        public SimpleResult(string resultCode, string message)
        {
            ResultCode = resultCode;
            Message = message;
        }
    }
}
