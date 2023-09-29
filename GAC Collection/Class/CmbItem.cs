using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gac
{
    public class CmbItem
    {
        public CmbItem(string Name, object Value)
        {
            this.Name = Name;
            this.Value = Value;
        }
        public string Name { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
    public class LVRuleItem
    {
        private string _RuleName = "";
        private string _PageName = "";
        private GacXml.Rule _Rule = null;
        public override string ToString()
        {
            return _RuleName;
        }
        public string RuleName
        {
            get
            {
                return _RuleName;
            }

            set
            {
                _RuleName = value;
            }
        }

        public string PageName
        {
            get
            {
                return _PageName;
            }

            set
            {
                _PageName = value;
            }
        }

        public GacXml.Rule Rule
        {
            get
            {
                return _Rule;
            }

            set
            {
                _Rule = value;
            }
        }
    }
}
