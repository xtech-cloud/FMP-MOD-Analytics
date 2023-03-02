
using System.Xml.Serialization;
using UnityEngine;

namespace XTC.FMP.MOD.Analytics.LIB.Unity
{
    /// <summary>
    /// 配置类
    /// </summary>
    public class MyConfig : MyConfigBase
    {
        public class Tracker
        {
            [XmlAttribute("appID")]
            public string appID { get; set; } = Application.productName;
        }

        public class Style
        {
            [XmlAttribute("name")]
            public string name { get; set; } = "";

            [XmlElement("Tracker")]
            public Tracker tracker { get; set; } = new Tracker();
        }


        [XmlArray("Styles"), XmlArrayItem("Style")]
        public Style[] styles { get; set; } = new Style[0];
    }
}

