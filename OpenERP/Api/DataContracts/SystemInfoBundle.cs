namespace AbrPlus.Integration.OpenERP.Api.DataContracts
{
    /// <summary>
    /// The main <c>SystemInfoBundle</c> class.
    /// Contains all properties of system information bundle.
    /// </summary>
    public class SystemInfoBundle
    {
        /// <summary>
        /// Name of system info bundle object.
        /// </summary>
        /// <value>Gets and sets value of Name</value>
        public string Name { get; set; }

        /// <summary>
        /// Vesion of system info bundle object.
        /// </summary>
        /// <value>Gets and sets value of Version</value>
        /// <remarks>If you can not specify the version. Its value is equal to "Error: Cannot identify version"</remarks>
        public string Version { get; set; }

        /// <summary>
        /// Can supports version or not.
        /// </summary>
        /// <value>Gets and sets value of VersionIsSupported</value>
        public bool VersionIsSupported { get; set; }
    }
}
