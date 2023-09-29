using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GAC_Collection.Common;
using Gac;
using GacXml;
using System.Threading;

namespace GAC_Collection
{
    public class SpiderCommon
    {
        public delegate void JobEvent(int ID);
        public event JobEvent StartJobCallBack ;
        public event JobEvent StopJobCallBack ;

        public RuleCommon spiderUrl;
        public  Class.ClassJob classJob;
        public GacJob Job;
        public int JobId;
        public SpiderCommon(int ID)
        {
            JobId = ID;
            JobDB jd = new JobDB();
            classJob = jd.JobGet(ID);
            XmlHelper xh = new XmlHelper();
            Job = xh.XmlToEntity<GacXml.GacJob>(classJob.XmlData);
            spiderUrl = new RuleCommon(Job);
            
            
        }
        public void Start()
        {
            Thread th = new Thread(delegate() {
                spiderUrl.Start();
            });
            th.Start();


            
        }

        public void StopJob()
        {
            spiderUrl.Stop();
        }
    }
}
