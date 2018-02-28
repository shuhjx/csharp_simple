using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sompo.Util;

namespace sompo.Model
{
    class BaseModel
    {
        [AutoIncrement]
        public long Id { get; set; }
        public int Deleted { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        public BaseModel()
        {
            Created_at = System.DateTime.Now;
            Updated_at = System.DateTime.Now;
            //Log.Println("====BaseModel构造函数====");
        }

    }
}
