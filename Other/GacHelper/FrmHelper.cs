using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GacHelper
{
    public partial class FrmHelper : Form
    {
        private class HelperClass
        {
            private string _From = "";
            private string _Category = "";
            private string _Title = "";
            private string _Content = "";
            private bool _IsAction = false;

            public HelperClass(string _From, string _Category, string _Title, string _Content,bool _IsAction=true)
            {
                this._From = _From;
                this._Category = _Category;
                this._Title = _Title;
                this._Content = _Content;
                this._IsAction = _IsAction;
            }

            public string Title
            {
                get
                {
                    return _Title;
                }

                set
                {
                    _Title = value;
                }
            }

            public string Content
            {
                get
                {
                    return _Content;
                }

                set
                {
                    _Content = value;
                }
            }

            public string Category
            {
                get
                {
                    return _Category;
                }

                set
                {
                    _Category = value;
                }
            }

            public string From
            {
                get
                {
                    return _From;
                }

                set
                {
                    _From = value;
                }
            }

            public bool IsAction
            {
                get
                {
                    return _IsAction;
                }

                set
                {
                    _IsAction = value;
                }
            }
        }
        Dictionary<string, HelperClass> dic = new Dictionary<string, HelperClass>();
        private void Init()
        {
            dic.Add("About", new HelperClass("Gac", "About", "关于GAC采集", "您正在使用一个完全免费的强大采集工具\r\n官网：http://www.gac.cc"));
            dic.Add("CheckUrl", new HelperClass("NewJob", "Step1", "检测网址重复的用途", " 为了防止重复采集数据，程序可以对已经采集的数据网址库进行对比去重，如果重复则 不采集。采集的网址是保存在单独的一个网址库文件中。每一个任务都有一个对应的网址库，每个网址库可以对应一个或多个任务。新建的任务都会单独设置一个新的网址库，用户如需要使用旧网址库，需要在“文件保存及部分高级设置“中选择网址库。"));
            dic.Add("UserAgent", new HelperClass("NewJob", "Step1", "User-Agent是什么", " User-Agent是浏览器的标识，某些网站会记录这些信息用来验证用户身份或是调整网页的显示效果。用户如设置了内置浏览器登录，则User-Agent会更改为内容浏览器的标识。用户可以更改该标识为自己需要的User-Agent。"));
            dic.Add("HandUrl", new HelperClass("NewJob", "Step1", "什么情况下需要手动填写规则？", " 对于某些脚本生成的网址，程序无法自动识别出链接地址。用户需要手动指定网址的链接格式，由程序获取匹配的数据并组合成新的网址。在写的匹配规则中，可以设置标签，该标签将被提取并保存到数据库中去。并在采内容时使用标签的数据处理功能进行二次处理。在网址组合部分，可以引用[参数X]和[标签:XX]."));
            dic.Add("XpathUrl", new HelperClass("NewJob", "Step1", "Xpath获取网址介绍", " 在Xpath方式获取网址过程中，只能设置 链接的格式且要选择多条匹配的格式。对于获取到的相对网址，程序会自动补全。"));
            dic.Add("ListPages", new HelperClass("NewJob", "Step1", "列表分页获取帮助", " 列表分页支持参数形式的地址组合方式获取，如果选自动识别分页则不必设置地址样式。列表分页是以网址获取的先后次序进行排列的。"));
            dic.Add("MultiPage", new HelperClass("NewJob", "Step2", "多页说明", " 这里列出了除默认页外的所有的多页。当用户在列表中删除某个多页时，该多页所包含的的所有标签也将被删除。多页管理中的使用原网址替换部分，使用的是纯正则的替换方式。", false));
            dic.Add("LoopRecord", new HelperClass("NewJob", "Step2", "标签循环处理说明", " 对于设置了该标签内容循环的记录，程序会按添加为新记录和用分隔符相连两种方式进行数据的保存。添加为新记录是针对所有循环项，按包含最多循环项的标签设置记录数，其它的有循环的记录参与循环，没有循环或循环记录不足的记录以空补全。"));
            dic.Add("PagesJonCode", new HelperClass("NewJob", "Step2","分页连接符", "当设置了标签在分页中匹配，且没有设置循环匹配的两个页面间的内容，会以分页内容连接代码合并。"));
            dic.Add("MultiPost", new HelperClass("NewJob", "Step3", "多网站乱序发布", "多网站乱序发布时，每个网站发布的数据都是不一样的，最后的结果相当于站群群发。"));
            dic.Add("SaveFile", new HelperClass("NewJob", "Step3", "文件保存格式", "文件保存支持多种方式，其中，word要使用word文件做模板。excel和CSV是以追加的形式将后面的数据添加到记录中去的。"));
            dic.Add("Thread", new HelperClass("NewJob", "Step4", "采集线程", "在任务运行时，线程越多，采集越快。但过多的线程会对采集网站或发布网站造成一定的影响，同时本地的数据库保存数据也会受到影响。一般可以根据网络网速调整自己的线程。"));
            dic.Add("DownMode", new HelperClass("NewJob", "Step4", "下载模式", "使用同步下载文件，是一条记录下载完成后开始下载文件，文件下载后再继续下一条记录的采集。异步下载是文件还没有下载完，另一条记录已经开始抓取并下载文件。"));
            dic.Add("LabelInCircle", new HelperClass("NewJob", "Lable", "循环匹配介绍", "循环匹配为竖向匹配，也就是当一个页面内存在多条记录时，用一个规则循环匹配它们；分页匹配为横向匹配，也就是信息存在于多个分页中，用一个规则在分页中分别匹配它们；网址中采集就是从当前网址中提取所需信息。"));
            dic.Add("InMultPages", new HelperClass("NewJob", "Lable", "关于所属多页的说明", "平常我们从得到页面的源代码中得到标签内容，请选择默认页。如果您需要的标签内容是在默认页代码中连接的另一个页面中，请选择使用多页。如果您需要的标签内容在网址中，请选择采集页地址作为所属页面"));
            dic.Add("AboutRegex", new HelperClass("NewJob", "Lable", "关于正则使用说明" ,"格式：正则前字符串(?<content>[\\w\\W]*?)正则后字符串,其中content是程序用来引用的。\r\n\r\n正则详细教程见：http://www.regexlab.com/zh/regref.htm"));
            dic.Add("LableCombination", new HelperClass("NewJob", "Lable", "标签组合说明", "标签组合的中的标签是将通过其它方式获取的数据组合成新数据这样可以对新数据进行内容处理如翻译，提取关键字等等。"));

            #region 发布模块部分
            dic.Add("GetCategory", new HelperClass("Module", "WebPostModule", "获取分类列表", "程序会提取符合条件的栏目信息，可以在发布配置中显示，方便用户选择。该项也可以不填写，在发布配置中直接指定。"));
            dic.Add("CopyRight", new HelperClass("Module", "WebPostModule", "模块密码", "用户可以将自己开发的模块添加版权说明。添加模块密码。没有输入密码的加密模块，只会以只读方式显示，用户不能修改。"));
            dic.Add("Login", new HelperClass("Module", "WebPostModule", "网站登陆", "网站登录时，程序会先请求来源页，然后用来源页获取的cookie提交登录网站。如果来原页和某个网页随机值是同一页面，则网页随机值会从这个页面获取。"));
            dic.Add("PostData", new HelperClass("Module", "WebPostModule", "发布数据说明", "表单名可以使用网页随机值，表单值可以使用右侧列出的所有的变量。"));
            #endregion

            #region 发布配置部分

            dic.Add("Globalvar", new HelperClass("Module", "WebPostManager", "全局变量说明", "全局变量可以在发布模块中所有位置使用，方便设置和修改某些参数。"));
            dic.Add("Encoding", new HelperClass("Module", "WebPostManager", "数据编码", "如果发布模块中未选择编码,建议此处手动选择正确编码,以提高编码准确率"));
            dic.Add("GetFidList", new HelperClass("Module", "WebPostManager", "获取分类列表", "如果发布模块中设置了栏目获取，则点击获取列表就可以得到栏目列表。如果出现格式不符的情况，可能是网站没有登录或是栏目获取规则有误。这时，程序会在左侧显示获取列表时返回的HTML源代码，方便用户分析查看。如果用户已知道分类ID号或分类名称，直接填写也可，不需要获取列表。"));
            dic.Add("Webbrowser", new HelperClass("Module", "WebPostManager", "内置浏览器登陆", "打开内置浏览器后，通过登录网站或浏览器已显示登录状态时，请点击获取cookie栏的确定按钮，程序会自动填写User-Agent和COOkie信息。"));
            dic.Add("PostLogin", new HelperClass("Module", "WebPostManager", "数据包登陆", "使用数据包方式登录不需要打开浏览器，适合一些验证简单的网站使用。如果发布模块中设置了获取验证码，请先获取验证码并填写后再点击登录按钮。如果验证码图片太大，请双击验证码图片，程序会弹出一个新窗口来显示验证码"));
            

            


            #endregion






        }
        public FrmHelper(string Action)
        {
            InitializeComponent();
            Init();
            if (string.IsNullOrEmpty(Action))
            {
                Action = "About";
            }
            if (dic.ContainsKey(Action))
            {
                HelperClass hc = dic[Action];
                this.Text = hc.Title;
                this.txtHelper.Text = hc.Content;
                this.txtHelper.Select(txtHelper.Text.Length, 0);
                if (hc.IsAction)
                {
                    this.Tag = "http://www.gac.cc/Helper/" + hc.From + "/" + hc.Category + ".html#" + Action;
                }
                else
                {
                    this.Tag = "http://www.gac.cc/Helper/" + hc.From + "/" + hc.Category + "/"+ Action + ".html" ;
                }
                
            }
        }

        private void FrmHelper_Load(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this.Tag.ToString());
        }
    }
}
