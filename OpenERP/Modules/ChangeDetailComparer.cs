using AbrPlus.Integration.OpenERP.Api.DataContracts;
using System.Collections.Generic;

namespace AbrPlus.Integration.OpenERP.Modules
{
    /// <summary>
    /// <para>The main <c>ChangeDetailComparer</c> class.</para>
    /// <para>implement <c>IEqualityComparer<ChangeDetail></c> interface.</para>
    /// <para>Contains <c>Equals</c> and <c>GetHashCode</c> method to compare <c>ChangeDetail</c> objects.</para>
    /// </summary>
    /// <list type="bullet">
    /// <item>
    /// <term>Equals</term>
    /// <description>Equals two <c>ChangeDetail</c> objects.</description>
    /// </item>
    /// <item>
    /// <term>GetHashCode</term>
    /// <description>Get hash code of <c>ChangeDetail</c> object.</description>
    /// </item>
    /// </list>
    /// <see cref="IEqualityComparer{T}"/>
    /// <seealso cref="ChangeDetail"/>
    public class ChangeDetailComparer : IEqualityComparer<ChangeDetail>
    {
        /// <summary>
        /// <para>
        /// If <paramref name="x"/> exactly equal to <paramref name="y"/>, Returns true. Otherwise returns the false.
        /// </para>
        /// <para>
        /// In order to returns true must <paramref name="x"/> id equal to <paramref name="y"/> id and
        /// <paramref name="x"/> action equal to <paramref name="y"/> action.
        /// </para>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Returns boolean.</returns>
        public bool Equals(ChangeDetail x, ChangeDetail y)
        {
            return x.Id == y.Id && x.Action == y.Action;
        }

        /// <summary>
        /// Gets <c>ChangeDetail</c> object as <paramref name="obj"/> and returns Id as hash code.
        /// </summary>
        /// <param name="obj"><c>ChangeDetail</c>'s object</param>
        /// <returns>Returns the object Id as hashed</returns>
        public int GetHashCode(ChangeDetail obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
