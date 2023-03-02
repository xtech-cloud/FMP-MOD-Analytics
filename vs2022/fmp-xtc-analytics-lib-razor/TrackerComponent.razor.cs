
using Microsoft.AspNetCore.Components;
using XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.Analytics.LIB.Proto;
using XTC.FMP.MOD.Analytics.LIB.Bridge;
using XTC.FMP.MOD.Analytics.LIB.MVCS;

namespace XTC.FMP.MOD.Analytics.LIB.Razor
{
    public partial class TrackerComponent
    {
        public class TrackerUiBridge : ITrackerUiBridge
        {

            public TrackerUiBridge(TrackerComponent _razor)
            {
                razor_ = _razor;
            }

            public void Alert(string _code, string _message, object? _context)
            {
                if (null == razor_.messageService_)
                    return;
                Task.Run(async () =>
                {
                    await razor_.messageService_.Error(_message);
                }); 
            }


            public void RefreshRecord(IDTO _dto, object? _context)
            {
                var dto = _dto as BlankResponseDTO;
                razor_.__debugRecord = dto?.Value.ToString();
            }


            private TrackerComponent razor_;
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        private async Task __debugClick()
        {
            var bridge = (getFacade()?.getViewBridge() as ITrackerViewBridge);
            if (null == bridge)
            {
                logger_?.Error("bridge is null");
                return;
            }

            var reqRecord = new TrackerRecordRequest();
            var dtoRecord = new TrackerRecordRequestDTO(reqRecord);
            logger_?.Trace("invoke OnRecordSubmit");
            await bridge.OnRecordSubmit(dtoRecord, null);

        }


        private string? __debugRecord;

    }
}
