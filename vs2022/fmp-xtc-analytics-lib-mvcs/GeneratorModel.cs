
using XTC.FMP.LIB.MVCS;

namespace XTC.FMP.MOD.Analytics.LIB.MVCS
{
    /// <summary>
    /// Generator数据层
    /// </summary>
    public class GeneratorModel : GeneratorModelBase
    {
        /// <summary>
        /// 完整名称
        /// </summary>
        public const string NAME = "XTC.FMP.MOD.Analytics.LIB.MVCS.GeneratorModel";

        /// <summary>
        /// Generator状态
        /// </summary>
        public class GeneratorStatus : Model.Status
        {
        }

        /// <summary>
        /// 带uid参数的构造函数
        /// </summary>
        /// <param name="_uid">实例化后的唯一识别码</param>
        /// <param name="_gid">直系的组的ID</param>
        public GeneratorModel(string _uid, string _gid) : base(_uid, _gid) 
        {
        }

        protected override void preSetup()
        {
            base.preSetup();

            // 实例化直系状态
            Error err;
            status_ = spawnStatus<GeneratorStatus>(this.getUID() + ".Status", out err);
            if (0 != err.getCode())
            {
                getLogger()?.Error(err.getMessage());
            }
            else
            {
                getLogger()?.Trace("setup {0}", this.getUID() + ".Status");
            }
        }

        protected override void preDismantle()
        {
            base.preDismantle();

            // 销毁直系状态
            Error err;
            killStatus(this.getUID() + ".Status", out err);
            if (0 != err.getCode())
            {
                getLogger()?.Error(err.getMessage());
            }
        }

    }
}


