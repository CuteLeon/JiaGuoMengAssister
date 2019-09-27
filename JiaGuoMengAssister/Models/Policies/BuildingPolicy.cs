using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using JiaGuoMengAssister.Models.Buildings;

namespace JiaGuoMengAssister.Models.Policies
{
    /// <summary>
    /// 建筑政策
    /// </summary>
    public class BuildingPolicy : PolicyBase, IEqualityComparer<BuildingPolicy>
    {
        /// <summary>
        /// 来源建筑物
        /// </summary>
        public Building SourceBuilding { get; set; }

        /// <summary>
        /// 目标建筑物
        /// </summary>
        public Building TargetBuilding { get; set; }

        /// <summary>
        /// 一对<建筑物, 建筑物>之间仅存在唯一政策
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals([AllowNull] BuildingPolicy x, [AllowNull] BuildingPolicy y)
            => x.SourceBuilding.Equals(y.SourceBuilding) && x.TargetBuilding.Equals(y.TargetBuilding);

        public int GetHashCode([DisallowNull] BuildingPolicy obj) => obj.GetHashCode();
    }
}
