using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSecurityCode
{
    class Program
    {
        // test SecurityCritical, SecurityTransparent
        //shaocu 18-11-27
        static void Main(string[] args)
        {
            
            Console.WriteLine("hi ");

            ClassLibrary1.Class1 c1 = new ClassLibrary1.Class1 ();  // set transparent , exc .  Unhandled Exception: System.MethodAccessException: Attempt by security transparent method 'ConsoleApp1.Program.Main(System.String[])' to access security critical method 'ClassLibrary1.Class1..ctor()' failed.
            c1.funPublic();

            //AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;  // set transparent , exc
            //Unhandled Exception: System.MethodAccessException: Attempt by security transparent method 'ConsoleApp1.Program.Main(System.String[])' to access security critical method 'System.AppDomain.add_UnhandledException(System.UnhandledExceptionEventHandler)' failed.

            //AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;

            //console   SecurityTransparent     SecurityTransparent
            //library   default                 SecurityTransparent
            //result    ex                      ok
        }

        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            Console.WriteLine("CurrentDomain_ProcessExit");
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("UnhandledException: " + e.ToString());
            Environment.Exit(-1);
        }
    }

//[assembly: System.Security.SecurityTransparent]
//Unhandled Exception: System.MethodAccessException: Attempt by security transparent method 'ConsoleApp1.Program.Main(System.String[])' to access security critical method 'ClassLibrary1.Class1..ctor()' failed.
//   at ConsoleApp1.Program.Main(String[] args)


//[assembly: System.Security.SecurityCritical]
//Unhandled Exception: System.IO.FileLoadException: Could not load file or assembly 'ConsoleApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies.An operation is not legal in the current state. (Exception from HRESULT: 0x80131509) ---> System.InvalidOperationException: SecurityTransparent and SecurityCritical attributes cannot be applied to the assembly scope at the same time.


//[assembly: System.Security.SecuritySafeCritical]
//Error CS0592  Attribute 'System.Security.SecuritySafeCritical' is not valid on this declaration type. It is only valid on 'class, struct, enum, constructor, method, field, interface, delegate' declarations.ConsoleApp1  
//[assembly: System.Security.SuppressUnmanagedCodeSecurity]
//Error CS0592  Attribute 'System.Security.SuppressUnmanagedCodeSecurity' is not valid on this declaration type. It is only valid on 'class, method, interface, delegate' declarations.ConsoleApp1  


//[assembly: System.Security.SecurityRules(System.Security.SecurityRuleSet.None)]
////Unhandled Exception: System.IO.FileLoadException: Assembly 'ConsoleApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' specified an unknown security rule set.
//[assembly: System.Security.SecurityRules(System.Security.SecurityRuleSet.Level1)]
//// ok
//[assembly: System.Security.SecurityRules(System.Security.SecurityRuleSet.Level2)]
//// ok

    
}


namespace ClassLibrary1
{
    public class Class1
    {
        public Class1()
        {
        }
        //[System.Security.SecuritySafeCritical]    
        public void funPublic()
        {
            Console.WriteLine(nameof(funPublic));
        }

        internal void funInt()
        {
            Console.WriteLine(nameof(funPublic) + " 2");
        }
    }
}

//// The following GUID is for the ID of the typelib if this project is exposed to COM
//[assembly: Guid("9dd70ddd-72d5-4963-9dec-133d528ed24d")]
//[assembly: System.Security.SecurityTransparent]

