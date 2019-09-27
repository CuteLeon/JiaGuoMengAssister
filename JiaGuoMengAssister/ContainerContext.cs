using JiaGuoMengAssister.Models;
using JiaGuoMengAssister.Models.Policies.PolicyContainers;

namespace JiaGuoMengAssister
{
    /// <summary>
    /// 容器交互
    /// </summary>
    public class ContainerContext
    {
        public IBuildingContainer BuildingContainer { get; set; }

        public IBuildingPolicyContainer BuildingPolicyContainer { get; set; }

        public ISystemPolicyContainer SystemPolicyContainer { get; set; }
    }
}
