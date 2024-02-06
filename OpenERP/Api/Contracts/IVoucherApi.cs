using AbrPlus.Integration.OpenERP.Api.DataContracts;
using System.ServiceModel;

namespace AbrPlus.Integration.OpenERP.Api.Contracts
{
    /// <summary>
    /// The main <c>IPayment</c> interface.
    /// <para>Interface for Voucher. contains methods to support Voucher. Creates a proxy for Voucher.</para>
    /// </summary>
    /// <see cref="IBaseIntegrationApi{T}"/>
    /// <seealso cref="VoucherBundle"/>
    [ServiceContract]
    public interface IVoucherApi : IBaseIntegrationApi<VoucherBundle>
    {
    }
}
