#include "say.c"

extern void say();

//some code local pc , call dll 2016

void say()
{
	printf("hello");
	printf("22222");
}

#include<stdio.h>
#include"say.h"
//dynamic link lib 160908
//dynamic link c 160908
int main()
{

	say();
	getchar();
	return 0;
}

=====
#include<stdio.h>
#include"say.h"

//dl c model 160908
int main()
{

	say();
	getchar();
	return 0;
}

//16 11 28
void Single_step_onBranch()
{
	int m, n
		MSR_STRUCT msr;
	if (!enablePrivilege(SE_DEBUG_NAME)
		|| !EnsureVersion(5, 1)
		|| !GetSysDbgAPI())
	{
		printf("fail on init");
		return E_FAIL;

	}
	memset()
}

========== cs call dll CS_Lib_Model say.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Lib_Model
{
    class Say
    {
        public void Hello()
        {
            Console.WriteLine("hello");
        }
    }
}

//class1.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Lib_Model
{
    public class Class1
    {
        public static void Main()
        {
            Say s = new Say();
            s.Hello();
            Console.ReadKey();
        }
        
    }
}

======= say CS_DLL_Model class1.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Say
{
    public class Class1
    {
        //internal void Hello()
       //'Say.Class1' does not contain a definition for 'Hello' and no extension method 'Hello' accepting a first argument of type 'Say.Class1' could be found (are you missing a using directive or an assembly reference?)	c:\users\v-shacui\documents\visual studio 2013\Projects\CS DLL Model\CS DLL Model\Program.cs	14	15	CS DLL Model

        public void Hello()
        {
            //Console.WriteLine("Hello!");
            //Console.WriteLine("Hello,World!");
            PrivateHello();
            PrivateHello();
        }
        void PrivateHello()
        {
            Console.WriteLine("PrivateHello()   Hello!");
        }
    }
}

//program.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DLL_Model
{
    class Program
    {
        static void Main(string[] args)
        {
            Say.Class1 c = new Say.Class1();
            c.Hello();

            Console.ReadKey();
        }
    }
}


