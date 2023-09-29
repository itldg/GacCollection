﻿using System;
using System.Collections.Generic;
using System.Text;
using GacXml;
using System.Text.RegularExpressions;
using PanGu;
using System.Linq;
using System.IO;
using System.Web;
using CsharpHttpHelper;

namespace Gac
{
    public class FilterCommon
    {
        public string GetFilterName(object filter)
        {
            if (filter is ReplaceFilter) { return "内容替换"; }
            else if (filter is RemoveHtmlFilter) { return "HTML标签排除"; }
            else if (filter is SubstringFilter) { return "字符截取"; }
            else if (filter is PureRegexFilter) { return "纯正则替换"; }
            else if (filter is ToEngFilter) { return "结果汉译英"; }
            else if (filter is GbkToBig5Filter) { return "结果简体转繁体"; }
            else if (filter is Big5ToGbkFilter) { return "结果繁体转简体"; }
            else if (filter is ToPinyinFilter) { return "自动转换为拼音"; }
            else if (filter is ToMarsFilter) { return "转换为火星文"; }
            else if (filter is ToSummaryFilter) { return "自动摘要"; }
            else if (filter is ToWordSegFilter) { return "自动分词"; }
            else if (filter is HttpHeader) { return "HTTP头信息提取"; }
            else if (filter is GacXml.HttpRequest) { return "HTTP请求"; }
            else if (filter is TextEncode) { return "字符编/解码"; }
            else if (filter is SynonymReplace) { return "同义词替换"; }
            else if (filter is GetThumPic) { return "提取第一张图片"; }
            else if (filter is FillEmpty) { return "内容空缺省"; }
            else if (filter is FillBothEnd) { return "内容添加前后缀"; }
            else if (filter is RandomInsert) { return "随机插入"; }
            else if (filter is ForceFillUrl) { return "补全当前网址"; }
            else
            {
                return "GAC未定义的处理1";
            }

        }
        public string GetFilterTitle(object filter)
        {
            if (filter is ReplaceFilter)
            {
                ReplaceFilter Filtertemp = (ReplaceFilter)filter;
                return "替换 " + Filtertemp.old + " 为" + Filtertemp.New;
            }
            else if (filter is RemoveHtmlFilter) { return "HTML标签排除"; }
            else if (filter is SubstringFilter) { return "字符截取"; }
            else if (filter is PureRegexFilter) { return "纯正则替换"; }
            else if (filter is ToEngFilter) { return "结果汉译英"; }
            else if (filter is GbkToBig5Filter) { return "结果简体转繁体"; }
            else if (filter is Big5ToGbkFilter) { return "结果繁体转简体"; }
            else if (filter is ToPinyinFilter) { return "自动转换为拼音"; }
            else if (filter is ToMarsFilter) { return "转换为火星文"; }
            else if (filter is ToSummaryFilter)
            {
                ToSummaryFilter Filtertemp = (ToSummaryFilter)filter;
                return "摘要前 " + Filtertemp.length + " 个字符";
            }
            else if (filter is ToWordSegFilter) { return "自动分词"; }
            else if (filter is HttpHeader) { return "HTTP头信息提取"; }
            else if (filter is GacXml.HttpRequest) { return "HTTP请求"; }
            else if (filter is TextEncode) { return "字符编/解码"; }
            else if (filter is SynonymReplace)
            {
                SynonymReplace Filtertemp = (SynonymReplace)filter;
                return "同义词替换 " + Filtertemp.value;
            }
            else if (filter is GetThumPic) { return "提取第一张图片"; }
            else if (filter is FillEmpty) { return "内容空缺省"; }
            else if (filter is FillBothEnd) { return "内容添加前后缀"; }
            else if (filter is RandomInsert) { return "随机插入"; }
            else if (filter is ForceFillUrl) { return "补全当前网址"; }
            else
            {
                return "GAC未定义的处理2";
            }

        }
        public string GetFilterResult(List<object> list, string lable,HttpResult httpInfo)
        {
            string result = lable;
            for (int i = 0; i < list.Count; i++)
            {
                result = GetFilterResult(list[i], result, httpInfo);
            }
            return result;
        }
        public string GetFilterResult(object filter, string lable, HttpResult httpInfo)
        {
            //字符替换
            if (filter is ReplaceFilter)
            {
                ReplaceFilter Filtertemp = (ReplaceFilter)filter;
                string result = GetReplaceFilter(Filtertemp, lable);
                return result;
            }
            //HTML标签排除
            else if (filter is RemoveHtmlFilter) {
                RemoveHtmlFilter Filtertemp = (RemoveHtmlFilter)filter;
                string result = GetRemoveHtmlFilter(Filtertemp, lable);
                return result;
           }
            //字符截取
            else if (filter is SubstringFilter) {
                SubstringFilter Filtertemp = (SubstringFilter)filter;
                string result = GetSubstringFilter(Filtertemp, lable);
                return result;
            }
            //纯正则替换
            else if (filter is PureRegexFilter) {
                PureRegexFilter Filtertemp = (PureRegexFilter)filter;
                string result = GetPureRegexFilter(Filtertemp, lable);
                return result;
            }
            else if (filter is ToEngFilter) { return "结果汉译英"; }
            //结果简体转繁体
            else if (filter is GbkToBig5Filter) {
                return GetGbkToBig5Filter(lable);
            }
            //结果繁体转简体
            else if (filter is Big5ToGbkFilter) {
                return GetBig5ToGbkFilter(lable);
            }
            //自动转换为拼音
            else if (filter is ToPinyinFilter) { return "自动转换为拼音"; }
            //转换为火星文
            else if (filter is ToMarsFilter) {

                return GetToMarsFilter(lable);
            }
            //摘要前N个字符
            else if (filter is ToSummaryFilter)
            {
                ToSummaryFilter Filtertemp = (ToSummaryFilter)filter;
                string temp = GetRemoveHtmlFilter(new RemoveHtmlFilter() { Indexs = "23" },lable);
                if (temp.Length > Filtertemp.length)
                {
                    return temp.Substring(0, Filtertemp.length);
                }
                else
                {
                    return temp;
                }
            }
            //自动分词
            else if (filter is ToWordSegFilter) {
                ToWordSegFilter Filtertemp = (ToWordSegFilter)filter;
                string result = GetToWordSegFilter(Filtertemp, lable);
                return result;
             }
            else if (filter is HttpHeader) {
                return "HTTP头信息提取";
            }
            else if (filter is GacXml.HttpRequest) { return "HTTP请求"; }
            //字符编/解码
            else if (filter is TextEncode) {
                return "字符编/解码";
            }
            //同义词替换
            else if (filter is SynonymReplace)
            {
                SynonymReplace Filtertemp = (SynonymReplace)filter;
               string result= GetSynonymReplace(Filtertemp, lable);
                return result;
            }
            //提取第一张图片
            else if (filter is GetThumPic) {
                string result = GetGetThumPic( lable);
                return result;
            }
            //内容空缺省
            else if (filter is FillEmpty) {
                FillEmpty Filtertemp = (FillEmpty)filter;
                if (string.IsNullOrEmpty(lable))
                {
                    return Filtertemp.fixdata;
                }
                return lable;
            }
            //内容添加前后缀
            else if (filter is FillBothEnd) {
                FillBothEnd Filtertemp = (FillBothEnd)filter;
                string result = GetFillBothEnd(Filtertemp, lable);
                return result;

            }
            else if (filter is RandomInsert) { return "随机插入"; }
            //补全当前网址
            else if (filter is ForceFillUrl) {
                string result = GetForceFillUrl(lable, httpInfo.item.URL);
                return result;
            }
            else
            {
                return lable;
            }

        }
        public string GetReplaceFilter(ReplaceFilter filter, string lable)
        {
            
            if (filter.old.Contains("(*)") || filter.old.Contains("[参数]"))
            {
                VariableHelper vh = new VariableHelper();
                string reg1 = vh.GetRegexStr(filter.old);
                string reg2 = vh.GetMatch(filter.New);
                string match = vh.ReplaceValue(reg1, reg2, lable);
                return match;
            }
            else
            {
                string result = lable.Replace(filter.old, filter.New);
                return result;
            }
        }
        public string GetRemoveHtmlFilter(RemoveHtmlFilter filter, string lable)
        {
            string[] ids = filter.Indexs.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            string result = lable;
            for (int i = 0; i < ids.Length; i++)
            {
                result = RemoveHtml(ids[i], result);
            }
            return result;
        }
        private string RemoveHtml(string id,string html)
        {
            if (id == "0")
            {
                return RegexReplace(html, "a");
            }
            else if (id == "1")
            {
                return RegexReplace(html, "table");
            }
            else if (id == "2")
            {
                return RegexReplace(html, "tr");
            }
            else if (id == "3")
            {
                return RegexReplace(html, "td");
            }
            else if (id == "4")
            {
                return RegexReplace(html, "p");
            }
            else if (id == "5")
            {
                return RegexReplace(html, "font");
            }
            else if (id == "6")
            {
                return RegexReplace(html, "div");
            }
            else if (id == "7")
            {
                return RegexReplace(html, "span");
            }
            else if (id == "8")
            {
                return RegexReplace(html, "tbody");
            }
            else if (id == "9")
            {
                return RegexReplace(html, "img");
            }
            else if (id == "10")
            {
                return RegexReplace(html, "script");
            }
            else if (id == "11")
            {
                string temp = RegexReplace(html, "b");
                return RegexReplace(temp, "strong");
            }
            else if (id == "12")
            {
                return RegexReplace(html, "br");
            }
            else if (id == "13")
            {
                return html.Replace("&nbsp;", "");
            }
            else if (id == "14")
            {
                return Regex.Replace(html, "<[hH]\\d[^>]*>|<\\/[hH]\\d[^>]*>", ""); ;
            }
            else if (id == "15")
            {
                return RegexReplace(html, "hr");
            }
            else if (id == "16")
            {
                return RegexReplace(html, "form");
            }
            else if (id == "17")
            {
                return RegexReplace(html, "frame");
            }
            else if (id == "18")
            {
                string temp = RegexReplace(html, "li");
                temp = RegexReplace(temp, "ul");
                temp = RegexReplace(temp, "dd");
                temp = RegexReplace(temp, "dt");
                return temp;
            }
            else if (id == "19")
            {
                return html.Replace("\\r", "").Replace("\\n", "").Replace("\\t", "");
            }
            else if (id == "20")
            {
                return html.Trim();
            }
            else if (id == "21")
            {
                return RegexReplace(html, "iframe");
            }
            else if (id == "22")
            {
                string temp = RegexReplace(html, "sub");
                return RegexReplace(temp, "sup");
            }
            else if (id == "23")
            {
                return Regex.Replace(html, "<[^>]*>|<\\/[^>]*>", ""); 
            }
            return html;
        }
        private string RegexReplace(string html, string lable)
        {
            string result = Regex.Replace(html, "<" + lable + "[^>]*>|<\\/" + lable + "[^>]*>", "");
            return result;
        }
        public string GetSubstringFilter(SubstringFilter filter, string lable)
        {
            if (lable.Contains("(*)"))
            {
                VariableHelper vh = new VariableHelper();
                string reg1 = vh.GetRegexStr(filter.start);
                string reg2 = vh.GetRegexStr(filter.end);
                reg1 = reg1 + "([\\s\\S]*?)" + reg2;
                Regex reg = new Regex(reg1);
                Match match = reg.Match(lable);
                if (match.Success)
                {
                    return match.Groups[1].Value;
                }
                else
                {
                    return "";
                }
                
            }
            else
            {
                int i = -1, i2 = -1;
                i = lable.IndexOf(filter.start, 0);
                if (i != -1)
                {
                    i += filter.start.Length;
                    i2 = lable.IndexOf(filter.end, i);
                    if (i2 != -1)
                    {
                        return lable.Substring(i, i2 - i);
                    }
                    else
                    {
                        return "";
                        //return lable.Substring(i);
                    }
                }
                else
                {
                    return "";
                }

            }
        }
        public string GetPureRegexFilter(PureRegexFilter filter, string lable)
        {
            string result = Regex.Replace(lable, filter.old, filter.New);
            return result;
        }
        public string GetGbkToBig5Filter(string lable)
        {
            string result = Microsoft.VisualBasic.Strings.StrConv(lable, Microsoft.VisualBasic.VbStrConv.TraditionalChinese, 0);
            return result;
        }
        /// <summary>
        /// 字符串繁体转简体
        /// </summary>
        /// <param name="lable">要转换的繁体字符串</param>
        /// <returns>返回转换后的简体字符</returns>
        public string GetBig5ToGbkFilter(string lable)
        {
            string result = Microsoft.VisualBasic.Strings.StrConv(lable, Microsoft.VisualBasic.VbStrConv.SimplifiedChinese, 0);
             return result;
        }
        public string GetToMarsFilter(string lable)
        {
            string jtw = "啊阿埃挨哎唉哀皑癌蔼矮艾碍爱隘鞍氨安俺按暗岸胺案肮昂盎凹敖熬翱袄傲奥懊澳芭捌扒叭吧笆八疤巴拔跋靶把耙坝霸罢爸白柏百摆佰败拜稗斑班搬扳般颁板版扮拌伴瓣半办绊邦帮梆榜膀绑棒磅蚌镑傍谤苞胞包褒剥薄雹保堡饱宝抱报暴豹鲍爆杯碑悲卑北辈背贝钡倍狈备惫焙被奔苯本笨崩绷甭泵蹦迸逼鼻比鄙笔彼碧蓖蔽毕毙毖币庇痹闭敝弊必辟壁臂避陛鞭边编贬扁便变卞辨辩辫遍标彪膘表鳖憋别瘪彬斌濒滨宾摈兵冰柄丙秉饼炳病并玻菠播拨钵波博勃搏铂箔伯帛舶脖膊渤泊驳捕卜哺补埠不布步簿部怖擦猜裁材才财睬踩采彩菜蔡餐参蚕残惭惨灿苍舱仓沧藏操糙槽曹草厕策侧册测层蹭插叉茬茶查碴搽察岔差诧拆柴豺搀掺蝉馋谗缠铲产阐颤昌猖场尝常长偿肠厂敞畅唱倡超抄钞朝嘲潮巢吵炒车扯撤掣彻澈郴臣辰尘晨忱沉陈趁衬撑称城橙成呈乘程惩澄诚承逞骋秤吃痴持匙池迟弛驰耻齿侈尺赤翅斥炽充冲虫崇宠抽酬畴踌稠愁筹仇绸瞅丑臭初出橱厨躇锄雏滁除楚础储矗搐触处揣川穿椽传船喘串疮窗幢床闯创吹炊捶锤垂春椿醇唇淳纯蠢戳绰疵茨磁雌辞慈瓷词此刺赐次聪葱囱匆从丛凑粗醋簇促蹿篡窜摧崔催脆瘁粹淬翠村存寸磋撮搓措挫错搭达答瘩打大呆歹傣戴带殆代贷袋待逮怠耽担丹单郸掸胆旦氮但惮淡诞弹蛋当挡党荡档刀捣蹈倒岛祷导到稻悼道盗德得的蹬灯登等瞪凳邓堤低滴迪敌笛狄涤翟嫡抵底地蒂第帝弟递缔颠掂滇碘点典靛垫电佃甸店惦奠淀殿碉叼雕凋刁掉吊钓调跌爹碟蝶迭谍叠丁盯叮钉顶鼎锭定订丢东冬董懂动栋侗恫冻洞兜抖斗陡豆逗痘都督毒犊独读堵睹赌杜镀肚度渡妒端短锻段断缎堆兑队对墩吨蹲敦顿囤钝盾遁掇哆多夺垛躲朵跺舵剁惰堕蛾峨鹅俄额讹娥恶厄扼遏鄂饿恩而儿耳尔饵洱二贰发罚筏伐乏阀法珐藩帆番翻樊矾钒繁凡烦反返范贩犯饭泛坊芳方肪房防妨仿访纺放菲非啡飞肥匪诽吠肺废沸费芬酚吩氛分纷坟焚汾粉奋份忿愤粪丰封枫蜂峰锋风疯烽逢冯缝讽奉凤佛否夫敷肤孵扶拂辐幅氟符伏俘服浮涪福袱弗甫抚辅俯釜斧脯腑府腐赴副覆赋复傅付阜父腹负富讣附妇缚咐噶嘎该改概钙盖溉干甘杆柑竿肝赶感秆敢赣冈刚钢缸肛纲岗港杠篙皋高膏羔糕搞镐稿告哥歌搁戈鸽胳疙割革葛格蛤阁隔铬个各给根跟耕更庚羹埂耿梗工攻功恭龚供躬公宫弓巩汞拱贡共钩勾沟苟狗垢构购够辜菇咕箍估沽孤姑鼓古蛊骨谷股故顾固雇刮瓜剐寡挂褂乖拐怪棺关官冠观管馆罐惯灌贯光广逛瑰规圭硅归龟闺轨鬼诡癸桂柜跪贵刽辊滚棍锅郭国果裹过哈骸孩海氦亥害骇酣憨邯韩含涵寒函喊罕翰撼捍旱憾悍焊汗汉夯杭航壕嚎豪毫郝好号浩呵喝荷菏核禾和何合盒貉阂河涸赫褐鹤贺嘿黑痕狠很恨哼亨横衡恒轰哄烘虹鸿洪宏弘红喉侯猴吼厚候后呼乎忽瑚壶葫胡蝴狐糊湖弧虎唬护互沪户花哗华猾滑画划化话槐徊怀淮坏欢环桓还缓换患唤痪豢焕涣宦幻荒慌黄磺蝗簧皇凰惶煌晃幌恍谎灰挥辉徽恢蛔回毁悔慧卉惠晦贿秽会烩汇讳诲绘荤昏婚魂浑混豁活伙火获或惑霍货祸击圾基机畸稽积箕肌饥迹激讥鸡姬绩缉吉极棘辑籍集及急疾汲即嫉级挤几脊己蓟技冀季伎祭剂悸济寄寂计记既忌际妓继纪嘉枷夹佳家加荚颊贾甲钾假稼价架驾嫁歼监坚尖笺间煎兼肩艰奸缄茧检柬碱拣捡简俭剪减荐槛鉴践贱见键箭件健舰剑饯渐溅涧建僵姜将浆江疆蒋桨奖讲匠酱降蕉椒礁焦胶交郊浇骄娇嚼搅铰矫侥脚狡角饺缴绞剿教酵轿较叫窖揭接皆秸街阶截劫节桔杰捷睫竭洁结解姐戒藉芥界借介疥诫届巾筋斤金今津襟紧锦仅谨进靳晋禁近烬浸尽劲荆兢茎睛晶鲸京惊精粳经井警景颈静境敬镜径痉靖竟竞净炯窘揪究纠玖韭久灸九酒厩救旧臼舅咎就疚鞠拘狙疽居驹菊局咀矩举沮聚拒据巨具距踞锯俱句惧炬剧捐鹃娟倦眷卷绢撅攫抉掘倔爵觉决诀绝均菌钧军君峻俊竣浚郡骏喀咖卡咯开揩楷凯慨刊堪勘坎砍看康慷糠扛抗亢炕考拷烤靠坷苛柯棵磕颗科壳咳可渴克刻客课肯啃垦恳坑吭空恐孔控抠口扣寇枯哭窟苦酷库裤夸垮挎跨胯块筷侩快宽款匡筐狂框矿眶旷况亏盔岿窥葵奎魁傀馈愧溃坤昆捆困括扩廓阔垃拉喇蜡腊辣啦莱来赖蓝婪栏拦篮阑兰澜谰揽览懒缆烂滥琅榔狼廊郎朗浪捞劳牢老佬姥酪烙涝勒乐雷镭蕾磊累儡垒擂肋类泪棱楞冷厘梨犁黎篱狸离漓理李里鲤礼莉荔吏栗丽厉励砾历利僳例俐痢立粒沥隶力璃哩俩联莲连镰廉怜涟帘敛脸链恋炼练粮凉梁粱良两辆量晾亮谅撩聊僚疗燎寥辽潦了撂镣廖料列裂烈劣猎琳林磷霖临邻鳞淋凛赁吝拎玲菱零龄铃伶羚凌灵陵岭领另令溜琉榴硫馏留刘瘤流柳六龙聋咙笼窿隆垄拢陇楼娄搂篓漏陋芦卢颅庐炉掳卤虏鲁麓碌露路赂鹿潞禄录陆戮驴吕铝侣旅履屡缕虑氯律率滤绿峦挛孪滦卵乱掠略抡轮伦仑沦纶论萝螺罗逻锣箩骡裸落洛骆络妈麻玛码蚂马骂嘛吗埋买麦卖迈脉瞒馒蛮满蔓曼慢漫谩芒茫盲氓忙莽猫茅锚毛矛铆卯茂冒帽貌贸么玫枚梅酶霉煤没眉媒镁每美昧寐妹媚门闷们萌蒙檬盟锰猛梦孟眯醚靡糜迷谜弥米秘觅泌蜜密幂棉眠绵冕免勉娩缅面苗描瞄藐秒渺庙妙蔑灭民抿皿敏悯闽明螟鸣铭名命谬摸摹蘑模膜磨摩魔抹末莫墨默沫漠寞陌谋牟某拇牡亩姆母墓暮幕募慕木目睦牧穆拿哪呐钠那娜纳氖乃奶耐奈南男难囊挠脑恼闹淖呢馁内嫩能妮霓倪泥尼拟你匿腻逆溺蔫拈年碾撵捻念娘酿鸟尿捏聂孽啮镊镍涅您柠狞凝宁拧泞牛扭钮纽脓浓农弄奴努怒女暖虐疟挪懦糯诺哦欧鸥殴藕呕偶沤啪趴爬帕怕琶拍排牌徘湃派攀潘盘磐盼畔判叛乓庞旁耪胖抛咆刨炮袍跑泡呸胚培裴赔陪配佩沛喷盆砰抨烹澎彭蓬棚硼篷膨朋鹏捧碰坯砒霹批披劈琵毗啤脾疲皮匹痞僻屁譬篇偏片骗飘漂瓢票撇瞥拼频贫品聘乒坪苹萍平凭瓶评屏坡泼颇婆破魄迫粕剖扑铺仆莆葡菩蒲埔朴圃普浦谱曝瀑期欺栖戚妻七凄漆柒沏其棋奇歧畦崎脐齐旗祈祁骑起岂乞企启契砌器气迄弃汽泣讫掐洽牵扦钎铅千迁签仟谦乾黔钱钳前潜遣浅谴堑嵌欠歉枪呛腔羌墙蔷强抢橇锹敲悄桥瞧乔侨巧鞘撬翘峭俏窍切茄且怯窃钦侵亲秦琴勤芹擒禽寝沁青轻氢倾卿清擎晴氰情顷请庆琼穷秋丘邱球求囚酋泅趋区蛆曲躯屈驱渠取娶龋趣去圈颧权醛泉全痊拳犬券劝缺炔瘸却鹊榷确雀裙群然燃冉染瓤壤攘嚷让饶扰绕惹热壬仁人忍韧任认刃妊纫扔仍日戎茸蓉荣融熔溶容绒冗揉柔肉茹蠕儒孺如辱乳汝入褥软阮蕊瑞锐闰润若弱撒洒萨腮鳃塞赛三叁伞散桑嗓丧搔骚扫嫂瑟色涩森僧莎砂杀刹沙纱傻啥煞筛晒珊苫杉山删煽衫闪陕擅赡膳善汕扇缮墒伤商赏晌上尚裳梢捎稍烧芍勺韶少哨邵绍奢赊蛇舌舍赦摄射慑涉社设砷申呻伸身深娠绅神沈审婶甚肾慎渗声生甥牲升绳省盛剩胜圣师失狮施湿诗尸虱十石拾时什食蚀实识史矢使屎驶始式示士世柿事拭誓逝势是嗜噬适仕侍释饰氏市恃室视试收手首守寿授售受瘦兽蔬枢梳殊抒输叔舒淑疏书赎孰熟薯暑曙署蜀黍鼠属术述树束戍竖墅庶数漱恕刷耍摔衰甩帅栓拴霜双爽谁水睡税吮瞬顺舜说硕朔烁斯撕嘶思私司丝死肆寺嗣四伺似饲巳松耸怂颂送宋讼诵搜艘擞嗽苏酥俗素速粟塑溯宿诉肃酸蒜算虽隋随绥髓碎岁穗遂隧祟孙损笋蓑梭唆缩琐索锁所塌他它她塔獭挞蹋踏胎苔抬台泰酞太态汰坍摊贪瘫滩坛檀痰潭谭谈坦毯袒碳探叹炭汤塘搪堂棠膛唐糖倘躺淌趟烫掏涛滔绦萄桃逃淘陶讨套特藤腾疼誊梯剔踢锑提题蹄啼体替嚏惕涕剃屉天添填田甜恬舔腆挑条迢眺跳贴铁帖厅听烃汀廷停亭庭挺艇通桐酮瞳同铜彤童桶捅筒统痛偷投头透凸秃突图徒途涂屠土吐兔湍团推颓腿蜕褪退吞屯臀拖托脱鸵陀驮驼椭妥拓唾挖哇蛙洼娃瓦袜歪外豌弯湾玩顽丸烷完碗挽晚皖惋宛婉万腕汪王亡枉网往旺望忘妄威巍微危韦违桅围唯惟为潍维苇萎委伟伪尾纬未蔚味畏胃喂魏位渭谓尉慰卫瘟温蚊文闻纹吻稳紊问嗡翁瓮挝蜗涡窝我斡卧握沃巫呜钨乌污诬屋无芜梧吾吴毋武五捂午舞伍侮坞戊雾晤物勿务悟误昔熙析西硒矽晰嘻吸锡牺稀息希悉膝夕惜熄烯溪汐犀檄袭席习媳喜铣洗系隙戏细瞎虾匣霞辖暇峡侠狭下厦夏吓掀锨先仙鲜纤咸贤衔舷闲涎弦嫌显险现献县腺馅羡宪陷限线相厢镶香箱襄湘乡翔祥详想响享项巷橡像向象萧硝霄削哮嚣销消宵淆晓小孝校肖啸笑效楔些歇蝎鞋协挟携邪斜胁谐写械卸蟹懈泄泻谢屑薪芯锌欣辛新忻心信衅星腥猩惺兴刑型形邢行醒幸杏性姓兄凶胸匈汹雄熊休修羞朽嗅锈秀袖绣墟戌需虚嘘须徐许蓄酗叙旭序畜恤絮婿绪续轩喧宣悬旋玄选癣眩绚靴薛学穴雪血勋熏循旬询寻驯巡殉汛训讯逊迅压押鸦鸭呀丫芽牙蚜崖衙涯雅哑亚讶焉咽阉烟淹盐严研蜒岩延言颜阎炎沿奄掩眼衍演艳堰燕厌砚雁唁彦焰宴谚验殃央鸯秧杨扬佯疡羊洋阳氧仰痒养样漾邀腰妖瑶摇尧遥窑谣姚咬舀药要耀椰噎耶爷野冶也页掖业叶曳腋夜液一壹医揖铱依伊衣颐夷遗移仪胰疑沂宜姨彝椅蚁倚已乙矣以艺抑易邑屹亿役臆逸肄疫亦裔意毅忆义益溢诣议谊译异翼翌绎茵荫因殷音阴姻吟银淫寅饮尹引隐印英樱婴鹰应缨莹萤营荧蝇迎赢盈影颖硬映哟拥佣臃痈庸雍踊蛹咏泳涌永恿勇用幽优悠忧尤由邮铀犹油游酉有友右佑釉诱又幼迂淤于盂榆虞愚舆余俞逾鱼愉渝渔隅予娱雨与屿禹宇语羽玉域芋郁吁遇喻峪御愈欲狱育誉浴寓裕预豫驭鸳渊冤元垣袁原援辕园员圆猿源缘远苑愿怨院曰约越跃钥岳粤月悦阅耘云郧匀陨允运蕴酝晕韵孕匝砸杂栽哉灾宰载再在咱攒暂赞赃脏葬遭糟凿藻枣早澡蚤躁噪造皂灶燥责择则泽贼怎增憎曾赠扎喳渣札轧铡闸眨栅榨咋乍炸诈摘斋宅窄债寨瞻毡詹粘沾盏斩辗崭展蘸栈占战站湛绽樟章彰漳张掌涨杖丈帐账仗胀瘴障招昭找沼赵照罩兆肇召遮折哲蛰辙者锗蔗这浙珍斟真甄砧臻贞针侦枕疹诊震振镇阵蒸挣睁征狰争怔整拯正政帧症郑证芝枝支吱蜘知肢脂汁之织职直植殖执值侄址指止趾只旨纸志挚掷至致置帜峙制智秩稚质炙痔滞治窒中盅忠钟衷终种肿重仲众舟周州洲诌粥轴肘帚咒皱宙昼骤珠株蛛朱猪诸诛逐竹烛煮拄瞩嘱主著柱助蛀贮铸筑住注祝驻抓爪拽专砖转撰赚篆桩庄装妆撞壮状椎锥追赘坠缀谆准捉拙卓桌琢茁酌啄着灼浊兹咨资姿滋淄孜紫仔籽滓子自渍字鬃棕踪宗综总纵邹走奏揍租足卒族祖诅阻组钻纂嘴醉最罪尊遵昨左佐柞做作坐座婵ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz123456789";
            string hxw = "錒阿埃挨砹唉哀皚癌藹矮艾碍噯隘鞍氨侒唵按黯堓胺案肮昻盎垇敖熬翱襖傲奧懊澳芭仈扒叭紦笆ハ疤巴拔跋靶夿耙垻灞罷爸苩柏粨擺佰贁拜稗斑班搬扳般頒板版扮拌姅瓣怑办絆邦幫梆榜膀綁棒磅蚌鎊徬謗苞胞苞褒剝薄雹葆堡飽寶菢報儤豹鮑爆柸碑蕜萆苝輩偝貝鋇倍狽俻憊焙被逩苯夲笨崩繃甭泵蹦逬逼濞笓鄙毞彼碧蓖蔽畢斃毖幣庇痹閉敝弊苾辟壁臂避陛鞭笾編貶扁緶変卞辨辯辮遍標滮膘裱鱉憋莂癟彬贇瀕濱賓擯兵栤柄丙秉餅炳寎幷箥菠播撥鉢啵愽葧搏鉑箔伯帛舶脖膊渤泊駁捕ト哺補埠卟咘埗簿蔀怖擦猜裁材ォ財睬踩綵彩菜蔡餐參蚕殘慚慘燦仺艙倉滄藏操糙槽曹愺廁憡側冊測層蹭插扠茬嗏查碴搽嚓岔鎈詫拆柴豺攙摻蟬饞谗纏鏟産闡顫誯猖場嘗鏛苌償腸廠敞暢唱倡趠抄鈔朝嘲謿巢吵炒車扯撤掣徹澈郴宧宸塵曟忱沉蔯趁襯撐稱城橙晟呈乗程惩澄誠承逞騁秤吃癡持匙池咫弛馳恥齒侈尺赤翅斥炽充沖蟲漴寵菗酬疇躊稠矁籌仇綢瞅醜溴初詘櫥廚躇鋤雏滁滁濋礎儲矗搐觸処揣巛穿椽傳船喘賗瘡窻幢床闖創吹炊捶錘垂舂椿醇滣淳蒓蠢戳綽疵茨磁雌辭慈瓷詞茈刺賜佽聰蔥囪匆苁丛湊粗醋簇促躥篡竄摧崔催脆瘁粹淬翠村洊団磋撮搓措挫諎搭達答瘩咑槑歹傣戴帶殆笩貸袋待逮怠耽擔丹單鄲撣膽旦氮但憚淡誕彈蛋噹擋黨蕩檔刀搗蹈倒島禱導菿稻悼檤盜德嘚の蹬燈登等瞪櫈鄧隄低嘀廸敵笛狄涤翟嫡牴厎哋蒂第偙弚递締顛掂滇碘嚸典靛墊電佃甸店惦奠澱殿碉叼雕凋刁鋽吊釣調跌爹碟蝶迭諜疊丁盯叮釘頂鼎錠啶訂銩倲咚董懂動棟侗恫凍洞兜抖乧陡豆逗痘嘟督毐犢獨讀堵睹賭杜鍍肚喥渡妒端短鍛段斷緞堆兌隊対墩吨蹲敦頓囤鈍盾遁掇哆誃奪垛躲朶跥舵刴惰墮蛾峨鵝俄額訛娥噁厄扼遏鄂餓恩侕ル珥爾餌洱ニ貳髮罰筏伐乏閥法琺藩帆番翻樊矾釩繁凡煩仮返範販犯飯泛坊芳方肪房防妨仿訪紡放菲非啡飛肥匪誹吠肺廢沸費芬酚吩氛衯紛墳燓汾蒶奮份忿憤糞丯葑楓蜂峯鋒颩瘋烽逢馮縫諷奉鳳佛俖夫敷肤孵扶拂輻幅氟符伏俘菔浮涪冨袱丳甫撫輔俯釜斧脯腑椨腐赴副覆賦複傅怤阜父腹負冨訃附婦縛咐噶嘎該攺概鈣蓋溉幹咁桿柑竿肝趕感稈澉贛岡剛鋼罁肛綱崗港杠篙臯髙膏羔糕搞鎬稿吿滒歌擱戈鴿胳疙割革葛格蛤閣隔鉻嗰各給根哏耕莄庚羹埂耿梗エ攻功恭龔供躬厷宮弜巩汞拱貢珙鈎勾溝苟狗垢構購夠辜菇咕箍估沽菰姑鼓古蠱嗗谷股故顧固雇刮苽剮寡掛褂乖箉怪棺関悹冠觀菅館罐慣灌貫茪廣逛瑰規圭硅歸龜閨軌廆詭癸溎櫃跪匮劊輥滾棍鍋郭啯淉裹濄哈骸孩海氦亥嗐駭酣憨邯韓浛菡寒函喊罕翰撼捍旱憾悍焊漢漢夯杭航壕嚎譹毫郝ぬ呺澔哬喝荷菏核秝啝何合盒貉閡菏涸赫褐鶴賀嘿潶痕狠佷詪哼亨橫衡恆轟哄烘渱鴻洪浤弘葒喉侯瘊吼厚堠逅泘苸惚瑚壺葫鬍鰗狐糊煳弧箎唬護彑滬戶埖嘩譁猾滑婳劃囮話槐徊懷淮壞歡環桓還緩換患喚瘓豢煥渙宦幻荒慌簧磺蝗簧隍凰惶瑝晃幌恍謊洃揮輝徽恢蛔徊毀誨懳泋蕙晦賄穢哙燴匯諱誨繪葷昬婚魂渾緄豁萿夥吙獲彧惑霍貨禍擊圾簊機畸稽積箕肌飢跡激讥鳮姬績緝吉極棘輯籍雧岌ゑ疾汲即嫉級擠凣脊巳薊技冀悸伎漈劑悸濟寄漃計誋溉誋際妓繼紀嘉枷夾佳傢伽莢頰賈曱鉀徦稼價架駕嫁殲監堅尖箋間煎兼肩艱奸緘茧檢柬碱揀撿簡儉剪減洊檻鑒踐濺笕鍵箭件旔艦劍餞漸濺澗建僵葁將漿茳彊蔣槳獎講匠醬跭蕉椒礁潐賋鲛郊澆驕嬌嚼攪鉸矯僥腳狡捔餃繳絞剿教酵轎較訆窖揭椄喈稭街階截劫兯桔烋捷睫竭潔結繲姊诫藉芥堺徣妎疥誡屆巾筋斤釒訡堻襟緊錦僅謹進靳晉僸近燼浸烬勁荊兢莖聙橸鯨亰驚精粳俓丼警景頸瀞境敬鏡徑痙靖竟競淨炯窘揪究糾玖韭玖灸艽酒廄救舊臼舅咎僦疚鞠拘狙疽居駒菊侷咀矩舉沮聚拒據巨具距踞鋸俱佝懼炬劇捐鵑鹃倦眷眷絹撅攫抉掘倔爵覺決訣絕均菌鈞軍珺峻俊竣浚郡駿喀咖咔咯幵揩楷凱慨刊堪勘坎砍看慷慷糠扛抗伉炕栲拷烤靠坷苛牁棵磕顆萪殼咳岢渴剋刻愙課肯啃墾懇坑吭悾恐孔控摳ロ扣寇喖哭窟苫酷庫褲誇垮挎跨胯塊筷儈筷寬款匡筐誑框礦眶曠況虧盔巋窺葵喹魁傀饋愧潰坤崑捆悃括擴廓闊垃菈喇蜡臘辣菈萊莱籟蘫婪欄攔籃闌蘭瀾讕攬覽懶纜爛濫琅榔誏廊鎯朗蒗撈勞哰佬佬姥酪烙澇勒楽雷鐳蕾磊蔂儡壘擂肋類涙棱楞泠厘藜犁黎籬狸離漓理李裡鯉禮峲荔吏栗郦厲勵礫歷悧僳例俐痢竝粒瀝隸ㄌ璃哩倆聯蓮連鐮濂憐漣簾斂臉鏈纞練練糧涼梁粱峎兩輛糧晾湸諒撩窷僚療燎寥遼潦ㄋ撂鐐廖料列裂煭劣獵諃林磷霖臨鄰鱗淋凜賃悋拎紷菱蕶齡鈴伶羚淩棂陵嶺領另囹溜琉榴硫餾留瀏瘤蓅柳⑥尨聋嚨籠窿隆壟攏隴樓婁摟簍漏陋蘆盧顱廬爐擄鹵虜魯麓碌虂璐賂簏潞祿錄陸戮驴呂鋁侶旅履屢縷慮氯嵂率濾綠巒攣孿滦卵薍掠略掄輪倫侖淪綸論蘿螺羅邏鑼籮騾裸落洛駱絡媽痲瑪碼螞馬罵嘛嗎埋買麥賣邁脈瞞饅蠻懑蔓謾謾漫謾芒鋩吂氓忙莽貓茅錨芼矛鉚卯茂瑁帽貌貿庅玫枚梅酶黣煤莈眉媒鎂每媄昧寐妹媚冂悶扪萌濛檬盟錳猛儚孟眯醚靡糜蒾謎彌冞秘覓泌藌嘧冪嬵眠綿冕浼勉娩緬緬苗描瞄藐秒渺廟妙蔑滅囻抿皿慜憫閩明螟鳴銘佲掵謬摸摹蘑模膜磨嚤魇抹ま嗼嚜默沫漠寞陌謀牟謀拇牡畝姆毋墓暮幕募慕朩目睦牧穆嗱哪呐鈉那娜納氖艿奶耐萘湳侽難囊撓脳悩鬧淖呢餒內嫩褦妮霓倪泥苨擬伱匿膩縌溺蔫拈哖碾攆撚淰娘釀袅尿捏聶孽啮鑷鎳涅您檸獰凝苧擰濘犇扭鈕紐膿濃侬挵奴努怒ㄝ暖虐瘧挪懦糯諾哦歐鷗毆蕅嘔偶漚啪趴爬帕怕琶拍排簰徘湃蒎攀瀋盤磐盻畔判頖乓龐臱耪胖拋咆刨炮袍跑萢呸肧培裵賠婄蓜姵沛噴盆砰抨烹澎嘭蓬棚硼篷膨倗鵬捧碰坯砒霹批披劈琵毗啤簲疲皮匹痞僻屁譬篇偏魸騙飄薸瓢票撇瞥拚頻貧榀聘乒坪蘋萍泙凴頩評幈坡潑頗嘙破魄迫粕剖扑鋪僕莆葡菩蒲埔樸圃鐠浦譜曝瀑剘欺棲鏚萋⑦淒漆柒沏萁棋奇歧畦崎臍齊旂祈祁騎起豈乞峜啓葜砌噐芞迄棄汽泣訖掐洽縴扦釺鉛仟遷簽仟謙乾黔銭鉗偂潛遣淺譴塹嵌芡歉槍嗆腔羌牆薔強搶橇鍬敲悄橋瞧喬僑巧鞘撬翹陗佾竅苆茄且怯窃欽侵瀙溱琴懃芹擒禽寢沁圊輕氫傾卿淸擎晴氰情頃請慶瓊窮萩丘邱銶俅囚酋泅趋岖蛆浀軀屈驅渠冣娶齲趣呿圏顴權醛湶佺痊拳猋券勸蒛炔瘸卻鵲榷確雀裙群嘫燃苒蒅瓤壤禳嚷讓饒擾繞惹熱壬仁亽忍韌恁認刃妊紉扔芿ㄖ戎茸蓉榮融熔溶傛絨冗揉柔肉茹蠕儒孺侞嗕乳汝兦褥軟阮蕊瑞銳閏潤婼鰯撒灑萨腮鰓塞賽③弎傘潵鎟嗓喪搔騷掃嫂瑟铯澀森僧莎砂殺刹唦紗儍啥煞篩曬珊苫杉屾刪煽衫閃陝擅贍膳善汕煽繕墒傷商賞晌丄尙裳梢捎稍燒芍勺韶尐哨邵紹奢賒蛇舌舎赦攝射懾涉社設砷申呻伸裑罙娠紳榊訦审嬸葚腎慎滲聲甡甥牲昇繩偗盛剰勝聖師矢獅施濕詩ㄕ虱⑩鉐拾埘什喰蝕實識史矢使屎駛始鉽呩壵丗柹亊拭誓逝勢媞嗜噬適仕侍釋飾氏铈恃室視試収手首垨壽授售綬瘦嘼蔬樞梳殊抒輸惄舒淑疎お贖孰熟薯暑曙署蜀黍癙属ポ蒁樹涑戍豎墅庻數漱恕刷耍摔縗甩帥栓拴孀雙爽誰氺娷稅吮瞬順舜說碩溯爍斯凘嘶偲俬司絲死肆寺嗣④伺似飼巳倯聳慫頌送宋訟誦搜艘擻嗽囌酥俗傃速粟塑溯宿訴肅酸蒜匴雖隋隨綏髓誶歲穗遂隧祟荪損筍蓑梭唆縮瑣索鎖所塌咃咜祂塔獺撻蹋踏胎苔擡囼泰酞冭態汰坍攤貪癱灘壇檀痰潭譚談鉭毯襢碳探歎炭湯塘搪嘡棠膛傏醣倘躺淌趟燙掏涛滔縧萄洮逃淘陶討套特藤騰疼謄梯剔踢銻提題蹄啼躰鐟嚏惕涕剃屜迗添填畾憇恬舔腆挑條迢眺跳貼鐵帖廳厛烴汀廷諪亭庭挺艇嗵桐酮瞳茼銅浵瞳桶捅筒統痛偸投頭透凸禿突图徒途塗屠汢吐兎湍团推頽腿蛻褪煺呑芚臋拖託脫鴕陀馱駝橢妥拓唾挖哇蛙窪鲑咓襪歪外豌彎灣魭頑芄烷綄碗挽晚皖惋宛婉萬腕汪仼亡枉網往旺望莣妄葳巍嶶危玮违桅圍蓶惟ゐ濰維葦萎諉偉偽尾緯耒蔚菋葨胄餵魏莅渭謂尉慰衛瘟薀蚊呅聞紋吻穩紊問嗡翁瓮撾蝸渦窩涐斡臥渥沃莁嗚鎢烏汚誣箼兂蕪梧忢吳毋倵⑤捂仵儛伍侮塢戊霧晤粅伆務悟誤昔熈析迺硒矽晰嘻吸錫犧稀蒠俙悉膝タ惜熄烯溪汐犀檄襲席習媳囍銑洗係隙戲細瞎蝦匣霞轄暇峽俠狹丅廈嗄嚇掀鍁筅苮鮮纖咸賢銜舷閑涎誸嫌显險現獻縣腺餡羨宪陥限綫葙廂鑲稥葙襄湘鄉翔祥詳想響享項巷橡像姠潒蕭硝霄削哮囂銷銷宵淆哓尐哮校綃嘯笶傚楔些歇蝎鞵協挾携峫斜脇諧冩械卸蠏懈洩瀉謝屑薪蕊鋅俽莘噺忻吢信衅煋鯹忻忻興刑型形邢哘醒啈莕性姓兄兇洶匈洶雄熊咻修羞朽嗅銹琇袖綉墟戌繻噓噓須蒣許蓄酗敘旭垿畜恤絮婿緒續軒喧宣懸漩玄選癬眩絢鞾薛學穴膤洫勛燻循旬詢尋馴巡殉汛訓訊遜迅壓押鴉鴨吖ㄚ芽伢蚜崖衙涯蕥啞娅訝焉咽閹煙淹盐严研蜒岩筵誩顏閻焱沿奄掩眼衍縯滟堰嚥厭硯鴈唁彥焰宴諺驗殃央鴦秧楊揚佯瘍佯烊陽氧仰癢養樣漾邀腰妖瑤搖堯遙窰謠姚咬舀葯崾耀椰噎耶爺嘢冶乜頁掖業葉曳腋夜液①壹醫揖銥铱咿衣頤夷遺移儀胰疑沂宐姨彝椅蚁倚已乙矣苡藝抑易邑屹億伇臆逸肄疫亦裔噫毅憶図益溢詣議誼譯异瀷翌繹茵蔭洇殷喑陰姻荶銀婬寅飲伊蚓隱茚渶櫻嬰鷹應纓瑩螢營荧蠅迎贏盈影穎硬映哟擁傭臃痈庸雍踴蛹詠泳湧詠慂勇甪幽優滺憂鱿甴郵鈾猶油遊酉冇叐祐祐釉誘ㄡ呦迂淤亍盂榆虞愚輿悇俞踰魚愉渝漁隅予娯雨與嶼禹穻語羽钰域芋喐訏遇喻峪禦癒慾獄逳誉浴寓裕預豫馭鴛渊冤え垣媴傆援轅園員圓猿源緣逺苑願惌院曰約樾跃鈅捳粵仴悅閲耘雲鄖匀隕允運蘊酝暈韵孕匝砸雜栽哉災縡載侢恠詯攢暫贊賍脏髒遭糟凿藻枣早澡蚤躁噪慥皂灶燥責萚則澤賊怎增憎噌贈紮喳渣札軋鍘閘眨柵榨咋乍炸詐摘斋宅窄債寨瞻毡詹粘惉盏斬輾嶄展蘸棧占戰站湛綻樟璋彰漳張掌漲杖丈帳賬仗脹瘴障招詔找沼趙照罩兆肇召遮悊哲蟄轍者鍺蔗這浙紾斟眞甄砧臻貞針偵枕疹診震振鎮陣蒸掙睜征猙爭怔整拯㊣政幀症鄭證芝枝支吱蜘倁肢脂汁徔织职直植殖執値侄址指芷趾呮恉紙綕摯擲臸致置帜峙製潪秩稚質炙痔滯治窒ф盅忠鍾衷終種腫喠仲众舟周喌洲诌粥軸肘帚咒皱宙昼驟珠株蛛茱潴諸誅逐竹燭煮拄瞩嘱註著柱助蛀贮铸筑住紸祝駐抓爪拽專磚啭撰賺篆桩莊娤妝撞壯狀椎錐縋贅墜綴諄准捉拙卓桌琢茁酌啄着灼濁茲咨澬姿滋淄孜紫仔籽滓孒洎漬牸鬃棕蹤宗綜總緃邹赱奏揍租哫卒鏃祖詛阻組钻纂嘴酔蕞罪尊遵葃佐佐柞做莋侳蓙嬋ＡвсＤЁ℉ＧＨＩＪκＬＭЙＯＰＱＲＳＴ∪∨Ｗ×ＹＺāｂｃｄéｆɡｈīｊｋｌｍńōｐｑｒ$τūｖωｘｙｚ①②③④⑤⑥⑦⑧⑨";
            //Dictionary<string, string> dic = new Dictionary<string, string>();
            string result = lable;
            for (int i = 0; i < jtw.Length; i++)
            {
                string key = jtw.Substring(i, 1);
                string value = hxw.Substring(i, 1);
                result = result.Replace(key, value);
            }
            return result;

        }
        public string GetToWordSegFilter(ToWordSegFilter filter, string lable)
        {
            PanGu.Segment.Init();
            var segment = new Segment();

            var words = segment.DoSegment(lable);
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (var wordInfo in words)
            {
                
                if (dic.ContainsKey(wordInfo.ToString()))
                {
                    
                        dic[wordInfo.ToString()]++;
                }
                else
                {
                if (wordInfo.Pos >= POS.POS_A_NZ&&wordInfo.Pos< POS.POS_A_M)
                {
                    dic.Add(wordInfo.ToString(), 1);
                    }
                }
            }
         
            dic = dic.OrderByDescending(r => r.Value).ToDictionary(r => r.Key, r => r.Value);
            string[] keys = dic.Keys.ToArray();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < (keys.Length< filter.maxsword? keys.Length: filter.maxsword); i++)
            {
                if (i != 0)
                {
                    sb.Append(filter.seq);
                }
                sb.Append(keys[i]);
                
            }
            return sb.ToString();
        }
        public string GetFillBothEnd(FillBothEnd filter, string lable)
        {
            if (!filter.EmptyNotFill || !string.IsNullOrEmpty(lable))
            {
                return filter.Start + lable + filter.End;
            }
            return lable;
        }
        public string GetForceFillUrl(string lable, string url)
        {
            VariableHelper vh = new VariableHelper();
            string result= vh.FormAturl(url, lable);
            return result;

        }
        public string GetGetThumPic(string lable)
        {
            Regex reg = new Regex("<img[^>]*src=['\"](.*?)['\"].*?>");
            Match match = reg.Match(lable);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            return "";
        }
        public string GetSynonymReplace(SynonymReplace filter, string lable)
        {
            string result = lable;
            string filename = System.Environment.CurrentDirectory + "\\Configuration\\Synonym\\" + filter.value + ".txt";
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] keys = lines[i].Split(new string[] { "," }, StringSplitOptions.None);
                    result = result.Replace(keys[0], keys[1]);
                    if (filter.IsOnlyReplaceFirstOne==0)
                    {
                        result = result.Replace(keys[1], keys[0]);
                    }
                }
            }
            return result;
        }
        public string GetTextEncode(TextEncode filter, string lable)
        {
            string result = "";
            switch (filter.codeType)
            {
                case 1: result = HttpUtility.UrlEncode(lable, Encoding.GetEncoding(filter.encoding));break;

                case 4:result = System.Web.HttpUtility.HtmlDecode(lable);break;
                case 5:result = DecodeBase64(lable);break;
                case 6:result = EncodeBase64(lable);break;
                case 7: result = System.Web.HttpUtility.HtmlEncode(lable); break;


                case 0:
                default:
                    result = HttpUtility.UrlEncode(lable, Encoding.GetEncoding(filter.encoding));
                    break;
            }
            return result;
        }
        /// <summary>
        /// 编码Base64
        /// </summary>
        /// <param name="code_type">编码</param>
        /// <param name="code">内容</param>
        /// <returns></returns>
        public string EncodeBase64( string code, string code_type = "")
        {
            string encode = "";
            byte[] bytes = null;
            if (string.IsNullOrEmpty(code_type))
            {
                bytes= Encoding.Default.GetBytes(code);
            }
            else
            {
                bytes= Encoding.GetEncoding(code_type).GetBytes(code);
            }
            
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = code;
            }
            return encode;
        }
        /// <summary>
        /// 解码Base64
        /// </summary>
        /// <param name="code_type">编码</param>
        /// <param name="code">内容</param>
        /// <returns></returns>
        public string DecodeBase64( string code, string code_type="")
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(code);
            try
            {
                if (string.IsNullOrEmpty(code_type))
                {
                    decode = Encoding.Default.GetString(bytes);
                }
                else
                {
                    decode = Encoding.GetEncoding(code_type).GetString(bytes);
                }

            }
            catch
            {
                decode = code;
            }
            return decode;
        }

    }
}
