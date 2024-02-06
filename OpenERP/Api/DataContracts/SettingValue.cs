namespace AbrPlus.Integration.OpenERP.Api.DataContracts
{
    /// <summary>
    /// The main <c>SettingValue</c> class.
    /// Specifies the name and value of the settings
    /// </summary>
    public class SettingValue
    {
        public SettingValue()
        {

        }
        public SettingValue(string name, string value)
        {
            Name = name;
            Value = value;
        }
        /// <summary>
        /// Name of setting value.
        /// </summary>
        /// <value>Gets and sets value of Name</value>
        public string Name { get; set; }

        /// <summary>
        /// Value of setting value.
        /// </summary>
        /// <value>Gets and sets value of Value</value>
        public string Value { get; set; }
    }
}
