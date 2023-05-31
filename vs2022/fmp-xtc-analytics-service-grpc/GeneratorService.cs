
using Grpc.Core;
using System.Buffers.Text;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;
using XTC.FMP.MOD.Analytics.LIB.Proto;

namespace XTC.FMP.MOD.Analytics.App.Service
{
    public class GeneratorService : GeneratorServiceBase
    {
        private readonly SingletonServices singletonServices_;
        private readonly JsonSerializerOptions jsonSerializerOptions_;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <remarks>
        /// 支持多个参数，均为自动注入，注入点位于MyProgram.PreBuild
        /// </remarks>
        /// <param name="_singletonServices">自动注入的单例服务</param>
        public GeneratorService(SingletonServices _singletonServices)
        {
            singletonServices_ = _singletonServices;
            jsonSerializerOptions_ = new JsonSerializerOptions
            {
                //Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
        }

        protected override async Task<GeneratorRecordResponse> safeRecord(GeneratorRecordRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredNumber((int)_request.StartTime, "startTime");
            ArgumentChecker.CheckRequiredNumber((int)_request.EndTime, "endTime");

            int count = _request.Count == 0 ? int.MaxValue : (int)_request.Count;
            var dao = singletonServices_.getRecordDAO();
            var entityS = await dao.SearchAsync((int)_request.Offset, count, _request.AppID, _request.SerialNumber, _request.UserID, _request.EventID, _request.EventParameter, _request.StartTime, _request.EndTime);
            string content;
            if (string.IsNullOrEmpty(_request.Template))
            {
                content = JsonSerializer.Serialize(entityS, jsonSerializerOptions_);
            }
            else
            {
                //TODO 使用模板
                content = JsonSerializer.Serialize(entityS);
            }

            content = Convert.ToBase64String(Encoding.UTF8.GetBytes(content));
            return new GeneratorRecordResponse
            {
                Status = new LIB.Proto.Status { Code = 0, Message = "" },
                Content = content
            };
        }
    }
}
