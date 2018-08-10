using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThread
{
//150811
    class Store
    {
    }

    class Construct
    {
        string _name;
        string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public Construct()
        {

        }
        public Construct(string name)
        {
            Name = name;
            Console.WriteLine("实例构造函数");
        }
        static Construct()
        {
            Console.WriteLine("静态构造函数");
        }
        ~Construct()
        {
            Console.WriteLine("变量『{0}』：析构函数", Name);
        }


        void TestConstruce()
        {
            Construct c1 = new Construct("c1");
            Construct c2 = new Construct("c2");
            Console.ReadKey();

            Construct c3 = new Construct("c3");
            Construct c4 = new Construct("c4");
            c3 = null;
            Console.ReadKey();
            GC.Collect();
            Console.WriteLine("after gc.collect()");
            Console.ReadKey();
        }
        //静态构造函数
        //实例构造函数
        //实例构造函数
        //实例构造函数
        //实例构造函数
        //after gc.collect()
        //变量『c3』：析构函数
        //...

        public static void Call()
        {
            Construct program = new Construct();
            program.TestConstruce();
        }
    }

    class aa
    {
        void TestDotNet()
        {
            string h = "hello,China!";
            Console.WriteLine(h);
        }
    }
}

==== class mrashal
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MultiThread
{
    class ClassMarshalByRefObject
    {
        public static void test()
        {
            Example.Main();
        }
    }
    

public class Worker : MarshalByRefObject
{
    public void PrintDomain() 
    { 
        Console.WriteLine("Object is executing in AppDomain \"{0}\"",
            AppDomain.CurrentDomain.FriendlyName); 
    }
}

class Example
{
    public static void Main()
    {
        // Create an ordinary instance in the current AppDomain
        Worker localWorker = new Worker();
        localWorker.PrintDomain();

        // Create a new application domain, create an instance
        // of Worker in the application domain, and execute code
        // there.
        AppDomain ad = AppDomain.CreateDomain("New domain");
        Worker remoteWorker = (Worker) ad.CreateInstanceAndUnwrap(
            Assembly.GetExecutingAssembly().FullName,
            "MultiThread.Worker");
        //补天就爱  不写MultiThread 发生异常 TypeLoadException 
        remoteWorker.PrintDomain();
    }
}

/* This code produces output similar to the following:

Object is executing in AppDomain "source.exe"
Object is executing in AppDomain "New domain"
 */
}

====== class mutex

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using InterlockedExchange_Example;

namespace MultiThread
{
    class ClassMutex
    {
        // This example shows how a Mutex is used to synchronize access
        // to a protected resource. Unlike Monitor, Mutex can be used with
        // WaitHandle.WaitAll and WaitAny, and can be passed across
        // AppDomain boundaries.
        class Test
        {
            // Create a new Mutex. The creating thread does not own the
            // Mutex.
            private static Mutex mut = new Mutex();
            private const int numIterations = 10;
            private const int numThreads = 3;

            internal static void Main()
            {
                // Create the threads that will use the protected resource.
                for(int i = 0; i < numThreads; i++)
                {
                    Thread myThread = new Thread(new ThreadStart(MyThreadProc));
                    myThread.Name = String.Format("Thread{0}", i + 1);
                    myThread.Start();
                }

                // The main thread exits, but the application continues to
                // run until all foreground threads have exited.
            }

            private static void MyThreadProc()
            {
                for(int i = 0; i < numIterations; i++)
                {
                    UseResource();
                }
            }

            // This method represents a resource that must be synchronized
            // so that only one thread at a time can enter.
            private static void UseResource()
            {
                // Wait until it is safe to enter.
                mut.WaitOne();

                Console.WriteLine("{0} has entered the protected area", 
                    Thread.CurrentThread.Name);

                // Place code to access non-reentrant resources here.

                // Simulate some work.
                Thread.Sleep(500);

                Console.WriteLine("{0} is leaving the protected area\r\n", 
                    Thread.CurrentThread.Name);

                // Release the Mutex.
                mut.ReleaseMutex();
            }
        }
        public static void test()
        {
            //Test t = new Test();
            //Test.Main();
            //ClassSemaphore.Main();
            // App.Main();
            MyInterlockedExchangeExampleClass.Main();
        }
    }
    

    
public class ClassSemaphore
{
    // A semaphore that simulates a limited resource pool.
    //
    private static Semaphore _pool;

