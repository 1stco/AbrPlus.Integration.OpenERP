using AbrPlus.Integration.OpenERP.Api.DataContracts;
using System;
using System.Collections.Generic;

namespace AbrPlus.Integration.OpenERP.Helpers
{
    /// <summary>
    /// The main <c>IdentityRemainHelper</c> class.
    /// <para>Adds <c>IdentityBalance</c> to list.</para>
    /// </summary>
    public static class IdentityRemainHelper
    {
        /// <summary>
        /// Gets An <c>IdentityBalance</c> list and an <c>IdentityBalance</c> object.
        /// Add the object to list.
        /// </summary>
        /// <remarks>
        /// <para>
        /// if <c>identityBalanceParams.BalanceResultType</c> is Equal to <c>BalanceResultType.AllHasRemain</c> and
        /// <c><CurrentidentityBalance.Remain == 0</c>). Doesn't add <paramref name="CurrentidentityBalance"/></para>
        /// <para>
        /// if <c>identityBalanceParams.ToBalanceAmount.HasValue</c> and <c>CurrentidentityBalance.Remain > identityBalanceParams.ToBalanceAmount.Value</c>
        /// Doesn't add <paramref name="CurrentidentityBalance"/>
        /// </para>
        /// <para>And etc.</para>
        /// </remarks>
        /// <param name="listIdentityBalance"></param>
        /// <param name="CurrentidentityBalance"></param>
        /// <param name="identityBalanceParams"></param>
        /// <see cref="IdentityBalance"/>
        /// <seealso cref="BalanceResultType"/>
        public static void AddIdentityBalanceToList(this List<IdentityBalance> listIdentityBalance, IdentityBalance CurrentidentityBalance, IdentityBalanceParams identityBalanceParams)
        {
            CurrentidentityBalance.Remain = Math.Abs(CurrentidentityBalance.Remain);
            if (identityBalanceParams.BalanceResultType == BalanceResultType.AllHasRemain && CurrentidentityBalance.Remain == 0)
                return;
            else if (identityBalanceParams.BalanceResultType == BalanceResultType.IsDebit && CurrentidentityBalance.Debit < CurrentidentityBalance.Credit)
                return;
            else if (identityBalanceParams.BalanceResultType == BalanceResultType.IsCredit && CurrentidentityBalance.Debit > CurrentidentityBalance.Credit)
                return;
            else if (identityBalanceParams.FromBalanceAmount.HasValue && CurrentidentityBalance.Remain < identityBalanceParams.FromBalanceAmount.Value)
                return;
            else if (identityBalanceParams.ToBalanceAmount.HasValue && CurrentidentityBalance.Remain > identityBalanceParams.ToBalanceAmount.Value)
                return;
            listIdentityBalance.Add(CurrentidentityBalance);
        }
    }
}
