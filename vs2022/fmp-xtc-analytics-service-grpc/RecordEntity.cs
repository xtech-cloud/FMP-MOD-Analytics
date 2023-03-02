namespace XTC.FMP.MOD.Analytics.App.Service
{
    public class RecordEntity : Entity
    {
        /// <summary>
        /// 应用程序ID
        /// </summary>
        public string AppID { get; set; } = "";

        /// <summary>
        /// 序列号
        /// </summary>
        public string SerialNumber { get; set; } = "";

        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID { get; set; } = "";

        /// <summary>
        /// 事件ID
        /// </summary>
        public string EventID { get; set; } = "";

        /// <summary>
        /// 事件参数
        /// </summary>
        public string EventParameter { get; set; } = "";

        /// <summary>
        /// 记录的时间戳
        /// </summary>
        public long Timestamp { get; set; } = 0;

    }
}
