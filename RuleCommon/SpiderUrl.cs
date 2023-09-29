using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace GAC_Collection
{
    public class SpiderUrlResult
    {
        private string _Text = "";
        private string _Index = "";
        private string _Url = "";
        private Dictionary<string, string> _lable = new Dictionary<string, string>();
        public List<int> ListIndex
        {
            get
            {
                List<int> list = new List<int>();
                string[] strs = Index.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in strs)
                {
                    list.Add(Convert.ToInt32(item));
                }
                return list;
            }
        }
        public override string ToString()
        {
            return _Url;
        }

        public SpiderUrlResult(string Url, Dictionary<string, string> _lable = null)
        {
            this._Url = Url;
            if (_lable != null)
            {
                this._lable = _lable;
            }

        }
        public SpiderUrlResult(string Url, string Index)
        {
            this._Url = Url;
            this._Index = Index;

        }

        public string Url
        {
            get
            {
                return _Url;
            }

            set
            {
                _Url = value;
            }
        }

        public Dictionary<string, string> Lable
        {
            get
            {
                return _lable;
            }

            set
            {
                _lable = value;
            }
        }

        public string Index
        {
            get
            {
                return _Index;
            }

            set
            {
                _Index = value;
            }
        }

        public string Text
        {
            get
            {
                if (string.IsNullOrEmpty(_Text))
                {
                    return _Url;
                }
                return _Text;
            }

            set
            {
                _Text = value;
            }
        }
    }
    public class Urlinfo
    {
        private string _Url = "";
        private string _Index = "";
        private TreeNode _node = null;
        private Dictionary<string, string> _lable = new Dictionary<string, string>();

        //public Urlinfo(string _url, TreeNode _node = null)
        //{
        //    this._url = _url;
        //    if (_node != null)
        //    {
        //        this._node = _node;
        //    }

        //}

        public Urlinfo(string _url, TreeNode _node = null, Dictionary<string, string> _lable = null)
        {
            this.Url = _url;
            if (_node != null)
            {
                this._node = _node;
            }
            if (_lable != null)
            {
                this._lable = _lable;
            }
        }
        public Urlinfo(string URL, string Index)
        {
            this._Url = URL;
            this.Index = Index;
        }
        public override string ToString()
        {
            return Url;
        }
        public Dictionary<string, string> Lable
        {
            get
            {
                return _lable;
            }

            set
            {
                _lable = value;
            }
        }
      
        public TreeNode Node
        {
            get
            {
                return _node;
            }

            set
            {
                _node = value;
            }
        }

        public string Index
        {
            get
            {
                return _Index;
            }

            set
            {
                _Index = value;
            }
        }

        public string Url
        {
            get
            {
                return _Url;
            }

            set
            {
                _Url = value;
            }
        }
    }
     
}
