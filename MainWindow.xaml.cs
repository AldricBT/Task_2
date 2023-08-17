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

namespace Task_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Client client = new Client("Иванов", "Иван", "Иванович", "89001112223", "5050123456");

        public MainWindow()
        {
            
            InitializeComponent();
            
        }

        private void phoneEdit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void clientView_Click(object sender, RoutedEventArgs e)
        {
            RefreshInfo();
        }

        private void chooseWorker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshInfo();
        }

        /// <summary>
        /// Вывод данных клиента на форму в зависимости от уровня доступа
        /// </summary>
        private void RefreshInfo()
        {
            IWorker worker = GetWorker();
            lastname.Content = worker.Lastname;
            name.Content = worker.Name;
            patronymic.Content = worker.Patronymic;
            phone.Content = worker.Phone;
            passport.Content = worker.Passport;
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            IWorker worker = GetWorker();
            worker.Lastname = lastnameEdit.Text;
            worker.Name = nameEdit.Text;
            worker.Patronymic = patronymicEdit.Text;
            worker.Phone = phoneEdit.Text;
            worker.Passport = passportEdit.Text;

            RefreshInfo();
        }

        private IWorker GetWorker()
        {
            IWorker worker;
            if (chooseWorker.SelectedValue.ToString() == "Консультант")
            {
                worker = new Consultant(client);
            }
            else
            {
                worker = new Manager(client);
            }
            return worker;
        }
    }
}
