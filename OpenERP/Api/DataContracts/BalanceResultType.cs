namespace AbrPlus.Integration.OpenERP.Api.DataContracts
{
    /// <summary>
    /// <para>The main <c>BalanceResultType</c> enum.</para>
    /// <para>Uses to determines <c>IdentityBalanceParams</c> properties</para>
    /// <para>Uses for Add <c>identityBalanceParams</c> to <c>listIdentityBalance</c>.</para>
    /// </summary>
    /// <remarks>An identity cannot be both creditor and debtor at the same time</remarks>
    public enum BalanceResultType
    {
        /// <summary>
        /// All of balance
        /// </summary>
        /// <remarks></remarks>
        All = 1,

        /// <summary>
        /// balance remains
        /// </summary>
        /// <remarks></remarks>
        AllHasRemain = 2,//ghalat emlaei => AllHasRemains

        /// <summary>
        /// Determines whether the identity is creditor or not
        /// </summary>
        /// <remarks>The amount of credit is determined in the <c>IdentityBalance</c>.</remarks>
        /// <see cref="IdentityBalance"/>
        IsCredit = 3,

        /// <summary>
        /// Determines whether the identity has a debt or not
        /// </summary>
        /// <remarks>The amount of debt is specified in the <c>IdentityBalance</c>.</remarks>
        /// <see cref="IdentityBalance"/>
        IsDebit = 4
    }
}
