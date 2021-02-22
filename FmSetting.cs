using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using Microsoft.Win32;
using TrOCR.Helper;
using TrOCR.Properties;

namespace TrOCR
{

	public sealed partial class FmSetting
    {

		public FmSetting()
		{
			Font = new Font(Font.Name, 9f / StaticValue.DpiFactor, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
			InitializeComponent();
		}

		public void readIniFile()
		{
			var value = IniHelper.GetValue("配置", "开机自启");
			if (value == "发生错误")
			{
				cbBox_开机.Checked = true;
			}
			try
			{
				cbBox_开机.Checked = Convert.ToBoolean(value);
			}
			catch
			{
				cbBox_开机.Checked = true;
			}
			var value2 = IniHelper.GetValue("配置", "快速翻译");
			if (value2 == "发生错误")
			{
				cbBox_翻译.Checked = true;
			}
			try
			{
				cbBox_翻译.Checked = Convert.ToBoolean(value2);
			}
			catch
			{
				cbBox_翻译.Checked = true;
			}
			var value3 = IniHelper.GetValue("配置", "识别弹窗");
			if (value3 == "发生错误")
			{
				cbBox_弹窗.Checked = true;
			}
			try
			{
				cbBox_弹窗.Checked = Convert.ToBoolean(value3);
			}
			catch
			{
				cbBox_弹窗.Checked = true;
			}
			var value4 = IniHelper.GetValue("配置", "窗体动画");
			cobBox_动画.Text = value4;
			if (value4 == "发生错误")
			{
				cobBox_动画.Text = "窗体";
			}
            var value42 = IniHelper.GetValue("配置", "接口");
            cmb_RecognitionType.Text = value42;
            if (value42 == "发生错误")
            {
                cmb_RecognitionType.Text = "搜狗";
            }

            var value5 = IniHelper.GetValue("配置", "记录数目");
			numbox_记录.Value = Convert.ToInt32(value5);
			if (value5 == "发生错误")
			{
				numbox_记录.Value = 20m;
			}
			var value6 = IniHelper.GetValue("配置", "自动保存");
			if (value6 == "发生错误")
			{
				cbBox_保存.Checked = false;
			}
			try
			{
				cbBox_保存.Checked = Convert.ToBoolean(value6);
			}
			catch
			{
				cbBox_保存.Checked = false;
			}
			if (cbBox_保存.Checked)
			{
				textBox_path.Enabled = true;
				btn_浏览.Enabled = true;
			}
			if (!cbBox_保存.Checked)
			{
				textBox_path.Enabled = false;
				btn_浏览.Enabled = false;
			}
			var value7 = IniHelper.GetValue("配置", "截图位置");
			textBox_path.Text = value7;
			if (value7 == "发生错误")
			{
				textBox_path.Text = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			}
			var value8 = IniHelper.GetValue("快捷键", "文字识别");
			txtBox_文字识别.Text = value8;
			if (value8 == "发生错误")
			{
				txtBox_文字识别.Text = "F4";
			}
			var value9 = IniHelper.GetValue("快捷键", "翻译文本");
			txtBox_翻译文本.Text = value9;
			if (value9 == "发生错误")
			{
				txtBox_翻译文本.Text = "F9";
			}
			var value10 = IniHelper.GetValue("快捷键", "记录界面");
			txtBox_记录界面.Text = value10;
			if (value10 == "发生错误")
			{
				txtBox_记录界面.Text = "请按下快捷键";
			}
			var value11 = IniHelper.GetValue("快捷键", "识别界面");
			txtBox_识别界面.Text = value11;
			if (value11 == "发生错误")
			{
				txtBox_识别界面.Text = "请按下快捷键";
			}
			pictureBox_文字识别.Image = txtBox_文字识别.Text == "请按下快捷键" ? Resources.快捷键_0 : Resources.快捷键_1;
			pictureBox_翻译文本.Image = txtBox_翻译文本.Text == "请按下快捷键" ? Resources.快捷键_0 : Resources.快捷键_1;
			pictureBox_记录界面.Image = txtBox_记录界面.Text == "请按下快捷键" ? Resources.快捷键_0 : Resources.快捷键_1;
			pictureBox_识别界面.Image = txtBox_识别界面.Text == "请按下快捷键" ? Resources.快捷键_0 : Resources.快捷键_1;
			var value12 = IniHelper.GetValue("密钥_百度", "secret_id");
			text_baiduaccount.Text = value12;
			if (value12 == "发生错误")
			{
				text_baiduaccount.Text = "YsZKG1wha34PlDOPYaIrIIKO";
			}
			var value13 = IniHelper.GetValue("密钥_百度", "secret_key");
			text_baidupassword.Text = value13;
			if (value13 == "发生错误")
			{
				text_baidupassword.Text = "HPRZtdOHrdnnETVsZM2Nx7vbDkMfxrkD";
			}
			var value23 = IniHelper.GetValue("截图音效", "粘贴板");
			if (value23 == "发生错误")
			{
				chbox_copy.Checked = false;
			}
			try
			{
				chbox_copy.Checked = Convert.ToBoolean(value23);
			}
			catch
			{
				chbox_copy.Checked = false;
			}
			var value24 = IniHelper.GetValue("截图音效", "自动保存");
			if (value24 == "发生错误")
			{
				chbox_save.Checked = true;
			}
			try
			{
				chbox_save.Checked = Convert.ToBoolean(value24);
			}
			catch
			{
				chbox_save.Checked = true;
			}
			var value25 = IniHelper.GetValue("截图音效", "音效路径");
			text_音效path.Text = value25;
			if (value25 == "发生错误")
			{
				text_音效path.Text = "Data\\screenshot.wav";
			}
			var value26 = IniHelper.GetValue("取色器", "类型");
			if (value26 == "发生错误")
			{
				chbox_取色.Checked = false;
			}
			if (value26 == "RGB")
			{
				chbox_取色.Checked = false;
			}
			if (value26 == "HEX")
			{
				chbox_取色.Checked = true;
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			var componentResourceManager = new ComponentResourceManager(typeof(FmMain));
			Icon = (Icon)componentResourceManager.GetObject("minico.Icon");
			var numericUpDown = numbox_记录;
			var array = new int[4];
			array[0] = 99;
			numericUpDown.Maximum = new decimal(array);
			var numericUpDown2 = numbox_记录;
			var array2 = new int[4];
			array2[0] = 1;
			numericUpDown2.Minimum = new decimal(array2);
			var numericUpDown3 = numbox_记录;
			var array3 = new int[4];
			array3[0] = 1;
			numericUpDown3.Value = new decimal(array3);
			var array4 = new int[4];
			array4[0] = 24;
			var array5 = new int[4];
			array5[0] = 1;
			var array6 = new int[4];
			array6[0] = 1;
			tab_标签.Height = (int)(350.0 * Program.Factor);
			Height = tab_标签.Height + 50;
			readIniFile();
		}

		private void 百度申请_Click(object sender, EventArgs e)
		{
			Process.Start("https://console.bce.baidu.com/ai/");
		}

		public static string Get_html(string url)
		{
			string result;
			var httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			try
			{
				using (var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
				{
					using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8))
					{
						result = streamReader.ReadToEnd();
						streamReader.Close();
						httpWebResponse.Close();
					}
				}
				httpWebRequest.Abort();
			}
			catch
			{
				result = "";
			}
			return result;
		}

		private void tab_标签_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tab_标签.SelectedTab == page_常规)
			{
				tab_标签.Height = (int)(350.0 * Program.Factor);
				Height = tab_标签.Height + 50;
			}
			if (tab_标签.SelectedTab == Page_快捷键)
			{
				tab_标签.Height = (int)(225.0 * Program.Factor);
				Height = tab_标签.Height + 50;
			}
			if (tab_标签.SelectedTab == Page_密钥)
			{
				tab_标签.Height = (int)(190.0 * Program.Factor);
				Height = tab_标签.Height + 50;
			}
		}

