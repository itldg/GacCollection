using System;
using System.Xml;
using System.Collections.Generic;
namespace GacXml
{

    public class GacJob
    {
        private string _JobName = default(string);
        /// <summary>
        /// 参考值：多级测试 
        /// </summary>
        public string JobName
        {
            get { return _JobName; }
            set { _JobName = value; }
        }

        private string _UserAgent = default(string);
        /// <summary>
        /// 参考值：Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; WOW64; Trident/7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729) 
        /// </summary>
        public string UserAgent
        {
            get { return _UserAgent; }
            set { _UserAgent = value; }
        }

        private string _Encdoing = default(string);
        /// <summary>
        /// 参考值：自动识别 
        /// </summary>
        public string Encdoing
        {
            get { return _Encdoing; }
            set { _Encdoing = value; }
        }

        private string _CheckUrlRepeat = default(string);
        public string CheckUrlRepeat
        {
            get { return _CheckUrlRepeat; }
            set { _CheckUrlRepeat = value; }
        }

        private Int32 _JobId = default(Int32);
        /// <summary>
        /// 参考值：441 
        /// </summary>
        public Int32 JobId
        {
            get { return _JobId; }
            set { _JobId = value; }
        }

        private Int32 _UrlId = default(Int32);
        /// <summary>
        /// 参考值：441 
        /// </summary>
        public Int32 UrlId
        {
            get { return _UrlId; }
            set { _UrlId = value; }
        }

        private string _LoopJoinCode = default(string);
        public string LoopJoinCode
        {
            get { return _LoopJoinCode; }
            set { _LoopJoinCode = value; }
        }

        private string _UseWebOutput = default(string);
        public string UseWebOutput
        {
            get { return _UseWebOutput; }
            set { _UseWebOutput = value; }
        }

        private string _UseFileOut = default(string);
        public string UseFileOut
        {
            get { return _UseFileOut; }
            set { _UseFileOut = value; }
        }

        private Int32 _WebOutType = default(Int32);
        /// <summary>
        /// 参考值：0 
        /// </summary>
        public Int32 WebOutType
        {
            get { return _WebOutType; }
            set { _WebOutType = value; }
        }

        private Int32 _FileType = default(Int32);
        /// <summary>
        /// 参考值：0 
        /// </summary>
        public Int32 FileType
        {
            get { return _FileType; }
            set { _FileType = value; }
        }

        private string _FileSavePath = default(string);
        /// <summary>
        /// 参考值：保存未知 
        /// </summary>
        public string FileSavePath
        {
            get { return _FileSavePath; }
            set { _FileSavePath = value; }
        }

        private string _FileTemplate = default(string);
        /// <summary>
        /// 参考值：D:\采集\Extensions\LocoySpider\FileTemplate\默认txt模版.txt 
        /// </summary>
        public string FileTemplate
        {
            get { return _FileTemplate; }
            set { _FileTemplate = value; }
        }

        private string _FilenNameType = default(string);
        /// <summary>
        /// 参考值：[任务名] 
        /// </summary>
        public string FilenNameType
        {
            get { return _FilenNameType; }
            set { _FilenNameType = value; }
        }

        private string _FileEncoding = default(string);
        /// <summary>
        /// 参考值：UTF-8 
        /// </summary>
        public string FileEncoding
        {
            get { return _FileEncoding; }
            set { _FileEncoding = value; }
        }

        private Int32 _SpiderThreadNum = default(Int32);
        /// <summary>
        /// 参考值：3 
        /// </summary>
        public Int32 SpiderThreadNum
        {
            get { return _SpiderThreadNum; }
            set { _SpiderThreadNum = value; }
        }

        private Int32 _SpiderTimeInterval = default(Int32);
        /// <summary>
        /// 参考值：400 
        /// </summary>
        public Int32 SpiderTimeInterval
        {
            get { return _SpiderTimeInterval; }
            set { _SpiderTimeInterval = value; }
        }

        private Int32 _OutThreadNum = default(Int32);
        /// <summary>
        /// 参考值：3 
        /// </summary>
        public Int32 OutThreadNum
        {
            get { return _OutThreadNum; }
            set { _OutThreadNum = value; }
        }

        private Int32 _OutTimeStart = default(Int32);
        /// <summary>
        /// 参考值：400 
        /// </summary>
        public Int32 OutTimeStart
        {
            get { return _OutTimeStart; }
            set { _OutTimeStart = value; }
        }

