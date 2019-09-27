using System.Collections.Generic;

namespace JiaGuoMengAssister.Models.Policies.PolicyContainers
{
    public interface IBuildingPolicyContainer : IPolicyContainer, IDictionary<string, BuildingPolicy>
    {
    }
}