		private void pic_help_Click(object sender, EventArgs e)
		{
			new FmHelp().Show();
		}

		private void cbBox_开机_CheckedChanged(object sender, EventArgs e)
		{
			AutoStart(cbBox_开机.Checked);
		}

		private void cbBox_保存_CheckedChanged(object sender, EventArgs e)
		{
			if (cbBox_保存.Checked)
			{
				textBox_path.Enabled = true;
				btn_浏览.Enabled = true;
			}
			if (!cbBox_保存.Checked)
			{
				textBox_path.Enabled = false;
				btn_浏览.Enabled = false;
			}
		}

		private void btn_浏览_Click(object sender, EventArgs e)
		{
			var folderBrowserDialog = new FolderBrowserDialog();
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				textBox_path.Text = folderBrowserDialog.SelectedPath;
			}
		}

		private void 密钥Button_Click(object sender, EventArgs e)
		{
			text_baiduaccount.Text = "YsZKG1wha34PlDOPYaIrIIKO";
			text_baidupassword.Text = "HPRZtdOHrdnnETVsZM2Nx7vbDkMfxrkD";
		}

		private void 常规Button_Click(object sender, EventArgs e)
		{
			cbBox_开机.Checked = true;
			cbBox_翻译.Checked = true;
			cbBox_弹窗.Checked = true;
			cobBox_动画.SelectedIndex = 0;
			numbox_记录.Value = 20m;
			cbBox_保存.Checked = true;
			textBox_path.Enabled = true;
			textBox_path.Text = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			btn_浏览.Enabled = true;
			chbox_save.Checked = true;
			text_音效path.Text = "Data\\screenshot.wav";
			chbox_copy.Checked = false;
			chbox_取色.Checked = false;
		}

        private void txtBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void txtBox_KeyUp(object sender, KeyEventArgs e)
		{
			var textBox = sender as TextBox;
			var regex = new Regex("[一-龥]+");
			var str = "";
			foreach (var obj in regex.Matches(textBox.Name))
			{
				str = ((Match)obj).ToString();
			}
			var key = "pictureBox_" + str;
			var pictureBox = (PictureBox)Controls.Find(key, true)[0];
			new ComponentResourceManager(typeof(FmSetting));
			if (e.KeyData == Keys.Back)
			{
				textBox.Text = "请按下快捷键";
				pictureBox.Image = Resources.快捷键_0;
				if (textBox.Name.Contains("文字识别"))
				{
					IniHelper.SetValue("快捷键", "文字识别", txtBox_文字识别.Text);
				}
				if (textBox.Name.Contains("翻译文本"))
				{
					IniHelper.SetValue("快捷键", "翻译文本", txtBox_翻译文本.Text);
				}
				if (textBox.Name.Contains("记录界面"))
				{
					IniHelper.SetValue("快捷键", "记录界面", txtBox_记录界面.Text);
				}
				if (textBox.Name.Contains("识别界面"))
				{
					IniHelper.SetValue("快捷键", "识别界面", txtBox_识别界面.Text);
                }
			}
			else if (e.KeyValue != 16 && e.KeyValue != 17 && e.KeyValue != 18)
			{
				var array = e.KeyData.ToString().Replace(" ", "").Replace("Control", "Ctrl").Split(',');
				pictureBox.Image = Resources.快捷键_1;
				if (array.Length == 1)
				{
					textBox.Text = array[0];
				}
				if (array.Length == 2)
				{
					textBox.Text = array[1] + "+" + array[0];
				}
				if (array.Length <= 2)
				{
					if (textBox.Name.Contains("文字识别"))
					{
						IniHelper.SetValue("快捷键", "文字识别", txtBox_文字识别.Text);
					}
					if (textBox.Name.Contains("翻译文本"))
					{
						IniHelper.SetValue("快捷键", "翻译文本", txtBox_翻译文本.Text);
					}
					if (textBox.Name.Contains("记录界面"))
					{
						IniHelper.SetValue("快捷键", "记录界面", txtBox_记录界面.Text);
					}
					if (textBox.Name.Contains("识别界面"))
					{
						IniHelper.SetValue("快捷键", "识别界面", txtBox_识别界面.Text);
					}
				}
			}
		}

		private void 快捷键Button_Click(object sender, EventArgs e)
		{
			new ComponentResourceManager(typeof(FmSetting));
			txtBox_文字识别.Text = "F4";
			pictureBox_文字识别.Image = Resources.快捷键_1;
			txtBox_翻译文本.Text = "F9";
			pictureBox_翻译文本.Image = Resources.快捷键_1;
			txtBox_记录界面.Text = "请按下快捷键";
			pictureBox_记录界面.Image = Resources.快捷键_0;
			txtBox_识别界面.Text = "请按下快捷键";
			pictureBox_识别界面.Image = Resources.快捷键_0;
		}

		private void 百度_btn_Click(object sender, EventArgs e)
		{
			if (Get_html(string.Format("{0}?{1}", "https://aip.baidubce.com/oauth/2.0/token", "grant_type=client_credentials&client_id=" + text_baiduaccount.Text + "&client_secret=" + text_baidupassword.Text)) != "")
			{
				MessageBox.Show("密钥正确!", "提醒");
				return;
			}
			MessageBox.Show("请确保密钥正确!", "提醒");
		}

		public string Post_Html(string url, string post_str)
		{
			var bytes = Encoding.UTF8.GetBytes(post_str);
			var result = "";
			var httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
			httpWebRequest.Method = "POST";
			httpWebRequest.Timeout = 6000;
			httpWebRequest.Proxy = null;
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			try
			{
				using (var requestStream = httpWebRequest.GetRequestStream())
				{
					requestStream.Write(bytes, 0, bytes.Length);
				}
				var responseStream = ((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream();
				var streamReader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
				result = streamReader.ReadToEnd();
				responseStream.Close();
				streamReader.Close();
				httpWebRequest.Abort();
			}
			catch
			{
			}
			return result;
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			IniHelper.SetValue("配置", "开机自启", cbBox_开机.Checked.ToString());
			IniHelper.SetValue("配置", "快速翻译", cbBox_翻译.Checked.ToString());
			IniHelper.SetValue("配置", "识别弹窗", cbBox_弹窗.Checked.ToString());
			IniHelper.SetValue("配置", "窗体动画", cobBox_动画.Text);
            IniHelper.SetValue("配置", "接口", cmb_RecognitionType.Text);
            IniHelper.SetValue("配置", "记录数目", numbox_记录.Text);
			IniHelper.SetValue("配置", "自动保存", cbBox_保存.Checked.ToString());
			IniHelper.SetValue("配置", "截图位置", textBox_path.Text);
			IniHelper.SetValue("快捷键", "文字识别", txtBox_文字识别.Text);
			IniHelper.SetValue("快捷键", "翻译文本", txtBox_翻译文本.Text);
			IniHelper.SetValue("快捷键", "记录界面", txtBox_记录界面.Text);
			IniHelper.SetValue("快捷键", "识别界面", txtBox_识别界面.Text);
			IniHelper.SetValue("密钥_百度", "secret_id", text_baiduaccount.Text);
			IniHelper.SetValue("密钥_百度", "secret_key", text_baidupassword.Text);
			IniHelper.SetValue("截图音效", "自动保存", chbox_save.Checked.ToString());
			IniHelper.SetValue("截图音效", "音效路径", text_音效path.Text);
			IniHelper.SetValue("截图音效", "粘贴板", chbox_copy.Checked.ToString());
			if (!chbox_取色.Checked)
			{
				IniHelper.SetValue("取色器", "类型", "RGB");
			}
			if (chbox_取色.Checked)
			{
				IniHelper.SetValue("取色器", "类型", "HEX");
			}
			DialogResult = DialogResult.OK;
		}

		public static void AutoStart(bool isAuto)
		{
			try
			{
				var value = Application.ExecutablePath.Replace("/", "\\");
				if (isAuto)
				{
					var currentUser = Registry.CurrentUser;
					var registryKey = currentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
					registryKey.SetValue("tianruoOCR", value);
					registryKey.Close();
					currentUser.Close();
				}
				else
				{
					var currentUser2 = Registry.CurrentUser;
					var registryKey2 = currentUser2.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
					registryKey2.DeleteValue("tianruoOCR", false);
					registryKey2.Close();
					currentUser2.Close();
				}
			}
			catch (Exception)
			{
				MessageBox.Show("您需要管理员权限修改", "提示");
			}
		}

		public void PlaySong(string file)
		{
			HelpWin32.mciSendString("close media", null, 0, IntPtr.Zero);
			HelpWin32.mciSendString("open \"" + file + "\" type mpegvideo alias media", null, 0, IntPtr.Zero);
			HelpWin32.mciSendString("play media notify", null, 0, Handle);
		}

		private void btn_音效_Click(object sender, EventArgs e)
		{
			PlaySong(text_音效path.Text);
		}

		private void btn_音效路径_Click(object sender, EventArgs e)
		{
			var openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "请选择音效文件";
			openFileDialog.Filter = "All files（*.*）|*.*|All files(*.*)|*.* ";
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				text_音效path.Text = Path.GetFullPath(openFileDialog.FileName);
			}
		}
	}
}
