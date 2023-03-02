
using System;
using LibMVCS = XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.Analytics.LIB.Bridge;
using XTC.FMP.MOD.Analytics.LIB.MVCS;
using XTC.FMP.LIB.MVCS;
using System.Collections.Generic;

namespace XTC.FMP.MOD.Analytics.LIB.Unity
{
    /// <summary>
    /// 虚拟视图，用于处理消息订阅
    /// </summary>
    public class DummyView : DummyViewBase
    {
        public DummyView(string _uid) : base(_uid)
        {
        }

        protected override void setup()
        {
            base.setup();
            addSubscriber(MySubject.TrackerRecord, handleTrackerRecord);
        }

        private void handleTrackerRecord(Model.Status _status, object _data)
        {
            string uuid = "";
            string eventID = "";
            string eventParameter = "";
            try
            {
                Dictionary<string, object> dict = _data as Dictionary<string, object>;
                uuid = dict["uid"] as string;
                eventID = dict["eventID"] as string;
                eventParameter = dict["eventParameter"] as string;
            }
            catch (Exception ex)
            {
                getLogger().Exception(ex);
            }
            MyInstance instance;
            runtime.instances.TryGetValue(uuid, out instance);
            if (null == instance)
            {
                getLogger().Error("instance {0} not found", uuid);
                return;
            }
            instance.Record(eventID, eventParameter);
        }
    }
}

