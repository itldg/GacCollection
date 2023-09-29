using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace GAC_Collection.Class
{

    [XmlRootAttribute("Categorys", Namespace = "Gac.RuleCategory", IsNullable = false)]
    public class RuleCategorys
    {
       
        [XmlArrayAttribute("Categorys")]
        public RuleCategory[] Categorys
        {
            get;
            set;
        }
    }

    [XmlRootAttribute("RuleCategory", Namespace = "Gac.RuleCategory", IsNullable = false)]
    public class RuleCategory
    {
        private string _Remarks = "";
        public RuleCategory()
        { }
        public RuleCategory(string Name,int Id,int ParentId,string Remarks,bool GetUrl,bool GetContent,bool Send, RuleCategory[] RuleCategorys)
        {
            this.Name = Name;
            this.Id = Id;
            this.ParentId = ParentId;
            this.Remarks = Remarks;
            this.GetUrl = GetUrl;
            this.GetContent = GetContent;
            this.Send = Send;
            //this.RuleCategorys = RuleCategorys;

        }
        [XmlAttribute("CategoryName")] 
        public string Name
        {
            get;
            set;
        }

        [XmlAttribute("CategoryId")] 
        public int Id
        {
            get;
            set;
        }
        [XmlAttribute("CategoryParentId")]
        public int ParentId
        {
            get;set;
        }
        [XmlAttribute("CategoryRemarks")]
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        [XmlAttribute("CategoryGetUrl")]
        public bool GetUrl
        {
            get;
            set;
        }
        [XmlAttribute("CategoryGetContent")]
        public bool GetContent
        {
            get;
            set;
        }
        [XmlAttribute("CategorySend")]
        public bool Send
        {
            get;
            set;
        }
        public bool RuleType
        {
            get;
            set;
        }

        //[XmlArrayAttribute("RuleCategorys")]
        //public RuleCategory[] RuleCategorys
        //{
        //    get;
        //    set;
        //}
    }


}
