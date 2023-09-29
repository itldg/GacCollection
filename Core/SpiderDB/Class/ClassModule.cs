using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GacDB.Class
{
    public class ClassModule
    {
        private int _ID = 0;
        private string _PostName = "";
        private string _XmlData = "";
        private DateTime _ModifyOn = DateTime.Now;
        /// <summary>
        /// 配置ID
        /// </summary>
        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }
        /// <summary>
        /// 发布配置名称
        /// </summary>
        public string PostName
        {
            get
            {
                return _PostName;
            }

            set
            {
                _PostName = value;
            }
        }
        /// <summary>
        /// 配置信息
        /// </summary>
        public string XmlData
        {
            get
            {
                return _XmlData;
            }

            set
            {
                _XmlData = value;
            }
        }
        /// <summary>
        /// 最后更新日期
        /// </summary>
        public DateTime ModifyOn
        {
            get
            {
                return _ModifyOn;
            }

            set
            {
                _ModifyOn = value;
            }
        }
        public override string ToString()
        {
            return PostName+"[ID="+ID.ToString()+"]";
        }
    }
}
