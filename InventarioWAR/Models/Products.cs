using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace InventarioWAR.Models
{
    public class Products
    {
        public int Idprod { get; set; }
        public string Name { get; set; }
        public int IdFam { get; set; }
        public int IdSubFam { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime? DateUnSubs { get; set; }
        public DateTime DateExpiration { get; set; }
        public int IdCustomersReg { get; set; }
        public int? IdCustomersUnsub { get; set; }
        public int baja { get; set; } //será 1 si ha sido dado de baja, por defecto es 0

        
    }


}