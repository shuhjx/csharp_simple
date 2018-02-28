using ServiceStack.DataAnnotations;
using sompo.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sompo.Model
{
    [Alias("companies")]
    class Company : BaseModel
    {
        [AutoIncrement]
        public string Name { get; set; }
        public decimal Unit_price { get; set; }
        public string Currency_unit { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public int Ctype { get; set; }

        public string ToS()
        {
            return "ID: "+Id+", Name: "+Name+ ", UnitPrice: "+ Unit_price+ ", CurrencyUnit: "+ Currency_unit+ 
                ", Email: "+ Email+ ", Status: "+ Status+", Ctype: "+Ctype + ", CreatedAt: " + Created_at;
        }

    }
}
