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
