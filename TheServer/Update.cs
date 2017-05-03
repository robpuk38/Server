using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheServer
{
    class Update
    {
      
        
        public static void TimeNow(Object o)
        {
           
           // Debug.Log("Update Time: " + DateTime.Now);
            
            GC.Collect();
        }
    }
}
