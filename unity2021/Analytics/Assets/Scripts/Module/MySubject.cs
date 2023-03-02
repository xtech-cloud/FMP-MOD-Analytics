
namespace XTC.FMP.MOD.Analytics.LIB.Unity
{
    public class MySubject : MySubjectBase
    {
        /// <summary>
        /// ʹ�ø���������һ����¼
        /// </summary>
        /// <example>
        /// var data = new Dictionary<string, object>();
        /// data["uid"] = "default";
        /// data["eventID"] = "�¼���id";
        /// data["eventParameter"] = "�¼��Ĳ���";
        /// model.Publish(/XTC/Analytics/TrackerRecord, data);
        /// </example>
        public const string TrackerRecord = "/XTC/Analytics/TrackerRecord";
    }
}
