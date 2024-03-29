
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.88.0.  DO NOT EDIT!
//*************************************************************************************

using System.Threading;
using XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.Analytics.LIB.Proto;

namespace XTC.FMP.MOD.Analytics.LIB.MVCS
{
    /// <summary>
    /// Tracker控制层基类
    /// </summary>
    public class TrackerControllerBase : Controller
    {
        /// <summary>
        /// 带uid参数的构造函数
        /// </summary>
        /// <param name="_uid">实例化后的唯一识别码</param>
        /// <param name="_gid">直系的组的ID</param>
        public TrackerControllerBase(string _uid, string _gid) : base(_uid)
        {
            gid_ = _gid;
        }


        /// <summary>
        /// 更新Record的数据
        /// </summary>
        /// <param name="_status">直系状态</param>
        /// <param name="_response">Record的回复</param>
        public virtual void UpdateProtoRecord(TrackerModel.TrackerStatus? _status, BlankResponse _response, object? _context)
        {
            Error err = new Error(_response.Status.Code, _response.Status.Message);
            BlankResponseDTO? dto = new BlankResponseDTO(_response);
            getView()?.RefreshProtoRecord(err, dto, _context);
        }


        /// <summary>
        /// 获取直系视图层
        /// </summary>
        /// <returns>视图层</returns>
        protected TrackerView? getView()
        {
            if(null == view_)
                view_ = findView(TrackerView.NAME + "." + gid_) as TrackerView;
            return view_;
        }

        /// <summary>
        /// 直系的MVCS的四个组件的组的ID
        /// </summary>
        protected string gid_ = "";

        /// <summary>
        /// 直系视图层
        /// </summary>
        private TrackerView? view_;
    }
}
