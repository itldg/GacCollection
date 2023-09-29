using System;
using System.Xml;
using System.Collections.Generic;
namespace GacXml
{
    public class LableInfo
    {
        private Rule _rule = new Rule();
        private string _MulitPageName = "";

        public Rule Rule
        {
            get
            {
                return _rule;
            }

            set
            {
                _rule = value;
            }
        }

        public string MulitPageName
        {
            get
            {
                return _MulitPageName;
            }

            set
            {
                _MulitPageName = value;
            }
        }
    }

    public class GacJob
    {
        private string _JobName = default(string);
        /// <summary>
        ///任务名称
        /// </summary>
        public string JobName
        {
            get { return _JobName; }
            set { _JobName = value; }
        }
        private string _Bak = default(string);
        /// <summary>
        ///任务备注
        /// </summary>
        public string Bak
        {
            get { return _Bak; }
            set { _Bak = value; }
        }
        private string _UserAgent = default(string);
        /// <summary>
        /// 浏览器用户代理
        /// </summary>
        public string UserAgent
        {
            get { return _UserAgent; }
            set { _UserAgent = value; }
        }

        private string _Cookie = default(string);
        /// <summary>
        /// 网页Cookie
        /// </summary>
        public string Cookie
        {
            get { return _Cookie; }
            set { _Cookie = value; }
        }

        private string _Encdoing = default(string);
        /// <summary>
        /// 网页编码
        /// </summary>
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

        private Int32 _JobId = default(Int32);
        /// <summary>
        /// 任务ID
        /// </summary>
        public Int32 JobId
        {
            get { return _JobId; }
            set { _JobId = value; }
        }

        private Int32 _UrlId = default(Int32);
        /// <summary>
        /// 用户ID
        /// </summary>
        public Int32 UrlId
        {
            get { return _UrlId; }
            set { _UrlId = value; }
        }
        
       private bool _LoopAddNewRecord = default(bool);
        /// <summary>
        /// 标签循环处理 添加为新记录
        /// </summary>
        public bool LoopAddNewRecord
        {
            get { return _LoopAddNewRecord; }
            set { _LoopAddNewRecord = value; }
        }

        private string _LoopJoinCode = default(string);
        /// <summary>
        /// 标签循环处理 用分隔符连接在上条记录后 分隔符
        /// </summary>
        public string LoopJoinCode
        {
            get { return _LoopJoinCode; }
            set { _LoopJoinCode = value; }
        }

        private bool _UseWebOutput = false;
        /// <summary>
        /// 是否启用方式一 发布到web
        /// </summary>
        public bool UseWebOutput
        {
            get { return _UseWebOutput; }
            set { _UseWebOutput = value; }
        }

        private bool _UseFileOut =false;
        /// <summary>
        /// 是否启用方式二 保存到本地文件
        /// </summary>
        public bool UseFileOut
        {
            get { return _UseFileOut; }
            set { _UseFileOut = value; }
        }

        private Int32 _WebOutType = default(Int32);
        /// <summary>
        /// web发布方式
        /// 0 正序发布
        /// 1 倒叙发布
        /// 2 乱序发布
        /// 3 多网站乱序发布
        /// </summary>
        public Int32 WebOutType
        {
            get { return _WebOutType; }
            set { _WebOutType = value; }
        }

        private Int32 _FileType = default(Int32);
        /// <summary>
        /// 发布方式二 文件类型
        /// 一条记录保存为一个txt文件
        ///一条记录保存为一个html文件
        ///一条记录保存为一个Word文档
        ///所有记录保存在一个Csv文件
        ///所有记录保存在一个Excel文件
        ///所有记录保存为一个txt文件
        ///所有记录保存为一个html文件
        /// </summary>
        public Int32 FileType
        {
            get { return _FileType; }
            set { _FileType = value; }
        }

        private string _FileSavePath = default(string);
        /// <summary>
        /// 发布方式二 保存位置
        /// </summary>
        public string FileSavePath
        {
            get { return _FileSavePath; }
            set { _FileSavePath = value; }
        }

        private string _FileTemplate = default(string);
        /// <summary>
        ///  发布方式二 文件模板
        /// </summary>
        public string FileTemplate
        {
            get { return _FileTemplate; }
            set { _FileTemplate = value; }
        }

        private string _FilenNameType = default(string);
        /// <summary>
        /// 发布方式二 文件名称
        /// </summary>
        public string FilenNameType
        {
            get { return _FilenNameType; }
            set { _FilenNameType = value; }
        }

        private string _FileEncoding = "UTF-8 ";
        /// <summary>
        /// 发布方式二 文件编码 默认：UTF-8 
        /// </summary>
        public string FileEncoding
        {
            get { return _FileEncoding; }
            set { _FileEncoding = value; }
        }

        private Int32 _SpiderThreadNum = default(Int32);
        /// <summary>
        ///单任务采集内容 线程数
        /// </summary>
        public Int32 SpiderThreadNum
        {
            get { return _SpiderThreadNum; }
            set { _SpiderThreadNum = value; }
        }

        private Int32 _SpiderTimeInterval = default(Int32);
        /// <summary>
        /// 单任务采集内容 延迟毫秒
        /// </summary>
        public Int32 SpiderTimeInterval
        {
            get { return _SpiderTimeInterval; }
            set { _SpiderTimeInterval = value; }
        }

        private Int32 _OutThreadNum = default(Int32);
        /// <summary>
        /// 发布内容 线程数
        /// </summary>
        public Int32 OutThreadNum
        {
            get { return _OutThreadNum; }
            set { _OutThreadNum = value; }
        }

