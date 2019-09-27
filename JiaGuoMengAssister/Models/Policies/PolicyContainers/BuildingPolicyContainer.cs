using System.Collections.Generic;

namespace JiaGuoMengAssister.Models.Policies.PolicyContainers
{
    public class BuildingPolicyContainer : Dictionary<string, BuildingPolicy>, IPolicyContainer
    {
    }
}
