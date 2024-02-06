using AbrPlus.Integration.OpenERP.Api.DataContracts;

namespace AbrPlus.Integration.OpenERP.Settings
{
    /// <summary>
    /// 
    /// </summary>
    public class Setting
    {
        /// <summary>
        /// Uses to find member name.
        /// </summary>
        /// <value>Gets or sets value of Key.</value>
        public string Key { get; set; }

        /// <summary>
        /// Maintains setting value.
        /// </summary>
        /// <value>Gets or sets value of Value</value>
        public string Value { get; set; }

        /// <summary>
        /// Maintains name of setting.
        /// </summary>
        /// <value>Gets or sets value of Title</value>
        public string Title { get; set; }

        /// <summary>
        /// Description about setting
        /// </summary>
        /// <value>Gets or sets value of Description</value>
        public string Description { get; set; }

        /// <summary>
        /// Determines type of setting
        /// </summary>
        /// <value>Gets or sets value of Type</value>
        public string Type { get; set; }

        /// <summary>
        /// Determines group name.
        /// </summary>
        /// <value>Gets or sets value of GroupName</value>
        public string GroupName { get; set; }

        /// <summary>
        /// Determines Setting values.
        /// </summary>
        /// <value>Gets or sets value of Values</value>
        /// <see cref="SettingValue"/>
        public SettingValue[] Values { get; set; }
    }
}
