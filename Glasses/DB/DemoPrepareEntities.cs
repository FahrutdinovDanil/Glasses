using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glasses.DB
{
    public partial class DemoPrepareEntities
    {
        private static DemoPrepareEntities context;
        public static DemoPrepareEntities GetContext()
        {
            if (context == null)
                context = new DemoPrepareEntities();
            return context;
        }
    }
}
