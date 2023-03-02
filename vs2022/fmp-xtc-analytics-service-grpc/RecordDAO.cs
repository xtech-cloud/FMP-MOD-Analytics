using MongoDB.Driver;

namespace XTC.FMP.MOD.Analytics.App.Service
{
    public class RecordDAO : MongoDAO<RecordEntity>
    {
        public RecordDAO(IMongoDatabase _mongoDatabase)
            : base(_mongoDatabase, "Record")
        {
        }

        /// <summary>
        /// 异步查询实体
        /// </summary>
        /// <param name="_offset">偏移量</param>
        /// <param name="_count">查询量</param>
        /// <returns></returns>
        public virtual async Task<List<RecordEntity>> SearchAsync(int _offset, int _count, string _appID, string _serialNumber, string _userID, string _eventID, string _eventParameter, long _startTime, long _endTime)
        {
            return await collection_.Find(x=>
            (string.IsNullOrEmpty(_appID) || x.AppID == _appID) &&
            (string.IsNullOrEmpty(_serialNumber) || x.SerialNumber == _serialNumber) &&
            (string.IsNullOrEmpty(_userID) || x.UserID == _userID) &&
            (string.IsNullOrEmpty(_eventID) || x.EventID == _eventID) &&
            (string.IsNullOrEmpty(_eventParameter) || x.EventParameter== _eventParameter) &&
            (x.Timestamp >= _startTime) &&
            (x.Timestamp <= _endTime)
            ).Skip(_offset).Limit(_count).ToListAsync();
        }
    }
}