        private Int32 _OutTimeEnd = default(Int32);
        /// <summary>
        /// 参考值：400 
        /// </summary>
        public Int32 OutTimeEnd
        {
            get { return _OutTimeEnd; }
            set { _OutTimeEnd = value; }
        }

        private string _Plugin = default(string);
        public string Plugin
        {
            get { return _Plugin; }
            set { _Plugin = value; }
        }

        private Int32 _ProxyType = default(Int32);
        /// <summary>
        /// 参考值：0 
        /// </summary>
        public Int32 ProxyType
        {
            get { return _ProxyType; }
            set { _ProxyType = value; }
        }

        private Int32 _ProxyPort = default(Int32);
        /// <summary>
        /// 参考值：1023 
        /// </summary>
        public Int32 ProxyPort
        {
            get { return _ProxyPort; }
            set { _ProxyPort = value; }
        }

        private string _FileUploadDomain = default(string);
        public string FileUploadDomain
        {
            get { return _FileUploadDomain; }
            set { _FileUploadDomain = value; }
        }

        private string _UseFtp = default(string);
        public string UseFtp
        {
            get { return _UseFtp; }
            set { _UseFtp = value; }
        }

        private string _FtpServer = default(string);
        /// <summary>
        /// 参考值：127.0.0.1 
        /// </summary>
        public string FtpServer
        {
            get { return _FtpServer; }
            set { _FtpServer = value; }
        }

        private Int32 _FtpPort = default(Int32);
        /// <summary>
        /// 参考值：21 
        /// </summary>
        public Int32 FtpPort
        {
            get { return _FtpPort; }
            set { _FtpPort = value; }
        }

        private string _FtpUserName = default(string);
        /// <summary>
        /// 参考值：test 
        /// </summary>
        public string FtpUserName
        {
            get { return _FtpUserName; }
            set { _FtpUserName = value; }
        }

        private string _FtpPassword = default(string);
        /// <summary>
        /// 参考值：test 
        /// </summary>
        public string FtpPassword
        {
            get { return _FtpPassword; }
            set { _FtpPassword = value; }
        }

        private string _FtpBaseDir = default(string);
        /// <summary>
        /// 参考值：/FileUpload/ 
        /// </summary>
        public string FtpBaseDir
        {
            get { return _FtpBaseDir; }
            set { _FtpBaseDir = value; }
        }

        private string _FtpPassiveMode = default(string);
        public string FtpPassiveMode
        {
            get { return _FtpPassiveMode; }
            set { _FtpPassiveMode = value; }
        }

        private string _FtpUploadFrist = default(string);
        public string FtpUploadFrist
        {
            get { return _FtpUploadFrist; }
            set { _FtpUploadFrist = value; }
        }

        private Int32 _MaxSpiderPerNum = default(Int32);
        /// <summary>
        /// 参考值：777 
        /// </summary>
        public Int32 MaxSpiderPerNum
        {
            get { return _MaxSpiderPerNum; }
            set { _MaxSpiderPerNum = value; }
        }

        private Int32 _MaxOutPerNum = default(Int32);
        /// <summary>
        /// 参考值：888 
        /// </summary>
        public Int32 MaxOutPerNum
        {
            get { return _MaxOutPerNum; }
            set { _MaxOutPerNum = value; }
        }

        private Int32 _MaxDownload = default(Int32);
        /// <summary>
        /// 参考值：1 
        /// </summary>
        public Int32 MaxDownload
        {
            get { return _MaxDownload; }
            set { _MaxDownload = value; }
        }

        private Int32 _UrlRepeat = default(Int32);
        /// <summary>
        /// 参考值：0 
        /// </summary>
        public Int32 UrlRepeat
        {
            get { return _UrlRepeat; }
            set { _UrlRepeat = value; }
        }

        private string _SignSucessIfAllPost = default(string);
        public string SignSucessIfAllPost
        {
            get { return _SignSucessIfAllPost; }
            set { _SignSucessIfAllPost = value; }
        }

        private Int32 _DownloadSegments = default(Int32);
        /// <summary>
        /// 参考值：2 
        /// </summary>
        public Int32 DownloadSegments
        {
            get { return _DownloadSegments; }
            set { _DownloadSegments = value; }
        }

