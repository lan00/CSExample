//arc 
//180802 
interface IMoveExecutor
    {
        //bool ExecuteAction(Engine engine, ActionToken actionToken);
        bool Test();
    }

    class DebuggableActionExecutor : IMoveExecutor
    {
        public bool Test()
        {
            //log
            this.ActionInternal();
            //this.AfterExecute();

            bool val = true;
            return val;
        }

        protected virtual void ActionInternal()
        {
            //a.execute();
        }

    }
    class DefaultActionExecutor : DebuggableActionExecutor
    {
        protected override void ActionInternal()
        {
            try
            {
                base.ActionInternal();
            }
            catch (Exception ex)
            {
                //log ex
            }
        }
    }


    class DecoratorActionExecutor : IMoveExecutor
    {
        IMoveExecutor Executor;
        public bool Test()
        {
            bool condtion = true;
            if (condtion)
                return ExecuteTop();
            else
                return ExecuteInternal();
        }

        bool ExecuteTop() { return Executor.Test(); }

        bool ExecuteInternal() { return Executor.Test(); }

    }

    class Engine
    { }
    class ActionToken
    { }

    //public interface ITest
    //{
    //    ITest GetNextTest(ITest current, bool previousBlockSucceeded);
    //    bool Execute(ITestProvider provider);
    //    IList<ITest> Items { get; }
    //}

    //public interface ITestProvider
    //{ }


    //art struct
    class ArcBase
    { }
    class PtoArc : ArcBase
    { }
    class PoneArc : PtoArc
    { }
    abstract class BaseArc: PoneArc
    {
       protected virtual void Init()
        {  //log init
        }
        protected abstract void Body();
       protected void Execute()
        {
            try
            {
                Init();

                Body();
            }
            catch (Exception ex)
            {
                //log
            }
            finally
            {
                Finaliza();
            }

           

        }

        void Finaliza()
        {
            //BeforeQuit();
            //GC
            //normal
            //    AfterQuit();
            //log end
        }


    }

   abstract  class AbstractArc:BaseArc
    {
        protected override void Init()
        {
            base.Init();
            //asdf
        }

    }

    class Arc:AbstractArc
    {
        public Arc()
        {
            //init
        }

        protected override void Body()
        {
            //normal
        }



    }

    class callfunc
    {
        void main()
        {
            Arc a = new Arc();
            a.Execute();
        }
    }
