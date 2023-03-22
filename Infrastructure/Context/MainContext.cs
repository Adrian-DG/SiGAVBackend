using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
	public class MainContext : DbContext
	{
		public MainContext(DbContextOptions options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//if(true)
			//{
			//	new Infrastructure.Helpers.EncryptHelper().CreatePasswordHash("admin01", out byte[] passwordHash, out byte[] passwordSalt);

			//	modelBuilder.Entity<Usuario>().HasData(
			//		new Usuario { Id = 1, Username = "admin", PasswordHash = passwordHash, PasswordSalt = passwordSalt, EsAdministrador = true, Estatus = true }
			//	);
			//}
		}

		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Permiso> Permisos { get; set; }
		public DbSet<UsuarioPermiso> UsuarioPermisos { get; set; }

	}
}
