using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gac
{
    public class ReturnResult
    {
        private bool _Success = true;
        private string _Msg = "操作成功";
        private string _Title = "操作成功";
        private object _Obj = null;
        private object _Tag = null;

        public bool Success
        {
            get
            {
                return _Success;
            }

            set
            {
                _Success = value;
            }
        }

        public string Msg
        {
            get
            {
                return _Msg;
            }

            set
            {
                _Msg = value;
            }
        }

        public object Obj
        {
            get
            {
                return _Obj;
            }

            set
            {
                _Obj = value;
            }
        }

        public object Tag
        {
            get
            {
                return _Tag;
            }

            set
            {
                _Tag = value;
            }
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
    }
    public class CategoryResult
    {
        private string _ID = "";
        private string _Name = "";

        public string ID
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

        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
            }
        }
        public override string ToString()
        {
            return Name + "[ID=" + ID + "]";
        }
    }
}