    // A padding interval to make the output more orderly.
    private static int _padding;

    public static void Main()
    {
        // Create a semaphore that can satisfy up to three
        // concurrent requests. Use an initial count of zero,
        // so that the entire semaphore count is initially
        // owned by the main program thread.
        //
        _pool = new Semaphore(0, 3);

        // Create and start five numbered threads. 
        //
        for(int i = 1; i <= 5; i++)
        {
            Thread t = new Thread(new ParameterizedThreadStart(Worker));

            // Start the thread, passing the number.
            //
            t.Start(i);
        }

        // Wait for half a second, to allow all the
        // threads to start and to block on the semaphore.
        //
        Thread.Sleep(500);

        // The main thread starts out holding the entire
        // semaphore count. Calling Release(3) brings the 
        // semaphore count back to its maximum value, and
        // allows the waiting threads to enter the semaphore,
        // up to three at a time.
        //
        Console.WriteLine("Main thread calls Release(3).");
        _pool.Release(3);

        Console.WriteLine("Main thread exits.");
    }

    private static void Worker(object num)
    {
        // Each worker thread begins by requesting the
        // semaphore.
        Console.WriteLine("Thread {0} begins " +
            "and waits for the semaphore.", num);
        _pool.WaitOne();

        // A padding interval to make the output more orderly.
        int padding = Interlocked.Add(ref _padding, 100);

        Console.WriteLine("Thread {0} enters the semaphore.", num);

        // The thread's "work" consists of sleeping for 
        // about a second. Each thread "works" a little 
        // longer, just to make the output more orderly.
        //
        Thread.Sleep(1000 + padding);

        Console.WriteLine("Thread {0} releases the semaphore.", num);
        Console.WriteLine("Thread {0} previous semaphore count: {1}",
            num, _pool.Release());
    }
}

    
public sealed class App 
{
    // Define an array with two AutoResetEvent WaitHandles.
    static WaitHandle[] waitHandles = new WaitHandle[] 
    {
        new AutoResetEvent(false),
        new AutoResetEvent(false)
    };

    // Define a random number generator for testing.
    static Random r = new Random();

    internal static void Main() 
    {
        // Queue up two tasks on two different threads; 
        // wait until all tasks are completed.
        DateTime dt = DateTime.Now;
        Console.WriteLine("Main thread is waiting for BOTH tasks to complete.");
        ThreadPool.QueueUserWorkItem(new WaitCallback(DoTask), waitHandles[0]);
        ThreadPool.QueueUserWorkItem(new WaitCallback(DoTask), waitHandles[1]);
        WaitHandle.WaitAll(waitHandles);
        // The time shown below should match the longest task.
        Console.WriteLine("Both tasks are completed (time waited={0})", 
            (DateTime.Now - dt).TotalMilliseconds);

        // Queue up two tasks on two different threads; 
        // wait until any tasks are completed.
        dt = DateTime.Now;
        Console.WriteLine();
        Console.WriteLine("The main thread is waiting for either task to complete.");
        ThreadPool.QueueUserWorkItem(new WaitCallback(DoTask), waitHandles[0]);
        ThreadPool.QueueUserWorkItem(new WaitCallback(DoTask), waitHandles[1]);
        int index = WaitHandle.WaitAny(waitHandles);
        // The time shown below should match the shortest task.
        Console.WriteLine("Task {0} finished first (time waited={1}).",
            index + 1, (DateTime.Now - dt).TotalMilliseconds);
    }

    static void DoTask(Object state) 
    {
        AutoResetEvent are = (AutoResetEvent) state;
        int time = 1000 * r.Next(2, 10);
        Console.WriteLine("Performing a task for {0} milliseconds.", time);
        Thread.Sleep(time);
        are.Set();
    }
}

// This code produces output similar to the following:
//
//  Main thread is waiting for BOTH tasks to complete.
//  Performing a task for 7000 milliseconds.
//  Performing a task for 4000 milliseconds.
//  Both tasks are completed (time waited=7064.8052)
// 
//  The main thread is waiting for either task to complete.
//  Performing a task for 2000 milliseconds.
//  Performing a task for 2000 milliseconds.
//  Task 1 finished first (time waited=2000.6528).

    



}

