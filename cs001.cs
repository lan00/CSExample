        static void Main(string[] args)
        {
            //4/26/2018
            //ie COM auto 
            SHDocVw.InternetExplorer i = new SHDocVw.InternetExplorer();
            i.Visible = true;
            i.Navigate("qq.com");
            System.Threading.Thread.Sleep(10000);
            i.Quit();
        }

/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Diagnostics;*/

namespace CloseChildProcess
{
// CloseChildProcess  11:16 AM 8/9/2018
    class Program
    {
        static void Main(string[] args)
        {
            int pid;
            string strPId;
            Console.Write("please input a number : ");
            strPId=Console.ReadLine();
            if (int.TryParse(strPId, out pid))
                KillProcessAndChildren(pid);
            else
                Console.WriteLine("input number error");

            Console.ReadKey();
        }

        public static void KillProcessAndChildren(int pid)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Process Where ParentProcessID=" + pid);
            ManagementObjectCollection moc = searcher.Get();
            foreach (ManagementObject mo in moc)
            {
                KillProcessAndChildren(Convert.ToInt32(mo["ProcessID"]));
            }
            try
            {
                Process proc = Process.GetProcessById(pid);
                Console.WriteLine(pid); proc.Kill();
            }
            catch (ArgumentException)
            {
                /* process already exited */
            }
        }
    }
}

using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Automation.Text;

//using System.Windows.Automation.Provider;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace AutoLoginRD
{
    class Program
    {
        static void Main(string[] args)
        {
            //empty
            
        }


    }
    /*
     *  try
            {
                Console.WriteLine("\nBegin WinForm UIAutomation test run\n");
                // launch Form1 application
                // get refernce to main Form control
                // get references to user controls
                // manipulate application
                // check resulting state and determine pass/fail

                Console.WriteLine("\nBegin WinForm UIAutomation test run\n");
                Console.WriteLine("Launching WinFormTest application");
                //启动被测试的程序
                Process p = Process.Start(@"c:\windows\System32\mstsc.exe");
                //Process p = Process.Start(@"c:\windows\System32\mstsc.exe", "/?");
                p.WaitForInputIdle();

                //自动化根元素
                AutomationElement aeDeskTop = AutomationElement.RootElement;
                while (p.MainWindowHandle == IntPtr.Zero)
                {
                    Thread.Sleep(1000);
                }

                //Thread.Sleep(2000);
                AutomationElement aeForm = AutomationElement.FromHandle(p.MainWindowHandle);
                //获得对主窗体对象的引用，该对象实际上就是 Form1 应用程序(方法一)
                //if (null == aeForm)
                //{
                //    Console.WriteLine("Can not find the WinFormTest from.");
                //}

                //获得对主窗体对象的引用，该对象实际上就是 Form1 应用程序(方法二)
                int numWaits = 0;
                do
                {
                    Console.WriteLine("Looking for WinFormTest……");
                    //查找第一个自动化元素
                    aeForm = aeDeskTop.FindFirst(TreeScope.Children, new PropertyCondition(
                        AutomationElement.NameProperty, "Remote Desktop Connection"));
                    ++numWaits;
                    Thread.Sleep(100);
                } while (null == aeForm && numWaits < 50);
                if (null == aeForm)
                    throw new NullReferenceException("Failed to find WinFormTest.");
                else
                    Console.WriteLine("Found it!");



            }
            catch (Exception e)
            {
                Console.WriteLine("Fatal error: " + e.Message);
                Console.WriteLine("call stack: " + e.StackTrace);
                Console.WriteLine( e);
                

            }
     */
    //StaticControl userName2 = new StaticControl (windowSecurity, new QID(";[UIA] name = 'Use another account'"),timeOut);

}

