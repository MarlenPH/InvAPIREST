using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InventarioWAR.Models;

namespace InventarioWAR.Controllers
{
    public class HomeController : ApiController
    {
        # region Datos
        List<Products> inventario = new List<Products>()
        {
            new Products {Idprod = 1, Name = "Leche Asturiana", IdFam = 1, IdSubFam = 1,
                           Stock = 10, Price = 0.75, DateRegister = DateTime.Now,
                           DateUnSubs = null, DateExpiration = DateTime.Now.AddYears(1), IdCustomersReg = 1, IdCustomersUnsub = null,baja = 0},
            new Products {Idprod = 2, Name = "Leche Pascual", IdFam = 1, IdSubFam = 1,
                           Stock = 20, Price = 0.85, DateRegister = DateTime.Now,
                           DateUnSubs = null, DateExpiration = DateTime.Now.AddYears(1), IdCustomersReg = 1, IdCustomersUnsub = null,baja = 0},
            new Products {Idprod = 3, Name = "Yogourt", IdFam = 1, IdSubFam = 2,
                           Stock = 10, Price = 0.30, DateRegister = DateTime.Now,
                           DateUnSubs = null, DateExpiration = DateTime.Now.AddMonths(-2), IdCustomersReg = 1, IdCustomersUnsub = null,baja = 0},
            new Products {Idprod = 4, Name = "La Española", IdFam = 2, IdSubFam = 3,
                           Stock = 3, Price = 2.99, DateRegister = DateTime.Now,
                           DateUnSubs = null, DateExpiration = DateTime.Now.AddYears(-1), IdCustomersReg = 2, IdCustomersUnsub = null,baja = 0}
            
        };
        #endregion

        #region Métodos

        
        /// <summary>Obtener todos los productos del inventario
        /// llamada a la api: GET api/Home/ 
        /// </summary>
        [HttpGet]
        public IEnumerable<Products> GetProductos()
        {
            return inventario;
        }

        /// <summary>Obtener los detalles de un producto determinado
        /// llamada a la api: GET api/Home/2 
        /// </summary> 
        [HttpGet]
        public Products GetDetailProd(int id)
        {
            Products myproduct = (from inv in inventario
                                  where inv.Idprod == id
                                  select inv).SingleOrDefault();
            return myproduct;
        }

        /// <summary>Obtener el nombre de los productos caducados
        /// llamada a la api: GET api/Home/GetCaducados 
        /// </summary> 
        [HttpGet]
        public IEnumerable<String> GetCaducados()
        {
            
            IEnumerable<String> caducados = from inv in inventario
                                         where DateTime.Now > inv.DateExpiration
                                         select inv.Name;  
            return caducados;
        }

        
        /// <summary>Adicionar un elemento al inventario
        /// llamada a la api: 'POST api/Home' 
        /// </summary> 
        [HttpPost]
        public IEnumerable<Products> PostProduct(Products prod)
        {
            inventario.Add(prod);

            return inventario;
        }

        /// <summary>Actualizar algunos datos de un producto determinado
        /// llamada a la api: PUT api/Home/
        /// </summary> 
        [HttpPut]
        public void UpdateInvDetails(Products prod)
        {
            Products myproduct = (from inv in inventario
                                  where inv.Idprod == prod.Idprod
                                  select inv).SingleOrDefault();

            myproduct.Name = prod.Name;            
            myproduct.IdFam = prod.IdFam;
            myproduct.IdSubFam = prod.IdSubFam;
            myproduct.Stock = prod.Stock;
            myproduct.Price = prod.Price;
            myproduct.DateExpiration = prod.DateExpiration;
            myproduct.IdCustomersUnsub = prod.IdCustomersUnsub;
        }
        /// <summary>Sacar el elemento del inventario sin ser eliminado(posu ID), modificando su campo 'baja'
        /// llamada a la api: PATCH api/Home/2 
        /// </summary>
        [HttpPatch]
        public string Patch(int idprod)
        {
            string nameprod = inventario.Where(p => p.Idprod == idprod).Select(p => p.Name).ToString();

            Products myproduct = (from inv in inventario
                                  where inv.Idprod == idprod
                                  select inv).SingleOrDefault();

            myproduct.baja = 1;

            return "El producto " + nameprod + "fue sacado del inventario";
        }

        /// <summary>Eliminar un elemento del inventario
        /// llamada a la api: DELETE api/Home/4 
        /// </summary> 
        [HttpDelete]
        public string Delete(int id){
            
            string nameprod = inventario.Where(p => p.Idprod == id).Select(p=>p.Name).ToString();            
            inventario.RemoveAll(p => p.Idprod == id);
            return "El producto " + nameprod + "fue eliminado del inventario";
        }

        
        #endregion
    }
}
