using System.Collections.Generic;

namespace JiaGuoMengAssister.Models.Policies.PolicyContainers
{
    public class PolicyContainerBase<TBinding, TPolicyBase> : Dictionary<TBinding, TPolicyBase>, IPolicyContainer
        where TPolicyBase : PolicyBase
    {
    }
}
