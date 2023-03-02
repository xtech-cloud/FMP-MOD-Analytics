
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System.Threading.Tasks;
using XTC.FMP.MOD.Analytics.LIB.Proto;

namespace XTC.FMP.MOD.Analytics.App.Service
{
    public class TrackerService : TrackerServiceBase
    {
        private readonly SingletonServices singletonServices_;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <remarks>
        /// 支持多个参数，均为自动注入，注入点位于MyProgram.PreBuild
        /// </remarks>
        /// <param name="_singletonServices">自动注入的单例服务</param>
        public TrackerService(SingletonServices _singletonServices)
        {
            singletonServices_ = _singletonServices;
        }

        protected override async Task<BlankResponse> safeRecord(TrackerRecordRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.AppID, "appID");
            ArgumentChecker.CheckRequiredString(_request.SerialNumber, "serialNumber");
            ArgumentChecker.CheckRequiredString(_request.EventID, "eventID");

            //单位毫秒
            long timestamp = (DateTime.UtcNow.Ticks - new DateTime(1970, 1, 1, 0, 0, 0, 0).Ticks) / 10000;

            var dao = singletonServices_.getRecordDAO();
            var entity = new RecordEntity
            {
                Uuid = Guid.NewGuid(),
                AppID = _request.AppID,
                SerialNumber = _request.SerialNumber,
                UserID = _request.UserID,
                EventID = _request.EventID,
                EventParameter = _request.EventParameter,
                Timestamp = timestamp,
            };
            await dao.CreateAsync(entity);

            return new BlankResponse
            {
                Status = new LIB.Proto.Status() { Code = 0, Message = "" }
            };
        }

    }
}
