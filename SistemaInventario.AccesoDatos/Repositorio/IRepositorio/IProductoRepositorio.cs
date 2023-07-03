using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio.IRepositorio
{
    public interface IProductoRepositorio : IRepositorio<Producto>
    {
        void Acutaliza(Producto producto);
        IEnumerable<SelectListItem> ObtenerTodosDropdownLista(string obj);
    }
}
