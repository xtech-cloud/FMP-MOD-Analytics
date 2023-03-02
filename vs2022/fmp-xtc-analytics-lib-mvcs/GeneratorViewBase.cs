
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.80.1.  DO NOT EDIT!
//*************************************************************************************

using System.Threading;
using XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.Analytics.LIB.Bridge;

namespace XTC.FMP.MOD.Analytics.LIB.MVCS
{
    /// <summary>
    /// Generator视图层基类
    /// </summary>
    public class GeneratorViewBase : View
    {
        /// <summary>
        /// 带uid参数的构造函数
        /// </summary>
        /// <param name="_uid">实例化后的唯一识别码</param>
        /// <param name="_gid">直系的组的ID</param>
        public GeneratorViewBase(string _uid, string _gid) : base(_uid)
        {
            gid_ = _gid;
        }


        /// <summary>
        /// 刷新Record的数据
        /// </summary>
        /// <param name="_err">错误</param>
        /// <param name="_dto">GeneratorRecordResponse的数据传输对象</param>
        public virtual void RefreshProtoRecord(Error _err, GeneratorRecordResponseDTO _dto, object? _context)
        {
            var bridge = getFacade()?.getUiBridge() as IGeneratorUiBridge; 
            if (!Error.IsOK(_err))
            {
                bridge?.Alert(string.Format("errcode_Record_{0}", _err.getCode()), _err.getMessage(), _context);
                return;
            }
            bridge?.RefreshRecord(_dto, _context);
        }


        /// <summary>
        /// 获取直系数据层
        /// </summary>
        /// <returns>数据层</returns>
        protected GeneratorModel? getModel()
        {
            if(null == model_)
                model_ = findModel(GeneratorModel.NAME + "." + gid_) as GeneratorModel;
            return model_;
        }

        /// <summary>
        /// 获取直系服务层
        /// </summary>
        /// <returns>服务层</returns>
        protected GeneratorService? getService()
        {
            if(null == service_)
                service_ = findService(GeneratorService.NAME + "." + gid_) as GeneratorService;
            return service_;
        }

        /// <summary>
        /// 获取直系UI装饰层
        /// </summary>
        /// <returns>UI装饰层</returns>
        protected GeneratorFacade? getFacade()
        {
            if(null == facade_)
                facade_ = findFacade(GeneratorFacade.NAME + "." + gid_) as GeneratorFacade;
            return facade_;
        }

        /// <summary>
        /// 直系的MVCS的四个组件的组的ID
        /// </summary>
        protected string gid_ = "";

        /// <summary>
        /// 直系数据层
        /// </summary>
        private GeneratorModel? model_;

        /// <summary>
        /// 直系服务层
        /// </summary>
        private GeneratorService? service_;

        /// <summary>
        /// 直系UI装饰层
        /// </summary>
        private GeneratorFacade? facade_;
    }
}

