using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GAC_Collection.Common;
using Gac;

namespace GAC_Collection
{
    public class SystemCommon
    {
        public delegate void JobEvent(int ID);
        public event JobEvent StartJobCallBack ;
        public event JobEvent StopJobCallBack ;
        public SystemCommon()
        {

        }
        public void StartJob(int ID)
        {
            if (StartJobCallBack!=null)
            {
                StartJobCallBack(ID);
            }
            
        }

        public void StopJob(int ID)
        {
            if (StopJobCallBack != null)
            {
                StopJobCallBack(ID);
            }
        }

        
    }
}
