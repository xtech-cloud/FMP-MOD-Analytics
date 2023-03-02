
namespace XTC.FMP.MOD.Analytics.LIB.Unity
{
    public class MySubject : MySubjectBase
    {
        /// <summary>
        /// 使用跟踪器保存一条记录
        /// </summary>
        /// <example>
        /// var data = new Dictionary<string, object>();
        /// data["uid"] = "default";
        /// data["eventID"] = "事件的id";
        /// data["eventParameter"] = "事件的参数";
        /// model.Publish(/XTC/Analytics/TrackerRecord, data);
        /// </example>
        public const string TrackerRecord = "/XTC/Analytics/TrackerRecord";
    }
}
