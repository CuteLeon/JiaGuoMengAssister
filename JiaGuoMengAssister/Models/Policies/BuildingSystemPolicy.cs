using JiaGuoMengAssister.Enums;
using JiaGuoMengAssister.Models.Buildings;

namespace JiaGuoMengAssister.Models.Policies
{
    /// <summary>
    /// 建筑物体系政策
    /// </summary>
    public class BuildingSystemPolicy : PolicyBase
    {
        /// <summary>
        /// 来源建筑物
        /// </summary>
        public Building SourceBuilding { get; set; }

        /// <summary>
        /// 体系
        /// </summary>
        public SystemTypes System { get; set; }
    }
}
