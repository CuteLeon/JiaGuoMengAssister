using System.Collections.Generic;
using JiaGuoMengAssister.Enums;

namespace JiaGuoMengAssister.Models.Policies.PolicyContainers
{
    public interface ISystemPolicyContainer : IPolicyContainer, IDictionary<SystemTypes, SystemPolicy>
    {
    }
}
