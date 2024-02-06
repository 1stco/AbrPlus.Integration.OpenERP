namespace AbrPlus.Integration.OpenERP.Hosting.NetFx.Services
{
    /// <summary>
    /// <para>The main <c>IFinancialSystemSettingService</c> interface</para>
    /// <para>Setting service interface</para>
    /// </summary>
    public partial interface IFinancialSystemSettingService
    {
        /// <summary>
        /// Load settings
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="zoneId">Zone identifier for which settigns should be loaded</param>
        T LoadSetting<T>(int zoneId = 0) where T : IFinancialSystemSetting, new();

        /// <summary>
        /// Save settings object
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="settings">Setting instance</param>
        void SaveSetting<T>(T settings, int zoneId = 0) where T : IFinancialSystemSetting, new();


    }
}