        private Int32 _OutTimeStart = default(Int32);
        /// <summary>
        /// 发布内容间隔时间 最小
        /// </summary>
        public Int32 OutTimeStart
        {
            get { return _OutTimeStart; }
            set { _OutTimeStart = value; }
        }

        private Int32 _OutTimeEnd = default(Int32);
        /// <summary>
        /// 发布内容间隔时间 最大
        /// </summary>
        public Int32 OutTimeEnd
        {
            get { return _OutTimeEnd; }
            set { _OutTimeEnd = value; }
        }

        private string _Plugin = default(string);
        /// <summary>
        /// 插件
        /// </summary>
        public string Plugin
        {
            get { return _Plugin; }
            set { _Plugin = value; }
        }

        private Int32 _ProxyType = default(Int32);
        /// <summary>
        ///HTTP代理  代理类型
        ///0 使用IE浏览器代理
        ///1 不使用代理
        ///2 使用指定代理
        /// </summary>
        public Int32 ProxyType
        {
            get { return _ProxyType; }
            set { _ProxyType = value; }
        }
        private string _ProxyServer = default(string);
        /// <summary>
        /// HTTP代理 IP 参考值：127.0.0.1 
        /// </summary>
        public string ProxyServer
        {
            get { return _ProxyServer; }
            set { _ProxyServer = value; }
        }

        private Int32 _ProxyPort = default(Int32);
        /// <summary>
        /// HTTP代理 代理端口
        /// </summary>
        public Int32 ProxyPort
        {
            get { return _ProxyPort; }
            set { _ProxyPort = value; }
        }

        private string _ProxyUsername = default(string);
        /// <summary>
        /// HTTP代理 用户名 参考值：username 
        /// </summary>
        public string ProxyUsername
        {
            get { return _ProxyUsername; }
            set { _ProxyUsername = value; }
        }

        private string _ProxyPassword = default(string);
        /// <summary>
        /// HTTP代理 密码 参考值：password 
        /// </summary>
        public string ProxyPassword
        {
            get { return _ProxyPassword; }
            set { _ProxyPassword = value; }
        }

        private string _BaseFileDir = default(string);
        /// <summary>
        /// 下载设置 所有文件保存文件夹  参考值：C:\Users\wangl\Desktop\80s 
        /// </summary>
        public string BaseFileDir
        {
            get { return _BaseFileDir; }
            set { _BaseFileDir = value; }
        }

        private string _FileUploadDomain = default(string);
        /// <summary>
        /// 下载设置 文件链接地址前缀 
        /// </summary>
        public string FileUploadDomain
        {
            get { return _FileUploadDomain; }
            set { _FileUploadDomain = value; }
        }
        /// <summary>
        /// 下载设置 异步下载
        /// </summary>
        private bool _DownFileAsy = default(bool);
        public bool DownFileAsy
        {
            get { return _DownFileAsy; }
            set { _DownFileAsy = value; }
        }

    
        private string _UseFtp = default(string);
        public string UseFtp
        {
            get { return _UseFtp; }
            set { _UseFtp = value; }
        }

        private string _FtpServer = default(string);
        /// <summary>
        /// FTP服务器
        /// </summary>
        public string FtpServer
        {
            get { return _FtpServer; }
            set { _FtpServer = value; }
        }

        private Int32 _FtpPort = default(Int32);
        /// <summary>
        /// FTP端口
        /// </summary>
        public Int32 FtpPort
        {
            get { return _FtpPort; }
            set { _FtpPort = value; }
        }

        private string _FtpUserName = default(string);
        /// <summary>
        /// FTP用户名
        /// </summary>
        public string FtpUserName
        {
            get { return _FtpUserName; }
            set { _FtpUserName = value; }
        }

        private string _FtpPassword = default(string);
        /// <summary>
        /// FTP密码
        /// </summary>
        public string FtpPassword
        {
            get { return _FtpPassword; }
            set { _FtpPassword = value; }
        }

        private string _FtpBaseDir = default(string);
        /// <summary>
        /// FTP初始文件夹
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

        private bool _UseCredentials = default(bool);
        /// <summary>
        /// 基于windows身份验证  是否开启
        /// </summary>
        public bool UseCredentials
        {
            get { return _UseCredentials; }
            set { _UseCredentials = value; }
        }

        private string _CredentialsUserName = default(string);
        /// <summary>
        /// 基于windows身份验证 windows用户名 
        /// </summary>
        public string CredentialsUserName
        {
            get { return _CredentialsUserName; }
            set { _CredentialsUserName = value; }
        }

        private string _CredentialsPassword = default(string);
        /// <summary>
        /// 基于windows身份验证 windows密码 
        /// </summary>
        public string CredentialsPassword
        {
            get { return _CredentialsPassword; }
            set { _CredentialsPassword = value; }
        }

        private string _CredentialsDomain = default(string);
        /// <summary>
        /// 基于windows身份验证  windows域 
        /// </summary>
        public string CredentialsDomain
        {
            get { return _CredentialsDomain; }
            set { _CredentialsDomain = value; }
        }
        private bool _NotWebOutIfFileNoDownLoad = default(bool);
        /// <summary>
        /// 文件未下载成功不发布
        /// </summary>
        public bool NotWebOutIfFileNoDownLoad
        {
            get { return _NotWebOutIfFileNoDownLoad; }
            set { _NotWebOutIfFileNoDownLoad = value; }
        }
        private Int32 _MaxSpiderPerNum = default(Int32);
        /// <summary>
        /// 最大抓取数量
        /// </summary>
        public Int32 MaxSpiderPerNum
        {
            get { return _MaxSpiderPerNum; }
            set { _MaxSpiderPerNum = value; }
        }

