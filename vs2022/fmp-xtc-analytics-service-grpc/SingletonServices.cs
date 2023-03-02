
using Grpc.Core;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Threading.Tasks;
using XTC.FMP.MOD.Analytics.LIB.Proto;

namespace XTC.FMP.MOD.Analytics.App.Service
{
    public class SingletonServices 
    {
        
        private MongoClient mongoClient_;
        private IMongoDatabase mongoDatabase_;
        private RecordDAO daoRecord_;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <remarks>
        /// 参数为自动注入，支持多个参数，DatabaseSettings的注入点在Program.cs中，自定义设置可在MyProgram.PreBuild中注入
        /// </remarks>
        public SingletonServices(IOptions<DatabaseSettings> _databaseSettings)
        {
            mongoClient_ = new MongoClient(_databaseSettings.Value.ConnectionString);
            mongoDatabase_ = mongoClient_.GetDatabase(_databaseSettings.Value.DatabaseName);

            daoRecord_ = new RecordDAO(mongoDatabase_);
        }

        public RecordDAO getRecordDAO()
        {
            return daoRecord_;
        }
    }
}
