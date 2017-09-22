using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDInfoRead
{
    public partial class Form_IPSet : Form
    {
        #region 构造函数

        public Form_IPSet()
        {
            InitializeComponent();
            LoadData();
        }

        #endregion

        #region 初始化载入数据

        private void LoadData()
        {
            SQLiteDB dao = SQLiteDB.Instance();
            DataTable dt = dao.QueryIP();
            if (dt.Rows.Count > 0)
            {
                AppContext.Server = dt.Rows[0]["Server"].ToString();
                AppContext.Port = int.Parse(dt.Rows[0]["Port"].ToString());

                tB_IPSet_Server.Text = AppContext.Server;
                tB_IPSet_Port.Text = AppContext.Port.ToString();               
            }
        }

        #endregion

        #region 事件

        /// <summary>
        /// 保存IP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_IPSet_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tB_IPSet_Server.Text) || string.IsNullOrEmpty(tB_IPSet_Port.Text))
            {
                MessageBox.Show("IP或端口未设置！", "提示");
            }
            else
            {
                string server = tB_IPSet_Server.Text;
                string port = tB_IPSet_Port.Text;

                int ret = SQLiteDB.Instance().InsertOrUpdateIP(server, int.Parse(port));

                if (ret > 0)
                {
                    this.Close();
                }
            }
        }

        /// <summary>
        /// 按下Enter键执行保存事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyDown_Handler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(tB_IPSet_Server.Text) || string.IsNullOrEmpty(tB_IPSet_Port.Text))
                {
                    MessageBox.Show("IP或端口未设置！", "提示");
                }
                else
                {
                    string server = tB_IPSet_Server.Text;
                    string port = tB_IPSet_Port.Text;

                    int ret = SQLiteDB.Instance().InsertOrUpdateIP(server, int.Parse(port));

                    if (ret > 0)
                    {
                        this.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 关闭窗口前检查端口是否配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormClosing_Handler(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(tB_IPSet_Server.Text) || string.IsNullOrEmpty(tB_IPSet_Port.Text))
            {
                e.Cancel = true;
                MessageBox.Show("IP或端口未设置！", "提示");
            }
        }

        #endregion
    }
}
