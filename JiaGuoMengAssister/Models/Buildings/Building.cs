using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using JiaGuoMengAssister.Enums;

namespace JiaGuoMengAssister.Models.Buildings
{
    /// <summary>
    /// 建筑物
    /// </summary>
    public class Building : IEqualityComparer<Building>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public SystemTypes Type { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 稀缺程度
        /// </summary>
        public ScarcityDegrees Scarcity { get; set; }

        /// <summary>
        /// 收入 (每秒)
        /// </summary>
        public int Income { get; set; }

        public bool Equals([AllowNull] Building x, [AllowNull] Building y)
            => x.Name.Equals(y.Name, StringComparison.OrdinalIgnoreCase);

        public int GetHashCode([DisallowNull] Building obj) => obj.GetHashCode();
    }
}
