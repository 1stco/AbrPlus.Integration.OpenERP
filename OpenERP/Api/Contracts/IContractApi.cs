using AbrPlus.Integration.OpenERP.Api.DataContracts;
using System.ServiceModel;

namespace AbrPlus.Integration.OpenERP.Api.Contracts
{
    /// <summary>
    /// The main <c>IContract</c> interface.
    /// <para>Interface for Contract. contains methods to support Contract. Creates a proxy for Contract.</para>
    /// </summary>
    /// <see cref="IBaseIntegrationApi{T}"/>
    /// <seealso cref="ContractBundle"/>
    [ServiceContract]
    public interface IContractApi : IBaseIntegrationApi<ContractBundle>
    {
    }
}
