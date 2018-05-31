
    //test yiled
    //cs 18 05 30
    class enuma
    {
        public enuma(string[] a)
        {
            arr = a;
        }

        string[] arr;
        //string[] arr = { "a", "b", "a2" };

        public IEnumerator<string> GetEnumerator()
        {
            return enumerator();
        }
        IEnumerator<string> enumerator()
        {
            //return arr.ToList().GetEnumerator();
            for (int i = 0; i < arr.Length; i++)
            {
                yield return arr[i];
            }
        }
        
        //test class
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
        public class TestEnuma
        {
            [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
            public void MyTestMethod()
            {
                string[] arr = { "a", "b", "a2","cd","hij" };
                enuma a1 = new enuma(arr);
                int i = 0;
                foreach (var a in a1)
                {
                    Console.WriteLine(a);
                    Assert.AreEqual(arr[i], a);
                    i++;
                }
            }
            //[TestMethod]
            //public void TMOK()
            //{

            //}

            //[TestMethod]
            //public void TMFail()
            //{
            //    Assert.Fail();
            //}
        }
    }
