using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankacount
{
    internal class AkunBank
    {
        public string Owner {  get; set; }
        public Guid IdAkun { get; set; }
        public decimal Saldo { get; set; }


        public AkunBank( string owner) 
        {
            Owner = owner;
            IdAkun = Guid.NewGuid();
            Saldo = 0;
        }

    }
}