        private Int32 _MaxOutPerNum = default(Int32);
        /// <summary>
        /// 最大抓取页码  ?最大发布数量?
        /// </summary>
        public Int32 MaxOutPerNum
        {
            get { return _MaxOutPerNum; }
            set { _MaxOutPerNum = value; }
        }

        private Int32 _MaxDownload = 3;
        /// <summary>
        /// 同时最多文件下载数
        /// </summary>
        public Int32 MaxDownload
        {
            get { return _MaxDownload; }
            set { _MaxDownload = value; }
        }

        private Int32 _UrlRepeat =0;
        /// <summary>
        /// 网址连续重复多少条后停止采网址 0为不限制
        /// </summary>
        public Int32 UrlRepeat
        {
            get { return _UrlRepeat; }
            set { _UrlRepeat = value; }
        }

        private bool _SignSucessIfAllPost = default(bool);
        /// <summary>
        /// 当所有的发布方式中所有配置都发布成功才标记数据为已发
        /// </summary>
        public bool SignSucessIfAllPost
        {
            get { return _SignSucessIfAllPost; }
            set { _SignSucessIfAllPost = value; }
        }

        private Int32 _DownloadSegments = 2;
        /// <summary>
        /// 文件下载设置-单文件下载分块数 默认为2
        /// </summary>
        public Int32 DownloadSegments
        {
            get { return _DownloadSegments; }
            set { _DownloadSegments = value; }
        }

        private string _PhpPlugin = default(string);
        /// <summary>
        /// php插件
        /// </summary>
        public string PhpPlugin
        {
            get { return _PhpPlugin; }
            set { _PhpPlugin = value; }
        }

        private bool _DownFileWithTools = default(bool);
        /// <summary>
        /// 下载地址保存为文件
        /// </summary>
        public bool DownFileWithTools
        {
            get { return _DownFileWithTools; }
            set { _DownFileWithTools = value; }
        }

        private bool _FinishDeleteOutFaild = default(bool);
        /// <summary>
        /// 发布结束后 删除未发布成功的数据
        /// </summary>
        public bool FinishDeleteOutFaild
        {
            get { return _FinishDeleteOutFaild; }
            set { _FinishDeleteOutFaild = value; }
        }
       
        private bool _FinishDeleteOutSucess = default(bool);
        /// <summary>
        /// 发布结束后 删除发布成功的数据
        /// </summary>
        public bool FinishDeleteOutSucess
        {
            get { return _FinishDeleteOutSucess; }
            set { _FinishDeleteOutSucess = value; }
        }
    
        private bool _FinishDeleteUrl = default(bool);
        /// <summary>
        /// 发布结束后 删除网址数据
        /// </summary>
        public bool FinishDeleteUrl
        {
            get { return _FinishDeleteUrl; }
            set { _FinishDeleteUrl = value; }
        }

        private bool _FinishSignOutSucess = default(bool);
        /// <summary>
        /// 发布结束后 标记所有记录为已发
        /// </summary>
        public bool FinishSignOutSucess
        {
            get { return _FinishSignOutSucess; }
            set { _FinishSignOutSucess = value; }
        }


        private string _VisitUrlAfterEnd = default(string);
        /// <summary>
        /// 发布完成后执行或访问网页
        /// </summary>
        public string VisitUrlAfterEnd
        {
            get { return _VisitUrlAfterEnd; }
            set { _VisitUrlAfterEnd = value; }
        }
        private List<SuperJob> _SuperJobCollection = default(List<SuperJob>);
        public List<SuperJob> SuperJobCollection
        {
            get { return _SuperJobCollection; }
            set { _SuperJobCollection = value; }
        }
        private bool _FillLoopWithFirst = default(bool);
        /// <summary>
        /// 标签循环处理 循环不足的记录以第一条记录补全
        /// </summary>
        public bool FillLoopWithFirst
        {
            get { return _FillLoopWithFirst; }
            set { _FillLoopWithFirst = value; }
        }
        private List<string> _StartAddress = default(List<string>);
        /// <summary>
        /// 起始网址,从该网址开始采集 
        /// </summary>
        public List<string> StartAddress
        {
            get { return _StartAddress; }
            set { _StartAddress = value; }
        }

        private List<StepAddress> _StepAddressCollection = new List<StepAddress>();
        public List<StepAddress> StepAddressCollection
        {
            get { return _StepAddressCollection; }
            set { _StepAddressCollection = value; }
        }

        private List<string> _SortLabel = default(List<string>);
        /// <summary>
        /// 标签列表 
        /// </summary>
        public List<string> SortLabel
        {
            get { return _SortLabel; }
            set { _SortLabel = value; }
        }

        private List<ListLabel> _ListLabelCollection =new List<ListLabel>();
        /// <summary>
        /// 列表标签
        /// </summary>
        public List<ListLabel> ListLabelCollection
        {
            get { return _ListLabelCollection; }
            set { _ListLabelCollection = value; }
        }

        private List<JobWebPost> _JobWebPostCollection = new List<JobWebPost>();
        /// <summary>
        /// 网站发布方式
        /// </summary>
        public List<JobWebPost> JobWebPostCollection
        {
            get { return _JobWebPostCollection; }
            set { _JobWebPostCollection = value; }
        }

        private List<string> _JobDatabase = new List<string>();
        /// <summary>
        /// 数据库发布方式 数字代表数据库发布的ID
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

        private bool _PagesUrlListAll = default(bool);
        /// <summary>
        /// 分页获取规则 全部列出模式
        /// </summary>
        public bool PagesUrlListAll
        {
            get { return _PagesUrlListAll; }
            set { _PagesUrlListAll = value; }
        }

        private string _PagesAreaStart = default(string);
        /// <summary>
        /// 分页获取规则 分页网址提取前
        /// </summary>
        public string PagesAreaStart
        {
            get { return _PagesAreaStart; }
            set { _PagesAreaStart = value; }
        }

