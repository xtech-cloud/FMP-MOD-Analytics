
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.88.0.  DO NOT EDIT!
//*************************************************************************************

using System.Threading;
using System.Threading.Tasks;
using XTC.FMP.LIB.MVCS;

namespace XTC.FMP.MOD.Analytics.LIB.Bridge
{
    /// <summary>
    /// Generator的视图桥接层（协议部分）
    /// 处理UI的事件
    /// </summary>
    public interface IGeneratorViewProtoBridge : View.Facade.Bridge
    {

        /// <summary>
        /// 处理Record的提交
        /// </summary>
        Task<Error> OnRecordSubmit(IDTO _dto, object? _context);


    }
}

