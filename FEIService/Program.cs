using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEIService
{
    /// <summary>
    /// Clase principal de la aplicación.
    /// </summary>
    public static class Program
    {
        // Logger estático para registrar eventos de la aplicación
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// Punto de entrada principal de la aplicación.
        /// </summary>
        /// <param name="args">Argumentos de la línea de comandos.</param>
        static void Main(string[] args)
        {
            // Configurar log4net desde app.config
            XmlConfigurator.Configure();

            // Registrar evento informativo de inicio de la aplicación
            log.Info("Aplicación iniciada");

        }
    }
}