        private string _PhpPlugin = default(string);
        public string PhpPlugin
        {
            get { return _PhpPlugin; }
            set { _PhpPlugin = value; }
        }

        private List<SuperJob> _SuperJobCollection = default(List<SuperJob>);
        public List<SuperJob> SuperJobCollection
        {
            get { return _SuperJobCollection; }
            set { _SuperJobCollection = value; }
        }

        private List<string> _StartAddress = default(List<string>);
        /// <summary>
        /// 参考值：http://www.lziyuan.com/vod/1_1.html 
        /// </summary>
        public List<string> StartAddress
        {
            get { return _StartAddress; }
            set { _StartAddress = value; }
        }

        private List<StepAddress> _StepAddressCollection = default(List<StepAddress>);
        public List<StepAddress> StepAddressCollection
        {
            get { return _StepAddressCollection; }
            set { _StepAddressCollection = value; }
        }

        private List<string> _SortLabel = default(List<string>);
        /// <summary>
        /// 参考值：标题 
        /// </summary>
        public List<string> SortLabel
        {
            get { return _SortLabel; }
            set { _SortLabel = value; }
        }

        private List<ListLabel> _ListLabelCollection = default(List<ListLabel>);
        public List<ListLabel> ListLabelCollection
        {
            get { return _ListLabelCollection; }
            set { _ListLabelCollection = value; }
        }

        private List<JobWebPost> _JobWebPostCollection = default(List<JobWebPost>);
        public List<JobWebPost> JobWebPostCollection
        {
            get { return _JobWebPostCollection; }
            set { _JobWebPostCollection = value; }
        }

        private List<string> _JobDatabase = default(List<string>);
        /// <summary>
        /// 参考值：2 
        /// </summary>
        public List<string> JobDatabase
        {
            get { return _JobDatabase; }
            set { _JobDatabase = value; }
        }

    }


    public class SuperJob
    {
        private Int32 _Level = default(Int32);
        /// <summary>
        /// 参考值：0 
        /// </summary>
        public Int32 Level
        {
            get { return _Level; }
            set { _Level = value; }
        }

        private string _PageName = default(string);
        /// <summary>
        /// 参考值：默认页 
        /// </summary>
        public string PageName
        {
            get { return _PageName; }
            set { _PageName = value; }
        }

        private string _PageEncoding = default(string);
        public string PageEncoding
        {
            get { return _PageEncoding; }
            set { _PageEncoding = value; }
        }

        private string _PagesAreaStart = default(string);
        /// <summary>
        /// 参考值：上页 
        /// </summary>
        public string PagesAreaStart
        {
            get { return _PagesAreaStart; }
            set { _PagesAreaStart = value; }
        }

        private string _PagesAreaEnd = default(string);
        /// <summary>
        /// 参考值：下页 
        /// </summary>
        public string PagesAreaEnd
        {
            get { return _PagesAreaEnd; }
            set { _PagesAreaEnd = value; }
        }

        private string _PagesStyle = default(string);
        /// <summary>
        /// 参考值：分页样式 
        /// </summary>
        public string PagesStyle
        {
            get { return _PagesStyle; }
            set { _PagesStyle = value; }
        }

        private string _PagesCombine = default(string);
        /// <summary>
        /// 参考值：分页网址 
        /// </summary>
        public string PagesCombine
        {
            get { return _PagesCombine; }
            set { _PagesCombine = value; }
        }

        private string _AcceptLanguage = default(string);
        /// <summary>
        /// 参考值：zh-cn,zh; 
        /// </summary>
        public string AcceptLanguage
        {
            get { return _AcceptLanguage; }
            set { _AcceptLanguage = value; }
        }

        private string _UserAgent = default(string);
        /// <summary>
        /// 参考值：Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; WOW64; Trident/7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729) 
        /// </summary>
        public string UserAgent
        {
            get { return _UserAgent; }
            set { _UserAgent = value; }
        }

        private string _AutoDirect = default(string);
        public string AutoDirect
        {
            get { return _AutoDirect; }
            set { _AutoDirect = value; }
        }

        private string _KeepAlive = default(string);
        public string KeepAlive
        {
            get { return _KeepAlive; }
            set { _KeepAlive = value; }
        }

