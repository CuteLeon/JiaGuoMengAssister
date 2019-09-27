namespace JiaGuoMengAssister.Models.Policies
{
    /// <summary>
    /// 建筑政策
    /// </summary>
    public class BuildingPolicy : PolicyBase
    {
        /// <summary>
        /// 来源建筑物
        /// </summary>
        public Building SourceBuilding { get; set; }

        /// <summary>
        /// 目标建筑物
        /// </summary>
        public Building TargetBuilding { get; set; }
    }
}
