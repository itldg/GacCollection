using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GAC_Collection;
using SpiderDB;
using GAC_Collection.Common;

namespace GAC_Collection.MainUi
{
    public partial class FrmDatabase : Form
    {
        GacDB gacdb = new GacDB();
        public FrmDatabase()
        {
            InitializeComponent();
        }
        public string DataType = "";
        private void FrmDatabase_Load(object sender, EventArgs e)
        {
            //读取Mysql配置
            GacXml.MySql mysql= gacdb.dbConfig.MySqlCollection[0];
            txtMysqlDataIp.Text = mysql.Host;
            txtMysqlDataPort.Text = mysql.Port.ToString();
            txtMysqlDataUser.Text = mysql.User;
            txtMysqlDataPwd.Text = mysql.Password;
            if (string.IsNullOrEmpty(mysql.Database))
            {
                chkMysqlInputDataName.Checked = false;
                //txtMysqlDataName.Text = mysql.Database;
            }
            else
            {
                txtMysqlDataName.Text = mysql.Database;
            }

            //读取SqlServer配置
            GacXml.SqlServer sqlserver = gacdb.dbConfig.SqlServerCollection[0];
            txtSqlServerHost.Text = sqlserver.Host;
            txtSqlServerUser.Text = sqlserver.User;
            txtSqlServerPassword.Text = sqlserver.Password;
            if (sqlserver.ConnetionType==1)
            {
                rbSqlServerConnetionType1.Checked = true;
            }
            if (string.IsNullOrEmpty(sqlserver.Database))
            {
                chkSqlServerInput.Checked = false;
            }
            else
            {
                txtSqlServerDatabase.Text = sqlserver.Database;
            }



            cmbMysqlDataEncoding.SelectedIndex = 0;
            DataType = gacdb.dbConfig.DatabaseType[0];
            SetDataBase(DataType);
            cmbDatabase.Text = DataType;
            //foreach (var item in cmbDatabase.Items)
            //{
            //    if (item.ToString() == DataType)
            //    {
            //        cmbDatabase.SelectedItem = item;

            //    }
            //}






        }
        private void SetDataBase(string Type)
        {
            DataType = Type;
            lblDataType.Text = "当前数据库为" + Type;

        }
        private void ConvertDb()
        {
            try
            {
                SaveData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存数据库信息出错\r\n" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtLog.Text = "";
            pnResult.Visible = true;
            JobDB jobdb = new JobDB();
            List<Class.ClassJob> list = jobdb.JobGetList("Status=1");
            foreach (var item in list)
            {
                string result= gacdb.ConvertDb( item.JobId, item.XmlData);
                txtLog.AppendText(item.JobName + "\t转换" + result + "\r\n");
            }
            txtLog.AppendText("全部转换结束");
        }
        private void SaveData()
        {
            string dbname = "";
            GacXml.DbConfig dbconfig = new GacXml.DbConfig();

            dbconfig.DatabaseType.Add(cmbDatabase.Text);
            dbconfig.ConnCollection.Add(new GacXml.Conn());
            //设置Mysql配置
            GacXml.MySql mysql = new GacXml.MySql();
            dbconfig.ConnCollection[0].MySql = GetSqlContent(true, ref dbname);
            mysql.Host = txtMysqlDataIp.Text;
            mysql.Port = Convert.ToInt32( txtMysqlDataPort.Text);
            mysql.User = txtMysqlDataUser.Text;
            mysql.Password = txtMysqlDataPwd.Text;
            if (chkMysqlInputDataName.Checked)
            {
                mysql.Database = txtMysqlDataName.Text;
            }
            else
            {
                mysql.Database = cmbMysqlDataName.Text;
            }
            dbconfig.MySqlCollection.Add(mysql);

            //设置SqlServer配置
            GacXml.SqlServer SqlServer = new GacXml.SqlServer();
            dbconfig.ConnCollection[0].SqlServer = GetSqlContent(true, ref dbname);
            SqlServer.Host = txtSqlServerHost.Text;
            SqlServer.User = txtSqlServerUser.Text;
            SqlServer.Password = txtSqlServerPassword.Text;
            SqlServer.ConnetionType = rbSqlServerConnetionType1.Checked ? 1 : 2;
            if (chkSqlServerInput.Checked)
            {
                SqlServer.Database = txtSqlServerDatabase.Text;
            } else
            {
                SqlServer.Database = cmbSqlServerDatabase.Text;
            }
            dbconfig.SqlServerCollection.Add(SqlServer);

            gacdb.SaveDbConfig(dbconfig);
            
            
            
        }

        private bool CheckContent()
        {
            if (cmbDatabase.SelectedIndex == 2 &&btnMysqlTest.Enabled==true)
            {
                return false;
            }
            return true;
        }
        private void btnTransformation_Click(object sender, EventArgs e)
        {
            if (!CheckContent())
            {
                MessageBox.Show("转换前请先测试"+cmbDatabase.Text+"的数据库链接", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbDatabase.Text == DataType)
            {
                if (MessageBox.Show("您选择的数据库类型和原来的数据库类型是一样的，如果您使用的是原数据库，则原来的数据将会全部清除，请确认！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.No)
                {
                    return;
                }
            }
            SetDataBase(cmbDatabase.SelectedItem.ToString());
            ConvertDb();
        }

        private void chkInputDataName_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbDatabase.SelectedIndex == 2)
            {
                txtMysqlDataName.Visible = chkMysqlInputDataName.Checked;
                cmbMysqlDataName.Visible = !chkMysqlInputDataName.Checked;
            }
            else
            {
                txtSqlServerDatabase.Visible = chkSqlServerInput.Checked;
                cmbSqlServerDatabase.Visible = !chkSqlServerInput.Checked;
            }
            
        }

        private void cmbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnMysql.Visible=pnSqlServer.Visible = pnResult.Visible  = false;
            if (cmbDatabase.SelectedIndex>1)
            {
                switch (cmbDatabase.SelectedIndex)
                {
                    case 2:pnMysql.Visible = true;break;
                    case 3: pnSqlServer.Visible = true; break;
                    default:
                        break;
                }
            }
        }

        private void SqlReload_Click(object sender, EventArgs e)
        {
            string dbname = "";
            string SqlContent = GetSqlContent(false, ref dbname);
            DataHelper dh = new DataHelper(SqlContent, cmbDatabase.Text);
            string result = dh.Connect();
            if (result == "ok")
            {
                string sql = "";
                if (cmbDatabase.SelectedIndex == 2)
                {
                    sql = "SHOW DATABASES";
                    List<string> tablename = dh.GetList(sql);
                    cmbMysqlDataName.Items.Clear();
                    foreach (var item in tablename)
                    {
                        if (item != "information_schema")
                        {
                            cmbMysqlDataName.Items.Add(item);
                        }
                    }
                    btnMysqlReload.Tag = true;
                    cmbMysqlDataName.Enabled = true;
                }
                else
                {
                    sql = "select * from sys.databases";
                    List<string> tablename = dh.GetList(sql);
                    cmbSqlServerDatabase.Items.Clear();
                    foreach (var item in tablename)
                    {
                        cmbSqlServerDatabase.Items.Add(item);
                    }
                    btnSqlServerReload.Tag = true;
                    cmbSqlServerDatabase.Enabled = true;
                }
                MessageBox.Show("成功连接到"+cmbDatabase.Text+"数据库,请选择", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else
            {
                btnMysqlReload.Tag = false;
                MessageBox.Show("连接到"+ cmbDatabase.Text + "数据库服务器发生以下错误：" + result, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SqlTest_Click(object sender, EventArgs e)
        {
            if ((chkMysqlInputDataName.Checked&&string.IsNullOrEmpty(txtMysqlDataName.Text))|| (!chkMysqlInputDataName.Checked && string.IsNullOrEmpty(cmbMysqlDataName.Text)))
            {
                MessageBox.Show("您没有选择或填写数据库！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbDatabase.SelectedIndex == 2)
            {
                btnMysqlTest.Enabled = false;
            }
            else
            {
                btnSqlServerTest.Enabled = false;
            }
            string dbname = "";
            string SqlContent = GetSqlContent(true,ref dbname);
            DataHelper dh = new DataHelper(SqlContent, cmbDatabase.Text);
            string result = dh.Connect();
            if (result == "ok")
            {
                MessageBox.Show("成功连接到"+ dbname + "数据库", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else
            {
                MessageBox.Show("连接到数据库"+dbname+"时出错：" + result, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (cmbDatabase.SelectedIndex == 2)
                {
                    btnMysqlTest.Enabled = true;
                }
                else
                {
                    btnSqlServerTest.Enabled = true;
                }
            }
        }

        private void TxtDataInfo_TextChanged(object sender, EventArgs e)
        {
            if (cmbDatabase.SelectedIndex == 2)
            {
                btnMysqlTest.Enabled = true;
            }
            else
            {
                btnSqlServerTest.Enabled = true;
            }
            
        }

        private void SqlDataName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDatabase.SelectedIndex == 2)
            {
                btnMysqlTest.Enabled = true;
            }
            else
            {
                btnSqlServerTest.Enabled = true;
            }

            
        }

        private void SqlCreat_Click(object sender, EventArgs e)
        {
            if ((cmbDatabase.SelectedIndex == 2&& btnMysqlReload.Tag.ToString() == "False")|| (cmbDatabase.SelectedIndex == 3 && btnSqlServerReload.Tag.ToString() == "False"))
            {
                MessageBox.Show("请先获取数据库列表,获取成功后再使用此功能", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FrmInput frm = new FrmInput("新建数据库", "数据库名");
            frm.CheckData += CheckData;
            if (frm.ShowDialog()==DialogResult.OK)
            {
                //暂无处理
            }
        }

        private bool CheckData(string Data)
        {

            string dbname = "";
            string SqlContent = GetSqlContent(false, ref dbname);
            DataHelper dh = new DataHelper(SqlContent, cmbDatabase.Text);
            try
            {
                dh.ExecuteSql("CREATE DATABASE " + Data + ";");

                MessageBox.Show("成功创建数据库" + Data, "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (message.Contains("database exists"))
                {
                    message = "数据库" + Data + "已经存在";
                }
                MessageBox.Show("创建新数据库失败，请检查配置或者手工创建\r\n" + message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


        }
        private string GetSqlContent(bool HaveName,ref string DbName)
        {
            string SqlContent = "";
            if (cmbDatabase.SelectedIndex == 2)
            {
                string dbname = "information_schema";
                if (HaveName)
                {
                    if (chkMysqlInputDataName.Checked)
                    {
                        dbname = txtMysqlDataName.Text;
                    }
                    else
                    {
                        dbname = cmbMysqlDataName.Text;
                    }
                    DbName = dbname;
                }
                SqlContent = "server=" + txtMysqlDataIp.Text + ";user id=" + txtMysqlDataUser.Text + "; password=" + txtMysqlDataPwd.Text + "; database="+dbname+"; pooling=true;charset=" + cmbMysqlDataEncoding.Text + ";Port=" + txtMysqlDataPort.Text + ";"; ;
            }
            else
            {
                string dbname = "";
                if (HaveName)
                {
                    if (chkSqlServerInput.Checked)
                    {
                        dbname = txtSqlServerDatabase.Text;
                    }
                    else
                    {
                        dbname = cmbSqlServerDatabase.Text;
                    }
                }
                DbName = dbname;
                SqlContent = "Data Source = "+txtSqlServerHost.Text+";"+ dbname + "Integrated Security = "+rbSqlServerConnetionType1.Checked+ ";User Id="+txtSqlServerUser.Text+";Password="+txtSqlServerPassword.Text+";";
            }
            return SqlContent;
        }
        private void btnTest_Click(object sender, EventArgs e)
        {

            
            string SqlContent = "";
            if (cmbDatabase.SelectedIndex == 0)
            {
                string mdbfile = System.Environment.CurrentDirectory + Properties.Resources.Configuration + "Sample\\Data.mdb";
                SqlContent = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + mdbfile;
            }
            else
            {
                string db3 = System.Environment.CurrentDirectory + Properties.Resources.Configuration + "Sample\\Data.db3";
                SqlContent = "Data Source="+ db3 + ";Pooling=true;FailIfMissing=false";
            }
            
            DataHelper dh = new DataHelper(SqlContent, cmbDatabase.Text);
            string result = dh.Connect();
            if (result == "ok")
            {
                MessageBox.Show("成功连接到"+ cmbDatabase.Text + "数据库", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbMysqlDataName.Enabled = true;
            }
            else
            {
                btnMysqlReload.Tag = false;
                MessageBox.Show("连接到"+ cmbDatabase.Text + "数据库服务器发生以下错误：" + result, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMysqlDataPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