        private Int32 _TimeOut = default(Int32);
        /// <summary>
        /// 参考值：30 
        /// </summary>
        public Int32 TimeOut
        {
            get { return _TimeOut; }
            set { _TimeOut = value; }
        }

        private Int32 _MaxPages = default(Int32);
        /// <summary>
        /// 参考值：666 
        /// </summary>
        public Int32 MaxPages
        {
            get { return _MaxPages; }
            set { _MaxPages = value; }
        }

        private List<Rule> _RuleCollection = default(List<Rule>);
        public List<Rule> RuleCollection
        {
            get { return _RuleCollection; }
            set { _RuleCollection = value; }
        }

        private List<string> _TestPageUrls = default(List<string>);
        /// <summary>
        /// 参考值：http://www.kppt.cc/meiju/3762.html 
        /// </summary>
        public List<string> TestPageUrls
        {
            get { return _TestPageUrls; }
            set { _TestPageUrls = value; }
        }

    }


    public class Rule
    {
        private string _LabelName = default(string);
        /// <summary>
        /// 参考值：标题 
        /// </summary>
        public string LabelName
        {
            get { return _LabelName; }
            set { _LabelName = value; }
        }

        private string _DataSpider = default(string);
        public string DataSpider
        {
            get { return _DataSpider; }
            set { _DataSpider = value; }
        }

        private Int32 _GetDataType = default(Int32);
        /// <summary>
        /// 参考值：0 
        /// </summary>
        public Int32 GetDataType
        {
            get { return _GetDataType; }
            set { _GetDataType = value; }
        }

        private string _StartStr = default(string);
        /// <summary>
        /// 参考值：<title> 
        /// </summary>
        public string StartStr
        {
            get { return _StartStr; }
            set { _StartStr = value; }
        }

        private string _EndStr = default(string);
        /// <summary>
        /// 参考值：</title> 
        /// </summary>
        public string EndStr
        {
            get { return _EndStr; }
            set { _EndStr = value; }
        }

        private string _RegexContent = default(string);
        public string RegexContent
        {
            get { return _RegexContent; }
            set { _RegexContent = value; }
        }

        private string _RegexCombine = default(string);
        public string RegexCombine
        {
            get { return _RegexCombine; }
            set { _RegexCombine = value; }
        }

        private string _XpathContent = default(string);
        public string XpathContent
        {
            get { return _XpathContent; }
            set { _XpathContent = value; }
        }

        private Int32 _XPathAttribue = default(Int32);
        /// <summary>
        /// 参考值：0 
        /// </summary>
        public Int32 XPathAttribue
        {
            get { return _XPathAttribue; }
            set { _XPathAttribue = value; }
        }

        private Int32 _TextRecognitionType = default(Int32);
        /// <summary>
        /// 参考值：0 
        /// </summary>
        public Int32 TextRecognitionType
        {
            get { return _TextRecognitionType; }
            set { _TextRecognitionType = value; }
        }

        private Int32 _TextRecognitionCodeReturnType = default(Int32);
        /// <summary>
        /// 参考值：1 
        /// </summary>
        public Int32 TextRecognitionCodeReturnType
        {
            get { return _TextRecognitionCodeReturnType; }
            set { _TextRecognitionCodeReturnType = value; }
        }

        private Int32 _LengthFiltOpertar = default(Int32);
        /// <summary>
        /// 参考值：0 
        /// </summary>
        public Int32 LengthFiltOpertar
        {
            get { return _LengthFiltOpertar; }
            set { _LengthFiltOpertar = value; }
        }

        private Int32 _LengthFiltValue = default(Int32);
        /// <summary>
        /// 参考值：0 
        /// </summary>
        public Int32 LengthFiltValue
        {
            get { return _LengthFiltValue; }
            set { _LengthFiltValue = value; }
        }

        private string _LabelContentMust = default(string);
        public string LabelContentMust
        {
            get { return _LabelContentMust; }
            set { _LabelContentMust = value; }
        }

        private string _LabelContentForbid = default(string);
        public string LabelContentForbid
        {
            get { return _LabelContentForbid; }
            set { _LabelContentForbid = value; }
        }

        private string _FileUrlMust = default(string);
        public string FileUrlMust
        {
            get { return _FileUrlMust; }
            set { _FileUrlMust = value; }
        }

        private string _FileSaveDir = default(string);
        public string FileSaveDir
        {
            get { return _FileSaveDir; }
            set { _FileSaveDir = value; }
        }

