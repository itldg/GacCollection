using System;
using System.Xml;
using System.Collections.Generic;
using System.Xml.Serialization;
using Gac;

namespace Gac1
{
    public class ClassTaskXml
    {
        private string _JobName = default(string);
        public string JobName
        {
            get { return _JobName; }
            set { _JobName = value; }
        }

        private string _Cookie = default(string);
        public string Cookie
        {
            get { return _Cookie; }
            set { _Cookie = value; }
        }

        private string _UserAgent = default(string);
        public string UserAgent
        {
            get { return _UserAgent; }
            set { _UserAgent = value; }
        }

        private string _Encdoing = default(string);
        public string Encdoing
        {
            get { return _Encdoing; }
            set { _Encdoing = value; }
        }

        private bool _CheckUrlRepeat = default(bool);
        public bool CheckUrlRepeat
        {
            get { return _CheckUrlRepeat; }
            set { _CheckUrlRepeat = value; }
        }

        private string _JobId = default(string);
        public string JobId
        {
            get { return _JobId; }
            set { _JobId = value; }
        }

        private string _UrlId = default(string);
        public string UrlId
        {
            get { return _UrlId; }
            set { _UrlId = value; }
        }
        private int _MultipleURLTestFirst = default(int);
        public int MultipleURLTestFirst
        {
            get { return _MultipleURLTestFirst; }
            set { _MultipleURLTestFirst = value; }
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

        private string _WebOutType = default(string);
        public string WebOutType
        {
            get { return _WebOutType; }
            set { _WebOutType = value; }
        }

        private string _FileType = default(string);
        public string FileType
        {
            get { return _FileType; }
            set { _FileType = value; }
        }

        private string _FileSavePath = default(string);
        public string FileSavePath
        {
            get { return _FileSavePath; }
            set { _FileSavePath = value; }
        }

        private string _FileTemplate = default(string);
        public string FileTemplate
        {
            get { return _FileTemplate; }
            set { _FileTemplate = value; }
        }

        private string _FilenNameType = default(string);
        public string FilenNameType
        {
            get { return _FilenNameType; }
            set { _FilenNameType = value; }
        }

        private string _FileEncoding = default(string);
        public string FileEncoding
        {
            get { return _FileEncoding; }
            set { _FileEncoding = value; }
        }

        private string _Bak = default(string);
        public string Bak
        {
            get { return _Bak; }
            set { _Bak = value; }
        }

        private string _SpiderThreadNum = default(string);
        public string SpiderThreadNum
        {
            get { return _SpiderThreadNum; }
            set { _SpiderThreadNum = value; }
        }

        private string _SpiderTimeInterval = default(string);
        public string SpiderTimeInterval
        {
            get { return _SpiderTimeInterval; }
            set { _SpiderTimeInterval = value; }
        }

        private string _OutThreadNum = default(string);
        public string OutThreadNum
        {
            get { return _OutThreadNum; }
            set { _OutThreadNum = value; }
        }

        private string _OutTimeStart = default(string);
        public string OutTimeStart
        {
            get { return _OutTimeStart; }
            set { _OutTimeStart = value; }
        }

        private string _OutTimeEnd = default(string);
        public string OutTimeEnd
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

        private string _ProxyType = default(string);
        public string ProxyType
        {
            get { return _ProxyType; }
            set { _ProxyType = value; }
        }

        private string _ProxyPort = default(string);
        public string ProxyPort
        {
            get { return _ProxyPort; }
            set { _ProxyPort = value; }
        }

        private string _BaseFileDir = default(string);
        public string BaseFileDir
        {
            get { return _BaseFileDir; }
            set { _BaseFileDir = value; }
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
        public string FtpServer
        {
            get { return _FtpServer; }
            set { _FtpServer = value; }
        }

        private string _FtpPort = default(string);
        public string FtpPort
        {
            get { return _FtpPort; }
            set { _FtpPort = value; }
        }

        private string _FtpUserName = default(string);
        public string FtpUserName
        {
            get { return _FtpUserName; }
            set { _FtpUserName = value; }
        }

        private string _FtpPassword = default(string);
        public string FtpPassword
        {
            get { return _FtpPassword; }
            set { _FtpPassword = value; }
        }

        private string _FtpBaseDir = default(string);
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

        private string _DeleteFileAfterUpload = default(string);
        public string DeleteFileAfterUpload
        {
            get { return _DeleteFileAfterUpload; }
            set { _DeleteFileAfterUpload = value; }
        }

        private string _NotWebOutIfFileNoDownLoad = default(string);
        public string NotWebOutIfFileNoDownLoad
        {
            get { return _NotWebOutIfFileNoDownLoad; }
            set { _NotWebOutIfFileNoDownLoad = value; }
        }

        private string _UseCredentials = default(string);
        public string UseCredentials
        {
            get { return _UseCredentials; }
            set { _UseCredentials = value; }
        }

        private string _CredentialsUserName = default(string);
        public string CredentialsUserName
        {
            get { return _CredentialsUserName; }
            set { _CredentialsUserName = value; }
        }

        private string _CredentialsPassword = default(string);
        public string CredentialsPassword
        {
            get { return _CredentialsPassword; }
            set { _CredentialsPassword = value; }
        }

        private string _CredentialsDomain = default(string);
        public string CredentialsDomain
        {
            get { return _CredentialsDomain; }
            set { _CredentialsDomain = value; }
        }

        private string _MaxSpiderPerNum = default(string);
        public string MaxSpiderPerNum
        {
            get { return _MaxSpiderPerNum; }
            set { _MaxSpiderPerNum = value; }
        }

        private string _MaxOutPerNum = default(string);
        public string MaxOutPerNum
        {
            get { return _MaxOutPerNum; }
            set { _MaxOutPerNum = value; }
        }

        private string _MaxDownload = default(string);
        public string MaxDownload
        {
            get { return _MaxDownload; }
            set { _MaxDownload = value; }
        }

        private int _UrlRepeat = default(int);
        public int UrlRepeat
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

        private string _DownloadSegments = default(string);
        public string DownloadSegments
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

        private string _FinishDeleteOutFaild = default(string);
        public string FinishDeleteOutFaild
        {
            get { return _FinishDeleteOutFaild; }
            set { _FinishDeleteOutFaild = value; }
        }

        private string _FinishDeleteOutSucess = default(string);
        public string FinishDeleteOutSucess
        {
            get { return _FinishDeleteOutSucess; }
            set { _FinishDeleteOutSucess = value; }
        }

        private string _FinishDeleteUrl = default(string);
        public string FinishDeleteUrl
        {
            get { return _FinishDeleteUrl; }
            set { _FinishDeleteUrl = value; }
        }

        private string _FinishSignOutSucess = default(string);
        public string FinishSignOutSucess
        {
            get { return _FinishSignOutSucess; }
            set { _FinishSignOutSucess = value; }
        }

        private string _VisitUrlAfterEnd = default(string);
        public string VisitUrlAfterEnd
        {
            get { return _VisitUrlAfterEnd; }
            set { _VisitUrlAfterEnd = value; }
        }

        private string _valueText = default(string);
        public string valueText
        {
            get { return _valueText; }
            set { _valueText = value; }
        }

        private List<SuperJob> _SuperJobCollection = default(List<SuperJob>);
        public List<SuperJob> SuperJobCollection
        {
            get { return _SuperJobCollection; }
            set { _SuperJobCollection = value; }
        }

        private List<string> _StartAddress = new List<string>();
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

        private string _SortLabel = default(string);
        public string SortLabel
        {
            get { return _SortLabel; }
            set { _SortLabel = value; }
        }

        private string _ListLabel = default(string);
        public string ListLabel
        {
            get { return _ListLabel; }
            set { _ListLabel = value; }
        }

        private List<JobWebPost> _JobWebPostCollection = default(List<JobWebPost>);
        public List<JobWebPost> JobWebPostCollection
        {
            get { return _JobWebPostCollection; }
            set { _JobWebPostCollection = value; }
        }

    }
    public class SuperJob
    {
        private string _Level = default(string);
        public string Level
        {
            get { return _Level; }
            set { _Level = value; }
        }

        private string _PageName = default(string);
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

        private string _PagesUrlListAll = default(string);
        public string PagesUrlListAll
        {
            get { return _PagesUrlListAll; }
            set { _PagesUrlListAll = value; }
        }

        private string _GetPagesUrlAuto = default(string);
        public string GetPagesUrlAuto
        {
            get { return _GetPagesUrlAuto; }
            set { _GetPagesUrlAuto = value; }
        }

        private string _AcceptLanguage = default(string);
        public string AcceptLanguage
        {
            get { return _AcceptLanguage; }
            set { _AcceptLanguage = value; }
        }

        private string _UserAgent = default(string);
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

        private string _TimeOut = default(string);
        public string TimeOut
        {
            get { return _TimeOut; }
            set { _TimeOut = value; }
        }

        private string _MaxPages = default(string);
        public string MaxPages
        {
            get { return _MaxPages; }
            set { _MaxPages = value; }
        }

        private string _valueText = default(string);
        public string valueText
        {
            get { return _valueText; }
            set { _valueText = value; }
        }

        private List<Rule> _RuleCollection = default(List<Rule>);
        public List<Rule> RuleCollection
        {
            get { return _RuleCollection; }
            set { _RuleCollection = value; }
        }

    }
    public class Rule
    {
        private string _LabelName = default(string);
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

        private string _GetDataType = default(string);
        public string GetDataType
        {
            get { return _GetDataType; }
            set { _GetDataType = value; }
        }

        private string _StartStr = default(string);
        public string StartStr
        {
            get { return _StartStr; }
            set { _StartStr = value; }
        }

        private string _EndStr = default(string);
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

        private string _XPathAttribue = default(string);
        public string XPathAttribue
        {
            get { return _XPathAttribue; }
            set { _XPathAttribue = value; }
        }

        private string _TextRecognitionType = default(string);
        public string TextRecognitionType
        {
            get { return _TextRecognitionType; }
            set { _TextRecognitionType = value; }
        }

        private string _TextRecognitionCodeReturnType = default(string);
        public string TextRecognitionCodeReturnType
        {
            get { return _TextRecognitionCodeReturnType; }
            set { _TextRecognitionCodeReturnType = value; }
        }

        private string _LabelNotRepeat = default(string);
        public string LabelNotRepeat
        {
            get { return _LabelNotRepeat; }
            set { _LabelNotRepeat = value; }
        }

        private string _LabelNotNull = default(string);
        public string LabelNotNull
        {
            get { return _LabelNotNull; }
            set { _LabelNotNull = value; }
        }

        private string _LengthFiltOpertar = default(string);
        public string LengthFiltOpertar
        {
            get { return _LengthFiltOpertar; }
            set { _LengthFiltOpertar = value; }
        }

        private string _LengthFiltValue = default(string);
        public string LengthFiltValue
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

        private string _DownloadImage = default(string);
        public string DownloadImage
        {
            get { return _DownloadImage; }
            set { _DownloadImage = value; }
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

        private string _ManualType = default(string);
        public string ManualType
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

        private string _ManualRadomStringNum = default(string);
        public string ManualRadomStringNum
        {
            get { return _ManualRadomStringNum; }
            set { _ManualRadomStringNum = value; }
        }

        private string _ManualRadomNumStart = default(string);
        public string ManualRadomNumStart
        {
            get { return _ManualRadomNumStart; }
            set { _ManualRadomNumStart = value; }
        }

        private string _ManualRadomNumEnd = default(string);
        public string ManualRadomNumEnd
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

        private string _valueText = default(string);
        public string valueText
        {
            get { return _valueText; }
            set { _valueText = value; }
        }

        private List<Filters> _FiltersCollection = default(List<Filters>);
        public List<Filters> FiltersCollection
        {
            get { return _FiltersCollection; }
            set { _FiltersCollection = value; }
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

        private string _ToEngFilter = default(string);
        public string ToEngFilter
        {
            get { return _ToEngFilter; }
            set { _ToEngFilter = value; }
        }

        private List<ToPinyinFilter> _ToPinyinFilterCollection = default(List<ToPinyinFilter>);
        public List<ToPinyinFilter> ToPinyinFilterCollection
        {
            get { return _ToPinyinFilterCollection; }
            set { _ToPinyinFilterCollection = value; }
        }

    }
    public class ReplaceFilter
    {
        private string _old = default(string);
        public string old
        {
            get { return _old; }
            set { _old = value; }
        }

        private string _new = default(string);
        [XmlArrayAttribute("new")]
        public string New
        {
            get { return _new; }
            set { _new = value; }
        }

        private string _valueText = default(string);
        public string valueText
        {
            get { return _valueText; }
            set { _valueText = value; }
        }

    }
    public class RemoveHtmlFilter
    {
        private string _Indexs = default(string);
        public string Indexs
        {
            get { return _Indexs; }
            set { _Indexs = value; }
        }

        private string _valueText = default(string);
        public string valueText
        {
            get { return _valueText; }
            set { _valueText = value; }
        }

    }
    public class SubstringFilter
    {
        private string _start = default(string);
        public string start
        {
            get { return _start; }
            set { _start = value; }
        }

        private string _end = default(string);
        public string end
        {
            get { return _end; }
            set { _end = value; }
        }

        private string _valueText = default(string);
        public string valueText
        {
            get { return _valueText; }
            set { _valueText = value; }
        }

    }
    public class PureRegexFilter
    {
        private string _old = default(string);
        public string old
        {
            get { return _old; }
            set { _old = value; }
        }

        private string _new = default(string);
        [XmlArrayAttribute("new")]
        public string New
        {
            get { return _new; }
            set { _new = value; }
        }

        private string _valueText = default(string);
        public string valueText
        {
            get { return _valueText; }
            set { _valueText = value; }
        }

    }
    public class ToPinyinFilter
    {
        private string _sep = default(string);
        public string sep
        {
            get { return _sep; }
            set { _sep = value; }
        }

        private string _upperLowerType = default(string);
        public string upperLowerType
        {
            get { return _upperLowerType; }
            set { _upperLowerType = value; }
        }

        private string _onlyFirst = default(string);
        public string onlyFirst
        {
            get { return _onlyFirst; }
            set { _onlyFirst = value; }
        }

        private string _maxLengh = default(string);
        public string maxLengh
        {
            get { return _maxLengh; }
            set { _maxLengh = value; }
        }

        private string _valueText = default(string);
        public string valueText
        {
            get { return _valueText; }
            set { _valueText = value; }
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

        private int _PostStart = 1;
        public int PostStart
        {
            get { return _PostStart; }
            set { _PostStart = value; }
        }

        private int _PostEnd =5;
        public int PostEnd
        {
            get { return _PostEnd; }
            set { _PostEnd = value; }
        }

        private int _HttpMethod =0;
        public int HttpMethod
        {
            get { return _HttpMethod; }
            set { _HttpMethod = value; }
        }

        private bool _AutoPages = true;
        public bool AutoPages
        {
            get { return _AutoPages; }
            set { _AutoPages = value; }
        }

        private string _GetUrlType = default(string);
        public string GetUrlType
        {
            get { return _GetUrlType; }
            set { _GetUrlType = value; }
        }

        private string _ManualUrlStyle = default(string);
        public string ManualUrlStyle
        {
            get { return _ManualUrlStyle; }
            set { _ManualUrlStyle = value; }
        }

        private string _ManualUrlCompile = default(string);
        public string ManualUrlCompile
        {
            get { return _ManualUrlCompile; }
            set { _ManualUrlCompile = value; }
        }

        private string _XpathContent = default(string);
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

        private int _PagesMax = 0;
        public int PagesMax
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

        private string _AspxEnd = default(string);
        public string AspxEnd
        {
            get { return _AspxEnd; }
            set { _AspxEnd = value; }
        }

        private string _valueText = default(string);
        public string valueText
        {
            get { return _valueText; }
            set { _valueText = value; }
        }

        private List<PostHashDic> _PostHashDicCollection = default(List<PostHashDic>);
        public List<PostHashDic> PostHashDicCollection
        {
            get { return _PostHashDicCollection; }
            set { _PostHashDicCollection = value; }
        }

    }
    public class PostHashDic
    {
        private string _Name = default(string);
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Key = default(string);
        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }

        private string _Value = default(string);
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        private string _valueText = default(string);
        public string valueText
        {
            get { return _valueText; }
            set { _valueText = value; }
        }

    }
    public class JobWebPost
    {
        private string _WebPostId = default(string);
        public string WebPostId
        {
            get { return _WebPostId; }
            set { _WebPostId = value; }
        }

        private string _FName = default(string);
        public string FName
        {
            get { return _FName; }
            set { _FName = value; }
        }

        private string _Fid = default(string);
        public string Fid
        {
            get { return _Fid; }
            set { _Fid = value; }
        }

        private string _Md5 = default(string);
        public string Md5
        {
            get { return _Md5; }
            set { _Md5 = value; }
        }

        private string _valueText = default(string);
        public string valueText
        {
            get { return _valueText; }
            set { _valueText = value; }
        }

    }
    public class QueryXml
    {
        //public ClassTaskXml queryConfig(string XmlContent)
        //{
        //    XmlSerializerHelper xml = new XmlSerializerHelper();
        //    ClassTaskXml xmlresult=(ClassTaskXml)xml.LoadFromXml(XmlContent, typeof(ClassTaskXml));
        //    return xmlresult;
        //}
        public ClassTaskXml queryConfig(string XmlContent)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(XmlContent);
            ClassTaskXml __root = new ClassTaskXml();
            XmlNodeList node_rootList = xml.SelectNodes("//root");
            foreach (XmlNode _nodeTmp_root in node_rootList)
            {
                __root = new ClassTaskXml();
                if (_nodeTmp_root.Attributes["JobName"] != null)
                {
                    __root.JobName = _nodeTmp_root.Attributes["JobName"].InnerText;
                }
                if (_nodeTmp_root.Attributes["Cookie"] != null)
                {
                    __root.Cookie = _nodeTmp_root.Attributes["Cookie"].InnerText;
                }
                if (_nodeTmp_root.Attributes["UserAgent"] != null)
                {
                    __root.UserAgent = _nodeTmp_root.Attributes["UserAgent"].InnerText;
                }
                if (_nodeTmp_root.Attributes["Encdoing"] != null)
                {
                    __root.Encdoing = _nodeTmp_root.Attributes["Encdoing"].InnerText;
                }
                if (_nodeTmp_root.Attributes["CheckUrlRepeat"] != null)
                {
                    __root.CheckUrlRepeat = true;
                }
                if (_nodeTmp_root.Attributes["MultipleURLTestFirst"] != null && !string.IsNullOrEmpty(_nodeTmp_root.Attributes["MultipleURLTestFirst"].InnerText))
                {
                    __root.MultipleURLTestFirst = Convert.ToInt32(_nodeTmp_root.Attributes["MultipleURLTestFirst"].InnerText);
                }
                if (_nodeTmp_root.Attributes["JobId"] != null)
                {
                    __root.JobId = _nodeTmp_root.Attributes["JobId"].InnerText;
                }
                if (_nodeTmp_root.Attributes["UrlId"] != null)
                {
                    __root.UrlId = _nodeTmp_root.Attributes["UrlId"].InnerText;
                }
                if (_nodeTmp_root.Attributes["LoopJoinCode"] != null)
                {
                    __root.LoopJoinCode = _nodeTmp_root.Attributes["LoopJoinCode"].InnerText;
                }
                if (_nodeTmp_root.Attributes["UseWebOutput"] != null)
                {
                    __root.UseWebOutput = _nodeTmp_root.Attributes["UseWebOutput"].InnerText;
                }
                if (_nodeTmp_root.Attributes["UseFileOut"] != null)
                {
                    __root.UseFileOut = _nodeTmp_root.Attributes["UseFileOut"].InnerText;
                }
                if (_nodeTmp_root.Attributes["WebOutType"] != null)
                {
                    __root.WebOutType = _nodeTmp_root.Attributes["WebOutType"].InnerText;
                }
                if (_nodeTmp_root.Attributes["FileType"] != null)
                {
                    __root.FileType = _nodeTmp_root.Attributes["FileType"].InnerText;
                }
                if (_nodeTmp_root.Attributes["FileSavePath"] != null)
                {
                    __root.FileSavePath = _nodeTmp_root.Attributes["FileSavePath"].InnerText;
                }
                if (_nodeTmp_root.Attributes["FileTemplate"] != null)
                {
                    __root.FileTemplate = _nodeTmp_root.Attributes["FileTemplate"].InnerText;
                }
                if (_nodeTmp_root.Attributes["FilenNameType"] != null)
                {
                    __root.FilenNameType = _nodeTmp_root.Attributes["FilenNameType"].InnerText;
                }
                if (_nodeTmp_root.Attributes["FileEncoding"] != null)
                {
                    __root.FileEncoding = _nodeTmp_root.Attributes["FileEncoding"].InnerText;
                }
                if (_nodeTmp_root.Attributes["Bak"] != null)
                {
                    __root.Bak = _nodeTmp_root.Attributes["Bak"].InnerText;
                }
                if (_nodeTmp_root.Attributes["SpiderThreadNum"] != null)
                {
                    __root.SpiderThreadNum = _nodeTmp_root.Attributes["SpiderThreadNum"].InnerText;
                }
                if (_nodeTmp_root.Attributes["SpiderTimeInterval"] != null)
                {
                    __root.SpiderTimeInterval = _nodeTmp_root.Attributes["SpiderTimeInterval"].InnerText;
                }
                if (_nodeTmp_root.Attributes["OutThreadNum"] != null)
                {
                    __root.OutThreadNum = _nodeTmp_root.Attributes["OutThreadNum"].InnerText;
                }
                if (_nodeTmp_root.Attributes["OutTimeStart"] != null)
                {
                    __root.OutTimeStart = _nodeTmp_root.Attributes["OutTimeStart"].InnerText;
                }
                if (_nodeTmp_root.Attributes["OutTimeEnd"] != null)
                {
                    __root.OutTimeEnd = _nodeTmp_root.Attributes["OutTimeEnd"].InnerText;
                }
                if (_nodeTmp_root.Attributes["Plugin"] != null)
                {
                    __root.Plugin = _nodeTmp_root.Attributes["Plugin"].InnerText;
                }
                if (_nodeTmp_root.Attributes["ProxyType"] != null)
                {
                    __root.ProxyType = _nodeTmp_root.Attributes["ProxyType"].InnerText;
                }
                if (_nodeTmp_root.Attributes["ProxyPort"] != null)
                {
                    __root.ProxyPort = _nodeTmp_root.Attributes["ProxyPort"].InnerText;
                }
                if (_nodeTmp_root.Attributes["BaseFileDir"] != null)
                {
                    __root.BaseFileDir = _nodeTmp_root.Attributes["BaseFileDir"].InnerText;
                }
                if (_nodeTmp_root.Attributes["FileUploadDomain"] != null)
                {
                    __root.FileUploadDomain = _nodeTmp_root.Attributes["FileUploadDomain"].InnerText;
                }
                if (_nodeTmp_root.Attributes["UseFtp"] != null)
                {
                    __root.UseFtp = _nodeTmp_root.Attributes["UseFtp"].InnerText;
                }
                if (_nodeTmp_root.Attributes["FtpServer"] != null)
                {
                    __root.FtpServer = _nodeTmp_root.Attributes["FtpServer"].InnerText;
                }
                if (_nodeTmp_root.Attributes["FtpPort"] != null)
                {
                    __root.FtpPort = _nodeTmp_root.Attributes["FtpPort"].InnerText;
                }
                if (_nodeTmp_root.Attributes["FtpUserName"] != null)
                {
                    __root.FtpUserName = _nodeTmp_root.Attributes["FtpUserName"].InnerText;
                }
                if (_nodeTmp_root.Attributes["FtpPassword"] != null)
                {
                    __root.FtpPassword = _nodeTmp_root.Attributes["FtpPassword"].InnerText;
                }
                if (_nodeTmp_root.Attributes["FtpBaseDir"] != null)
                {
                    __root.FtpBaseDir = _nodeTmp_root.Attributes["FtpBaseDir"].InnerText;
                }
                if (_nodeTmp_root.Attributes["FtpPassiveMode"] != null)
                {
                    __root.FtpPassiveMode = _nodeTmp_root.Attributes["FtpPassiveMode"].InnerText;
                }
                if (_nodeTmp_root.Attributes["FtpUploadFrist"] != null)
                {
                    __root.FtpUploadFrist = _nodeTmp_root.Attributes["FtpUploadFrist"].InnerText;
                }
                if (_nodeTmp_root.Attributes["DeleteFileAfterUpload"] != null)
                {
                    __root.DeleteFileAfterUpload = _nodeTmp_root.Attributes["DeleteFileAfterUpload"].InnerText;
                }
                if (_nodeTmp_root.Attributes["NotWebOutIfFileNoDownLoad"] != null)
                {
                    __root.NotWebOutIfFileNoDownLoad = _nodeTmp_root.Attributes["NotWebOutIfFileNoDownLoad"].InnerText;
                }
                if (_nodeTmp_root.Attributes["UseCredentials"] != null)
                {
                    __root.UseCredentials = _nodeTmp_root.Attributes["UseCredentials"].InnerText;
                }
                if (_nodeTmp_root.Attributes["CredentialsUserName"] != null)
                {
                    __root.CredentialsUserName = _nodeTmp_root.Attributes["CredentialsUserName"].InnerText;
                }
                if (_nodeTmp_root.Attributes["CredentialsPassword"] != null)
                {
                    __root.CredentialsPassword = _nodeTmp_root.Attributes["CredentialsPassword"].InnerText;
                }
                if (_nodeTmp_root.Attributes["CredentialsDomain"] != null)
                {
                    __root.CredentialsDomain = _nodeTmp_root.Attributes["CredentialsDomain"].InnerText;
                }
                if (_nodeTmp_root.Attributes["MaxSpiderPerNum"] != null)
                {
                    __root.MaxSpiderPerNum = _nodeTmp_root.Attributes["MaxSpiderPerNum"].InnerText;
                }
                if (_nodeTmp_root.Attributes["MaxOutPerNum"] != null)
                {
                    __root.MaxOutPerNum = _nodeTmp_root.Attributes["MaxOutPerNum"].InnerText;
                }
                if (_nodeTmp_root.Attributes["MaxDownload"] != null)
                {
                    __root.MaxDownload = _nodeTmp_root.Attributes["MaxDownload"].InnerText;
                }
                if (_nodeTmp_root.Attributes["UrlRepeat"] != null)
                {
                    __root.UrlRepeat = Convert.ToInt32(_nodeTmp_root.Attributes["UrlRepeat"].InnerText);
                }
                if (_nodeTmp_root.Attributes["SignSucessIfAllPost"] != null)
                {
                    __root.SignSucessIfAllPost = _nodeTmp_root.Attributes["SignSucessIfAllPost"].InnerText;
                }
                if (_nodeTmp_root.Attributes["DownloadSegments"] != null)
                {
                    __root.DownloadSegments = _nodeTmp_root.Attributes["DownloadSegments"].InnerText;
                }
                if (_nodeTmp_root.Attributes["PhpPlugin"] != null)
                {
                    __root.PhpPlugin = _nodeTmp_root.Attributes["PhpPlugin"].InnerText;
                }
                if (_nodeTmp_root.Attributes["FinishDeleteOutFaild"] != null)
                {
                    __root.FinishDeleteOutFaild = _nodeTmp_root.Attributes["FinishDeleteOutFaild"].InnerText;
                }
                if (_nodeTmp_root.Attributes["FinishDeleteOutSucess"] != null)
                {
                    __root.FinishDeleteOutSucess = _nodeTmp_root.Attributes["FinishDeleteOutSucess"].InnerText;
                }
                if (_nodeTmp_root.Attributes["FinishDeleteUrl"] != null)
                {
                    __root.FinishDeleteUrl = _nodeTmp_root.Attributes["FinishDeleteUrl"].InnerText;
                }
                if (_nodeTmp_root.Attributes["FinishSignOutSucess"] != null)
                {
                    __root.FinishSignOutSucess = _nodeTmp_root.Attributes["FinishSignOutSucess"].InnerText;
                }
                if (_nodeTmp_root.Attributes["VisitUrlAfterEnd"] != null)
                {
                    __root.VisitUrlAfterEnd = _nodeTmp_root.Attributes["VisitUrlAfterEnd"].InnerText;
                }
                __root.valueText = _nodeTmp_root.InnerText;
                SuperJob __SuperJob = new SuperJob();
                if (__root.SuperJobCollection == null)
                {
                    __root.SuperJobCollection = new List<SuperJob>();
                }
                XmlNodeList node_SuperJobList = _nodeTmp_root.SelectNodes("SuperJob");
                foreach (XmlNode _nodeTmp_SuperJob in node_SuperJobList)
                {
                    __SuperJob = new SuperJob();
                    if (_nodeTmp_SuperJob.Attributes["Level"] != null)
                    {
                        __SuperJob.Level = _nodeTmp_SuperJob.Attributes["Level"].InnerText;
                    }
                    if (_nodeTmp_SuperJob.Attributes["PageName"] != null)
                    {
                        __SuperJob.PageName = _nodeTmp_SuperJob.Attributes["PageName"].InnerText;
                    }
                    if (_nodeTmp_SuperJob.Attributes["PageEncoding"] != null)
                    {
                        __SuperJob.PageEncoding = _nodeTmp_SuperJob.Attributes["PageEncoding"].InnerText;
                    }
                    if (_nodeTmp_SuperJob.Attributes["PagesUrlListAll"] != null)
                    {
                        __SuperJob.PagesUrlListAll = _nodeTmp_SuperJob.Attributes["PagesUrlListAll"].InnerText;
                    }
                    if (_nodeTmp_SuperJob.Attributes["GetPagesUrlAuto"] != null)
                    {
                        __SuperJob.GetPagesUrlAuto = _nodeTmp_SuperJob.Attributes["GetPagesUrlAuto"].InnerText;
                    }
                    if (_nodeTmp_SuperJob.Attributes["AcceptLanguage"] != null)
                    {
                        __SuperJob.AcceptLanguage = _nodeTmp_SuperJob.Attributes["AcceptLanguage"].InnerText;
                    }
                    if (_nodeTmp_SuperJob.Attributes["UserAgent"] != null)
                    {
                        __SuperJob.UserAgent = _nodeTmp_SuperJob.Attributes["UserAgent"].InnerText;
                    }
                    if (_nodeTmp_SuperJob.Attributes["AutoDirect"] != null)
                    {
                        __SuperJob.AutoDirect = _nodeTmp_SuperJob.Attributes["AutoDirect"].InnerText;
                    }
                    if (_nodeTmp_SuperJob.Attributes["KeepAlive"] != null)
                    {
                        __SuperJob.KeepAlive = _nodeTmp_SuperJob.Attributes["KeepAlive"].InnerText;
                    }
                    if (_nodeTmp_SuperJob.Attributes["TimeOut"] != null)
                    {
                        __SuperJob.TimeOut = _nodeTmp_SuperJob.Attributes["TimeOut"].InnerText;
                    }
                    if (_nodeTmp_SuperJob.Attributes["MaxPages"] != null)
                    {
                        __SuperJob.MaxPages = _nodeTmp_SuperJob.Attributes["MaxPages"].InnerText;
                    }
                    __SuperJob.valueText = _nodeTmp_SuperJob.InnerText;
                    Rule __Rule = new Rule();
                    if (__SuperJob.RuleCollection == null)
                    {
                        __SuperJob.RuleCollection = new List<Rule>();
                    }
                    XmlNodeList node_RuleList = _nodeTmp_SuperJob.SelectNodes("Rule");
                    foreach (XmlNode _nodeTmp_Rule in node_RuleList)
                    {
                        __Rule = new Rule();
                        if (_nodeTmp_Rule.Attributes["LabelName"] != null)
                        {
                            __Rule.LabelName = _nodeTmp_Rule.Attributes["LabelName"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["DataSpider"] != null)
                        {
                            __Rule.DataSpider = _nodeTmp_Rule.Attributes["DataSpider"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["GetDataType"] != null)
                        {
                            __Rule.GetDataType = _nodeTmp_Rule.Attributes["GetDataType"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["StartStr"] != null)
                        {
                            __Rule.StartStr = _nodeTmp_Rule.Attributes["StartStr"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["EndStr"] != null)
                        {
                            __Rule.EndStr = _nodeTmp_Rule.Attributes["EndStr"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["RegexContent"] != null)
                        {
                            __Rule.RegexContent = _nodeTmp_Rule.Attributes["RegexContent"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["RegexCombine"] != null)
                        {
                            __Rule.RegexCombine = _nodeTmp_Rule.Attributes["RegexCombine"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["XpathContent"] != null)
                        {
                            __Rule.XpathContent = _nodeTmp_Rule.Attributes["XpathContent"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["XPathAttribue"] != null)
                        {
                            __Rule.XPathAttribue = _nodeTmp_Rule.Attributes["XPathAttribue"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["TextRecognitionType"] != null)
                        {
                            __Rule.TextRecognitionType = _nodeTmp_Rule.Attributes["TextRecognitionType"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["TextRecognitionCodeReturnType"] != null)
                        {
                            __Rule.TextRecognitionCodeReturnType = _nodeTmp_Rule.Attributes["TextRecognitionCodeReturnType"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["LabelNotRepeat"] != null)
                        {
                            __Rule.LabelNotRepeat = _nodeTmp_Rule.Attributes["LabelNotRepeat"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["LabelNotNull"] != null)
                        {
                            __Rule.LabelNotNull = _nodeTmp_Rule.Attributes["LabelNotNull"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["LengthFiltOpertar"] != null)
                        {
                            __Rule.LengthFiltOpertar = _nodeTmp_Rule.Attributes["LengthFiltOpertar"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["LengthFiltValue"] != null)
                        {
                            __Rule.LengthFiltValue = _nodeTmp_Rule.Attributes["LengthFiltValue"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["LabelContentMust"] != null)
                        {
                            __Rule.LabelContentMust = _nodeTmp_Rule.Attributes["LabelContentMust"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["LabelContentForbid"] != null)
                        {
                            __Rule.LabelContentForbid = _nodeTmp_Rule.Attributes["LabelContentForbid"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["DownloadImage"] != null)
                        {
                            __Rule.DownloadImage = _nodeTmp_Rule.Attributes["DownloadImage"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["FileUrlMust"] != null)
                        {
                            __Rule.FileUrlMust = _nodeTmp_Rule.Attributes["FileUrlMust"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["FileSaveDir"] != null)
                        {
                            __Rule.FileSaveDir = _nodeTmp_Rule.Attributes["FileSaveDir"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["FileSaveFormat"] != null)
                        {
                            __Rule.FileSaveFormat = _nodeTmp_Rule.Attributes["FileSaveFormat"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["ManualType"] != null)
                        {
                            __Rule.ManualType = _nodeTmp_Rule.Attributes["ManualType"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["ManualString"] != null)
                        {
                            __Rule.ManualString = _nodeTmp_Rule.Attributes["ManualString"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["ManualTimeStr"] != null)
                        {
                            __Rule.ManualTimeStr = _nodeTmp_Rule.Attributes["ManualTimeStr"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["ManualRadomStringLib"] != null)
                        {
                            __Rule.ManualRadomStringLib = _nodeTmp_Rule.Attributes["ManualRadomStringLib"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["ManualRadomStringNum"] != null)
                        {
                            __Rule.ManualRadomStringNum = _nodeTmp_Rule.Attributes["ManualRadomStringNum"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["ManualRadomNumStart"] != null)
                        {
                            __Rule.ManualRadomNumStart = _nodeTmp_Rule.Attributes["ManualRadomNumStart"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["ManualRadomNumEnd"] != null)
                        {
                            __Rule.ManualRadomNumEnd = _nodeTmp_Rule.Attributes["ManualRadomNumEnd"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["ManualRadomString"] != null)
                        {
                            __Rule.ManualRadomString = _nodeTmp_Rule.Attributes["ManualRadomString"].InnerText;
                        }
                        if (_nodeTmp_Rule.Attributes["MergeContent"] != null)
                        {
                            __Rule.MergeContent = _nodeTmp_Rule.Attributes["MergeContent"].InnerText;
                        }
                        __Rule.valueText = _nodeTmp_Rule.InnerText;
                        Filters __Filters = new Filters();
                        if (__Rule.FiltersCollection == null)
                        {
                            __Rule.FiltersCollection = new List<Filters>();
                        }
                        XmlNodeList node_FiltersList = _nodeTmp_Rule.SelectNodes("Filters");
                        foreach (XmlNode _nodeTmp_Filters in node_FiltersList)
                        {
                            ReplaceFilter __ReplaceFilter = new ReplaceFilter();
                            if (__Filters.ReplaceFilterCollection == null)
                            {
                                __Filters.ReplaceFilterCollection = new List<ReplaceFilter>();
                            }
                            XmlNodeList node_ReplaceFilterList = _nodeTmp_Filters.SelectNodes("ReplaceFilter");
                            foreach (XmlNode _nodeTmp_ReplaceFilter in node_ReplaceFilterList)
                            {
                                __ReplaceFilter = new ReplaceFilter();
                                if (_nodeTmp_ReplaceFilter.Attributes["old"] != null)
                                {
                                    __ReplaceFilter.old = _nodeTmp_ReplaceFilter.Attributes["old"].InnerText;
                                }
                                if (_nodeTmp_ReplaceFilter.Attributes["new"] != null)
                                {
                                    __ReplaceFilter.New = _nodeTmp_ReplaceFilter.Attributes["new"].InnerText;
                                }
                                __ReplaceFilter.valueText = _nodeTmp_ReplaceFilter.InnerText;
                                __Filters.ReplaceFilterCollection.Add(__ReplaceFilter);
                            }
                            RemoveHtmlFilter __RemoveHtmlFilter = new RemoveHtmlFilter();
                            if (__Filters.RemoveHtmlFilterCollection == null)
                            {
                                __Filters.RemoveHtmlFilterCollection = new List<RemoveHtmlFilter>();
                            }
                            XmlNodeList node_RemoveHtmlFilterList = _nodeTmp_Filters.SelectNodes("RemoveHtmlFilter");
                            foreach (XmlNode _nodeTmp_RemoveHtmlFilter in node_RemoveHtmlFilterList)
                            {
                                __RemoveHtmlFilter = new RemoveHtmlFilter();
                                if (_nodeTmp_RemoveHtmlFilter.Attributes["Indexs"] != null)
                                {
                                    __RemoveHtmlFilter.Indexs = _nodeTmp_RemoveHtmlFilter.Attributes["Indexs"].InnerText;
                                }
                                __RemoveHtmlFilter.valueText = _nodeTmp_RemoveHtmlFilter.InnerText;
                                __Filters.RemoveHtmlFilterCollection.Add(__RemoveHtmlFilter);
                            }
                            SubstringFilter __SubstringFilter = new SubstringFilter();
                            if (__Filters.SubstringFilterCollection == null)
                            {
                                __Filters.SubstringFilterCollection = new List<SubstringFilter>();
                            }
                            XmlNodeList node_SubstringFilterList = _nodeTmp_Filters.SelectNodes("SubstringFilter");
                            foreach (XmlNode _nodeTmp_SubstringFilter in node_SubstringFilterList)
                            {
                                __SubstringFilter = new SubstringFilter();
                                if (_nodeTmp_SubstringFilter.Attributes["start"] != null)
                                {
                                    __SubstringFilter.start = _nodeTmp_SubstringFilter.Attributes["start"].InnerText;
                                }
                                if (_nodeTmp_SubstringFilter.Attributes["end"] != null)
                                {
                                    __SubstringFilter.end = _nodeTmp_SubstringFilter.Attributes["end"].InnerText;
                                }
                                __SubstringFilter.valueText = _nodeTmp_SubstringFilter.InnerText;
                                __Filters.SubstringFilterCollection.Add(__SubstringFilter);
                            }
                            PureRegexFilter __PureRegexFilter = new PureRegexFilter();
                            if (__Filters.PureRegexFilterCollection == null)
                            {
                                __Filters.PureRegexFilterCollection = new List<PureRegexFilter>();
                            }
                            XmlNodeList node_PureRegexFilterList = _nodeTmp_Filters.SelectNodes("PureRegexFilter");
                            foreach (XmlNode _nodeTmp_PureRegexFilter in node_PureRegexFilterList)
                            {
                                __PureRegexFilter = new PureRegexFilter();
                                if (_nodeTmp_PureRegexFilter.Attributes["old"] != null)
                                {
                                    __PureRegexFilter.old = _nodeTmp_PureRegexFilter.Attributes["old"].InnerText;
                                }
                                if (_nodeTmp_PureRegexFilter.Attributes["new"] != null)
                                {
                                    __PureRegexFilter.New = _nodeTmp_PureRegexFilter.Attributes["new"].InnerText;
                                }
                                __PureRegexFilter.valueText = _nodeTmp_PureRegexFilter.InnerText;
                                __Filters.PureRegexFilterCollection.Add(__PureRegexFilter);
                            }
                            ToPinyinFilter __ToPinyinFilter = new ToPinyinFilter();
                            if (__Filters.ToPinyinFilterCollection == null)
                            {
                                __Filters.ToPinyinFilterCollection = new List<ToPinyinFilter>();
                            }
                            XmlNodeList node_ToPinyinFilterList = _nodeTmp_Filters.SelectNodes("ToPinyinFilter");
                            foreach (XmlNode _nodeTmp_ToPinyinFilter in node_ToPinyinFilterList)
                            {
                                __ToPinyinFilter = new ToPinyinFilter();
                                if (_nodeTmp_ToPinyinFilter.Attributes["sep"] != null)
                                {
                                    __ToPinyinFilter.sep = _nodeTmp_ToPinyinFilter.Attributes["sep"].InnerText;
                                }
                                if (_nodeTmp_ToPinyinFilter.Attributes["upperLowerType"] != null)
                                {
                                    __ToPinyinFilter.upperLowerType = _nodeTmp_ToPinyinFilter.Attributes["upperLowerType"].InnerText;
                                }
                                if (_nodeTmp_ToPinyinFilter.Attributes["onlyFirst"] != null)
                                {
                                    __ToPinyinFilter.onlyFirst = _nodeTmp_ToPinyinFilter.Attributes["onlyFirst"].InnerText;
                                }
                                if (_nodeTmp_ToPinyinFilter.Attributes["maxLengh"] != null)
                                {
                                    __ToPinyinFilter.maxLengh = _nodeTmp_ToPinyinFilter.Attributes["maxLengh"].InnerText;
                                }
                                __ToPinyinFilter.valueText = _nodeTmp_ToPinyinFilter.InnerText;
                                __Filters.ToPinyinFilterCollection.Add(__ToPinyinFilter);
                            }
                            foreach (XmlNode _nodeChild in _nodeTmp_Filters.ChildNodes)
                            {
                                if (_nodeChild.Name.Equals("ToEngFilter"))
                                {
                                    __Filters.ToEngFilter = _nodeChild.InnerText;
                                }
                            }
                            __Rule.FiltersCollection.Add(__Filters);
                        }
                        __SuperJob.RuleCollection.Add(__Rule);
                    }
                    __root.SuperJobCollection.Add(__SuperJob);
                }
                StepAddress __StepAddress = new StepAddress();
                if (__root.StepAddressCollection == null)
                {
                    __root.StepAddressCollection = new List<StepAddress>();
                }
                XmlNodeList node_StepAddressList = _nodeTmp_root.SelectNodes("StepAddress");
                foreach (XmlNode _nodeTmp_StepAddress in node_StepAddressList)
                {
                    __StepAddress = new StepAddress();
                    if (_nodeTmp_StepAddress.Attributes["UrlAreaStart"] != null)
                    {
                        __StepAddress.UrlAreaStart = _nodeTmp_StepAddress.Attributes["UrlAreaStart"].InnerText;
                    }
                    if (_nodeTmp_StepAddress.Attributes["UrlAreaEnd"] != null)
                    {
                        __StepAddress.UrlAreaEnd = _nodeTmp_StepAddress.Attributes["UrlAreaEnd"].InnerText;
                    }
                    if (_nodeTmp_StepAddress.Attributes["UrlForbid"] != null)
                    {
                        __StepAddress.UrlForbid = _nodeTmp_StepAddress.Attributes["UrlForbid"].InnerText;
                    }
                    if (_nodeTmp_StepAddress.Attributes["UrlMust"] != null)
                    {
                        __StepAddress.UrlMust = _nodeTmp_StepAddress.Attributes["UrlMust"].InnerText;
                    }
                    if (_nodeTmp_StepAddress.Attributes["PostData"] != null)
                    {
                        __StepAddress.PostData = _nodeTmp_StepAddress.Attributes["PostData"].InnerText;
                    }
                    if (_nodeTmp_StepAddress.Attributes["PostStart"] != null)
                    {
                        __StepAddress.PostStart = Convert.ToInt32( _nodeTmp_StepAddress.Attributes["PostStart"].InnerText);
                    }
                    if (_nodeTmp_StepAddress.Attributes["PostEnd"] != null)
                    {
                        __StepAddress.PostEnd = Convert.ToInt32(_nodeTmp_StepAddress.Attributes["PostEnd"].InnerText);
                    }
                    if (_nodeTmp_StepAddress.Attributes["HttpMethod"] != null)
                    {
                        __StepAddress.HttpMethod = Convert.ToInt32( _nodeTmp_StepAddress.Attributes["HttpMethod"].InnerText);
                    }
                    if (_nodeTmp_StepAddress.Attributes["AutoPages"] != null&&!string.IsNullOrEmpty(_nodeTmp_StepAddress.Attributes["AutoPages"].InnerText))
                    {
                        __StepAddress.AutoPages = Convert.ToBoolean( _nodeTmp_StepAddress.Attributes["AutoPages"].InnerText);
                    }
                    if (_nodeTmp_StepAddress.Attributes["GetUrlType"] != null)
                    {
                        __StepAddress.GetUrlType = _nodeTmp_StepAddress.Attributes["GetUrlType"].InnerText;
                    }
                    if (_nodeTmp_StepAddress.Attributes["ManualUrlStyle"] != null)
                    {
                        __StepAddress.ManualUrlStyle = _nodeTmp_StepAddress.Attributes["ManualUrlStyle"].InnerText;
                    }
                    if (_nodeTmp_StepAddress.Attributes["ManualUrlCompile"] != null)
                    {
                        __StepAddress.ManualUrlCompile = _nodeTmp_StepAddress.Attributes["ManualUrlCompile"].InnerText;
                    }
                    if (_nodeTmp_StepAddress.Attributes["XpathContent"] != null)
                    {
                        __StepAddress.XpathContent = _nodeTmp_StepAddress.Attributes["XpathContent"].InnerText;
                    }
                    if (_nodeTmp_StepAddress.Attributes["PagesAreaStart"] != null)
                    {
                        __StepAddress.PagesAreaStart = _nodeTmp_StepAddress.Attributes["PagesAreaStart"].InnerText;
                    }
                    if (_nodeTmp_StepAddress.Attributes["PagesAreaEnd"] != null)
                    {
                        __StepAddress.PagesAreaEnd = _nodeTmp_StepAddress.Attributes["PagesAreaEnd"].InnerText;
                    }
                    if (_nodeTmp_StepAddress.Attributes["PagesUrlStyle"] != null)
                    {
                        __StepAddress.PagesUrlStyle = _nodeTmp_StepAddress.Attributes["PagesUrlStyle"].InnerText;
                    }
                    if (_nodeTmp_StepAddress.Attributes["PagesUrlCompile"] != null)
                    {
                        __StepAddress.PagesUrlCompile = _nodeTmp_StepAddress.Attributes["PagesUrlCompile"].InnerText;
                    }
                    if (_nodeTmp_StepAddress.Attributes["PagesMax"] != null)
                    {
                        __StepAddress.PagesMax = Convert.ToInt32( _nodeTmp_StepAddress.Attributes["PagesMax"].InnerText);
                    }
                    if (_nodeTmp_StepAddress.Attributes["AddLabel"] != null)
                    {
                        __StepAddress.AddLabel = _nodeTmp_StepAddress.Attributes["AddLabel"].InnerText;
                    }
                    if (_nodeTmp_StepAddress.Attributes["AspxEnd"] != null)
                    {
                        __StepAddress.AspxEnd = _nodeTmp_StepAddress.Attributes["AspxEnd"].InnerText;
                    }
                    __StepAddress.valueText = _nodeTmp_StepAddress.InnerText;
                    PostHashDic __PostHashDic = new PostHashDic();
                    if (__StepAddress.PostHashDicCollection == null)
                    {
                        __StepAddress.PostHashDicCollection = new List<PostHashDic>();
                    }
                    XmlNodeList node_PostHashDicList = _nodeTmp_StepAddress.SelectNodes("PostHashDic");
                    foreach (XmlNode _nodeTmp_PostHashDic in node_PostHashDicList)
                    {
                        __PostHashDic = new PostHashDic();
                        if (_nodeTmp_PostHashDic.Attributes["Name"] != null)
                        {
                            __PostHashDic.Name = _nodeTmp_PostHashDic.Attributes["Name"].InnerText;
                        }
                        if (_nodeTmp_PostHashDic.Attributes["Key"] != null)
                        {
                            __PostHashDic.Key = _nodeTmp_PostHashDic.Attributes["Key"].InnerText;
                        }
                        if (_nodeTmp_PostHashDic.Attributes["Value"] != null)
                        {
                            __PostHashDic.Value = _nodeTmp_PostHashDic.Attributes["Value"].InnerText;
                        }
                        __PostHashDic.valueText = _nodeTmp_PostHashDic.InnerText;
                        __StepAddress.PostHashDicCollection.Add(__PostHashDic);
                    }
                    __root.StepAddressCollection.Add(__StepAddress);
                }
                JobWebPost __JobWebPost = new JobWebPost();
                if (__root.JobWebPostCollection == null)
                {
                    __root.JobWebPostCollection = new List<JobWebPost>();
                }
                XmlNodeList node_JobWebPostList = _nodeTmp_root.SelectNodes("JobWebPost");
                foreach (XmlNode _nodeTmp_JobWebPost in node_JobWebPostList)
                {
                    __JobWebPost = new JobWebPost();
                    if (_nodeTmp_JobWebPost.Attributes["WebPostId"] != null)
                    {
                        __JobWebPost.WebPostId = _nodeTmp_JobWebPost.Attributes["WebPostId"].InnerText;
                    }
                    if (_nodeTmp_JobWebPost.Attributes["FName"] != null)
                    {
                        __JobWebPost.FName = _nodeTmp_JobWebPost.Attributes["FName"].InnerText;
                    }
                    if (_nodeTmp_JobWebPost.Attributes["Fid"] != null)
                    {
                        __JobWebPost.Fid = _nodeTmp_JobWebPost.Attributes["Fid"].InnerText;
                    }
                    if (_nodeTmp_JobWebPost.Attributes["Md5"] != null)
                    {
                        __JobWebPost.Md5 = _nodeTmp_JobWebPost.Attributes["Md5"].InnerText;
                    }
                    __JobWebPost.valueText = _nodeTmp_JobWebPost.InnerText;
                    __root.JobWebPostCollection.Add(__JobWebPost);
                }
                foreach (XmlNode _nodeChild in _nodeTmp_root.ChildNodes)
                {
                    if (_nodeChild.Name.Equals("StartAddress"))
                    {
                        __root.StartAddress.Add(_nodeChild.InnerText);
                    }
                    if (_nodeChild.Name.Equals("SortLabel"))
                    {
                        __root.SortLabel = _nodeChild.InnerText;
                    }
                    if (_nodeChild.Name.Equals("ListLabel"))
                    {
                        __root.ListLabel = _nodeChild.InnerText;
                    }
                }
            }
            return __root;
        }
    }
}