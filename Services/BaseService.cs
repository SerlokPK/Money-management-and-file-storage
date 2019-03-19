using Services.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BaseService
    {
        public MoneyDBEntities GetContext()
        {
            return new MoneyDBEntities();
        }
    }
}