        private string _FileSaveFormat = default(string);
        public string FileSaveFormat
        {
            get { return _FileSaveFormat; }
            set { _FileSaveFormat = value; }
        }

        private Int32 _ManualType = default(Int32);
        /// <summary>
        /// 参考值：0 
        /// </summary>
        public Int32 ManualType
        {
            get { return _ManualType; }
            set { _ManualType = value; }
        }

        private string _ManualString = default(string);
        public string ManualString
        {
            get { return _ManualString; }
            set { _ManualString = value; }
        }

        private string _ManualTimeStr = default(string);
        public string ManualTimeStr
        {
            get { return _ManualTimeStr; }
            set { _ManualTimeStr = value; }
        }

        private string _ManualRadomStringLib = default(string);
        public string ManualRadomStringLib
        {
            get { return _ManualRadomStringLib; }
            set { _ManualRadomStringLib = value; }
        }

        private Int32 _ManualRadomStringNum = default(Int32);
        /// <summary>
        /// 参考值：0 
        /// </summary>
        public Int32 ManualRadomStringNum
        {
            get { return _ManualRadomStringNum; }
            set { _ManualRadomStringNum = value; }
        }

        private Int32 _ManualRadomNumStart = default(Int32);
        /// <summary>
        /// 参考值：0 
        /// </summary>
        public Int32 ManualRadomNumStart
        {
            get { return _ManualRadomNumStart; }
            set { _ManualRadomNumStart = value; }
        }

        private Int32 _ManualRadomNumEnd = default(Int32);
        /// <summary>
        /// 参考值：0 
        /// </summary>
        public Int32 ManualRadomNumEnd
        {
            get { return _ManualRadomNumEnd; }
            set { _ManualRadomNumEnd = value; }
        }

        private string _ManualRadomString = default(string);
        public string ManualRadomString
        {
            get { return _ManualRadomString; }
            set { _ManualRadomString = value; }
        }

        private string _MergeContent = default(string);
        public string MergeContent
        {
            get { return _MergeContent; }
            set { _MergeContent = value; }
        }

        private List<object> _FiltersCollection = default(List<object>);
        public List<object> FiltersCollection
        {
            get { return _FiltersCollection; }
            set { _FiltersCollection = value; }
        }

        private string _FillRelativeUrl = default(string);
        public string FillRelativeUrl
        {
            get { return _FillRelativeUrl; }
            set { _FillRelativeUrl = value; }
        }

        private string _OnlyFetchValidUrl = default(string);
        public string OnlyFetchValidUrl
        {
            get { return _OnlyFetchValidUrl; }
            set { _OnlyFetchValidUrl = value; }
        }

        private string _DownloadImage = default(string);
        public string DownloadImage
        {
            get { return _DownloadImage; }
            set { _DownloadImage = value; }
        }

        private string _DownloadOtherFile = default(string);
        public string DownloadOtherFile
        {
            get { return _DownloadOtherFile; }
            set { _DownloadOtherFile = value; }
        }

    }


    public class Filters
    {
        private List<ReplaceFilter> _ReplaceFilterCollection = default(List<ReplaceFilter>);
        public List<ReplaceFilter> ReplaceFilterCollection
        {
            get { return _ReplaceFilterCollection; }
            set { _ReplaceFilterCollection = value; }
        }

        private List<RemoveHtmlFilter> _RemoveHtmlFilterCollection = default(List<RemoveHtmlFilter>);
        public List<RemoveHtmlFilter> RemoveHtmlFilterCollection
        {
            get { return _RemoveHtmlFilterCollection; }
            set { _RemoveHtmlFilterCollection = value; }
        }

        private List<SubstringFilter> _SubstringFilterCollection = default(List<SubstringFilter>);
        public List<SubstringFilter> SubstringFilterCollection
        {
            get { return _SubstringFilterCollection; }
            set { _SubstringFilterCollection = value; }
        }

        private List<PureRegexFilter> _PureRegexFilterCollection = default(List<PureRegexFilter>);
        public List<PureRegexFilter> PureRegexFilterCollection
        {
            get { return _PureRegexFilterCollection; }
            set { _PureRegexFilterCollection = value; }
        }

        private List<ToEngFilter> _ToEngFilterCollection = default(List<ToEngFilter>);
        public List<ToEngFilter> ToEngFilterCollection
        {
            get { return _ToEngFilterCollection; }
            set { _ToEngFilterCollection = value; }
        }

