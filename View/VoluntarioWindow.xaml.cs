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
using System.Windows.Shapes;
using Trabalho_Final___Desenvolvimento_de_Sistemas_de_Informação.Data;

namespace Trabalho_Final___Desenvolvimento_de_Sistemas_de_Informação.View
{
    /// <summary>
    /// Lógica interna para VoluntarioWindow.xaml
    /// </summary>
    public partial class VoluntarioWindow : Window
    {
        VoluntarioDAO voluntarioDAO = new VoluntarioDAO();

        public VoluntarioWindow()
        {
            InitializeComponent();
            GetVoluntarios();
        }

        private void GetVoluntarios()
        {
            voluntariosDataGrid.ItemsSource = (System.Collections.IEnumerable)VoluntarioDAO.GetVoluntarios();
        }

        private void ExitVoluntario(object sender, RoutedEventArgs e) => Close();
    }
}