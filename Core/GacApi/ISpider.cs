using CsharpHttpHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace GacApi
{
    public interface ISpider : ICloneable, IDisposable
    {
        /// <summary>
        /// 修改采集器采集到的网址列表,可以在此过滤采集到的结果
        /// </summary>
        bool UseChangeStepUrls
        {
            get;
        }


        /// <summary>
        /// 是否使用获取多级网址(采集器不提取网址，调用GetStepUrls方法获取网址)
        /// </summary>
        bool UseGetStepUrls
        {
            get;
        }

        /// <summary>
        /// 是否由插件生成起始网址(调用MakeStartAddress方法，对每个起始网址再进行处理)
        /// </summary>
        bool UseMakeStartAddress
        {
            get;
        }



        /// <summary>
        /// 是否启用修改保存文件，启用户将调用ChangeSaveFiles方法对下载的文件名及标签进行处理
        /// </summary>
        bool UseChangeSaveFiles
        {
            get;
        }



        /// <summary>
        /// 是否对http请求进行修改
        /// </summary>
        bool UseChangeWebRequest { get; }

        /// <summary>
        /// 是否对Http结果进行修改
        /// </summary>
        bool UseChangeWebResutl { get; }



        void ChangeStepUrls(List<KeyValuePair<string, Dictionary<string, string>>> StepUrls);
        

        /// <summary>
        /// 对起始网址进行处理，对每一个起始网址可以返回多个网址。注意这里的起始网址是采集器对起始规则进行解析后生成的新的起始网址
        /// </summary>
        /// <param name="urlData"></param>
        /// <param name="useragent"></param>
        /// <param name="refer"></param>
        /// <param name="cookie"></param>
        /// <returns>如果UseMakeStartAddress，请直接返回空List或null</returns>
        List<string> MakeStartAddress(string urlData,  string refer, CookieCollection cookie);



        /// <summary>
        /// 获取列表页地址和自定义标签,注意每个Dictionary中的标签键名和数量要一样
        /// </summary>
        /// <param name="html">网页源代码，是插件处理过的</param>
        /// <param name="areaStart">网址提取区域开始</param>
        /// <param name="areaEnd">网址提取区域结束</param>
        /// <param name="urlStyle">自定义网址规则样式</param>
        /// <param name="urlCombine">自定义组合网址</param>
        /// <param name="allow">网址中包含</param>
        /// <param name="forbidden">网址中不得包含</param>
        /// <returns>一个网址，对应的dic是标签，如果UseGetStepUrls是True,直接返回null即可</returns>
        List<KeyValuePair<string, Dictionary<string, string>>> GetStepUrls(string html, string areaStart, string areaEnd, string urlStyle, string urlCombine, string allow, string forbidden);



        #region 修改采集结果
        /// <summary>
        /// 对Gac采集器最终采集的结果字符串进行再处理，注意这时文件已下载完成，处理完该字符串后，程序再会进行一个包含和不得包含的判断处理，看结果是否需要保留，然后数据将保存到本地数据库或发布。
        /// </summary>
        /// <param name="dic"></param>
        void ChangeResultDic(Dictionary<string, string> dic);
        #endregion


        #region 修改保存文件

        /// <summary>
        /// 对还没有下载前的文件进行修改，在这里可以修改文件保存的地址和替换地址，也可以修改每个标签的返回值，这个操作在ChangeResultDic方法之前执行。
        /// </summary>
        /// <param name="fieldandfiles">标签名，所有文件，下载地址，文件保存地址和替换地址</param>
        /// <param name="dic">标签名和html值</param>
        void ChangeSaveFiles(Dictionary<string, Dictionary<string, KeyValuePair<string, string>>> fieldandfiles, Dictionary<string, string> dic);

        #endregion


        #region 任务状态

        /// <summary>
        /// 任务完成后做什么操作，提示什么信息，方便用户做统计，数据清理等工作。
        /// </summary>
        /// <param name="handstop">是否手动停止</param>
        /// <param name="jobname">任务名</param>
        /// <param name="jobid">任务id</param>
        /// <param name="url">采网址成功条数</param>
        /// <param name="content">采内容成功条数</param>
        /// <param name="post">发内容成功条数</param>
        /// <param name="job">任务的变量</param>
        /// <returns>需要在界面上显示的字,null或空不显示</returns>
        string EndJob(bool handstop, string jobname, string jobid, int url, int content, int post, object job);

        /// <summary>
        /// 运行任务时的操作，可以做额外的一些检查，并将结果显示在任务运行界面上。
        /// </summary>
        /// <returns>需要在界面上显示的字,null或空不显示</returns>
        string StartJob();
        #endregion


        #region 请求修改
        /// <summary>
        /// 修改当前http请求的一些信息
        /// </summary>
        /// <param name="request">http请求信息</param>
        void ChangeWebRequest( HttpItem httpItem);

        /// <summary>
        /// 对http请求后结果进行处理
        /// </summary>
        /// <param name="result">http请求后结果</param>
        /// <param name="pageurl">当前页网址</param>
        /// <returns></returns>
        void ChangeWebResutl( HttpResult result, HttpItem httpItem);
        #endregion


        ////
        //// 摘要:
        ////     根据多页名称生成新的网址
        ////
        //// 参数:
        ////   multPageName:
        ////     多页名称
        ////
        ////   pageurl:
        ////     当前页网址
        ////
        ////   html:
        ////     当前页源码，插件处理过的
        ////
        ////   multPageStyle:
        ////     多页正则匹配内容
        ////
        ////   multPageCombine:
        ////     多页网址组合地址
        //string GetMultPageUrl(string multPageName, string pageurl, string html, string multPageStyle, string multPageCombine);
        ////
        //// 摘要:
        ////     得到所有分页的地址
        ////
        //// 参数:
        ////   level:
        ////     当前的层数,从0开始
        ////
        ////   pageurl:
        ////     当前页网址
        ////
        ////   html:
        ////     当前页源代码,插件处理过的
        ////
        ////   pagesStyle:
        ////     分页链接地址样式
        ////
        ////   pagesCombine:
        ////     分页组合网址
        //List<string> GetPagesUrl(int level, string pageurl, string html, string pagesStyle, string pagesCombine);
    }
}