        private List<GbkToBig5Filter> _GbkToBig5FilterCollection = default(List<GbkToBig5Filter>);
        public List<GbkToBig5Filter> GbkToBig5FilterCollection
        {
            get { return _GbkToBig5FilterCollection; }
            set { _GbkToBig5FilterCollection = value; }
        }

        private List<Big5ToGbkFilter> _Big5ToGbkFilterCollection = default(List<Big5ToGbkFilter>);
        public List<Big5ToGbkFilter> Big5ToGbkFilterCollection
        {
            get { return _Big5ToGbkFilterCollection; }
            set { _Big5ToGbkFilterCollection = value; }
        }

        private List<ToMarsFilter> _ToMarsFilterCollection = default(List<ToMarsFilter>);
        public List<ToMarsFilter> ToMarsFilterCollection
        {
            get { return _ToMarsFilterCollection; }
            set { _ToMarsFilterCollection = value; }
        }

        private List<ForceFillUrl> _ForceFillUrlCollection = default(List<ForceFillUrl>);
        public List<ForceFillUrl> ForceFillUrlCollection
        {
            get { return _ForceFillUrlCollection; }
            set { _ForceFillUrlCollection = value; }
        }

    }


    public class ReplaceFilter
    {
        private string _old = default(string);
        /// <summary>
        /// 参考值：替换前 
        /// </summary>
        public string old
        {
            get { return _old; }
            set { _old = value; }
        }

        private string _New = default(string);
        /// <summary>
        /// 参考值：替换后 
        /// </summary>
        public string New
        {
            get { return _New; }
            set { _New = value; }
        }

    }


    public class RemoveHtmlFilter
    {
        private Double _Indexs = default(Double);
        /// <summary>
        /// 参考值：0,1,23 
        /// </summary>
        public Double Indexs
        {
            get { return _Indexs; }
            set { _Indexs = value; }
        }

    }


    public class SubstringFilter
    {
        private string _start = default(string);
        /// <summary>
        /// 参考值：截取前 
        /// </summary>
        public string start
        {
            get { return _start; }
            set { _start = value; }
        }

        private string _end = default(string);
        /// <summary>
        /// 参考值：截取后 
        /// </summary>
        public string end
        {
            get { return _end; }
            set { _end = value; }
        }

    }


    public class PureRegexFilter
    {
        private string _old = default(string);
        /// <summary>
        /// 参考值：正则替换前 
        /// </summary>
        public string old
        {
            get { return _old; }
            set { _old = value; }
        }

        private string _New = default(string);
        /// <summary>
        /// 参考值：正则替换后 
        /// </summary>
        public string New
        {
            get { return _New; }
            set { _New = value; }
        }

    }


    public class ToEngFilter
    {
    }


    public class GbkToBig5Filter
    {
    }


    public class Big5ToGbkFilter
    {
    }


    public class ToMarsFilter
    {
    }


    public class ForceFillUrl
    {
    }


