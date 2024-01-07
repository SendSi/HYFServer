namespace HYFServer.Utils
{
    public abstract class Singleton<T> where T : Singleton<T>, new()
    {
        static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                    instance.OnInit();
                }

                return instance;
            }
        }

        public void Dispose()
        {
            OnDispose();
            instance = null;
        }

        protected virtual void OnInit() { }
        protected virtual void OnDispose() { }
    }
}
