using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace IDInfoRead
{
    public partial class Form_Main : Form
    {
        #region 变量

        SQLiteDB dao = SQLiteDB.Instance();

        private int initRet = 1;

        private Thread autoReadThread = null;

        private bool leave = true;

        private int iPort = 1001;

        #endregion

        #region 构造函数

        public Form_Main()
        {
            InitializeComponent();
            //this.MaximizeBox = false;
            initRet = InitComm(iPort);

            ParameterizedThreadStart ts = new ParameterizedThreadStart(readID);
            autoReadThread = new Thread(ts);
            autoReadThread.Start();
        }

        #endregion

        #region 动态链接库调用

        [DllImport("Sdtapi.dll")]
        //初始化端口
        private static extern int InitComm( int iPort );

        [DllImport("Sdtapi.dll")]
        //关闭端口
        private static extern int CloseComm();

        [DllImport("Sdtapi.dll")]
        //卡认证
        private static extern int Authenticate();

        [DllImport("Sdtapi.dll")]
        //信息读取
        private static extern int ReadBaseInfos( StringBuilder Name, StringBuilder Gender, StringBuilder Folk, StringBuilder BirthDay, StringBuilder Code, StringBuilder Address, StringBuilder Agency, StringBuilder ExpireStart, StringBuilder ExpireEnd );

        //信息读取并指定保存图片的位置
        [DllImport("Sdtapi.dll")]
        private static extern int ReadBaseInfosPhoto( StringBuilder Name, StringBuilder Gender, StringBuilder Folk, StringBuilder BirthDay, StringBuilder Code, StringBuilder Address, StringBuilder Agency, StringBuilder ExpireStart, StringBuilder ExpireEnd, string Direct );

        [DllImport("Sdtapi.dll")]
        //判断身份证是否在设备上，只能在读取完身份证信息后使用
        private static extern int CardOn();

        #endregion

        #region 事件

        /// <summary>
        /// 点击打开端口配置窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbar_IPSet_Click( object sender, EventArgs e )
        {
            Form_IPSet formIp = new Form_IPSet();
            formIp.ShowDialog();
        }

        /// <summary>
        /// 点击打开端口配置窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_IPSet_Click(object sender, EventArgs e)
        {
            Form_IPSet formIp = new Form_IPSet();
            formIp.ShowDialog();
        }

        /// <summary>
        /// 点击关闭窗口按钮时最小化到托盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormClosing_Handle( object sender, FormClosingEventArgs e )
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;    //取消"关闭窗口"事件
                ShowInTaskbar = false; //不显示任务栏图标
                this.Hide(); 
            }

            //CloseComm();
            //Application.Exit();
            //Environment.Exit(0);
        }

        /// <summary>
        /// 鼠标右键单击托盘图标显示退出菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            MouseEventArgs em = (MouseEventArgs)e;
            if (em.Button == MouseButtons.Right)
            {
                //右键退出菜单显示
                contextMenuStrip1.Show(Control.MousePosition); //根据鼠标位置显示菜单
            }
        }

        /// <summary>
        /// 鼠标左键双击托盘图标显示程序主界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs em = (MouseEventArgs)e;

            if (em.Button == MouseButtons.Left)
            {
                this.Activate();
                this.Visible = true;
                //任务栏区显示图标 
                this.ShowInTaskbar = true;

                this.WindowState = FormWindowState.Normal;
            }
        }

        /// <summary>
        /// 点击托盘图标右键菜单，退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuExit_Click(object sender, EventArgs e)
        {
            //if (autoReadThread != null)
            //{
                //autoReadThread.Interrupt(); //中断读取线程
            //}

            CloseComm(); //关闭串口
            Dispose(true);
            Application.Exit();
            Environment.Exit(0);
        }

        /// <summary>
        /// 最小化到托盘时显示托盘图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)    //最小化到系统托盘
            {
                notifyIcon1.Visible = true;    //显示托盘图标
                this.Hide();    //隐藏窗口
            }
        }

        #endregion

        #region 方法

        #region 读取身份证相关操作

        /// <summary>
        /// 读取身份证信息操作
        /// </summary>
        /// <param name="obj"></param>
        private void readID( object obj )
        {
            #region 打开程序时检查端口是否配置好

            DataTable d = dao.QueryIP();
            if (d.Rows.Count == 0)
            {
                MessageBox.Show("端口未设置，请设置端口", "提示");
                Form_IPSet formip = new Form_IPSet();
                formip.ShowDialog();
            }

            #endregion
            while (true)
            {
                if (initRet == 1)
                {
                    while (true)
                    {
                        Authenticate();
                        read();

                        leave = CardOn() == 0 ? true : false;
                        while (!leave)
                        {
                            leave = CardOn() == 0 ? true : false;
                        }
                        this.lbl_Status.Text = "请放卡...";

                        if (InitComm(iPort) != 1)
                        {
                            initRet = InitComm(iPort);
                            MessageBox.Show("身份证读卡器断开", "提示");
                        }
                    }
                }
                else
                {
                    initRet = InitComm(iPort);
                    MessageBox.Show("身份证读卡器未连接", "提示");
                }
            }                
        }

        /// <summary>
        /// 读取身份证信息并提交表单给服务器
        /// </summary>
        private void read()
        {

            #region 变量

            StringBuilder Name = new StringBuilder(31);
            StringBuilder Gender = new StringBuilder(3);
            StringBuilder Folk = new StringBuilder(10);
            StringBuilder Birth = new StringBuilder(9);
            StringBuilder ID = new StringBuilder(19);
            StringBuilder Address = new StringBuilder(71);
            StringBuilder Agency = new StringBuilder(31);
            StringBuilder Validity_Start = new StringBuilder(9);
            StringBuilder Validity_End = new StringBuilder(9);

            string name, gender, folk, birth, id, address, agency, validity_start, validity_end;

            #endregion

            if (leave)
            {
                #region 卡信息读取

                initRet = ReadBaseInfos(Name, Gender, Folk, Birth, ID, Address, Agency, Validity_Start, Validity_End);

                if (initRet != 1)
                {
                    ShowInfoLabel("", label_ID);
                    ShowInfoLabel("", label_Name);
                    ShowInfoLabel("", label_Gender);
                    ShowInfoLabel("", label_Folk);
                    ShowInfoLabel("", label_Birth);
                    ShowInfoLabel("", label_Address);
                    ShowInfoLabel("", label_Agency);
                    ShowInfoLabel("", label_Validity);
                    ShowPhoto("blank", pB_Photo);

                    return;
                }

                #endregion
            }

            //Thread.Sleep(500);
            this.lbl_Status.Text = "找到卡，正在读卡";
            Thread.Sleep(500);
            this.lbl_Status.Text = "读卡成功，正在保存";

            #region 用 - 分隔日期

            Birth = Birth.Insert(4, "-");
            Birth = Birth.Insert(7, "-");

            Validity_Start = Validity_Start.Insert(4, "-");
            Validity_Start = Validity_Start.Insert(7, "-");

            Validity_End = Validity_End.Insert(4, "-");
            Validity_End = Validity_End.Insert(7, "-");

            #endregion

            #region 显示读取到的身份证信息,并保存到本地数据库

            #region 保存头像


            //如果Photo文件夹不存在，则创建
            //string bmpath = @".\Photo";

            //if (!Directory.Exists(bmpath))
            //{
            //    Directory.CreateDirectory(bmpath);
            //}

            //using (Bitmap image = new Bitmap(@".\photo.bmp"))
            //{
            //if (File.Exists(@".\Photo\head.png"))
            //{
            //    File.Delete(@".\Photo\head.png");
            //}
            //photo.Save(@".\Photo\head.png");
            //head =  (Image)image.Clone();
            //}


            //string timenow = DateTime.Now.ToString("s");
            //timenow = timenow.Replace(":", "-");
            //timenow = timenow.Replace("T", "-");
            //string photoName = timenow + "-" + ID.ToString();
            //if (File.Exists(@".\Photo\head.png"))
            //{
            //    File.Delete(@".\Photo\head.png");
            //}
            //photo.Save(@".\Photo\head.png");
            //File.Delete(@".\photo.bmp");

            #endregion

            id = ID.ToString();
            ShowInfoLabel(id, label_ID);

            name = Name.ToString();
            ShowInfoLabel(name, label_Name);

            gender = Gender.ToString();
            ShowInfoLabel(gender, label_Gender);

            folk = Folk.ToString();
            ShowInfoLabel(folk, label_Folk);

            birth = Birth.ToString();
            ShowInfoLabel(birth, label_Birth);

            address = Address.ToString();
            ShowInfoLabel(address, label_Address);

            agency = Agency.ToString();
            ShowInfoLabel(agency, label_Agency);

            validity_start = Validity_Start.ToString();
            validity_end = Validity_End.ToString();
            ShowInfoLabel(validity_start + "  -  " + validity_end, label_Validity);

            ShowPhoto(@"./photo.bmp", pB_Photo);

            // 记录保存到本地数据库
            dao.InsertData(name, gender, folk, birth, id, address, agency, validity_start, validity_end);
            Thread.Sleep(500);
            this.lbl_Status.Text = "保存成功，正在同步";

            #endregion

            #region 提交表单给服务器

            DataTable dt = dao.QueryIP();

            if (dt.Rows.Count > 0)
            {
                AppContext.Server = dt.Rows[0]["Server"].ToString();
                AppContext.Port = int.Parse(dt.Rows[0]["Port"].ToString());

                string URL = "http://" + AppContext.Server + ":" + AppContext.Port + "/photo/image_upload";
                string localmac = GetLocalMAC();

                PostData p = new PostData();

                p.localmac = localmac.Trim();
                p.name = name.Trim();
                p.sex = gender.Trim();
                p.nation = folk.Trim();
                p.birthday = birth.Trim();
                p.number = id.Trim();
                p.address = address.Trim();
                p.issue = agency.Trim();
                p.enable_time = validity_start.Trim() + " - " + validity_end.Trim();
                //p.Photo = imageToBase64(@"./photo.bmp");

                #region 测试Json数据

                //->json
                byte[] dat = Encoding.UTF8.GetBytes(p.ToJsonString());
                //ShowInfoLabel(Encoding.UTF8.GetString(dat), richTextBox1);

                //->object
                string json = Encoding.UTF8.GetString(dat);
                //string json = "{ \"data\":{ \"id\":18,\"url\":\"123\"},\"state\":\"ok\"}";
                var jObj = JObject.Parse(json);

                string field = jObj.SelectToken("nation").ToString();
                //string field = jObj.SelectToken("data.id").ToString();
                //string field = jObj["nation"].ToString();
                //string field = jObj["data"]["id"].ToString();
                //ShowInfoLabel(field, richTextBox2);

                #endregion

                PostFormHandler(URL, p);
            }
            else
            {
                MessageBox.Show("端口未设置", "提示");
                return;
            }

            #endregion
        }

        #endregion

        #region 提交表单


        /// <summary>
        /// 提交表单处理
        /// </summary>
        private async void PostFormHandler( string url, PostData pd )
        {
            //string msg =  await DoPost(url, pd);
            string msg = await DoPostForm(url, pd);
            if (msg.Equals("Success"))
            {
                this.lbl_Status.Text = "同步成功，请重新放卡...";
            }
            else
            {
                Console.WriteLine("提交错误为：" + msg);
                this.lbl_Status.Text = "同步失败，请重试...";
                DialogResult dr = MessageBox.Show("同步失败，请检查网络连接或端口配置", "提示", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 向服务器提交表单 HttpWebRequest & HttpClient
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        private Task<string> DoPostForm( string url, PostData data )
        {
            return Task.Run(() =>
            {
                try
                {
                    var filePath = @"./photo.bmp";
                    var fileKeyName = "photo";
                    var fileName = "photo.bmp";
                    string result = null;

                    var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    var memStream = new MemoryStream();
                    var webRequest = (HttpWebRequest)WebRequest.Create(url);

                    //边界符
                    var boundary = "---------------" + DateTime.Now.Ticks.ToString("x");
                    //开头边界符
                    var beginBoundary = Encoding.UTF8.GetBytes("--" + boundary + "\r\n");
                    //最后的结束符
                    var endBoundary = Encoding.UTF8.GetBytes("--" + boundary + "--\r\n");

                    //设置属性
                    webRequest.Method = "POST";
                    webRequest.Timeout = 10000; //5s
                    webRequest.ContentType = "multipart/form-data;boundary=" + boundary;

                    //写入文件
                    const string filePartHeader = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" +
                                                    "Content-Type: application/bmp\r\n\r\n";
                    var header = string.Format(filePartHeader, fileKeyName, fileName);
                    var headerBytes = Encoding.UTF8.GetBytes(header);

                    memStream.Write(beginBoundary, 0, beginBoundary.Length);
                    memStream.Write(headerBytes, 0, headerBytes.Length);

                    var buffer = new byte[4096];
                    int bytesRead; // =0  

                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        memStream.Write(buffer, 0, bytesRead);
                    }
                    fileStream.Close();

                    var subHeader = "\r\n--" + boundary +
                                    "\r\nContent-Disposition: form-data;name=\"submit\"\r\n\r\n\r\n";
                    var subHeaderBytes = Encoding.UTF8.GetBytes(subHeader);

                    memStream.Write(subHeaderBytes, 0, subHeaderBytes.Length);

                    //写入字符串的Key
                    //var stringKeyHeader = "\r\n--" + boundary +
                    //                      "\r\nContent-Disposition: form-data; name=\"{0}\"" +
                    //                      "\r\n\r\n{1}\r\n";

                    //foreach (byte[] formitembytes in from string key in stringDict.Keys
                    //                                 select string.Format(stringKeyHeader, key, stringDict[key])
                    //                                     into formitem
                    //                                 select Encoding.UTF8.GetBytes(formitem))
                    //{
                    //    memStream.Write(formitembytes, 0, formitembytes.Length);
                    //}

                    //写入最后的结束边界符
                    memStream.Write(endBoundary, 0, endBoundary.Length);

                    webRequest.ContentLength = memStream.Length;

                    var requestStream = webRequest.GetRequestStream();

                    memStream.Position = 0;
                    var tempBuffer = new byte[memStream.Length];
                    memStream.Read(tempBuffer, 0, tempBuffer.Length);
                    memStream.Close();

                    requestStream.Write(tempBuffer, 0, tempBuffer.Length);
                    requestStream.Close();

                    try
                    {
                        var httpWebResponse = (HttpWebResponse)webRequest.GetResponse();

                        using (var httpStreamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("utf-8")))
                        {
                            result = httpStreamReader.ReadToEnd();
                        }

                        fileStream.Close();
                        httpWebResponse.Close();
                        webRequest.Abort();

                        if (!string.IsNullOrEmpty(result))
                        {
                            Console.WriteLine(result);

                            #region 获取从服务器返回的Json中的id

                            var jObj = JObject.Parse(result);
                            string photo_id = jObj.SelectToken("data.id").ToString();
                            //string field = jObj["data"]["id"].ToString();
                            data.photo_id = photo_id;
                            //ShowInfoLabel(data.photo_id, richTextBox3);

                            #endregion

                            #region 提交字段

                            try
                            {
                                HttpClient httpClient = new HttpClient();
                                string URL = "http://" + AppContext.Server + ":" + AppContext.Port + "/api/id_card/data_add";

                                httpClient.MaxResponseContentBufferSize = 256000;
                                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");
                                HttpResponseMessage response = httpClient.GetAsync(new Uri(URL)).Result;
                                String result_ = response.Content.ReadAsStringAsync().Result;

                                if (data.sex.Equals("男"))
                                {
                                    data.sex = "1";
                                }
                                else
                                {
                                    data.sex = "2";
                                }

                                List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<String, String>>();
                                paramList.Add(new KeyValuePair<string, string>("name", data.name));
                                paramList.Add(new KeyValuePair<string, string>("sex", data.sex));
                                paramList.Add(new KeyValuePair<string, string>("nation", data.nation));
                                paramList.Add(new KeyValuePair<string, string>("birthday", data.birthday));
                                paramList.Add(new KeyValuePair<string, string>("address", data.address));
                                paramList.Add(new KeyValuePair<string, string>("number", data.number));
                                paramList.Add(new KeyValuePair<string, string>("issue", data.issue));
                                paramList.Add(new KeyValuePair<string, string>("enable_time", data.enable_time));
                                paramList.Add(new KeyValuePair<string, string>("photo_id", data.photo_id));

                                response = httpClient.PostAsync(new Uri(URL), new FormUrlEncodedContent(paramList)).Result;
                                result_ = response.Content.ReadAsStringAsync().Result;

                                //释放连接
                                httpClient.Dispose();

                                if (!string.IsNullOrEmpty(result_))
                                {
                                    Console.WriteLine(result_);
                                    dao.InsertOrUpdateIP(AppContext.Server, AppContext.Port);

                                    return "Success";
                                }
                                else
                                {
                                    return "Fail";
                                }
                            }
                            catch (WebException e)
                            {
                                return e.Message;
                            }

                            #endregion
                        }
                        else
                        {
                            return "Fail";
                        }
                    }
                    catch (WebException e)
                    {
                        return e.Message;
                    }
                }
                catch (WebException e)
                {
                    return e.Message;
                }
            });
        }

        /// <summary>
        /// 向服务器提交字段 HttpClient
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private Task<string> DoPost( string url, PostData data )
        {
            return Task.Run(() =>
            {
                #region 传输字段

                try
                {
                    HttpClient httpClient = new HttpClient();

                    httpClient.MaxResponseContentBufferSize = 256000;
                    httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");
                    HttpResponseMessage response = httpClient.GetAsync(new Uri(url)).Result;
                    String result = response.Content.ReadAsStringAsync().Result;

                    if (data.sex.Equals("男"))
                    {
                        data.sex = "1";
                    }
                    else
                    {
                        data.sex = "2";
                    }

                    List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<String, String>>();
                    paramList.Add(new KeyValuePair<string, string>("name", data.name));
                    paramList.Add(new KeyValuePair<string, string>("sex", data.sex));
                    paramList.Add(new KeyValuePair<string, string>("nation", data.nation));
                    paramList.Add(new KeyValuePair<string, string>("birthday", data.birthday));
                    paramList.Add(new KeyValuePair<string, string>("address", data.address));
                    paramList.Add(new KeyValuePair<string, string>("number", data.number));
                    paramList.Add(new KeyValuePair<string, string>("issue", data.issue));
                    paramList.Add(new KeyValuePair<string, string>("enable_time", data.enable_time));
                    paramList.Add(new KeyValuePair<string, string>("photo_id", data.photo_id));

                    response = httpClient.PostAsync(new Uri(url), new FormUrlEncodedContent(paramList)).Result;
                    result = response.Content.ReadAsStringAsync().Result;

                    //释放连接
                    httpClient.Dispose();

                    if (!string.IsNullOrEmpty(result))
                    {
                        Console.WriteLine(result);
                        dao.InsertOrUpdateIP(AppContext.Server, AppContext.Port);

                        return "Success";
                    }
                    else
                    {
                        return "Fail";
                    }
                }
                catch (WebException e)
                {
                    return e.Message;
                }

                #endregion
            });
        }


        #endregion

        #region 获取 IP MAC

        /// <summary>
        /// 获取本地真实IP
        /// </summary>
        /// <returns></returns>
        private string GetLocalRealIP()
        {
            // 获取本地IP地址列表
            string[] ipV4 = new string[10];
            int i = 0;

            IPAddress[] addressList = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress ip in addressList)
            {
                // 获取本地IPv4地址列表
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ipV4[i++] = ip.ToString();
                }
            }

            Array.Resize(ref ipV4, i);

            return ipV4[ipV4.Length - 1];
        }

        /// <summary>
        /// 获取本地MAC
        /// </summary>
        /// <returns></returns>
        private string GetLocalMAC()
        {
            NetworkInterface[] Net = NetworkInterface.GetAllNetworkInterfaces();
            string mac = null;

            foreach (NetworkInterface item in Net)
            {
                if (!string.IsNullOrEmpty(item.GetPhysicalAddress().ToString()))
                {
                    mac = item.GetPhysicalAddress().ToString();
                    for (int i = 1; i < 6; i++)
                    {
                        mac = mac.Insert(3 * i - 1, ":");
                    }
                    break;
                }
            }

            return mac;
        }

        #endregion

        #region 图片序列化为Base64字符串

        private string imageToBase64( string imgpath )
        {
            Stream s = File.OpenRead(imgpath);
            Image img = Image.FromStream(s);

            BinaryFormatter binFormatter = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();

            try
            {
                binFormatter.Serialize(memStream, img);
            }
            catch (Exception)
            {

            }

            byte[] bytes = memStream.GetBuffer();
            string base64 = Convert.ToBase64String(bytes);

            //ShowInfoLabel(base64, richTextBox2);
            memStream.Close();
            s.Close();


            byte[] bytess = Convert.FromBase64String(base64);
            MemoryStream memmStream = new MemoryStream(bytess);
            BinaryFormatter binnFormatter = new BinaryFormatter();

            try
            {
                Image iimg = (Image)binFormatter.Deserialize(memmStream);
                //this.pictureBox1.Image = iimg;
            }
            catch (Exception)
            {

            }

            memmStream.Close();

            return base64;
        }

        #endregion

        #region 跨线程调用Label和pictureBox

        /// <summary>
        /// 跨线程调用Label
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="c"></param>
        private void ShowInfoLabel( string msg, Control c )
        {
            SetText(msg, c);
        }

        /// <summary>
        /// 跨线程调用pictureBox
        /// </summary>
        /// <param name="imgpath"></param>
        /// <param name="c"></param>
        private void ShowPhoto( string imgpath, PictureBox c )
        {
            SetPhoto(imgpath, c);
        }

        //创建Label显示文字委托
        delegate void SetTextCallback( string text, Control c );

        //创建pictureBox显示图片委托
        delegate void SetPhotoCallback( string imgpath, PictureBox c );

        /// <summary>
        /// Label上显示文字
        /// </summary>
        /// <param name="text"></param>
        /// <param name="c"></param>
        private void SetText( string text, Control c )
        {
            if (c.InvokeRequired)//如果调用控件的线程和创建控件的线程不是同一个则为True
            {
                while (!c.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (c.Disposing || c.IsDisposed)
                        return;
                }
                SetTextCallback d = new SetTextCallback(SetText);
                if (c.IsHandleCreated && !c.IsDisposed)
                    c.Invoke(d, new object[] { text, c, });
            }
            else
            {
                c.Text = text;
            }
        }

        /// <summary>
        /// pictureBox上显示图片
        /// </summary>
        /// <param name="imgpath"></param>
        /// <param name="c"></param>
        private void SetPhoto( string imgpath, PictureBox c )
        {
            if (c.InvokeRequired)//如果调用控件的线程和创建控件的线程不是同一个则为True
            {
                while (!c.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (c.Disposing || c.IsDisposed)
                        return;
                }
                SetPhotoCallback d = new SetPhotoCallback(SetPhoto);
                if (c.IsHandleCreated && !c.IsDisposed)
                    c.Invoke(d, new object[] { imgpath, c, });
            }
            else
            {
                if (imgpath == "blank")
                {
                    c.ImageLocation = "./TransparentBg/transparentBg.png";
                    // c.BackgroundImage = Properties.Resources.transBg; //一直占用资源
                }
                else
                {
                    c.ImageLocation = imgpath;
                    // c.BackgroundImage = new Bitmap(imgpath); //一直占用资源
                    // c.BackgroundImage = Image.FromFile(imgpath); //一直占用资源
                }
            }
        }



        #endregion

        #endregion
    }
}