    public class TestPageUrls
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：http://www.kppt.cc/meiju/3762.html 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class StartAddress
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：http://www.lziyuan.com/vod/1_1.html 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class StepAddress
    {
        private string _UrlAreaStart = default(string);
        public string UrlAreaStart
        {
            get { return _UrlAreaStart; }
            set { _UrlAreaStart = value; }
        }

        private string _UrlAreaEnd = default(string);
        public string UrlAreaEnd
        {
            get { return _UrlAreaEnd; }
            set { _UrlAreaEnd = value; }
        }

        private string _UrlForbid = default(string);
        public string UrlForbid
        {
            get { return _UrlForbid; }
            set { _UrlForbid = value; }
        }

        private string _UrlMust = default(string);
        public string UrlMust
        {
            get { return _UrlMust; }
            set { _UrlMust = value; }
        }

        private string _PostData = default(string);
        public string PostData
        {
            get { return _PostData; }
            set { _PostData = value; }
        }

        private Int32 _PostStart = default(Int32);
        /// <summary>
        /// 参考值：1 
        /// </summary>
        public Int32 PostStart
        {
            get { return _PostStart; }
            set { _PostStart = value; }
        }

        private Int32 _PostEnd = default(Int32);
        /// <summary>
        /// 参考值：3 
        /// </summary>
        public Int32 PostEnd
        {
            get { return _PostEnd; }
            set { _PostEnd = value; }
        }

        private Int32 _HttpMethod = default(Int32);
        /// <summary>
        /// 参考值：0 
        /// </summary>
        public Int32 HttpMethod
        {
            get { return _HttpMethod; }
            set { _HttpMethod = value; }
        }

        private string _AutoPages = default(string);
        public string AutoPages
        {
            get { return _AutoPages; }
            set { _AutoPages = value; }
        }

        private Int32 _GetUrlType = default(Int32);
        /// <summary>
        /// 参考值：1 
        /// </summary>
        public Int32 GetUrlType
        {
            get { return _GetUrlType; }
            set { _GetUrlType = value; }
        }

        private string _ManualUrlStyle = default(string);
        /// <summary>
        /// 参考值：<dd><a  href="[参数]">[标签:分类]</a><dd> 
        /// </summary>
        public string ManualUrlStyle
        {
            get { return _ManualUrlStyle; }
            set { _ManualUrlStyle = value; }
        }

        private string _ManualUrlCompile = default(string);
        /// <summary>
        /// 参考值：[参数1] 
        /// </summary>
        public string ManualUrlCompile
        {
            get { return _ManualUrlCompile; }
            set { _ManualUrlCompile = value; }
        }

        private string _XpathContent = default(string);
        /// <summary>
        /// 参考值：/html[1]/body[1]/div[4]/ul[1]/li[1]/dl[1]//dd/a[1] 
        /// </summary>
        public string XpathContent
        {
            get { return _XpathContent; }
            set { _XpathContent = value; }
        }

        private string _PagesAreaStart = default(string);
        public string PagesAreaStart
        {
            get { return _PagesAreaStart; }
            set { _PagesAreaStart = value; }
        }

        private string _PagesAreaEnd = default(string);
        public string PagesAreaEnd
        {
            get { return _PagesAreaEnd; }
            set { _PagesAreaEnd = value; }
        }

        private string _PagesUrlStyle = default(string);
        public string PagesUrlStyle
        {
            get { return _PagesUrlStyle; }
            set { _PagesUrlStyle = value; }
        }

        private string _PagesUrlCompile = default(string);
        public string PagesUrlCompile
        {
            get { return _PagesUrlCompile; }
            set { _PagesUrlCompile = value; }
        }

        private Int32 _PagesMax = default(Int32);
        /// <summary>
        /// 参考值：0 
        /// </summary>
        public Int32 PagesMax
        {
            get { return _PagesMax; }
            set { _PagesMax = value; }
        }

        private string _AddLabel = default(string);
        public string AddLabel
        {
            get { return _AddLabel; }
            set { _AddLabel = value; }
        }

        private Int32 _AspxEnd = default(Int32);
        /// <summary>
        /// 参考值：3 
        /// </summary>
        public Int32 AspxEnd
        {
            get { return _AspxEnd; }
            set { _AspxEnd = value; }
        }

    }


    public class SortLabel
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：标题 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class ListLabel
    {
        private List<Rule> _RuleCollection = default(List<Rule>);
        public List<Rule> RuleCollection
        {
            get { return _RuleCollection; }
            set { _RuleCollection = value; }
        }

    }


    public class JobWebPost
    {
        private Int32 _WebPostId = default(Int32);
        /// <summary>
        /// 参考值：15 
        /// </summary>
        public Int32 WebPostId
        {
            get { return _WebPostId; }
            set { _WebPostId = value; }
        }

        private string _FName = default(string);
        /// <summary>
        /// 参考值：大陆电视剧 
        /// </summary>
        public string FName
        {
            get { return _FName; }
            set { _FName = value; }
        }

        private Int32 _Fid = default(Int32);
        /// <summary>
        /// 参考值：5 
        /// </summary>
        public Int32 Fid
        {
            get { return _Fid; }
            set { _Fid = value; }
        }

        private string _Md5 = default(string);
        /// <summary>
        /// 参考值：b2121e6babc6af84 
        /// </summary>
        public string Md5
        {
            get { return _Md5; }
            set { _Md5 = value; }
        }

    }


    public class JobDatabase
    {
        private Int32 _Value = default(Int32);
        /// <summary>
        /// 参考值：2 
        /// </summary>
        public Int32 Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


}
