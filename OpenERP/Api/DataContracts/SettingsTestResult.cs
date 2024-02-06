using System.Runtime.Serialization;

namespace AbrPlus.Integration.OpenERP.Api.DataContracts
{
    /// <summary>
    /// The main <c>SettingsTestResult</c>
    /// Contains properties for for setting test result.
    /// </summary>
    [DataContract]
    public class SettingsTestResult
    {
        /// <summary>
        /// Maintains SettingTestResul status.
        /// </summary>
        /// <value>Gets and sets value of Success</value>
        [DataMember]
        public bool Success { get; set; }

        /// <summary>
        /// Maintains SettingTestResul error message.
        /// </summary>
        /// <value>Gets and sets value of ErrorMessage</value>
        [DataMember]
        public string ErrorMessage { get; set; }
    }
}
