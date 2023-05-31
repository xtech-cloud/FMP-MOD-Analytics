
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.88.0.  DO NOT EDIT!
//*************************************************************************************

using System;
using System.IO;
using UnityEngine;

namespace XTC.FMP.MOD.Analytics.LIB.Unity
{
    /// <summary>
    /// 内容读取器
    /// </summary>
    public class AssetReader
    {
        protected ObjectsPool assetObjectsPool_ { get; private set; }

        public AssetReader(ObjectsPool _assetObjectsPool)
        {
            assetObjectsPool_ = _assetObjectsPool;
        }

        /// <summary>
        /// 资产库的根目录的绝对路径
        /// </summary>
        public string AssetRootPath { get; set; }

        /// <summary>
        /// 加载纹理
        /// </summary>
        /// <param name="_file">文件在AssetRootPath中的相对路径</param>
        public void LoadTexture(string _file, Action<Texture2D> _onFinish, Action _onError)
        {
            string filefullpath = Path.Combine(AssetRootPath, _file);
            assetObjectsPool_.LoadTexture(filefullpath, null, _onFinish, _onError);
        }

        /// <summary>
        /// 加载文本
        /// </summary>
        /// <param name="_file">文件在AssetRootPath中的相对路径</param>
        public void LoadText(string _file, Action<byte[]> _onFinish, Action _onError)
        {
            string filefullpath = Path.Combine(AssetRootPath, _file);
            assetObjectsPool_.LoadText(filefullpath, null, _onFinish, _onError);
        }
    }
}
