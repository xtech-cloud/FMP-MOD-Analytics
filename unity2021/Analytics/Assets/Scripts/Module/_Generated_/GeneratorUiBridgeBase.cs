
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.80.1.  DO NOT EDIT!
//*************************************************************************************

using System;
using System.Threading;
using LibMVCS = XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.Analytics.LIB.Bridge;

namespace XTC.FMP.MOD.Analytics.LIB.Unity
{

    public class GeneratorUiBridgeBase : IGeneratorUiBridge
    {
        public LibMVCS.Logger logger { get; set; }

        public virtual void Alert(string _code, string _message, object _context)
        {
            throw new NotImplementedException();
        }


        public virtual void RefreshRecord(IDTO _dto, object _context)
        {
            throw new NotImplementedException();
        }

    }
}
