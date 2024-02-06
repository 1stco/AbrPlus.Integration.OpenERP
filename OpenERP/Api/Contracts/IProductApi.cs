using AbrPlus.Integration.OpenERP.Api.DataContracts;
using System.ServiceModel;

namespace AbrPlus.Integration.OpenERP.Api.Contracts
{
    /// <summary>
    /// The main <c>IProduct</c> interface.
    /// <para>Interface for product. contains methods to support product. Creates a proxy for product.</para>
    /// </summary>
    /// <see cref="IBaseIntegrationApi{T}"/>
    /// <seealso cref="PaymentBundle"/>
    [ServiceContract]
    public interface IProductApi : IBaseIntegrationApi<ProductBundle>
    {

    }
}
