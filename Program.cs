using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TrOCR.Helper;

namespace TrOCR
{

    internal static class Program
    {
        public static float Factor = 1.0f;

        [STAThread]
        public static void Main(string[] args)
        {
            var programStarted = new EventWaitHandle(false, EventResetMode.AutoReset, "天若OCR文字识别", out var needNew);
            if (!needNew)
            {
                programStarted.Set();
                CommonHelper.ShowHelpMsg("软件已经运行");
                return;
            }
            InitConfig();
            DealErrorConfig();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Factor = CommonHelper.GetDpiFactor();
            CommonHelper.SetProcessDPIAware();
            Application.Run(new FmMain());
        }


        private static void InitConfig()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "Data\\config.ini";
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Data"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Data");
            }

            if (!File.Exists(path))
            {
                using (File.Create(path))
                {
                }

                IniHelper.SetValue("配置", "接口", "腾讯");
                IniHelper.SetValue("配置", "开机自启", "True");
                IniHelper.SetValue("配置", "快速翻译", "True");
                IniHelper.SetValue("配置", "识别弹窗", "True");
                IniHelper.SetValue("配置", "窗体动画", "窗体");
                IniHelper.SetValue("配置", "记录数目", "20");
                IniHelper.SetValue("配置", "自动保存", "True");
                IniHelper.SetValue("配置", "截图位置", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
                IniHelper.SetValue("配置", "翻译接口", "谷歌");
                IniHelper.SetValue("快捷键", "文字识别", "F4");
                IniHelper.SetValue("快捷键", "翻译文本", "F9");
                IniHelper.SetValue("快捷键", "记录界面", "请按下快捷键");
                IniHelper.SetValue("快捷键", "识别界面", "请按下快捷键");
                IniHelper.SetValue("密钥_百度", "secret_id", "YsZKG1wha34PlDOPYaIrIIKO");
                IniHelper.SetValue("密钥_百度", "secret_key", "HPRZtdOHrdnnETVsZM2Nx7vbDkMfxrkD");
                IniHelper.SetValue("代理", "代理类型", "系统代理");
                IniHelper.SetValue("代理", "服务器", "");
                IniHelper.SetValue("代理", "端口", "");
                IniHelper.SetValue("代理", "需要密码", "False");
                IniHelper.SetValue("代理", "服务器账号", "");
                IniHelper.SetValue("代理", "服务器密码", "");
                IniHelper.SetValue("更新", "检测更新", "True");
                IniHelper.SetValue("更新", "更新间隔", "True");
                IniHelper.SetValue("更新", "间隔时间", "24");
                IniHelper.SetValue("截图音效", "自动保存", "True");
                IniHelper.SetValue("截图音效", "音效路径", "Data\\screenshot.wav");
                IniHelper.SetValue("截图音效", "粘贴板", "False");
                IniHelper.SetValue("工具栏", "合并", "False");
                IniHelper.SetValue("工具栏", "分段", "False");
                IniHelper.SetValue("工具栏", "分栏", "False");
                IniHelper.SetValue("工具栏", "拆分", "False");
                IniHelper.SetValue("工具栏", "检查", "False");
                IniHelper.SetValue("工具栏", "翻译", "False");
                IniHelper.SetValue("工具栏", "顶置", "True");
                IniHelper.SetValue("取色器", "类型", "RGB");
            }
        }

        private static void DealErrorConfig()
        {
            if (IniHelper.GetValue("配置", "接口") == "发生错误")
            {
                IniHelper.SetValue("配置", "接口", "腾讯");
            }

            if (IniHelper.GetValue("配置", "开机自启") == "发生错误")
            {
                IniHelper.SetValue("配置", "开机自启", "True");
            }

            if (IniHelper.GetValue("配置", "快速翻译") == "发生错误")
            {
                IniHelper.SetValue("配置", "快速翻译", "True");
            }

            if (IniHelper.GetValue("配置", "识别弹窗") == "发生错误")
            {
                IniHelper.SetValue("配置", "识别弹窗", "True");
            }

            if (IniHelper.GetValue("配置", "窗体动画") == "发生错误")
            {
                IniHelper.SetValue("配置", "窗体动画", "窗体");
            }

            if (IniHelper.GetValue("配置", "记录数目") == "发生错误")
            {
                IniHelper.SetValue("配置", "记录数目", "20");
            }

            if (IniHelper.GetValue("配置", "自动保存") == "发生错误")
            {
                IniHelper.SetValue("配置", "自动保存", "True");
            }

            if (IniHelper.GetValue("配置", "翻译接口") == "发生错误")
            {
                IniHelper.SetValue("配置", "翻译接口", "谷歌");
            }

            if (IniHelper.GetValue("配置", "截图位置") == "发生错误")
            {
                IniHelper.SetValue("配置", "截图位置", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            }

            if (IniHelper.GetValue("快捷键", "文字识别") == "发生错误")
            {
                IniHelper.SetValue("快捷键", "文字识别", "F4");
            }

            if (IniHelper.GetValue("快捷键", "翻译文本") == "发生错误")
            {
                IniHelper.SetValue("快捷键", "翻译文本", "F9");
            }

            if (IniHelper.GetValue("快捷键", "记录界面") == "发生错误")
            {
                IniHelper.SetValue("快捷键", "记录界面", "请按下快捷键");
            }

            if (IniHelper.GetValue("快捷键", "识别界面") == "发生错误")
            {
                IniHelper.SetValue("快捷键", "识别界面", "请按下快捷键");
            }

            if (IniHelper.GetValue("密钥_百度", "secret_id") == "发生错误")
            {
                IniHelper.SetValue("密钥_百度", "secret_id", "YsZKG1wha34PlDOPYaIrIIKO");
            }

            if (IniHelper.GetValue("密钥_百度", "secret_key") == "发生错误")
            {
                IniHelper.SetValue("密钥_百度", "secret_key", "HPRZtdOHrdnnETVsZM2Nx7vbDkMfxrkD");
            }

            if (IniHelper.GetValue("代理", "代理类型") == "发生错误")
            {
                IniHelper.SetValue("代理", "代理类型", "系统代理");
            }

            if (IniHelper.GetValue("代理", "服务器") == "发生错误")
            {
                IniHelper.SetValue("代理", "服务器", "");
            }

            if (IniHelper.GetValue("代理", "端口") == "发生错误")
            {
                IniHelper.SetValue("代理", "端口", "");
            }

            if (IniHelper.GetValue("代理", "需要密码") == "发生错误")
            {
                IniHelper.SetValue("代理", "需要密码", "False");
            }

            if (IniHelper.GetValue("代理", "服务器账号") == "发生错误")
            {
                IniHelper.SetValue("代理", "服务器账号", "");
            }

            if (IniHelper.GetValue("代理", "服务器密码") == "发生错误")
            {
                IniHelper.SetValue("代理", "服务器密码", "");
            }

            if (IniHelper.GetValue("更新", "检测更新") == "发生错误")
            {
                IniHelper.SetValue("更新", "检测更新", "True");
            }

            if (IniHelper.GetValue("更新", "更新间隔") == "发生错误")
            {
                IniHelper.SetValue("更新", "更新间隔", "True");
            }

            if (IniHelper.GetValue("更新", "间隔时间") == "发生错误")
            {
                IniHelper.SetValue("更新", "间隔时间", "24");
            }

            if (IniHelper.GetValue("截图音效", "自动保存") == "发生错误")
            {
                IniHelper.SetValue("截图音效", "自动保存", "True");
            }

            if (IniHelper.GetValue("截图音效", "音效路径") == "发生错误")
            {
                IniHelper.SetValue("截图音效", "音效路径", "Data\\screenshot.wav");
            }

            if (IniHelper.GetValue("截图音效", "粘贴板") == "发生错误")
            {
                IniHelper.SetValue("截图音效", "粘贴板", "False");
            }

            if (IniHelper.GetValue("工具栏", "合并") == "发生错误")
            {
                IniHelper.SetValue("工具栏", "合并", "False");
            }

            if (IniHelper.GetValue("工具栏", "拆分") == "发生错误")
            {
                IniHelper.SetValue("工具栏", "拆分", "False");
            }

            if (IniHelper.GetValue("工具栏", "检查") == "发生错误")
            {
                IniHelper.SetValue("工具栏", "检查", "False");
            }

            if (IniHelper.GetValue("工具栏", "翻译") == "发生错误")
            {
                IniHelper.SetValue("工具栏", "翻译", "False");
            }

            if (IniHelper.GetValue("工具栏", "分段") == "发生错误")
            {
                IniHelper.SetValue("工具栏", "分段", "False");
            }

            if (IniHelper.GetValue("工具栏", "分栏") == "发生错误")
            {
                IniHelper.SetValue("工具栏", "分栏", "False");
            }

            if (IniHelper.GetValue("工具栏", "顶置") == "发生错误")
            {
                IniHelper.SetValue("工具栏", "顶置", "True");
            }

            if (IniHelper.GetValue("取色器", "类型") == "发生错误")
            {
                IniHelper.SetValue("取色器", "类型", "RGB");
            }

            if (IniHelper.GetValue("特殊", "ali_cookie") == "发生错误")
            {
                IniHelper.SetValue("特殊", "ali_cookie",
                    "cna=noXhE38FHGkCAXDve7YaZ8Tn; cnz=noXhE4/VhB8CAbZ773ApeV14; isg=BGJi2c2YTeeP6FG7S_Re8kveu-jEs2bNwToQnKz7jlWAfwL5lEO23eh9q3km9N5l; ");
            }

            if (IniHelper.GetValue("特殊", "ali_account") == "发生错误")
            {
                IniHelper.SetValue("特殊", "ali_account", "");
            }

            if (IniHelper.GetValue("特殊", "ali_password") == "发生错误")
            {
                IniHelper.SetValue("特殊", "ali_password", "");
            }
        }
    }
}
