

using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using LibMVCS = XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.Analytics.LIB.Proto;
using XTC.FMP.MOD.Analytics.LIB.MVCS;

namespace XTC.FMP.MOD.Analytics.LIB.Unity
{
    /// <summary>
    /// 实例类
    /// </summary>
    public class MyInstance : MyInstanceBase
    {
        private string serialNumber_ = "";

        public MyInstance(string _uid, string _style, MyConfig _config, MyCatalog _catalog, LibMVCS.Logger _logger, Dictionary<string, LibMVCS.Any> _settings, MyEntryBase _entry, MonoBehaviour _mono, GameObject _rootAttachments)
            : base(_uid, _style, _config, _catalog, _logger, _settings, _entry, _mono, _rootAttachments)
        {
            serialNumber_ = _settings["serialnumber"].AsString();
        }

        /// <summary>
        /// 当被创建时
        /// </summary>
        /// <remarks>
        /// 可用于加载主题目录的数据
        /// </remarks>
        public void HandleCreated()
        {
        }

        /// <summary>
        /// 当被删除时
        /// </summary>
        public void HandleDeleted()
        {
        }

        /// <summary>
        /// 当被打开时
        /// </summary>
        /// <remarks>
        /// 可用于加载内容目录的数据
        /// </remarks>
        public void HandleOpened(string _source, string _uri)
        {
            rootUI.gameObject.SetActive(true);
            rootWorld.gameObject.SetActive(true);
        }

        /// <summary>
        /// 当被关闭时
        /// </summary>
        public void HandleClosed()
        {
            rootUI.gameObject.SetActive(false);
            rootWorld.gameObject.SetActive(false);
        }

        public void Record(string _eventID, string _eventParameter)
        {
            Task.Run(async () =>
            {
                var request = new TrackerRecordRequest();
                request.AppID = style_.tracker.appID;
                request.SerialNumber = serialNumber_;
                request.UserID = "";
                request.EventID = _eventID;
                request.EventParameter = _eventParameter;
                var dto = new TrackerRecordRequestDTO(request);
                var error = await viewBridgeTracker.OnRecordSubmit(dto, null);
                if (error.getCode() != 0)
                {
                    Debug.LogError(error.getMessage());
                }
            });

        }
    }
}
