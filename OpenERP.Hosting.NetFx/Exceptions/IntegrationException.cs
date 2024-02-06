using System;

namespace AbrPlus.Integration.OpenERP.Hosting.NetFx.Exceptions
{
    /// <summary>
    /// <para>The main <c>IntegrationException</c> class.</para>
    /// <para>Integrate Exeptions.</para>
    /// </summary>
    /// <list type="bullet">
    /// <item>
    /// <term>IntegrationException</term>
    /// <description>Constructor</description>
    /// </item>
    /// </list>
    /// <see cref="Exception"/>
    [Serializable]
    public class IntegrationException : Exception
    {
        /// <summary>
        /// <para>Constructor</para>
        /// </summary>
        public IntegrationException() { }

        /// <summary>
        /// <para>Constructor</para>
        /// <para>
        /// Initializes a new instance of the System.Exception class with a specified errormessage.
        /// </para>
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public IntegrationException(string message) : base(message) { }

        /// <summary>
        /// <para>Constructor</para>
        /// <para>
        /// Initializes a new instance of the System.Exception class with a specified error 
        ///  message and a reference to the inner exception that is the cause of this exception.
        /// </para>
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">
        /// The exception that is the cause of the current exception, or a null reference
        /// (Nothing in Visual Basic) if no inner exception is specified.
        /// </param>
        public IntegrationException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// <para>Constructor</para>
        /// <para>Initializes a new instance of the System.Exception class with serialized data.</para>
        /// </summary>
        /// <param name="info">
        /// The System.Runtime.Serialization.SerializationInfo that holds the serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The System.Runtime.Serialization.StreamingContext that contains contextual information about the source or destination.
        /// </param>
        protected IntegrationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
