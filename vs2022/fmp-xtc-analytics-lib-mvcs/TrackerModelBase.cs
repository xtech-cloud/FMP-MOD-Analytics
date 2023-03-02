
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.80.1.  DO NOT EDIT!
//*************************************************************************************

using System.Threading;
using XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.Analytics.LIB.Proto;

namespace XTC.FMP.MOD.Analytics.LIB.MVCS
{
    /// <summary>
    /// Tracker数据层基类
    /// </summary>
    public class TrackerModelBase : Model
    {
        /// <summary>
        /// 带uid参数的构造函数
        /// </summary>
        /// <param name="_uid">实例化后的唯一识别码</param>
        /// <param name="_gid">直系的组的ID</param>
        public TrackerModelBase(string _uid, string _gid) : base(_uid)
        {
            gid_ = _gid;
        }


        /// <summary>
        /// 更新Record的数据
        /// </summary>
        /// <param name="_response">Record的回复</param>
        public virtual void UpdateProtoRecord(BlankResponse _response, object? _context)
        {
            getController()?.UpdateProtoRecord(status_ as TrackerModel.TrackerStatus, _response, _context);
        }


        /// <summary>
        /// 获取直系控制层
        /// </summary>
        /// <returns>控制层</returns>
        protected TrackerController? getController()
        {
            if(null == controller_)
                controller_ = findController(TrackerController.NAME + "." + gid_) as TrackerController;
            return controller_;
        }

        /// <summary>
        /// 直系的MVCS的四个组件的组的ID
        /// </summary>
        protected string gid_ = "";

        /// <summary>
        /// 直系控制层
        /// </summary>
        private TrackerController? controller_;
    }
}

