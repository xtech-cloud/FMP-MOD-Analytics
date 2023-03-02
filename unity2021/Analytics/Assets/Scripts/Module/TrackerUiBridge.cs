
using System;
using LibMVCS = XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.Analytics.LIB.MVCS;
using XTC.FMP.MOD.Analytics.LIB.Bridge;

namespace XTC.FMP.MOD.Analytics.LIB.Unity
{
    public class TrackerUiBridge : TrackerUiBridgeBase
    {
        public override void RefreshRecord(IDTO _dto, object _context)
        {
            var dto = _dto as BlankResponseDTO;
            if (dto.Value.Status.Code == 0)
                logger.Trace("Record success");
            else
                logger.Error("Record failure");
        }
    }
}
