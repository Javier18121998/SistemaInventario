using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Configuracion
{
    public class ProductoConfiguracion : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            /*
             * Configuración de las propiedades y atributos por cada una
             */

            builder.Property(x => x.Id)
                   .IsRequired();

            builder.Property(x => x.NumeroSerie)
                   .IsRequired()
                   .HasMaxLength(60);

            builder.Property(x => x.Descripcion)
                   .IsRequired()
                   .HasMaxLength(60);

            builder.Property(x => x.Precio)
                   .IsRequired();

            builder.Property(x => x.Costo)
                   .IsRequired();

            builder.Property(x => x.Estado)
                   .IsRequired();

            builder.Property(x => x.CategoriaId)
                   .IsRequired();

            builder.Property(x => x.MarcaId)
                   .IsRequired();

            builder.Property(x => x.ImagenUrl)
                   .IsRequired(false);

            builder.Property(x => x.PadreId)
                   .IsRequired(false);

            /*
             * Relaciones
             */

            builder.HasOne(x => x.Categoria)
                   .WithMany()
                   .HasForeignKey(x => x.CategoriaId)
                   .OnDelete(DeleteBehavior.NoAction); /* La entidad Categoria tiene relacion 
                                                        foranea con Producto por medio de CategoriaId en 
                                                        la entidad Producto 
                                                        */

            builder.HasOne(x => x.Marca)
                   .WithMany()
                   .HasForeignKey(x => x.MarcaId)
                   .OnDelete(DeleteBehavior.NoAction); /* La entidad Categoria tiene relacion 
                                                        foranea con Producto por medio de CategoriaId en 
                                                        la entidad Producto 
                                                        */

            builder.HasOne(x => x.Padre)
                   .WithMany()
                   .HasForeignKey(x => x.PadreId)
                   .OnDelete(DeleteBehavior.NoAction); /* La entidad Categoria tiene relacion 
                                                        foranea con Producto por medio de CategoriaId en 
                                                        la entidad Producto 
                                                        */
        }
    }
}
