using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaitCS
{
    class Program
    {
        TimeSpan sleepTime = new TimeSpan(0, 1, 0); //1 min
        TimeSpan timeForWatiTo;
        TimeSpan timeForWaitLong;
        //
        //eg: wait(timeOfDay, HowLongTime, timePolling)
        //wait("16:20:10","","00:10:00")  wait to 16:20:10
        //wait("","16:00:00","00:10:00")  wait 16 hour, every 10s check one time
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Usage();
                throw new Exception("argument error");
            }
            if (args[0] == "?" || args[0] == "/?")
            {
                Usage();
                return;
            }


            Program prog = new Program();
            if (args[0] != "")
            {
                //prog.timeForWatiTo = TimeSpan.Parse(args[0]);

                try
                {
                    prog.timeForWatiTo = TimeSpan.Parse(args[0]);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("first argument timeOfDay time format error ");
                    throw e;
                }
            }
            else
            {
                try
                {

                    prog.timeForWaitLong = TimeSpan.Parse(args[1]);
                }
                catch (ArgumentNullException e1)
                {
                    Console.WriteLine("first argument timeOfDay and second argument howLongTime both is empty");
                    throw e1;
                }
                catch (FormatException e2)
                {
                    Console.WriteLine("second argument howLongTime time format error ");
                    throw e2;
                }
                catch (Exception e3)
                {
                    throw e3;
                }
            }
            if (args.Length >= 3)
            {
                try
                {
                    prog.sleepTime = TimeSpan.Parse(args[2]);
                }
                catch (Exception e1)
                {
                    Console.WriteLine("third argument timePolling  time format error");
                    throw e1;
                }
            }

            //都是静态的怎样 ？？
            //检测 参数正确，arg0 < arg 2 || arg1 < arg2 
            TimeSpan waitTime;
            if (prog.timeForWatiTo != TimeSpan.Zero)
                waitTime = prog.timeForWatiTo;
            else
                waitTime = prog.timeForWaitLong + DateTime.Now.TimeOfDay;

            WaitToCetertainTime(waitTime, prog.sleepTime);
            AfterTask();
        }

        //error deal
        static void Usage()
        {
            Console.WriteLine("usage");
            Console.WriteLine("eg: wait(timeOfDay)");
            Console.WriteLine("eg: wait(timeOfDay, howLongTime)");
            Console.WriteLine("eg: wait(timeOfDay, howLongTime, timePolling)");
        }
        static void ProgramError(string message)
        {
            Console.WriteLine(message);
            Usage();
        }

        static int WaitToCetertainTime(TimeSpan timeForWatiTo, TimeSpan sleepTime)
        {
            Console.WriteLine("wait to : " + timeForWatiTo.ToString());

            while (true)
            {
                if (DateTime.Now.TimeOfDay > timeForWatiTo)
                    break;
                else
                {
                    System.Threading.Thread.Sleep(sleepTime);  //1 min
                    //An object reference is required for the non-static field, method, or property 'WaitCS.Program.sleepTime'	c:\Users\v-shacui\documents\visual studio 2013\Projects\wait\WaitCS\Program.cs	111	51	WaitCS
                    //static int WaitToCetertainTime(TimeSpan timeForWatiTo)
                }
                //MTAThreadAttribute
                //STAThreadAttribute
            }

            Console.WriteLine("time is over ");
            return 0;
        }
        static void AfterTask()
        {
            Console.WriteLine("task is over ");
            System.Threading.Thread.Sleep(1000 * 5);  //sleep 5s

        }
        //1.输出格式 
        //2.输出一些状态信息 ， eg:当前时间
    }
}
