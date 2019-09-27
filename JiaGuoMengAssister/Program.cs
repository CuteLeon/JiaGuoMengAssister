using System;
using JiaGuoMengAssister.Models;
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
