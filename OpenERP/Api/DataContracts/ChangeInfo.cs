namespace AbrPlus.Integration.OpenERP.Api.DataContracts
{
    /// <summary>
    ///  <para>The main <c>ChangeInfo</c> class.</para>
    /// <para>Information about the change. by the table of database name and last tracked version.</para>
    /// </summary>

    public class ChangeInfo
    {
        /// <summary>   Default constructor. </summary>
        public ChangeInfo()
        {
            Changes = new ChangeDetail[] { };

        }

        /// <summary>   Gets or sets the name of the table. </summary>
        /// <value> The name of the table. </value>
        public string TableName { get; set; }

        /// <summary>   Gets or sets the changes. </summary>
        /// <value> The changes. </value>
        public ChangeDetail[] Changes { get; set; }

        /// <summary>   Gets or sets the last tracked version. </summary>
        /// <value> The last tracked version. </value>
        public string LastTrackedVersion { get; set; }
    }

}
