using System;
using JiaGuoMengAssister.Enums;
using JiaGuoMengAssister.Models.Buildings;
using JiaGuoMengAssister.Models.Policies.PolicyContainers;

namespace JiaGuoMengAssister
{
    class Program
    {
        /// <summary>
        /// 容器交互
        /// </summary>
        public static ContainerContext ContainerContext { get; set; }

        /// <summary>
        /// 全部建筑容器
        /// </summary>
        public static IBuildingContainer TotalBuildingContainer { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("正在初始化...");
            ContainerContext = new ContainerContext();
            ContainerContext.BuildingContainer = CreateBuildingContainer();
            ContainerContext.BuildingPolicyContainer = CreateBuildingPolicyContainer();
            ContainerContext.SystemPolicyContainer = CreateSystemPolicyContainer();
            TotalBuildingContainer = CreateTotalBuildingContainer();

            Console.ReadLine();
        }

        /// <summary>
        /// 创建所有建筑物容器
        /// </summary>
        /// <returns></returns>
        private static IBuildingContainer CreateTotalBuildingContainer()
        {
            IBuildingContainer container = new BuildingContainer();
            container.Add("平房", new Building() { Name = "平房", Type = SystemTypes.House, Scarcity = ScarcityDegrees.Ordinary });
            container.Add("居民楼", new Building() { Name = "居民楼", Type = SystemTypes.House, Scarcity = ScarcityDegrees.Ordinary });
            container.Add("木屋", new Building() { Name = "木屋", Type = SystemTypes.House, Scarcity = ScarcityDegrees.Ordinary });
            container.Add("钢结构房", new Building() { Name = "钢结构房", Type = SystemTypes.House, Scarcity = ScarcityDegrees.Ordinary });
            container.Add("空中别墅", new Building() { Name = "空中别墅", Type = SystemTypes.House, Scarcity = ScarcityDegrees.Epic });
            container.Add("复兴公馆", new Building() { Name = "复兴公馆", Type = SystemTypes.House, Scarcity = ScarcityDegrees.Epic });
            container.Add("人才公寓", new Building() { Name = "人才公寓", Type = SystemTypes.House, Scarcity = ScarcityDegrees.Rare });
            container.Add("花园洋房", new Building() { Name = "花园洋房", Type = SystemTypes.House, Scarcity = ScarcityDegrees.Rare });
            container.Add("中式小楼", new Building() { Name = "中式小楼", Type = SystemTypes.House, Scarcity = ScarcityDegrees.Rare });
            container.Add("小型公寓", new Building() { Name = "小型公寓", Type = SystemTypes.House, Scarcity = ScarcityDegrees.Rare });

            container.Add("五金店", new Building() { Name = "五金店", Type = SystemTypes.Business, Scarcity = ScarcityDegrees.Ordinary });
            container.Add("便利店", new Building() { Name = "便利店", Type = SystemTypes.Business, Scarcity = ScarcityDegrees.Ordinary });
            container.Add("菜市场", new Building() { Name = "菜市场", Type = SystemTypes.Business, Scarcity = ScarcityDegrees.Ordinary });
            container.Add("学校", new Building() { Name = "学校", Type = SystemTypes.Business, Scarcity = ScarcityDegrees.Ordinary });
            container.Add("服装店", new Building() { Name = "服装店", Type = SystemTypes.Business, Scarcity = ScarcityDegrees.Ordinary });
            container.Add("民食斋", new Building() { Name = "民食斋", Type = SystemTypes.Business, Scarcity = ScarcityDegrees.Epic });
            container.Add("图书城", new Building() { Name = "图书城", Type = SystemTypes.Business, Scarcity = ScarcityDegrees.Rare });
            container.Add("媒体之声", new Building() { Name = "媒体之声", Type = SystemTypes.Business, Scarcity = ScarcityDegrees.Epic });
            container.Add("商贸中心", new Building() { Name = "商贸中心", Type = SystemTypes.Business, Scarcity = ScarcityDegrees.Rare });
            container.Add("加油站", new Building() { Name = "加油站", Type = SystemTypes.Business, Scarcity = ScarcityDegrees.Rare });

            container.Add("木材厂", new Building() { Name = "木材厂", Type = SystemTypes.Industry, Scarcity = ScarcityDegrees.Ordinary });
            container.Add("食品厂", new Building() { Name = "食品厂", Type = SystemTypes.Industry, Scarcity = ScarcityDegrees.Ordinary });
            container.Add("纺织厂", new Building() { Name = "纺织厂", Type = SystemTypes.Industry, Scarcity = ScarcityDegrees.Rare });
            container.Add("造纸厂", new Building() { Name = "造纸厂", Type = SystemTypes.Industry, Scarcity = ScarcityDegrees.Ordinary });
            container.Add("钢铁厂", new Building() { Name = "钢铁厂", Type = SystemTypes.Industry, Scarcity = ScarcityDegrees.Rare });
            container.Add("电厂", new Building() { Name = "电厂", Type = SystemTypes.Industry, Scarcity = ScarcityDegrees.Ordinary });
            container.Add("企鹅机械", new Building() { Name = "企鹅机械", Type = SystemTypes.Industry, Scarcity = ScarcityDegrees.Epic });
            container.Add("人民石油", new Building() { Name = "人民石油", Type = SystemTypes.Industry, Scarcity = ScarcityDegrees.Epic });
            container.Add("零件厂", new Building() { Name = "零件厂", Type = SystemTypes.Industry, Scarcity = ScarcityDegrees.Rare });
            container.Add("水厂", new Building() { Name = "水厂", Type = SystemTypes.Industry, Scarcity = ScarcityDegrees.Ordinary });

            return container;
        }

        /// <summary>
        /// 创建建筑容器
        /// </summary>
        /// <returns></returns>
        private static IBuildingContainer CreateBuildingContainer()
        {
            IBuildingContainer container = new BuildingContainer();

            return container;
        }

        /// <summary>
        /// 创建建筑政策容器
        /// </summary>
        /// <returns></returns>
        private static IBuildingPolicyContainer CreateBuildingPolicyContainer()
        {
            IBuildingPolicyContainer container = new BuildingPolicyContainer();

            return container;
        }

        /// <summary>
        /// 创建体系政策容器
        /// </summary>
        /// <returns></returns>
        private static ISystemPolicyContainer CreateSystemPolicyContainer()
        {
            ISystemPolicyContainer container = new SystemPolicyContainer();

            return container;
        }
    }
}
