using JiaGuoMengAssister.Enums;

namespace JiaGuoMengAssister.Models.Policies
{
    /// <summary>
    /// 系统政策
    /// </summary>
    public class SystemPolicy : PolicyBase
    {
        /// <summary>
        /// 体系
        /// </summary>
        public SystemTypes System { get; set; }
    }
}
