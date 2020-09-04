using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Insert
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Creamos un TableRowGroup vacio
            Table.RowGroups.Add(new TableRowGroup());
        }

        private void OnAddClicked(object sender, RoutedEventArgs e)
        {
            var desde = TBDesde.Text;
            var precio = TBPrecio.Text;

            TableRow tr = new TableRow();
            tr.Cells.Add(new TableCell(new Paragraph(new Run(desde))));
            tr.Cells.Add(new TableCell(new Paragraph(new Run(precio))));
            Table.RowGroups[0].Rows.Add(tr);
        }
    }
}
