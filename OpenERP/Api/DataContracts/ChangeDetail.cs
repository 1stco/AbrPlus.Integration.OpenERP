using AbrPlus.Integration.OpenERP.Enums;

namespace AbrPlus.Integration.OpenERP.Api.DataContracts
{
    /// <summary>
    /// <para>The main <c>ChangeDetail</c> class.</para>
    /// <para>This class is used to store and maintain changes made.</para>
    /// </summary>
    /// <remarks></remarks>
    public class ChangeDetail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeDetail" /> class. 
        /// </summary>
        /// <remarks>Value of Id will null. And amount of it will be PaymentKey</remarks>
        public ChangeDetail()
        {

        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ChangeDetail" /> class.
        /// </summary>
        /// <remarks>   Value of Id will null. And amount of it will be PaymentKey. </remarks>
        /// <param name="action">   The action. </param>
        /// <param name="id">       The identifier. </param>
        public ChangeDetail(ActionType action, string id)
        {
            Action = action;
            Id = id;
        }

        /// <summary>   Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        public string Id { get; set; }

        /// <summary>   Gets or sets the action. </summary>
        /// <value> The action. </value>

        public ActionType Action { get; set; }
    }
}
