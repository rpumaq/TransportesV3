using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TransportesV3.Models
{
    public partial class transportesv3Context : DbContext
    {
        public virtual DbSet<BoletoViaje> BoletoViaje { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Comprobante> Comprobante { get; set; }
        public virtual DbSet<Conductor> Conductor { get; set; }
        public virtual DbSet<DatosReniec> DatosReniec { get; set; }
        public virtual DbSet<Destino> Destino { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<HorarioHora> HorarioHora { get; set; }
        public virtual DbSet<ModeloDetalle> ModeloDetalle { get; set; }
        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<Ruta> Ruta { get; set; }
        public virtual DbSet<RutaDetalle> RutaDetalle { get; set; }
        public virtual DbSet<Sucursal> Sucursal { get; set; }
        public virtual DbSet<SucursalComprobante> SucursalComprobante { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
        public virtual DbSet<Unidad> Unidad { get; set; }
        public virtual DbSet<UnidadModelo> UnidadModelo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        public transportesv3Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-VRAFAHR;Database=transportesv3;User Id=sa;Password=breakdance;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoletoViaje>(entity =>
            {
                entity.ToTable("BOLETO_VIAJE");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaEmision).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.FkCliente)
                    .HasColumnName("FK_Cliente")
                    .HasMaxLength(8);

                entity.Property(e => e.FkHorarioHora).HasColumnName("FK_HorarioHora");

                entity.Property(e => e.FkSucursal).HasColumnName("FK_Sucursal");

                entity.Property(e => e.FkSucursalPago).HasColumnName("FK_SucursalPago");

                entity.Property(e => e.PrecioVenta).HasColumnType("decimal");

                entity.Property(e => e.RazonSocial).HasMaxLength(250);

                entity.Property(e => e.Reservado).HasMaxLength(10);

                entity.Property(e => e.Ruc)
                    .HasColumnName("RUC")
                    .HasMaxLength(11);

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UsuarioModificacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.ValorIgv)
                    .HasColumnName("ValorIGV")
                    .HasColumnType("decimal");

                entity.Property(e => e.ValorVenta).HasColumnType("decimal");

                entity.HasOne(d => d.FkHorarioHoraNavigation)
                    .WithMany(p => p.BoletoViaje)
                    .HasForeignKey(d => d.FkHorarioHora)
                    .HasConstraintName("FK_BOLETO_VIAJE_HORARIO_HORA");

                entity.HasOne(d => d.FkSucursalNavigation)
                    .WithMany(p => p.BoletoViajeFkSucursalNavigation)
                    .HasForeignKey(d => d.FkSucursal)
                    .HasConstraintName("FK_BOLETO_VIAJE_SUCURSAL");

                entity.HasOne(d => d.FkSucursalPagoNavigation)
                    .WithMany(p => p.BoletoViajeFkSucursalPagoNavigation)
                    .HasForeignKey(d => d.FkSucursalPago)
                    .HasConstraintName("FK_BOLETO_VIAJE_SUCURSAL1");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("CLIENTE");

                entity.HasIndex(e => e.Dni)
                    .HasName("IX_CLIENTE")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.FkTipoDocumento).HasColumnName("FK_TipoDocumento");

                entity.Property(e => e.OtroDocumento).HasMaxLength(12);

                entity.HasOne(d => d.FkTipoDocumentoNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.FkTipoDocumento)
                    .HasConstraintName("FK_CLIENTE_TIPO_DOCUMENTO");
            });

            modelBuilder.Entity<Comprobante>(entity =>
            {
                entity.ToTable("COMPROBANTE");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UsuarioModificacion)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Conductor>(entity =>
            {
                entity.HasKey(e => e.Licencia)
                    .HasName("PK_CONDUCTOR");

                entity.ToTable("CONDUCTOR");

                entity.Property(e => e.Licencia).HasMaxLength(15);

                entity.Property(e => e.Descripcion).HasMaxLength(250);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.FkPersonal).HasColumnName("FK_Personal");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UsuarioModificacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.FkPersonalNavigation)
                    .WithMany(p => p.Conductor)
                    .HasForeignKey(d => d.FkPersonal)
                    .HasConstraintName("FK_CONDUCTOR_PERSONAL");
            });

            modelBuilder.Entity<DatosReniec>(entity =>
            {
                entity.ToTable("DATOS_RENIEC");

                entity.Property(e => e.Id).HasColumnType("nchar(10)");

                entity.Property(e => e.Apellidos).HasColumnType("nchar(10)");

                entity.Property(e => e.Nombres).HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<Destino>(entity =>
            {
                entity.ToTable("DESTINO");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Codcentropob).HasColumnName("CODCENTROPOB");

                entity.Property(e => e.Coddepartam).HasColumnName("CODDEPARTAM");

                entity.Property(e => e.Coddistrito).HasColumnName("CODDISTRITO");

                entity.Property(e => e.Codprovincia).HasColumnName("CODPROVINCIA");

                entity.Property(e => e.Descripcion).HasMaxLength(250);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UsuarioModificacion)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.Ruc)
                    .HasName("PK_EMPRESA");

                entity.ToTable("EMPRESA");

                entity.Property(e => e.Ruc)
                    .HasColumnName("RUC")
                    .HasMaxLength(11);

                entity.Property(e => e.Celular1).HasMaxLength(12);

                entity.Property(e => e.Celular2).HasMaxLength(12);

                entity.Property(e => e.DireccionPrincipal)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Icono).HasMaxLength(250);

                entity.Property(e => e.Logo).HasMaxLength(250);

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.UrlFacebook).HasMaxLength(250);

                entity.Property(e => e.UrlTwitter).HasMaxLength(250);

                entity.Property(e => e.UrlWeb).HasMaxLength(250);

                entity.Property(e => e.UrlYoutube).HasMaxLength(250);

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UsuarioModificacion)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.ToTable("HORARIO");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.FkRuta).HasColumnName("FK_Ruta");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UsuarioModificacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.FkRutaNavigation)
                    .WithMany(p => p.Horario)
                    .HasForeignKey(d => d.FkRuta)
                    .HasConstraintName("FK_HORARIO_RUTA");
            });

            modelBuilder.Entity<HorarioHora>(entity =>
            {
                entity.ToTable("HORARIO_HORA");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.FkConductor)
                    .HasColumnName("FK_Conductor")
                    .HasMaxLength(15);

                entity.Property(e => e.FkHorario).HasColumnName("FK_Horario");

                entity.Property(e => e.FkUnidad)
                    .HasColumnName("FK_Unidad")
                    .HasMaxLength(10);

                entity.Property(e => e.Precio).HasColumnType("decimal");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UsuarioModificacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.FkConductorNavigation)
                    .WithMany(p => p.HorarioHora)
                    .HasForeignKey(d => d.FkConductor)
                    .HasConstraintName("FK_HORARIO_HORA_CONDUCTOR");

                entity.HasOne(d => d.FkHorarioNavigation)
                    .WithMany(p => p.HorarioHora)
                    .HasForeignKey(d => d.FkHorario)
                    .HasConstraintName("FK_HORARIO_HORA_HORARIO");

                entity.HasOne(d => d.FkUnidadNavigation)
                    .WithMany(p => p.HorarioHora)
                    .HasForeignKey(d => d.FkUnidad)
                    .HasConstraintName("FK_HORARIO_HORA_UNIDAD");
            });

            modelBuilder.Entity<ModeloDetalle>(entity =>
            {
                entity.ToTable("MODELO_DETALLE");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.FkModelo).HasColumnName("FK_Modelo");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UsuarioModificacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.FkModeloNavigation)
                    .WithMany(p => p.ModeloDetalle)
                    .HasForeignKey(d => d.FkModelo)
                    .HasConstraintName("FK_MODELO_DETALLE_UNIDAD_MODELO");
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.ToTable("PERSONAL");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CelularEmpresa).HasMaxLength(12);

                entity.Property(e => e.CelularPersonal).HasMaxLength(12);

                entity.Property(e => e.Coddepartam).HasColumnName("CODDEPARTAM");

                entity.Property(e => e.Coddistrito).HasColumnName("CODDISTRITO");

                entity.Property(e => e.Codprovincia).HasColumnName("CODPROVINCIA");

                entity.Property(e => e.Direccion).HasMaxLength(250);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Telefono).HasMaxLength(10);

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UsuarioModificacion)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Ruta>(entity =>
            {
                entity.ToTable("RUTA");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.PrecioDefecto).HasColumnType("decimal");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UsuarioModificacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.DestinoNavigation)
                    .WithMany(p => p.RutaDestinoNavigation)
                    .HasForeignKey(d => d.Destino)
                    .HasConstraintName("FK_RUTA_DESTINO1");

                entity.HasOne(d => d.OrigenNavigation)
                    .WithMany(p => p.RutaOrigenNavigation)
                    .HasForeignKey(d => d.Origen)
                    .HasConstraintName("FK_RUTA_DESTINO");
            });

            modelBuilder.Entity<RutaDetalle>(entity =>
            {
                entity.ToTable("RUTA_DETALLE");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.FkRuta).HasColumnName("FK_Ruta");

                entity.Property(e => e.Precio).HasColumnType("decimal");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UsuarioModificacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.FkRutaNavigation)
                    .WithMany(p => p.RutaDetalle)
                    .HasForeignKey(d => d.FkRuta)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_RUTA_DETALLE_RUTA");
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.ToTable("SUCURSAL");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Celular1).HasMaxLength(12);

                entity.Property(e => e.Celular2).HasMaxLength(12);

                entity.Property(e => e.Coddepartam).HasColumnName("CODDEPARTAM");

                entity.Property(e => e.Coddistrito).HasColumnName("CODDISTRITO");

                entity.Property(e => e.Codigo).HasMaxLength(5);

                entity.Property(e => e.Codprovincia).HasColumnName("CODPROVINCIA");

                entity.Property(e => e.ColorReserva).HasMaxLength(7);

                entity.Property(e => e.ColorVenta).HasMaxLength(7);

                entity.Property(e => e.Descripcion).HasMaxLength(500);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.FkEmpresa)
                    .HasColumnName("FK_Empresa")
                    .HasMaxLength(11);

                entity.Property(e => e.HorarioDom).HasMaxLength(100);

                entity.Property(e => e.HorarioLv)
                    .HasColumnName("HorarioLV")
                    .HasMaxLength(100);

                entity.Property(e => e.HorarioSab).HasMaxLength(100);

                entity.Property(e => e.Latitud).HasColumnType("numeric");

                entity.Property(e => e.Longitud).HasColumnType("numeric");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Telefono).HasMaxLength(15);

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UsuarioModificacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.FkEmpresaNavigation)
                    .WithMany(p => p.Sucursal)
                    .HasForeignKey(d => d.FkEmpresa)
                    .HasConstraintName("FK_SUCURSAL_EMPRESA");
            });

            modelBuilder.Entity<SucursalComprobante>(entity =>
            {
                entity.HasKey(e => new { e.IdSucursal, e.IdComprobante })
                    .HasName("PK_SUCURSAL_COMPROBANTE");

                entity.ToTable("SUCURSAL_COMPROBANTE");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UsuarioModificacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.IdComprobanteNavigation)
                    .WithMany(p => p.SucursalComprobante)
                    .HasForeignKey(d => d.IdComprobante)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SUCURSAL_COMPROBANTE_COMPROBANTE");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.SucursalComprobante)
                    .HasForeignKey(d => d.IdSucursal)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SUCURSAL_COMPROBANTE_SUCURSAL");
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.ToTable("TIPO_DOCUMENTO");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UsuarioModificacion)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Unidad>(entity =>
            {
                entity.HasKey(e => e.Placa)
                    .HasName("PK_UNIDAD");

                entity.ToTable("UNIDAD");

                entity.Property(e => e.Placa).HasMaxLength(10);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.FkModelo).HasColumnName("FK_Modelo");

                entity.Property(e => e.NroCertificado).HasMaxLength(20);

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UsuarioModificacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.FkModeloNavigation)
                    .WithMany(p => p.Unidad)
                    .HasForeignKey(d => d.FkModelo)
                    .HasConstraintName("FK_UNIDAD_UNIDAD_MODELO");
            });

            modelBuilder.Entity<UnidadModelo>(entity =>
            {
                entity.ToTable("UNIDAD_MODELO");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Anio).HasMaxLength(4);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Modelo).HasMaxLength(50);

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UsuarioModificacion)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Usuario1)
                    .HasName("PK_USUARIO");

                entity.ToTable("USUARIO");

                entity.Property(e => e.Usuario1)
                    .HasColumnName("Usuario")
                    .HasMaxLength(25);

                entity.Property(e => e.FkPersonal).HasColumnName("FK_Personal");

                entity.HasOne(d => d.FkPersonalNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.FkPersonal)
                    .HasConstraintName("FK_USUARIO_PERSONAL");
            });
        }
    }
}