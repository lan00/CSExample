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
