
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.88.0.  DO NOT EDIT!
//*************************************************************************************

using System.Threading.Tasks;
using XTC.FMP.MOD.Analytics.LIB.Proto;

namespace XTC.FMP.MOD.Analytics.LIB.MVCS
{
    /// <summary>
    /// Tracker服务模拟类
    /// </summary>
    public class TrackerServiceMock
    {


        public System.Func<TrackerRecordRequest, Task<BlankResponse>>? CallRecordDelegate { get; set; } = null;

    }
}
