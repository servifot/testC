using Selection.Clases;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Reflection;
using System.Windows.Controls;
using System;

namespace Selection
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly int POS_ID = 0;
        private static readonly int POS_CPU = 1;
        private static readonly int POS_HDD = 2;
        private static readonly int POS_RAM = 3;

        private LinkedList<Computer> Computers = null;

        public MainWindow()
        {
            InitializeComponent();

            LoadComputers();
        }

        /// <summary>
        /// Carga la lista de ordenadors a partir del archivo donde se definen
        /// </summary>
        private void LoadComputers()
        {
            if (Computers == null)
            {
                Computers = new LinkedList<Computer>();
            }
            string[] lines = Properties.Resources.pcs.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (string result in lines)
            {
                string[] computerParams = result.Split(';');
                Computers.AddLast(new Computer(computerParams[POS_ID], computerParams[POS_CPU], computerParams[POS_HDD], computerParams[POS_RAM]));
            }
        }

        /// <summary>
        ///  Busca un id en la lista y si lo encuentra muestra sus características en la ventana
        /// </summary>
        /// <param name="id">Identificador del PC</param>
        private void LoadComputerInfo(string id)
        {
            // Arrancamos un medidor de tiempo
            var watch = System.Diagnostics.Stopwatch.StartNew();

            bool found = false;

            // Buscamos el Ornedaor dado su ID
            foreach (Computer c in Computers)
            {
                if (c.Id.Equals(id))
                {
                    LBLCpu.Content = c.Cpu;
                    LBLHdd.Content = c.Hdd;
                    LBLRam.Content = c.Ram;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                LBLCpu.Content = "-";
                LBLHdd.Content = "-";
                LBLRam.Content = "-";
            }

            watch.Stop();
            LBLTime.Content = $"Total Execution Time: {watch.ElapsedMilliseconds} ms";
        }

        /// <summary>
        /// Cuando algún botón es pulsado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnIDClick(object sender, RoutedEventArgs e)
        {
            // Obtenemos el texto del botón
            string id = (e.Source as Button).Content.ToString();
            // Mostramos la identificación del ordenador al que corresponde el ID
            LoadComputerInfo(id);
        }

        
    }
}
