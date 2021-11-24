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
using Trabalho_Final___Desenvolvimento_de_Sistemas_de_Informação.Data;
using Trabalho_Final___Desenvolvimento_de_Sistemas_de_Informação.Model;
using Trabalho_Final___Desenvolvimento_de_Sistemas_de_Informação.View;

namespace Trabalho_Final___Desenvolvimento_de_Sistemas_de_Informação
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public HospitalDAO hospitalDAO = new HospitalDAO();
        Hospital novoHospital = new Hospital();
        Hospital selectedHospital = new Hospital();
        string action = "adicionar";


        public MainWindow()
        {
            InitializeComponent();
            GetHospitais(); ;
        }

        private void GetHospitais()
        {
            HospitaisDataGrid.ItemsSource = HospitalDAO.GetHospital();
        }

        private void EditHospital(object sender, RoutedEventArgs e)
        {
            selectedHospital = (sender as FrameworkElement).DataContext as Hospital;
            HospitalGrid.DataContext = selectedHospital;
            action = "editar";
        }

        private void DeleteHospital(object sender, RoutedEventArgs e)
        {
            var hospitalToDelete = (sender as FrameworkElement).DataContext as Hospital;

            if (MessageBox.Show("Tem certeza que deseja remover o hospital " + hospitalToDelete.Nome + "?", "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                HospitalDAO.DeleteHospital(hospitalToDelete);
                GetHospitais();
            }



        }

        private void HospitalConfirm(object sender, RoutedEventArgs e)
        {
            if (action == "adicionar")
            {
                HospitalDAO.InsereHospital(novoHospital);
                GetHospitais();
                novoHospital = new Hospital();
                HospitalGrid.DataContext = novoHospital;
            }
            else if (action == "editar")
            {
                HospitalDAO.AtualizaHospital(selectedHospital);
                GetHospitais();
                HospitalGrid.DataContext = novoHospital;
                action = "adicionar";
            }

        }

        private void OpenVoluntario(object sender, RoutedEventArgs e)
        {
            var voluntario = new VoluntarioWindow();
            voluntario.Show();
        }
    }
}
