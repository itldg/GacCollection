using Gac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GAC_Collection
{
    public class OutData
    {
  
        /// <summary>
        /// 发布数据
        /// </summary>
        /// <param name="Out">发布数据配置</param>
        /// <param name="dic">要发布的数据</param>
        /// <returns></returns>
        public ReturnResult Out(object Out,Dictionary<string, string> dic)
        {
            OutHelper oh=(OutHelper)Out;
            ReturnResult result = oh.Out(dic);
            return result;
            //文件发布
            //if (Out is OutFile)
            //{
            //    OutFile of = (OutFile)Out;

            //}//else if(Out is)

            //return "ok";
        }
    }
    /// <summary>
    /// 发布类库
    /// </summary>
    public class OutHelper
    {
        /// <summary>
        /// 通用继承发布接口
        /// </summary>
        /// <param name="Dic">要发布的数据</param>
        /// <returns>返回发布结果 </returns>
        public virtual ReturnResult Out(Dictionary<string, string> Dic)
        {
            return new ReturnResult()
            {
                Success = false,
                Msg = "未重写发布接口",
                Title = "未重写发布接口"

            };
        }
    }

}