namespace InterlockedExchange_Example
{
    class MyInterlockedExchangeExampleClass
    {
        //0 for false, 1 for true.
        private static int usingResource = 0;

        private const int numThreadIterations = 5;
        private const int numThreads = 10;

        public static void Main()
        {
            Thread myThread;
            Random rnd = new Random();

            for (int i = 0; i < numThreads; i++)
            {
                myThread = new Thread(new ThreadStart(MyThreadProc));
                myThread.Name = String.Format("Thread{0}", i + 1);

                //Wait a random amount of time before starting next thread.
                Thread.Sleep(rnd.Next(0, 1000));
                myThread.Start();
            }
        }

        private static void MyThreadProc()
        {
            for (int i = 0; i < numThreadIterations; i++)
            {
                UseResource();

                //Wait 1 second before next attempt.
                Thread.Sleep(1000);
            }
        }

        //A simple method that denies reentrancy.
        static bool UseResource()
        {
            //0 indicates that the method is not in use.
            if (0 == Interlocked.Exchange(ref usingResource, 1))
            {
                Console.WriteLine("{0} acquired the lock", Thread.CurrentThread.Name);

                //Code to access a resource that is not thread safe would go here.

                //Simulate some work
                Thread.Sleep(500);

                Console.WriteLine("{0} exiting lock", Thread.CurrentThread.Name);

                //Release the lock
                Interlocked.Exchange(ref usingResource, 0);
                return true;
            }
            else
            {
                Console.WriteLine("   {0} was denied the lock", Thread.CurrentThread.Name);
                return false;
            }
        }

        int resource = 0;
        internal void  TestInterlockedAdd()
        {
            Interlocked.Add(ref resource, 1);
        }


       

    }
    //改变 startup 方法
    //测试 interlocked.add

    class ThreadExampleClass
    {
        public ThreadExampleClass(Action a)
        {
            m_action = a;
        }

        private  int numThreadIterations = 5;
        private  int numThreads = 10;

        private void StartThread()
        {
            for(int i=0;i<numThreads;i++)
            {
                //Thread myThread = new Thread(action);
                //cannot convert from 'System.Action' to 'System.Threading.ParameterizedThreadStart'	
                Thread myThread = new Thread(myThreadProc);
                myThread.Start();
            }
        }

        private Action m_action;
        private void myThreadProc()
        {
            for(int i=0;i< numThreadIterations;i++)
            {
                if (m_action != null)
                    m_action();
            }
        }

        //================================
        //use ThreadPool
        private void StartManyThread(WaitCallback callback)
        {
            for (int i = 0; i < numThreads; i++)
            {
                ThreadPool.QueueUserWorkItem(callback);
            }
        }

        int mInterlockedAdd = 0;
        internal void TestInterlockedAdd()
        {
            StartManyThread(TestInterlockedAddCallback);
        }

        //internal static void TestInterlockedAdd2()
        // TestInterlockedAdd2（）  不能是静态方法
        internal  void TestInterlockedAdd2()
        {
            ThreadExampleClass t = new ThreadExampleClass(() => Console.WriteLine(++mInterlockedAdd));
            t.StartManyThread(TestInterlockedAddCallback);
        }
        StringBuilder stringBuildInterlockedAdd = new StringBuilder();
        private void TestInterlockedAddCallback(object o)
        {
            stringBuildInterlockedAdd.Append(string.Format("{0} + 1 = {1} \n", mInterlockedAdd, ++mInterlockedAdd));
        }
        public static void  Test_TestInterlockedAdd2()
        {
            //TestInterlockedAdd2();
            //An object reference is required for the non-static field, method, or property 'InterlockedExchange_Example.ThreadExampleClass.TestInterlockedAdd2()'	
        }
    }
}  
