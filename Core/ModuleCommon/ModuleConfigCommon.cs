
using Gac;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Gac
{
    public class ModuleConfigCommon
    {
        /// <summary>
        /// 通过XML代码获取模块配置信息
        /// </summary>
        /// <param name="xmldata">要转换的XML代码</param>
        /// <returns>返回转换后的模块配置信息</returns>
        public ModuleConfigInfo GetModuleConfigInfo(string xmldata)
        {
            
            
            XmlSerializerHelper xsh = new XmlSerializerHelper();
            ModuleConfigInfo module = new ModuleConfigInfo();
            try
            {
                module=(ModuleConfigInfo)xsh.LoadFromXml(xmldata, module.GetType());
            }
            catch (Exception ex)
            {
                Console.WriteLine("获取模块配置信息时发生错误:" + ex.Message);
            }
            return module;
        }
        /// <summary>
        /// 模块信息转换为XML代码
        /// </summary>
        /// <param name="mci">模块配置信息</param>
        /// <returns>返回转换后的xml代码</returns>
        public string GetXmlData(ModuleConfigInfo mci)
        {
            XmlSerializerHelper xsh = new XmlSerializerHelper();
            try
            {
                string xmlstr=xsh.GetXmlCode(mci, mci.GetType(), "root");
                return xmlstr;
            }
            catch (Exception ex)
            {
                Console.WriteLine("转换模块配置时发生错误:" + ex.Message);
                return "";
            }
        }


        ///// <summary>
        ///// 通过XML代码获取模块配置信息
        ///// </summary>
        ///// <param name="xmldata">要转换的XML代码</param>
        ///// <returns>返回转换后的模块配置信息</returns>
        //public ModuleConfigInfo GetModuleConfigInfo(string xmldata)
        //{
        //    XmlHelper xml = new XmlHelper();
        //    ModuleConfigInfo module = new ModuleConfigInfo();
        //    try
        //    {
        //        module = xml.XmlToEntity<ModuleConfigInfo>(xmldata);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("获取模块配置信息时发生错误:" + ex.Message);
        //    }
        //    return module;
        //}
        ///// <summary>
        ///// 模块信息转换为XML代码
        ///// </summary>
        ///// <param name="mci">模块配置信息</param>
        ///// <returns>返回转换后的xml代码</returns>
        //public string GetXmlData(ModuleConfigInfo mci)
        //{
        //    XmlHelper xml = new XmlHelper();
        //    try
        //    {
        //        string xmlstr = xml.EntityToXml<ModuleInfo>(mci);
        //        return xmlstr;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("转换模块配置时发生错误:" + ex.Message);
        //        return "";
        //    }
        //}

    }
}
