using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Modelos.Especificaciones
{
    public class PagedList<T> : List<T>
    {
        public MetaData MetaData { get; set; }
        public PagedList( List<T> items,
                          int count,
                          int pageNumber,
                          int pageSize
                        ) 
        {
            MetaData = new MetaData
            {
                TotalCount = count,
                PageSize = pageSize,
                /*
                 * Por ejemplo 1.5 lo transforma a 2
                 */
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };
            AddRange(items); // Agregar los elementos de la coleccion al final de la lista
        }
        public static PagedList<T> TopagegList( IEnumerable<T> entidad,
                                                int pageNumber,
                                                int pageSize
                                              )
        {
            var count = entidad.Count();
            var items = entidad.Skip( (pageNumber - 1) * pageSize )
                               .Take( pageSize )
                               .ToList();
            return new PagedList<T>( items, 
                                     count, 
                                     pageNumber,
                                     pageSize
                                   );
        }
    }
}
