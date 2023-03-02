
using Microsoft.AspNetCore.Components;
using XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.Analytics.LIB.Proto;
using XTC.FMP.MOD.Analytics.LIB.Bridge;
using XTC.FMP.MOD.Analytics.LIB.MVCS;

namespace XTC.FMP.MOD.Analytics.LIB.Razor
{
    public partial class GeneratorComponent
    {
        public class GeneratorUiBridge : IGeneratorUiBridge
        {

            public GeneratorUiBridge(GeneratorComponent _razor)
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
                var dto = _dto as GeneratorRecordResponseDTO;
                razor_.__debugRecord = dto?.Value.ToString();
            }


            private GeneratorComponent razor_;
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        private async Task __debugClick()
        {
            var bridge = (getFacade()?.getViewBridge() as IGeneratorViewBridge);
            if (null == bridge)
            {
                logger_?.Error("bridge is null");
                return;
            }

            var reqRecord = new GeneratorRecordRequest();
            var dtoRecord = new GeneratorRecordRequestDTO(reqRecord);
            logger_?.Trace("invoke OnRecordSubmit");
            await bridge.OnRecordSubmit(dtoRecord, null);

        }


        private string? __debugRecord;

    }
}
