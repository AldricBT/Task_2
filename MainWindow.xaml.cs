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
        
        private RepositoryOfClients clients;
                
        
        public MainWindow()
        {   
            InitializeComponent();
            clients = new RepositoryOfClients("clients.json");
            clients.Load();
            RefreshInfo();
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
            if (clients != null)
                RefreshInfo();
        }

        private void chooseWorker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (clients != null)
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

            lastnameEdit.Text = worker.Lastname;
            nameEdit.Text = worker.Name;
            patronymicEdit.Text = worker.Patronymic;
            phoneEdit.Text = worker.Phone;
            passportEdit.Text = worker.Passport;
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            IWorker worker = GetWorker();
            worker.Lastname = lastnameEdit.Text;
            worker.Name = nameEdit.Text;
            worker.Patronymic = patronymicEdit.Text;
            worker.Phone = phoneEdit.Text;
            worker.Passport = passportEdit.Text;

            clients.Save();
            RefreshInfo();
        }

        private IWorker GetWorker()
        {
            IWorker worker;
            if (chooseWorker.SelectedValue.ToString() == "Консультант")
            {
                worker = new Consultant(clients.Clients[0]);
                lastnameEdit.IsReadOnly = true;
                nameEdit.IsReadOnly= true;
                patronymicEdit.IsReadOnly = true;
                passportEdit.IsReadOnly = true;
                inputMessage.Content = "Вы можете изменять только телефон!";                
            }
            else
            {
                worker = new Manager(clients.Clients[0]);
                lastnameEdit.IsReadOnly = false;
                nameEdit.IsReadOnly = false;
                patronymicEdit.IsReadOnly = false;
                passportEdit.IsReadOnly = false;
                inputMessage.Content = "";
            }
            return worker;
        }
    }
}
