using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GAC_Collection.Class
{
    public class ClassJob
    {
        private int _JobId = 0;
        private int _CategoryId = 0;
        private string _JobName = "";
        private string _XmlData = "";
        private bool _SpiderUrl = true;
        private bool _SpiderContent = true;
        private bool _OutContent = true;
        private bool _Status = true;
        public ClassJob()
        { }
        
        public ClassJob(int _JobId, int _CategoryId, string _JobName, string _XmlData, bool _SpiderUrl, bool _SpiderContent, bool _OutContent, bool _Status)
        {
            this._JobId = _JobId;
            this._CategoryId = _CategoryId;
            this._JobName = _JobName;
            this._XmlData = _XmlData;
            this._SpiderUrl = _SpiderUrl;
            this._SpiderContent = _SpiderContent;
            this._OutContent = _OutContent;
            this._Status = _Status;
        }

        public int JobId
        {
            get
            {
                return _JobId;
            }

            set
            {
                _JobId = value;
            }
        }

        public int CategoryId
        {
            get
            {
                return _CategoryId;
            }

            set
            {
                _CategoryId = value;
            }
        }

        public string JobName
        {
            get
            {
                return _JobName;
            }

            set
            {
                _JobName = value;
            }
        }

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

        public bool SpiderUrl
        {
            get
            {
                return _SpiderUrl;
            }

            set
            {
                _SpiderUrl = value;
            }
        }

        public bool SpiderContent
        {
            get
            {
                return _SpiderContent;
            }

            set
            {
                _SpiderContent = value;
            }
        }

        public bool OutContent
        {
            get
            {
                return _OutContent;
            }

            set
            {
                _OutContent = value;
            }
        }

        public bool Status
        {
            get
            {
                return _Status;
            }

            set
            {
                _Status = value;
            }
        }
        //private int ListOrder=



    }
}
