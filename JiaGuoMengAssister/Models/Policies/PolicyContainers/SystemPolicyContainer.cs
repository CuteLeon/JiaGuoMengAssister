using System.Collections.Generic;
using JiaGuoMengAssister.Enums;

namespace JiaGuoMengAssister.Models.Policies.PolicyContainers
{
    public class SystemPolicyContainer : Dictionary<SystemTypes, SystemPolicy>, IPolicyContainer
    {
    }
}
