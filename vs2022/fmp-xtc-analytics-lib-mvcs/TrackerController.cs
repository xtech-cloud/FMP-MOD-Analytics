
namespace XTC.FMP.MOD.Analytics.LIB.MVCS
{
    /// <summary>
    /// Tracker控制层
    /// </summary>
    public class TrackerController : TrackerControllerBase
    {
        /// <summary>
        /// 完整名称
        /// </summary>
        public const string NAME = "XTC.FMP.MOD.Analytics.LIB.MVCS.TrackerController";

        /// <summary>
        /// 带uid参数的构造函数
        /// </summary>
        /// <param name="_uid">实例化后的唯一识别码</param>
        /// <param name="_gid">直系的组的ID</param>
        public TrackerController(string _uid, string _gid) : base(_uid, _gid) 
        {
        }
    }
}

