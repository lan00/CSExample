using System;

// cs 11:10 PM 8/7/2018
namespace RemoteClient
{
    class MyClient
    {
        [STAThread]
        static void Main(string[] args)
        {
            //RemoteObject.MyObject app = (RemoteObject.MyObject)Activator.GetObject(typeof(RemoteObject.MyObject), System.Configuration.ConfigurationSettings.AppSettings["ServiceURL"]);  obsolete
            RemoteObject.MyObject app = (RemoteObject.MyObject)Activator.GetObject(typeof(RemoteObject.MyObject), System.Configuration.ConfigurationManager.AppSettings["ServiceURL"]);

            Console.WriteLine(app.Add(1, 2));
            //Console.ReadLine();
        }
    }
}

<configuration>
  <appSettings>
    <add key="ServiceURL" value="tcp://localhost:9999/RemoteObject.MyObject"/>
  </appSettings>
</configuration>

========== RemoteObject ==========
using System;

namespace RemoteObject
{
    public class MyObject : MarshalByRefObject
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}

=============== RemoteServer ==================
using System;
using System.Runtime.Remoting;

namespace RemoteServer
{
    class MyServer
    {
        [STAThread]
        static void Main(string[] args)
        {
            //RemotingConfiguration.Configure("RemoteServer.exe.config");  obsolete
            RemotingConfiguration.Configure("RemoteServer.exe.config", true);

            Console.ReadLine();
        }
    }
}

<configuration>
     <system.runtime.remoting>
         <application name="RemoteServer">
             <service>
                 <wellknown type="RemoteObject.MyObject,RemoteObject" objectUri="RemoteObject.MyObject"
                     mode="Singleton" />
             </service>
             <channels>
                 <channel ref="tcp" port="9999"/>
             </channels>
         </application>
     </system.runtime.remoting>
 </configuration>

from https://www.cnblogs.com/zhangzhu/articles/2495010.html
