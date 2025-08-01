using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using BE.Modelo;
using DAL;
using BE.Backup;

namespace BLL.Servicios
{
    public class BackupBLL
    {
        private readonly string carpetaDatos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        private readonly string carpetaBackup = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backups");

        public BackupBLL()
        {
            Directory.CreateDirectory(carpetaDatos);
            Directory.CreateDirectory(carpetaBackup);
        }

        public void RealizarBackup()
        {
            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var zipPath = Path.Combine(carpetaBackup, $"backup_{timestamp}.zip");
            var user = SesionUsuario.Instancia.UsuarioActual?.username;
            var bitacoraPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BitacoraBackups.xml");
            var destinoBitacora = Path.Combine(carpetaDatos, "BitacoraBackups.xml");

            if (File.Exists(bitacoraPath)) File.Copy(bitacoraPath, destinoBitacora, overwrite: true);

            ZipFile.CreateFromDirectory(carpetaDatos, zipPath, CompressionLevel.Optimal, false);
            if (File.Exists(destinoBitacora)) File.Delete(destinoBitacora);

            BackupDAL.GuardarEvento(new Backup
            {
                Fecha = DateTime.Now,
                Operacion = "Backup",
                Usuario = user,
                ArchivoPath = zipPath
            });
        }

        public void RestaurarBackup(string zipPath)
        {
            if (!File.Exists(zipPath)) throw new FileNotFoundException("Archivo de backup no encontrado", zipPath);

            if (Directory.Exists(carpetaDatos)) Directory.Delete(carpetaDatos, recursive: true);

            ZipFile.ExtractToDirectory(zipPath, carpetaDatos);

            var bitacoraRestaurada = Path.Combine(carpetaDatos, "BitacoraBackups.xml");
            var destinoBitacora = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BitacoraBackups.xml");

            if (File.Exists(bitacoraRestaurada)) File.Copy(bitacoraRestaurada, destinoBitacora, overwrite: true);


            BackupDAL.GuardarEvento(new Backup
            {
                Fecha = DateTime.Now,
                Operacion = "Restore",
                Usuario = SesionUsuario.Instancia.UsuarioActual?.username,
                ArchivoPath = zipPath
            });
        }

        public List<Backup> ListarEventos()=> BackupDAL.ListarEventos();
    }
}