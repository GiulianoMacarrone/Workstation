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

            ZipFile.CreateFromDirectory(carpetaDatos, zipPath, CompressionLevel.Optimal, false);

            BackupDAL.GuardarEvento(new Backup
            {
                Fecha = DateTime.Now,
                Operacion = "Backup",
                Usuario = SesionUsuario.Instancia.UsuarioActual?.username,
                ArchivoPath = zipPath
            });
        }

        public void RestaurarBackup(string zipPath)
        {
            if (!File.Exists(zipPath)) throw new FileNotFoundException("Archivo de backup no encontrado", zipPath);

            if (Directory.Exists(carpetaDatos)) Directory.Delete(carpetaDatos, recursive: true);

            ZipFile.ExtractToDirectory(zipPath, carpetaDatos);

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