using Services.Interface;
using Services.Page;
using Services.User;

namespace Services
{
    public class SimpleDI
    {
        private static volatile SimpleDI instance = null;
        private static readonly object padlock = new object();

        public IPageService PageService { get; private set; }
        public IUserService UserService { get; private set; }

        private SimpleDI()
        {
            PageService = new PageService();
            UserService = new UserService();
        }

        public static SimpleDI Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new SimpleDI();
                        }
                    }
                }

                return instance;
            }
        }
    }
}
