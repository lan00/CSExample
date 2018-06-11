       static void Main(string[] args)
        {
            Program p = new Program();
            StructA a1 = new StructA();
            //p.StackOverflow(a1, 0);
            p.StackOverflow();

            //p.StackOverflow(30000000);
            //a[] a1 = new a[100*0000];

        }

        //mack stack overflow  18.05.19
        void StackOverflow(int length)
        {
            StructA[] a1 = new StructA[length];
            StructA a2;
            for (int i = 0; i < length; i++)
            {
                a1[i] = new StructA();
                //a1[i].arr = new int[1000];  slow
                a1[i].i = i;
                // a2 = new a();
                //a2.arr = new int[1000];  slow
            }
        }
        //can't 
        static void StackOverflow(params StructA[] a1)
        {
            for (int i = 0; i < a1.Count(); i++)
            {
                a1[i] = new StructA();
            }
        }

        //ok 5000
        void StackOverflow(StructA a1, int count)
        {
            if (count > 0)
                StackOverflow(a1, ++count);
        }
        //ok  20000 
        int count = 0;
        void StackOverflow()
        {
            count = count + 1;
            StackOverflow();
        }
        struct StructA
        {
            //a i =null;  recly
            //int[] i =null;  init
            internal int i;
            long l;
            float f;
            double d;
            decimal dec;//16 byte
                        //all 40 byte
            internal int[] arr;
        }
        int OneM = 1024 * 1024;  //100 0000 / 40 = 25 000
    }
    
    //empty netcore
    //18 0607  vary encode output 
            app.Run(async (context) =>
            {
                //System.Threading.Thread.Sleep(3000);

                await context.Response.WriteAsync("Hello World! ");
                await context.Response.WriteAsync(Environment.NewLine);
                await context.Response.WriteAsync("Hello World! a", System.Text.Encoding.ASCII);
                await context.Response.WriteAsync(Environment.NewLine);
                await context.Response.WriteAsync("Hello World! u", System.Text.Encoding.Unicode);
                await context.Response.WriteAsync(Environment.NewLine);
                await context.Response.WriteAsync("Hello World! u32", System.Text.Encoding.UTF32);
                await context.Response.WriteAsync(Environment.NewLine);
                await context.Response.WriteAsync("Hello World! u7", System.Text.Encoding.UTF7);
                await context.Response.WriteAsync(Environment.NewLine);
                await context.Response.WriteAsync("Hello World! u8", System.Text.Encoding.UTF8);
                await context.Response.WriteAsync(Environment.NewLine);

                await context.Response.WriteAsync("英文");
                await context.Response.WriteAsync(Environment.NewLine);
                await context.Response.WriteAsync("英文 a", System.Text.Encoding.ASCII);
                await context.Response.WriteAsync(Environment.NewLine);
                await context.Response.WriteAsync("英文 u", System.Text.Encoding.Unicode);
                await context.Response.WriteAsync(Environment.NewLine);
                await context.Response.WriteAsync("英文 u32", System.Text.Encoding.UTF32);
                await context.Response.WriteAsync(Environment.NewLine);
                await context.Response.WriteAsync("英文 u7", System.Text.Encoding.UTF7);
                await context.Response.WriteAsync(Environment.NewLine);
                await context.Response.WriteAsync("英文 u8", System.Text.Encoding.UTF8);  //中文乱码， 用unicode 打开 有的正常 其它的乱码，u 两字节/32 4字节
            });
