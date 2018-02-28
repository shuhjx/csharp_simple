using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sompo.Model
{
    [Alias("admins")]
    class Admin : BaseModel
    {
        [AutoIncrement]
        public int Company_id { get; set; }
        public string Email { get; set; }
        public int Authority { get; set; }
        public int Status { get; set; }
        public string Admin_name { get; set; }

        public string ToS()
        {
            return "ID: "+Id+", CompanyId: "+Company_id+ ", Email: "+ Email+ ", Authority: "+ Authority+", Status: "+Status+
                ", AdminName: "+ Admin_name + ", CreatedAt: " + Created_at;
        }
    }
}
