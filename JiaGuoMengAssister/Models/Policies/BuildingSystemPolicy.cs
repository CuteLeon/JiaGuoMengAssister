using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using JiaGuoMengAssister.Enums;
using JiaGuoMengAssister.Models.Buildings;

namespace JiaGuoMengAssister.Models.Policies
{
    /// <summary>
    /// 建筑物体系政策
    /// </summary>
    public class BuildingSystemPolicy : PolicyBase, IEqualityComparer<BuildingSystemPolicy>
    {
        /// <summary>
        /// 来源建筑物
        /// </summary>
        public Building SourceBuilding { get; set; }

        /// <summary>
        /// 体系
        /// </summary>
        public SystemTypes System { get; set; }

        /// <summary>
        /// 一对<建筑物, 体系> 仅存在唯一政策
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals([AllowNull] BuildingSystemPolicy x, [AllowNull] BuildingSystemPolicy y)
            => x.SourceBuilding.Equals(y.SourceBuilding) && x.System == y.System;

        public int GetHashCode([DisallowNull] BuildingSystemPolicy obj) => obj.GetHashCode();
    }
}
