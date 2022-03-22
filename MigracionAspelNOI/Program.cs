using System;
using System.IO;
using System.Linq;

namespace MigracionAspelNOI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var carpetaRaiz = Directory.GetCurrentDirectory();
            var carpetaBasesDatos = Path.Combine(carpetaRaiz, "Datos");
            if (Directory.Exists(carpetaBasesDatos))
            {
                Console.WriteLine($"{nameof(carpetaBasesDatos)}:{carpetaBasesDatos}");
                var carpetas = Directory.GetDirectories(carpetaBasesDatos);
                var carpetaPlantillas = Path.Combine(carpetaRaiz, "Plantillas");
                var contadorCarpetaReportes = 1;
                foreach (var carpeta in carpetas)
                {
                    Console.WriteLine($"{nameof(carpeta)}:{carpeta}");
                    var archivos = Directory.GetFiles(carpeta, "*.fdb");
                    if (archivos.Any(t => t.Contains("NOI90")))
                    {
                        var fdb = new FileInfo(archivos.FirstOrDefault(t => t.ToLower().EndsWith(".fdb")));
                        Console.WriteLine($"{nameof(fdb)}:{fdb}");
                        File.Move(fdb.FullName, fdb.FullName.Replace("NOI90", "NOI100"));
                        Console.WriteLine($"{nameof(fdb)}:{fdb.FullName.Replace("NOI90", "NOI100")}");
                        Console.WriteLine("Finaliza Renombre");
                    }
                    if (Directory.Exists(carpetaPlantillas))
                    {
                        var carpetaReportes = Path.Combine(carpetaRaiz, $"Datos{contadorCarpetaReportes}");
                        if (!Directory.Exists(carpetaReportes))
                        {
                            Directory.CreateDirectory(carpetaReportes);
                            CopyFilesRecursively(carpetaPlantillas, carpetaReportes);
                        }
                    }
                    contadorCarpetaReportes++;
                }
            }
            var archivoConexiones = Path.Combine(carpetaRaiz + @"\Conexiones.ini");
            if (File.Exists(archivoConexiones))
            {
                var textoConexiones = File.ReadAllText(archivoConexiones);
                textoConexiones = textoConexiones.Replace("NOI9.00", "NOI10.00");
                textoConexiones = textoConexiones.Replace("NOI90Empre", "NOI100Empre");
                File.WriteAllText(Path.Combine(carpetaRaiz, "Conexiones10.ini"), textoConexiones);
                Console.WriteLine($"Finaliza renombrado conexiones");
            }
            Console.ReadLine();
        }

        private static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }
    }
}
