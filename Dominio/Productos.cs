using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Productos
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string CodArt { get; set; }  
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public string Imagen { get; set; }
        public decimal Precio { get; set; } 
        public  int Id { get; set; }


    }
}