        private string _PagesAreaEnd = default(string);
        /// <summary>
        /// 分页获取规则 分页网址提取后
        /// </summary>
        public string PagesAreaEnd
        {
            get { return _PagesAreaEnd; }
            set { _PagesAreaEnd = value; }
        }


        private bool _GetPagesUrlAuto = default(bool);
        /// <summary>
        /// 分页获取规则 自动识别
        /// </summary>
        public bool GetPagesUrlAuto
        {
            get { return _GetPagesUrlAuto; }
            set { _GetPagesUrlAuto = value; }
        }

        private string _PagesStyle = default(string);
        /// <summary>
        /// 分页获取规则 分页样式 
        /// </summary>
        public string PagesStyle
        {
            get { return _PagesStyle; }
            set { _PagesStyle = value; }
        }

        private string _PagesCombine = default(string);
        /// <summary>
        /// 分页获取规则 分页网址 
        /// </summary>
        public string PagesCombine
        {
            get { return _PagesCombine; }
            set { _PagesCombine = value; }
        }

        private string _PagesJoinCode = default(string);
        /// <summary>
        /// 分页内容链接代码 
        /// </summary>
        public string PagesJoinCode
        {
            get { return _PagesJoinCode; }
            set { _PagesJoinCode = value; }
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

        private Int32 _TimeOut = 30;
        /// <summary>
        /// Http请求 超时时间 默认30 
        /// </summary>
        public Int32 TimeOut
        {
            get { return _TimeOut; }
            set { _TimeOut = value; }
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

        private bool _AutoDirect = default(bool);
        /// <summary>
        /// Http请求自动跳转
        /// </summary>
        public bool AutoDirect
        {
            get { return _AutoDirect; }
            set { _AutoDirect = value; }
        }


        private bool _Deflate = default(bool);
        /// <summary>
        /// Http请求 Deflate
        /// </summary>
        public bool Deflate
        {
            get { return _Deflate; }
            set { _Deflate = value; }
        }


        private bool _Gzip = default(bool);
        /// <summary>
        /// Http请求 Gzip压缩
        /// </summary>
        public bool Gzip
        {
            get { return _Gzip; }
            set { _Gzip = value; }
        }

        private bool _KeepAlive = default(bool);
        /// <summary>
        /// Http请求 KeepAlive
        /// </summary>
        public bool KeepAlive
        {
            get { return _KeepAlive; }
            set { _KeepAlive = value; }
        }



        private Int32 _MaxPages =0;
        /// <summary>
        /// 最大采集分页数，0为不限 默认为0
        /// </summary>
        public Int32 MaxPages
        {
            get { return _MaxPages; }
            set { _MaxPages = value; }
        }

        private List<Rule> _RuleCollection =new List<Rule>();
        public List<Rule> RuleCollection
        {
            get { return _RuleCollection; }
            set { _RuleCollection = value; }
        }
        private List<MultPages> _MultPagesCollection = new List<MultPages>();
        /// <summary>
        /// 多页
        /// </summary>
        public List<MultPages> MultPagesCollection
        {
            get { return _MultPagesCollection; }
            set { _MultPagesCollection = value; }
        }
        private List<string> _TestPageUrls = new List<string>();
        /// <summary>
        /// 参考值：http://www.kppt.cc/meiju/3762.html 
        /// </summary>
        public List<string> TestPageUrls
        {
            get { return _TestPageUrls; }
            set { _TestPageUrls = value; }
        }

    }

    /// <summary>
    /// 标签规则
    /// </summary>
    public class Rule
    {
        private string _LabelName = default(string);
        /// <summary>
        /// 标签名称 参考值：标题 
        /// </summary>
        public string LabelName
        {
            get { return _LabelName; }
            set { _LabelName = value; }
        }

        private bool _LabelInCircle = default(bool);
        /// <summary>
        /// 是否循环获取
        /// </summary>
        public bool LabelInCircle
        {
            get { return _LabelInCircle; }
            set { _LabelInCircle = value; }
        }

        private bool _LabelInPage = default(bool);
        /// <summary>
        /// 是否在分页中获取
        /// </summary>
        public bool LabelInPage
        {
            get { return _LabelInPage; }
            set { _LabelInPage = value; }
        }
        private bool _DataSpider = false;
        /// <summary>
        /// 是否是采集的数据（非固定格式）
        /// </summary>
        public bool DataSpider
        {
            get { return _DataSpider; }
            set { _DataSpider = value; }
        }

        private Int32 _GetDataType = default(Int32);
        /// <summary>
        /// 提取数据方式
        ///   0 前后截取
        ///   1 正则提取
        ///   3 标签组合
        ///   4 正文提取
        /// </summary>
        public Int32 GetDataType
        {
            get { return _GetDataType; }
            set { _GetDataType = value; }
        }

        private string _StartStr = default(string);
        /// <summary>
        /// 提取数据方式 文本截取 开始文本
        /// </summary>
        public string StartStr
        {
            get { return _StartStr; }
            set { _StartStr = value; }
        }

        private string _EndStr = default(string);
        /// <summary>
        /// 提取数据方式 文本截取 结束文本
        /// </summary>
        public string EndStr
        {
            get { return _EndStr; }
            set { _EndStr = value; }
        }

        private string _RegexContent = default(string);
        /// <summary>
        /// 提取数据方式 正则提取 正则匹配内容
        /// </summary>
        public string RegexContent
        {
            get { return _RegexContent; }
            set { _RegexContent = value; }
        }

        private string _RegexCombine = default(string);
        /// <summary>
        /// 提取数据方式 正则提取 组合结果
        /// </summary>
        public string RegexCombine
        {
            get { return _RegexCombine; }
            set { _RegexCombine = value; }
        }

        private string _XpathContent = default(string);
        /// <summary>
        /// 提取数据方式 可视化提取 Xpath表达式
        /// </summary>
        public string XpathContent
        {
            get { return _XpathContent; }
            set { _XpathContent = value; }
        }

        private Int32 _XPathAttribue = default(Int32);
        /// <summary>
        ///提取数据方式 可视化提取 选择节点属性
        ///0,InnerHtml  1,InnerText   2,OuterHtml   3,Href
        /// </summary>
        public Int32 XPathAttribue
        {
            get { return _XPathAttribue; }
            set { _XPathAttribue = value; }
        }

        private Int32 _TextRecognitionType = default(Int32);
        /// <summary>
        /// 提取数据方式 正文提取 提取类型
        /// 0,标题 1,内容 2,时间
        /// </summary>
        public Int32 TextRecognitionType
        {
            get { return _TextRecognitionType; }
            set { _TextRecognitionType = value; }
        }

        private Int32 _TextRecognitionCodeReturnType = default(Int32);
        /// <summary>
        /// 提取数据方式 正文提取 提取内容代码返回类型
        /// 0是完全
        /// 1是普通
        /// </summary>
        public Int32 TextRecognitionCodeReturnType
        {
            get { return _TextRecognitionCodeReturnType; }
            set { _TextRecognitionCodeReturnType = value; }
        }
        private bool _TextRecognitionNewsTrueBBsFalse = default(bool);
        /// <summary>
        /// 是否是新闻模式
        /// </summary>
        public bool TextRecognitionNewsTrueBBsFalse
        {
            get { return _TextRecognitionNewsTrueBBsFalse; }
            set { _TextRecognitionNewsTrueBBsFalse = value; }
        }
        private bool _LabelNotRepeat = default(bool);
        /// <summary>
        /// 内容过滤 采集结果不得重复
        /// </summary>
        public bool LabelNotRepeat
        {
            get { return _LabelNotRepeat; }
            set { _LabelNotRepeat = value; }
        }

        private bool _LabelNotNull = default(bool);
        /// <summary>
        /// 内容过滤 采集结果不得为空
        /// </summary>
        public bool LabelNotNull
        {
            get { return _LabelNotNull; }
            set { _LabelNotNull = value; }
        }

        private Int32 _LengthFiltOpertar = default(Int32);
        /// <summary>
        /// 内容过滤 长度操作判断
        /// 1 大于 
        /// 2 小于
        /// 3 等于
        /// 4 不等于
        /// </summary>
        public Int32 LengthFiltOpertar
        {
            get { return _LengthFiltOpertar; }
            set { _LengthFiltOpertar = value; }
        }

        private Int32 _LengthFiltValue = default(Int32);
        /// <summary>
        /// 内容过滤 长度参数
        /// </summary>
        public Int32 LengthFiltValue
        {
            get { return _LengthFiltValue; }
            set { _LengthFiltValue = value; }
        }

        private string _LabelContentMust = default(string);
        /// <summary>
        /// 内容过滤删除 必须包含关键词
        /// </summary>
        public string LabelContentMust
        {
            get { return _LabelContentMust; }
            set { _LabelContentMust = value; }
        }

        private string _LabelContentForbid = default(string);
        /// <summary>
        /// 内容过滤删除 不得包含关键词
        /// </summary>
        public string LabelContentForbid
        {
            get { return _LabelContentForbid; }
            set { _LabelContentForbid = value; }
        }

        private string _FileUrlMust = default(string);
        /// <summary>
        /// 文件下载 文件地址必须包含
        /// </summary>
        public string FileUrlMust
        {
            get { return _FileUrlMust; }
            set { _FileUrlMust = value; }
        }

        private string _FileSaveDir = default(string);
        /// <summary>
        /// 文件保存目录
        /// </summary>
        public string FileSaveDir
        {
            get { return _FileSaveDir; }
            set { _FileSaveDir = value; }
        }

        private string _FileSaveFormat = default(string);
        /// <summary>
        /// 文件保存格式
        /// </summary>
        public string FileSaveFormat
        {
            get { return _FileSaveFormat; }
            set { _FileSaveFormat = value; }
        }

        private Int32 _ManualType = default(Int32);
        /// <summary>
        /// 自定义固定数据类型 
        /// 0,固定字符串 1,系统时间 2,随机字符串 3,随机数字 4,随机抽取信息  5,系统时间戳
        /// </summary>
        public Int32 ManualType
        {
            get { return _ManualType; }
            set { _ManualType = value; }
        }

        private string _ManualString = default(string);
        /// <summary>
        /// 自定义固定数据类型 固定字符串
        /// </summary>
        public string ManualString
        {
            get { return _ManualString; }
            set { _ManualString = value; }
        }
        /// <summary>
        /// 自定义固定数据类型 系统时间
        /// </summary>
        private string _ManualTimeStr = default(string);
        public string ManualTimeStr
        {
            get { return _ManualTimeStr; }
            set { _ManualTimeStr = value; }
        }
        /// <summary>
        /// 自定义固定数据类型 随机字符串 字符库
        /// </summary>
        private string _ManualRadomStringLib = default(string);
        public string ManualRadomStringLib
        {
            get { return _ManualRadomStringLib; }
            set { _ManualRadomStringLib = value; }
        }

        private Int32 _ManualRadomStringNum = default(Int32);
        /// <summary>
        /// 自定义固定数据类型 随机字符串 随机长度
        /// </summary>
        public Int32 ManualRadomStringNum
        {
            get { return _ManualRadomStringNum; }
            set { _ManualRadomStringNum = value; }
        }

        private Int32 _ManualRadomNumStart = default(Int32);
        /// <summary>
        /// 自定义固定数据类型 随机数字 最小数字
        /// </summary>
        public Int32 ManualRadomNumStart
        {
            get { return _ManualRadomNumStart; }
            set { _ManualRadomNumStart = value; }
        }

        private Int32 _ManualRadomNumEnd = default(Int32);
        /// <summary>
        /// 自定义固定数据类型 随机数字 最大数字
        /// </summary>
        public Int32 ManualRadomNumEnd
        {
            get { return _ManualRadomNumEnd; }
            set { _ManualRadomNumEnd = value; }
        }

        private string _ManualRadomString = default(string);
        /// <summary>
        /// 自定义固定数据类型 随机抽取信息
        /// </summary>
        public string ManualRadomString
        {
            get { return _ManualRadomString; }
            set { _ManualRadomString = value; }
        }

        private string _MergeContent = default(string);
        /// <summary>
        /// 标签组合内容
        /// </summary>
        public string MergeContent
        {
            get { return _MergeContent; }
            set { _MergeContent = value; }
        }
        private bool _DataFromUrl = default(bool);
        /// <summary>
        /// 从网址中采集
        /// </summary>
        public bool DataFromUrl
        {
            get { return _DataFromUrl; }
            set { _DataFromUrl = value; }
        }
        
        private List<object> _FiltersCollection = new List<object>();
        /// <summary>
        /// 数据处理
        /// </summary>
        public List<object> FiltersCollection
        {
            get { return _FiltersCollection; }
            set { _FiltersCollection = value; }
        }

        private bool _FillRelativeUrl = default(bool);
        /// <summary>
        /// 文件下载 相对网址补全
        /// </summary>
        public bool FillRelativeUrl
        {
            get { return _FillRelativeUrl; }
            set { _FillRelativeUrl = value; }
        }

        private bool _OnlyFetchValidUrl = default(bool);
        /// <summary>
        /// 文件下载 只探测不下载
        /// </summary>
        public bool OnlyFetchValidUrl
        {
            get { return _OnlyFetchValidUrl; }
            set { _OnlyFetchValidUrl = value; }
        }

        private bool _DownloadImage = default(bool);
        /// <summary>
        /// 文件下载 下载图片
        /// </summary>
        public bool DownloadImage
        {
            get { return _DownloadImage; }
            set { _DownloadImage = value; }
        }

        private bool _DownloadOtherFile = default(bool);
        /// <summary>
        /// 探测并下载
        /// </summary>
        public bool DownloadOtherFile
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


    #region Filters
    /// <summary>
    /// 内容替换
    /// </summary>
    public class ReplaceFilter
    {
        private string _old = default(string);
        /// <summary>
        /// 要替换什么字符串
        /// </summary>
        public string old
        {
            get { return _old; }
            set { _old = value; }
        }

        private string _New = default(string);
        /// <summary>
        /// 替换为什么字符串
        /// </summary>
        public string New
        {
            get { return _New; }
            set { _New = value; }
        }

    }

    /// <summary>
    /// HTML标签排除
    /// </summary>
    public class RemoveHtmlFilter
    {
        private string _Indexs = default(string);
        /// <summary>
        /// 逗号分割
        /// </summary>
        public string Indexs
        {
            get { return _Indexs; }
            set { _Indexs = value; }
        }

    }

    /// <summary>
    /// 内容截取
    /// </summary>
    public class SubstringFilter
    {
        private string _start = default(string);
        /// <summary>
        /// 从什么地方开始截取
        /// </summary>
        public string start
        {
            get { return _start; }
            set { _start = value.Replace("\r\n", "\n"); }
        }

        private string _end = default(string);
        /// <summary>
        /// 从什么地方结束截取
        /// </summary>
        public string end
        {
            get { return _end; }
            set { _end = value.Replace("\r\n", "\n"); }
        }

    }


    /// <summary>
    /// 纯正则替换
    /// </summary>
    public class PureRegexFilter
    {
        private string _old = default(string);
        /// <summary>
        /// 原正则表达式
        /// </summary>
        public string old
        {
            get { return _old; }
            set { _old = value.Replace("\r\n","\n"); }
        }

        private string _New = default(string);
        /// <summary>
        /// 替换正则表达式
        /// </summary>
        public string New
        {
            get { return _New; }
            set { _New = value.Replace("\r\n", "\n"); }
        }

    }


    /// <summary>
    /// 结果汉译英
    /// </summary>
    public class ToEngFilter
    {
    }

    /// <summary>
    /// 结果简体转繁体
    /// </summary>
    public class GbkToBig5Filter
    {
    }

    /// <summary>
    /// 结果繁体转简体
    /// </summary>
    public class Big5ToGbkFilter
    {
    }

    /// <summary>
    /// 自动转换为拼音
    /// </summary>
    public class ToPinyinFilter
    {
        private string _sep = "-";
        /// <summary>
        /// 分割符号 默认是-
        /// </summary>
        public string sep
        {
            get { return _sep; }
            set { _sep = value; }
        }

        private Int32 _upperLowerType = default(Int32);
        /// <summary>
        /// 大小写方式
        /// 0,首字母大写 1,全部大写 2,全部小写
        /// </summary>
        public Int32 upperLowerType
        {
            get { return _upperLowerType; }
            set { _upperLowerType = value; }
        }
       
        private Int32 _onlyFirst = default(Int32);
        /// <summary>
        /// 只获取首字母
        /// </summary>
        public Int32 onlyFirst
        {
            get { return _onlyFirst; }
            set { _onlyFirst = value; }
        }

        private Int32 _maxLengh = default(Int32);
        /// <summary>
        /// 拼音结果最大长度
        /// </summary>
        public Int32 maxLengh
        {
            get { return _maxLengh; }
            set { _maxLengh = value; }
        }

    }

    /// <summary>
    /// 转换为火星文
    /// </summary>
    public class ToMarsFilter
    {
    }

    /// <summary>
    /// 自动摘要
    /// </summary>
    public class ToSummaryFilter
    {
        private Int32 _length = default(Int32);
        /// <summary>
        /// 生成时截取摘要的前N个字符
        /// </summary>
        public Int32 length
        {
            get { return _length; }
            set { _length = value; }
        }

    }

    /// <summary>
    /// 自动分词
    /// </summary>
    public class ToWordSegFilter
    {
        private string _seq = "-";
        /// <summary>
        /// 分词分隔符，默认为-
        /// </summary>
        public string seq
        {
            get { return _seq; }
            set { _seq = value; }
        }

        private Int32 _maxsword = 3;
        /// <summary>
        ///取几个最高频率得词 默认为3
        /// </summary>
        public Int32 maxsword
        {
            get { return _maxsword; }
            set { _maxsword = value; }
        }

    }


    /// <summary>
    /// HTTP头信息提取
    /// </summary>
    public class HttpHeader
    {
        private Int32 _value = default(Int32);
        /// <summary>
        ///0,以Http请求的响应正文填充当前标签
        ///1,以Http请求的网页地址填充当前标签
        ///2,以Http请求返回的Location填充当前标签(无Location则为空)
        ///3,以Http请求返回的Last-Modified内容填充当前标签
        ///4,以Http请求返回的Header内容填充当前标签
        /// </summary>
        public Int32 value
        {
            get { return _value; }
            set { _value = value; }
        }

    }

    /// <summary>
    /// HTTP请求
    /// </summary>
    public class HttpRequest
    {
    }

    /// <summary>
    /// 字符编/解码
    /// </summary>
    public class TextEncode
    {
        private Int32 _codeType = default(Int32);
        /// <summary>
        /// 未严格测试
        ///0,URLDecode
        ///1,URLEncode
        ///2,From JS String
        ///3,To JS String
        ///4,HTML Encode
        ///5,From Base64
        ///6,To Base64
        ///7,HTML Decode
        /// </summary>
        public Int32 codeType
        {
            get { return _codeType; }
            set { _codeType = value; }
        }

        private string _encoding = "GBK ";
        /// <summary>
        /// 网页编码，默认GBK 
        /// </summary>
        public string encoding
        {
            get { return _encoding; }
            set { _encoding = value; }
        }

    }

    /// <summary>
    /// 同义词替换
    /// </summary>
    public class SynonymReplace
    {
        private string _value = default(string);
        /// <summary>
        /// 参考值：80s电影分类 
        /// </summary>
        public string value
        {
            get { return _value; }
            set { _value = value; }
        }

        private Int32 _IsOnlyReplaceFirstOne = default(Int32);
        /// <summary>
        /// 参考值：0 
        /// </summary>
        public Int32 IsOnlyReplaceFirstOne
        {
            get { return _IsOnlyReplaceFirstOne; }
            set { _IsOnlyReplaceFirstOne = value; }
        }

    }

    /// <summary>
    /// 提取第一张图片
    /// </summary>
    public class GetThumPic
    {
    }

    /// <summary>
    /// 内容空缺省
    /// </summary>
    public class FillEmpty
    {
        private string _fixdata = default(string);
        /// <summary>
        /// 缺省值 
        /// </summary>
        public string fixdata
        {
            get { return _fixdata; }
            set { _fixdata = value; }
        }

    }

    /// <summary>
    /// 内容添加前后缀
    /// </summary>
    public class FillBothEnd
    {
        private string _Start = default(string);
        /// <summary>
        /// 前缀
        /// </summary>
        public string Start
        {
            get { return _Start; }
            set { _Start = value; }
        }

        private string _End = default(string);
        /// <summary>
        /// 后缀
        /// </summary>
        public string End
        {
            get { return _End; }
            set { _End = value; }
        }

        private bool _EmptyNotFill = default(bool);
        /// <summary>
        /// 为空不添加
        /// </summary>
        public bool EmptyNotFill
        {
            get { return _EmptyNotFill; }
            set { _EmptyNotFill = value; }
        }

    }

    /// <summary>
    /// 随机插入
    /// </summary>
    public class RandomInsert
    {
        private string _SrcFile = default(string);
        /// <summary>
        /// 文本文件位置
        /// </summary>
        public string SrcFile
        {
            get { return _SrcFile; }
            set { _SrcFile = value; }
        }

        private Int32 _SelectRowNum = default(Int32);
        /// <summary>
        ///每次读取几行？
        /// </summary>
        public Int32 SelectRowNum
        {
            get { return _SelectRowNum; }
            set { _SelectRowNum = value; }
        }

        private bool _NotInHtmlTag = default(bool);
        /// <summary>
        /// 不要插入到HTML标签
        /// </summary>
        public bool NotInHtmlTag
        {
            get { return _NotInHtmlTag; }
            set { _NotInHtmlTag = value; }
        }

    }
    
    /// <summary>
    /// 补全当前网址
    /// </summary>
    public class ForceFillUrl
    {
    }
    #endregion




    public class MultPages
    {
        /// <summary>
        /// 虽然声明的是数组,但一般只有一个页面
        /// </summary>
        private List<MultPage> _MultPageCollection = default(List<MultPage>);
        public List<MultPage> MultPageCollection
        {
            get { return _MultPageCollection; }
            set { _MultPageCollection = value; }
        }

        /// <summary>
        /// 使用该多页的任务
        /// </summary>
        private List<SuperJob> _SuperJobCollection = default(List<SuperJob>);
        public List<SuperJob> SuperJobCollection
        {
            get { return _SuperJobCollection; }
            set { _SuperJobCollection = value; }
        }

    }


    public class MultPage
    {
        private string _PageName = default(string);
        /// <summary>
        /// 多页名称 参考值：平板MP4 
        /// </summary>
        public string PageName
        {
            get { return _PageName; }
            set { _PageName = value; }
        }

        private string _PageReplaceUrl = default(string);
        /// <summary>
        /// 多页 地址替换 正则规则 参考值：http://www.80s.tw/movie/(\d+) 
        /// </summary>
        public string PageReplaceUrl
        {
            get { return _PageReplaceUrl; }
            set { _PageReplaceUrl = value; }
        }

        private string _PageReplaceNew = default(string);
        /// <summary>
        /// 多页 地址替换 替换规则 参考值：http://www.80s.tw/movie/$1/bd-1 
        /// </summary>
        public string PageReplaceNew
        {
            get { return _PageReplaceNew; }
            set { _PageReplaceNew = value; }
        }

        private string _PageUrlStyle = default(string);
        /// <summary>
        /// 多页 源码采集 匹配内容
        /// </summary>
        public string PageUrlStyle
        {
            get { return _PageUrlStyle; }
            set { _PageUrlStyle = value; }
        }

        private string _PageUrlCombine = default(string);
        /// <summary>
        /// 多页 源码采集 组合结果
        /// </summary>
        public string PageUrlCombine
        {
            get { return _PageUrlCombine; }
            set { _PageUrlCombine = value; }
        }
        private bool _MultPageUrlFromHtml = default(bool);
        /// <summary>
        /// 多页 是否从源码中获取网址
        /// </summary>
        public bool MultPageUrlFromHtml
        {
            get { return _MultPageUrlFromHtml; }
            set { _MultPageUrlFromHtml = value; }
        }

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
        /// <summary>
        /// 从选定区域中提取网址-开始文本
        /// </summary>
        public string UrlAreaStart
        {
            get { return _UrlAreaStart; }
            set { _UrlAreaStart = value; }
        }

        private string _UrlAreaEnd = default(string);
        /// <summary>
        /// 从选定区域中提取网址-结束文本
        /// </summary>
        public string UrlAreaEnd
        {
            get { return _UrlAreaEnd; }
            set { _UrlAreaEnd = value; }
        }

        private string _UrlForbid = default(string);
        /// <summary>
        /// 网址不得包含
        /// </summary>
        public string UrlForbid
        {
            get { return _UrlForbid; }
            set { _UrlForbid = value; }
        }

        private string _UrlMust = default(string);
        /// <summary>
        /// 网址必须包含
        /// </summary>
        public string UrlMust
        {
            get { return _UrlMust; }
            set { _UrlMust = value; }
        }

        private string _PostData = default(string);
        /// <summary>
        /// Post方式获取列表-发送的数据
        /// </summary>
        public string PostData
        {
            get { return _PostData; }
            set { _PostData = value; }
        }

        private Int32 _PostStart = default(Int32);
        /// <summary>
        /// Post方式获取列表-分页标签从几开始 默认1
        /// </summary>
        public Int32 PostStart
        {
            get { return _PostStart; }
            set { _PostStart = value; }
        }

        private Int32 _PostEnd = default(Int32);
        /// <summary>
        /// Post方式获取列表-分页标签到几结束 默认3
        /// </summary>
        public Int32 PostEnd
        {
            get { return _PostEnd; }
            set { _PostEnd = value; }
        }

        private Int32 _HttpMethod = default(Int32);
        /// <summary>
        /// 请求类型 
        /// 0=Get
        /// 1=Post
        /// </summary>
        public Int32 HttpMethod
        {
            get { return _HttpMethod; }
            set { _HttpMethod = value; }
        }

        private bool _AutoPages = default(bool);
        /// <summary>
        /// 自动获取分页
        /// </summary>
        public bool AutoPages
        {
            get { return _AutoPages; }
            set { _AutoPages = value; }
        }

        private Int32 _GetUrlType = default(Int32);
        /// <summary>
        /// 网址获取方式 
        /// 0 自动提取
        /// 1 手动获取
        /// 2 Xpath
        /// </summary>
        public Int32 GetUrlType
        {
            get { return _GetUrlType; }
            set { _GetUrlType = value; }
        }

        private string _ManualUrlStyle = default(string);
        /// <summary>
        /// 手动填写链接地址规则-脚本规则 
        /// </summary>
        public string ManualUrlStyle
        {
            get { return _ManualUrlStyle; }
            set { _ManualUrlStyle = value; }
        }

        private string _ManualUrlCompile = default(string);
        /// <summary>
        /// 手动填写链接地址规则-实际连接 参考值：[参数1] 
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
        /// <summary>
        /// 附加参数-参数提取方式
        /// </summary>
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
        private List<PostHashDic> _PostHashDicCollection = new List<PostHashDic>();
        /// <summary>
        /// 提交的post参数取值
        /// </summary>
        public List<PostHashDic> PostHashDicCollection
        {
            get { return _PostHashDicCollection; }
            set { _PostHashDicCollection = value; }
        }
    }
    public class PostHashDic
    {
        private string _Name = default(string);
        /// <summary>
        /// 参考值：[POST随机值1] 
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Key = default(string);
        /// <summary>
        /// 参考值：<input type="hidden" name="__EVENTVALIDATION" id="__EVENTVALIDATION" value=" 
        /// </summary>
        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }

        private string _Value = default(string);
        /// <summary>
        /// 参考值：" /> 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
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

        private string _Fid = default(string);
        /// <summary>
        /// 参考值：5 
        /// </summary>
        public string Fid
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
