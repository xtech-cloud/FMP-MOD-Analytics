
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.88.0.  DO NOT EDIT!
//*************************************************************************************

using System.Net;
using Grpc.Core;
using System.Threading.Tasks;
using XTC.FMP.MOD.Analytics.LIB.Proto;

namespace XTC.FMP.MOD.Analytics.App.Service
{
    /// <summary>
    /// Generator基类
    /// </summary>
    public class GeneratorServiceBase : LIB.Proto.Generator.GeneratorBase
    {
    

        public override async Task<GeneratorRecordResponse> Record(GeneratorRecordRequest _request, ServerCallContext _context)
        {
            try
            {
                return await safeRecord(_request, _context);
            }
            catch (ArgumentRequiredException ex)
            {
                return await Task.Run(() => new GeneratorRecordResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.BadRequest.GetHashCode(), Message = ex.Message },
                });
            }
            catch (Exception ex)
            {
                return await Task.Run(() => new GeneratorRecordResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.InternalServerError.GetHashCode(), Message = ex.Message },
                });
            }
        }



        protected virtual async Task<GeneratorRecordResponse> safeRecord(GeneratorRecordRequest _request, ServerCallContext _context)
        {
            return await Task.Run(() => new GeneratorRecordResponse {
                    Status = new LIB.Proto.Status() { Code = -1, Message = "Not Implemented" },
            });
        }

    }
}

