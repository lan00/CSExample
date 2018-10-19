namespace ConsoleApp_TestInit
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassB b = new ClassB();
            b.Myfunc();

            TestFinallyReturn();

        }


        static int TestFinallyReturn()
        {
            int i=1;
            try
            {
                i = 1;
                return i+ returnn(10);
            }
            catch (Exception ex)
            {
                  i= -1 ;
                return -1;

            }
            finally
            {
                  i = 2;
            }
        }

        static  int returnn(int n)
        {
            return n;
        }

        /*
        after return, then finally
        
        --- D:\Users\fwtlaba-local\Documents\Visual Studio 16\Projects\ConsoleApp1\ConsoleApp1\Program.cs 
                i = 1;
00730738  push        ebp  
00730739  mov         ebp,esp  
0073073B  push        edi  
0073073C  sub         esp,24h  
0073073F  lea         edi,[ebp-28h]  
00730742  mov         ecx,8  
00730747  xor         eax,eax  
00730749  rep stos    dword ptr es:[edi]  
0073074B  cmp         dword ptr ds:[6042C0h],0  
00730752  je          00730759  
00730754  call        6A394030  
00730759  xor         edx,edx  
0073075B  mov         dword ptr [ebp-1Ch],edx  
0073075E  mov         dword ptr [ebp-20h],1  
00730765  mov         ecx,0Ah  
0073076A  call        dword ptr ds:[604D68h]  
00730770  mov         dword ptr [ebp-24h],eax  
                return i+ returnn(10);
00730773  mov         eax,dword ptr [ebp-20h]  
00730776  add         eax,dword ptr [ebp-24h]  
00730779  mov         dword ptr [ebp-1Ch],eax  
0073077C  nop  
0073077D  mov         dword ptr [ebp-14h],0  
00730784  mov         dword ptr [ebp-10h],0FCh  
0073078B  push        7307CBh  
00730790  jmp         007307B6  
            }
            catch (Exception ex)
00730792  mov         dword ptr [ebp-28h],eax  
            {
                  i= -1 ;
                return -1;
00730795  mov         dword ptr [ebp-1Ch],0FFFFFFFFh  
0073079C  call        6A04EBB1  
007307A1  mov         dword ptr [ebp-14h],0  
007307A8  mov         dword ptr [ebp-10h],0FCh  
007307AF  push        7307C2h  
007307B4  jmp         007307B6  

            }
            finally
            {
                  i = 2;
            }
007307B6  pop         eax  
007307B7  jmp         eax  
        }
007307B9  mov         eax,dword ptr [ebp-1Ch]  
        }
007307BC  lea         esp,[ebp-4]  
007307BF  pop         edi  
007307C0  pop         ebp  
007307C1  ret  
007307C2  mov         dword ptr [ebp-10h],0  
007307C9  jmp         007307B9  
007307CB  mov         dword ptr [ebp-10h],0  
007307D2  jmp         007307B9  


--- D:\Users\fwtlaba-local\Documents\Visual Studio 16\Projects\ConsoleApp1\ConsoleApp1\Program.cs 
            return n;
00730E68  push        ebp  
00730E69  mov         ebp,esp  
00730E6B  push        eax  
00730E6C  mov         dword ptr [ebp-4],ecx  
00730E6F  cmp         dword ptr ds:[6042C0h],0  
00730E76  je          00730E7D  
00730E78  call        6A394030  
00730E7D  mov         eax,dword ptr [ebp-4]  
00730E80  mov         esp,ebp  
00730E82  pop         ebp  
00730E83  ret  

         */
    }

    //TestInit  180929
    class ClassA
    {
        //static void Call(string[] args)
        //{
        //    ClassB b = new ClassB();
        //    b.Myfunc();
        //}
            //int a1 = 1;

            //public Classa()
            //{
            //    a1 = 2;
            //}

            //static Classa()
            //{
            //    Classa.a1 = 3;
            //}

            // static string str = "t1";
            Sometype t1 = new Sometype("t1");
        static Sometype t2 = new Sometype("t2");


        public ClassA()
        {
            // str = "t3";
            Sometype t1 = new Sometype("t3 ");

        }

        static ClassA()
        {
            // str = "t4";
            Sometype t1 = new Sometype("t4 ");

        }

        public void Myfunc()
        {
            // str = "t5";
            Sometype t1 = new Sometype("t5 ");
        }

    }

    class ClassB : ClassA
    {
        //static string  str = "t1 2";
        Sometype t1 = new Sometype("t1 2 ");
        static Sometype t2 = new Sometype("t2 2");


        public ClassB()
        {
            // str = "t3 2";
            Sometype t1 = new Sometype("t3 2 ");

        }

        static ClassB()
        {
            // str = "t4 2";
            Sometype t1 = new Sometype("t4 2 ");

        }

        public new void Myfunc()
        {
            // str = "t5 2";
            Sometype t1 = new Sometype("t5 2 ");
        }

    }
    /*
        t2 2
        t4 2
        t1 2
        
        t2
        t4
        t1
        t3
        t3 2
        t5 2

    静态变量 初始化
静态 构造
实例 初始化

构造 呼叫基类构造， 静态变量、构造、实例
继续构造。

子函数
     */


    class Sometype
    {
        public Sometype(string str)
        {
            Console.WriteLine(str);
        }
    }



}

namespace MEFTest
{
    class Program
    {
      //181010
        [Import("MusicBook")]
        public IBookService Service { get; set; }
        static void Main(string[] args)
        {
            Program pro = new Program();
            pro.Compose();
            if (pro.Service != null)
            {
                // pro.Service  type
                var m = pro.Service as MusicBook;
                if (m!=null)
                {
                    m.BookName = "book123";
                }

                Console.WriteLine(pro.Service.GetBookName());
            }
            //Console.Read();
        }
        //宿主MEF并组合部件
        private void Compose()
        {
            //获取包含当前执行的代码的程序集
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            CompositionContainer container = new CompositionContainer(catalog);
            //将部件（part）和宿主程序添加到组合容器
            container.ComposeParts(this);
        }

    }

    interface IBookService
    {
         string GetBookName();

    }
    ////Export(typeof(IBookService)) 这句话将类声明导出为IBookService接口类型
    //[Export(typeof(IBookService))]
    [Export("MusicBook", typeof(IBookService))]
    class MusicBook : IBookService
    {
       public MusicBook()
        {

        }
        public MusicBook(string bookName)
        {
            BookName = bookName;
        }

        public string BookName { get; set; }
        public string GetBookName()
        {
            return BookName;
            //return "BookName";
        }
    }

}
