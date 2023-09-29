/*
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace LsCommon
{
    public class CronManager
    {

        public class JobState
        {
            public string JobId;

            public DateTime AddTime;

            public DateTime RunTime;

            public DateTime EndTime;

            public bool IsManualStart;

            public bool IsManualStop;

            public string Result;


            public JobState(string string_0, DateTime dateTime_0, bool bool_0)
            {
                this.JobId = string_0;
                this.AddTime = dateTime_0;
                this.IsManualStart = bool_0;
            }
        }

        public class Event
        {
            public delegate void StartJobDelegate(string string_0);
        }

        public static Dictionary<string, string> TriggerTypeMap;

        public static Dictionary<JobStatus, string> JobStatusMap;

        public static readonly object cornLock;

        public static List<string> CronJobs;

        private static readonly object scheduleLock;

        public static IScheduler Scheduler;

        private static string error;

        public static List<CronManager.JobState> WaitingList;

        public static Dictionary<string, CronManager.JobState> WorkingList;

        public static CronManager.Event.StartJobDelegate StartJob;

        public static event CronManager.JobStatusChangedEventHandler JobStatusChanged
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                CronManager.JobStatusChanged = (CronManager.JobStatusChangedEventHandler)Delegate.Combine(CronManager.JobStatusChanged, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                CronManager.JobStatusChanged = (CronManager.JobStatusChangedEventHandler)Delegate.Remove(CronManager.JobStatusChanged, value);
            }
        }

        public static event CronManager.JobRunStatChangedEventHandler JobRunStatChanged
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                CronManager.JobRunStatChanged = (CronManager.JobRunStatChangedEventHandler)Delegate.Combine(CronManager.JobRunStatChanged, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                CronManager.JobRunStatChanged = (CronManager.JobRunStatChangedEventHandler)Delegate.Remove(CronManager.JobRunStatChanged, value);
            }
        }

        public static string Error
        {
            get
            {
                return CronManager.error;
            }
        }

        static CronManager()
        {
            CronManager.old_acctor_mc();
        }

        public static void OnJobStatusChanged(JobStatusEventArgs jobStatusEventArgs_0)
        {
            if (CronManager.JobStatusChanged != null)
            {
                CronManager.JobStatusChanged(jobStatusEventArgs_0);
            }
        }

        public static void OnJobRunStatChanged(JobRunStatEventArgs jobRunStatEventArgs_0)
        {
            if (CronManager.JobRunStatChanged != null)
            {
                CronManager.JobRunStatChanged(jobRunStatEventArgs_0);
            }
        }

        private static void old_acctor_mc()
        {
            CronManager.TriggerTypeMap = new Dictionary<string, string>();
            CronManager.JobStatusMap = new Dictionary<JobStatus, string>();
            CronManager.cornLock = new object();
            CronManager.CronJobs = new List<string>();
            CronManager.scheduleLock = new object();
            CronManager.error = "";
            CronManager.WaitingList = new List<CronManager.JobState>();
            CronManager.WorkingList = new Dictionary<string, CronManager.JobState>();
            try
            {
                ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
                CronManager.Scheduler = schedulerFactory.GetScheduler();
                lock (JobManager.jobLock)
                {
                    foreach (LsCommon.Table.Job current in JobManager.GoodJobList.Values)
                    {
                        if (!string.IsNullOrEmpty(current.CronExpr) && current.CronEnable)
                        {
                            CronManager.AddNewJobDetail(current.JobId, TriggerModel.Load(current.CronXml));
                        }
                    }
                }
                CronManager.TriggerTypeMap.Add("interval", LangManager.Current.CronIntervar);
                CronManager.TriggerTypeMap.Add("weekly", LangManager.Current.CronWeekly);
                CronManager.TriggerTypeMap.Add("daily", LangManager.Current.CronDaily);
                CronManager.TriggerTypeMap.Add("runOnce", LangManager.Current.CronRunOnce);
                CronManager.TriggerTypeMap.Add("cron", LangManager.Current.CronCorn);
                CronManager.JobStatusMap.Add(JobStatus.Idle, "等待中");
                CronManager.JobStatusMap.Add(JobStatus.Pause, "暂停");
                CronManager.JobStatusMap.Add(JobStatus.Running, "运行中");
                new Thread(new ThreadStart(CronManager.AutoThread))
                {
                    Name = "CronAutoThread"
                }.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.TargetSite, "Error");
                Environment.Exit(110);
            }
        }

        public static void AddSchedulerListener(IJobListener ijobListener_0)
        {
            CronManager.Scheduler.AddGlobalJobListener(ijobListener_0);
        }

        public static void RemoveSchedulerListener(IJobListener ijobListener_0)
        {
            CronManager.Scheduler.RemoveGlobalJobListener(ijobListener_0);
        }

        public static void AddAuto(string string_0)
        {
            lock (JobManager.jobLock)
            {
                if (!JobManager.GoodJobList.ContainsKey(string_0))
                {
                    return;
                }
            }
            CronManager.JobState jobState = new CronManager.JobState(string_0, DateTime.Now, false);
            lock (CronManager.cornLock)
            {
                CronManager.WaitingList.Add(jobState);
            }
            CronManager.OnJobStatusChanged(new JobStatusEventArgs(jobState.JobId, JobStatus.Idle, DateTime.MinValue));
        }

        public static void AddManual(string string_0)
        {
            bool flag = false;
            lock (CronManager.cornLock)
            {
                foreach (CronManager.JobState current in CronManager.WaitingList)
                {
                    if (current.JobId == string_0)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag && CronManager.WorkingList.ContainsKey(string_0))
                {
                    flag = true;
                }
            }
            if (!flag)
            {
                CronManager.JobState jobState = new CronManager.JobState(string_0, DateTime.Now, true);
                lock (CronManager.cornLock)
                {
                    CronManager.WaitingList.Insert(0, jobState);
                }
                CronManager.OnJobStatusChanged(new JobStatusEventArgs(jobState.JobId, JobStatus.Idle, DateTime.MinValue));
            }
        }

        public static bool WaitingListContain(string string_0)
        {
            bool result = false;
            lock (CronManager.cornLock)
            {
                foreach (CronManager.JobState current in CronManager.WaitingList)
                {
                    if (current.JobId == string_0)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        public static bool WaitingListRemoveById(string string_0)
        {
            CronManager.JobState jobState = null;
            lock (CronManager.cornLock)
            {
                foreach (CronManager.JobState current in CronManager.WaitingList)
                {
                    if (current.JobId == string_0)
                    {
                        jobState = current;
                        break;
                    }
                }
                if (jobState != null)
                {
                    CronManager.WaitingList.Remove(jobState);
                }
            }
            return CronManager.WaitingList != null;
        }

        public static JobStatus GetJobStatus(string string_0)
        {
            JobStatus result;
            lock (CronManager.cornLock)
            {
                if (CronManager.WorkingList.ContainsKey(string_0))
                {
                    result = CronManager.WorkingList[string_0].JobStatus;
                    return result;
                }
            }
            result = JobStatus.Idle;
            return result;
        }

        public static bool CheckJobStatus(string string_0, JobStatus jobStatus_0, bool bool_0)
        {
            bool result;
            if (CronManager.WorkingList.ContainsKey(string_0))
            {
                lock (CronManager.cornLock)
                {
                    if (CronManager.WorkingList.ContainsKey(string_0))
                    {
                        if (bool_0)
                        {
                            result = (CronManager.WorkingList[string_0].JobStatus == jobStatus_0);
                            return result;
                        }
                        result = (CronManager.WorkingList[string_0].JobStatus != jobStatus_0);
                        return result;
                    }
                }
            }
            if (bool_0)
            {
                result = (jobStatus_0 == JobStatus.Idle);
            }
            else
            {
                result = (jobStatus_0 != JobStatus.Idle);
            }
            return result;
        }

        public static void SetJobStatus(string string_0, JobStatus jobStatus_0)
        {
            if (CronManager.WorkingList.ContainsKey(string_0))
            {
                lock (CronManager.cornLock)
                {
                    if (CronManager.WorkingList.ContainsKey(string_0))
                    {
                        CronManager.WorkingList[string_0].JobStatus = jobStatus_0;
                    }
                }
            }
        }

        public static bool AddJobSchedule(string string_0, TriggerModel triggerModel_0)
        {
            bool flag = false;
            string text = LsCommon.Table.Job.UpdateCron(string_0, triggerModel_0.Cron, triggerModel_0.ToString(), triggerModel_0.Group, triggerModel_0.Enalbe);
            bool result;
            if (text != null)
            {
                CronManager.error = text;
                result = flag;
            }
            else
            {
                JobManager.GoodJobList[string_0].CronExpr = triggerModel_0.Cron;
                JobManager.GoodJobList[string_0].CronGroup = triggerModel_0.Group;
                JobManager.GoodJobList[string_0].CronXml = triggerModel_0.ToString();
                JobManager.GoodJobList[string_0].CronEnable = triggerModel_0.Enalbe;
                try
                {
                    CronManager.AddNewJobDetail(string_0, triggerModel_0);
                    flag = true;
                }
                catch (Exception ex)
                {
                    CronManager.error = ex.Message + ex.TargetSite + "\r\n";
                    flag = false;
                }
                result = flag;
            }
            return result;
        }

        private static void AddNewJobDetail(string string_0, TriggerModel triggerModel_0)
        {
            if (triggerModel_0 != null && triggerModel_0.Enalbe)
            {
                JobDetail jobDetail = new JobDetail(string_0, typeof(LsCommon.Cron.Job));
                jobDetail.Group = "lvgroup";
                Trigger trigger = new CronTrigger(string_0, "lvgroup", triggerModel_0.Cron);
                if (triggerModel_0.Type == "interval")
                {
                    DateTime dateTime = triggerModel_0.StartTime.Value.ToUniversalTime();
                    DateTime value = triggerModel_0.EndTime.Value.ToUniversalTime();
                    TimeSpan maxValue = TimeSpan.MaxValue;
                    switch (triggerModel_0.typeOfInterval.Value)
                    {
                        case IntervalType.hour:
                            maxValue = new TimeSpan(triggerModel_0.Interval.Value, 0, 0);
                            break;
                        case IntervalType.minute:
                            maxValue = new TimeSpan(0, triggerModel_0.Interval.Value, 0);
                            break;
                        case IntervalType.second:
                            maxValue = new TimeSpan(0, 0, triggerModel_0.Interval.Value);
                            break;
                    }
                    trigger = new ExSimpleTrigger(string_0, "lvgroup", dateTime, new DateTime?(value), -1, maxValue);
                }
                else if (triggerModel_0.Type == "daily")
                {
                    DateTime dateTime = triggerModel_0.StartTime.Value.ToUniversalTime();
                    if (dateTime > DateTime.UtcNow)
                    {
                        trigger.StartTimeUtc = dateTime;
                    }
                }
                else if (triggerModel_0.Type == "weekly")
                {
                    DateTime dateTime = triggerModel_0.StartTime.Value.ToUniversalTime();
                    if (dateTime > DateTime.UtcNow)
                    {
                        trigger.StartTimeUtc = dateTime.Date;
                    }
                }
                if (trigger.GetFireTimeAfter(new DateTime?(DateTime.UtcNow)).HasValue)
                {
                    lock (CronManager.scheduleLock)
                    {
                        string[] jobNames = CronManager.Scheduler.GetJobNames("lvgroup");
                        string[] array = jobNames;
                        for (int i = 0; i < array.Length; i++)
                        {
                            string a = array[i];
                            if (a == jobDetail.Name)
                            {
                                return;
                            }
                        }
                        CronManager.Scheduler.ScheduleJob(jobDetail, trigger);
                        CronManager.Scheduler.Start();
                    }
                }
            }
        }

        public static bool RescheduleJob(string string_0, TriggerModel triggerModel_0)
        {
            bool flag = false;
            string text = LsCommon.Table.Job.UpdateCron(string_0, triggerModel_0.Cron, triggerModel_0.ToString(), JobManager.GoodJobList[string_0].CronGroup, triggerModel_0.Enalbe);
            bool result;
            if (text != null)
            {
                CronManager.error = text;
                result = flag;
            }
            else
            {
                JobManager.GoodJobList[string_0].CronExpr = triggerModel_0.Cron;
                JobManager.GoodJobList[string_0].CronXml = triggerModel_0.ToString();
                JobManager.GoodJobList[string_0].CronEnable = triggerModel_0.Enalbe;
                try
                {
                    lock (CronManager.scheduleLock)
                    {
                        CronManager.Scheduler.UnscheduleJob(string_0, "lvgroup");
                    }
                    if (triggerModel_0.Enalbe)
                    {
                        CronManager.AddNewJobDetail(string_0, triggerModel_0);
                    }
                    flag = true;
                }
                catch (Exception ex)
                {
                    CronManager.error = ex.Message + ex.TargetSite + "\r\n";
                    flag = false;
                }
                result = flag;
            }
            return result;
        }

        public static bool PauseJob(string string_0)
        {
            bool flag = false;
            string text = LsCommon.Table.Job.SetCronEnable(string_0, false);
            bool result;
            if (text != null)
            {
                CronManager.error = text;
                result = flag;
            }
            else
            {
                JobManager.GoodJobList[string_0].CronEnable = false;
                try
                {
                    lock (CronManager.scheduleLock)
                    {
                        flag = CronManager.Scheduler.UnscheduleJob(string_0, "lvgroup");
                    }
                }
                catch (Exception ex)
                {
                    CronManager.error = ex.Message + ex.TargetSite + "\r\n";
                    flag = false;
                }
                result = flag;
            }
            return result;
        }

        public static bool PauseJobByGroup(string string_0)
        {
            bool result;
            foreach (KeyValuePair<string, LsCommon.Table.Job> current in JobManager.GoodJobList)
            {
                if (current.Value.CronGroup == string_0 && current.Value.CronEnable && !CronManager.PauseJob(current.Key))
                {
                    result = false;
                    return result;
                }
            }
            result = true;
            return result;
        }

        public static bool ResumeJobByGroup(string string_0)
        {
            bool result;
            foreach (KeyValuePair<string, LsCommon.Table.Job> current in JobManager.GoodJobList)
            {
                if (current.Value.CronGroup == string_0 && !current.Value.CronEnable && !CronManager.ResumeJob(current.Key))
                {
                    result = false;
                    return result;
                }
            }
            result = true;
            return result;
        }

        public static bool ResumeJob(string string_0)
        {
            bool flag = false;
            string text = LsCommon.Table.Job.SetCronEnable(string_0, true);
            bool result;
            if (text != null)
            {
                CronManager.error = text;
                result = flag;
            }
            else
            {
                JobManager.GoodJobList[string_0].CronEnable = true;
                try
                {
                    CronManager.AddNewJobDetail(string_0, TriggerModel.Load(JobManager.GoodJobList[string_0].CronXml));
                    flag = true;
                }
                catch (Exception ex)
                {
                    CronManager.error = ex.Message + ex.TargetSite + "\r\n";
                    flag = false;
                }
                result = flag;
            }
            return result;
        }

        public static bool UnscheduleJobByGroup(string string_0)
        {
            bool result;
            foreach (KeyValuePair<string, LsCommon.Table.Job> current in JobManager.GoodJobList)
            {
                if (current.Value.CronGroup == string_0 && !CronManager.UnscheduleJob(current.Value.JobId))
                {
                    result = false;
                    return result;
                }
            }
            result = true;
            return result;
        }

        public static bool UnscheduleJob(string string_0)
        {
            bool flag = true;
            string text = LsCommon.Table.Job.DeleteCron(string_0);
            bool result;
            if (text != null)
            {
                CronManager.error = text;
                result = false;
            }
            else
            {
                JobManager.GoodJobList[string_0].CronExpr = "";
                JobManager.GoodJobList[string_0].CronXml = "";
                JobManager.GoodJobList[string_0].CronGroup = "0";
                try
                {
                    if (JobManager.GoodJobList[string_0].CronEnable)
                    {
                        lock (CronManager.scheduleLock)
                        {
                            flag = CronManager.Scheduler.UnscheduleJob(string_0, "lvgroup");
                        }
                    }
                }
                catch (Exception ex)
                {
                    flag = false;
                    CronManager.error = ex.Message + ex.TargetSite + "\r\n";
                }
                result = flag;
            }
            return result;
        }

        public static List<string[]> SelectScheduleJobByGroup(string string_0)
        {
            List<string[]> list = new List<string[]>();
            foreach (KeyValuePair<string, LsCommon.Table.Job> current in JobManager.GoodJobList)
            {
                if (current.Value.CronGroup == string_0)
                {
                    string[] array = CronManager.SelectScheduleJob(current.Value.JobId);
                    if (array != null)
                    {
                        list.Add(array);
                    }
                }
            }
            return list;
        }

        public static string[] SelectScheduleJob(string string_0)
        {
            string[] array = null;
            Trigger trigger;
            lock (CronManager.scheduleLock)
            {
                trigger = CronManager.Scheduler.GetTrigger(string_0, "lvgroup");
            }
            LsCommon.Table.Job job = JobManager.GoodJobList[string_0];
            TriggerModel triggerModel = TriggerModel.Load(job.CronXml);
            if (triggerModel != null)
            {
                array = new string[5];
                array[0] = string_0;
                array[1] = job.JobName;
                array[2] = CronManager.TriggerTypeMap[triggerModel.Type];
                if (trigger != null)
                {
                    array[3] = CronManager.JobStatusMap[CronManager.GetJobStatus(string_0)];
                    DateTime? fireTimeAfter = trigger.GetFireTimeAfter(new DateTime?(DateTime.UtcNow));
                    if (!fireTimeAfter.HasValue)
                    {
                        array[4] = "无";
                    }
                    else
                    {
                        array[4] = fireTimeAfter.Value.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
                else
                {
                    array[3] = CronManager.JobStatusMap[JobStatus.Pause];
                    array[4] = "无";
                }
            }
            return array;
        }

        public static List<string[]> SelectAllScheduleJob()
        {
            List<string[]> list = new List<string[]>();
            foreach (KeyValuePair<string, LsCommon.Table.Job> current in JobManager.GoodJobList)
            {
                if (!string.IsNullOrEmpty(current.Value.CronExpr))
                {
                    string[] array = CronManager.SelectScheduleJob(current.Value.JobId);
                    if (array != null)
                    {
                        list.Add(array);
                    }
                }
            }
            return list;
        }

        public static void FinishJob(string string_0, string string_1, bool bool_0)
        {
            if (CronManager.WorkingList.ContainsKey(string_0))
            {
                lock (CronManager.cornLock)
                {
                    if (CronManager.WorkingList.ContainsKey(string_0))
                    {
                        CronManager.JobState jobState = CronManager.WorkingList[string_0];
                        jobState.EndTime = DateTime.Now;
                        jobState.IsManualStop = bool_0;
                        jobState.Result = string_1;
                        CronManager.WorkingList.Remove(string_0);
                    }
                }
            }
        }

        private static void AutoThread()
        {
            while (true)
            {
                if (CronManager.WorkingList.Count < Options.Config.MaxJobNum)
                {
                    CronManager.JobState jobState = null;
                    lock (CronManager.cornLock)
                    {
                        foreach (CronManager.JobState current in CronManager.WaitingList)
                        {
                            if (CronManager.WorkingList.ContainsKey(current.JobId))
                            {
                                if (!Options.Config.SkipWhenCronBlock)
                                {
                                    continue;
                                }
                                CronManager.WaitingList.Remove(current);
                            }
                            else
                            {
                                current.JobStatus = JobStatus.Running;
                                jobState = current;
                                CronManager.WaitingList.Remove(current);
                            }
                            break;
                        }
                    }
                    if (jobState != null)
                    {
                        jobState.RunTime = DateTime.Now;
                        lock (CronManager.cornLock)
                        {
                            CronManager.WorkingList.Add(jobState.JobId, jobState);
                        }
                        CronManager.StartJob(jobState.JobId);
                    }
                }
                Thread.Sleep(10);
            }
        }
    }
}
*/