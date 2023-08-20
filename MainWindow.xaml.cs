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

namespace Task_3
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
            FillClientComboBox();
            RefreshInfo();
        }

        private void phoneEdit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
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
            editTime.Content = worker.EditTime.ToString("dd.MM.yyyy HH:mm");
            editWho.Content = worker.EditWho;
            editType.Content = worker.EditType;
            editData.Content = worker.EditData;
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeInfo();
            RefreshClientComboBox();
            clients.Save();
            RefreshInfo();
        }

        private void ChangeInfo()
        {
            IWorker worker = GetWorker();
            if (IsInfoChanged(worker))
            {
                worker.Lastname = lastnameEdit.Text;
                worker.Name = nameEdit.Text;
                worker.Patronymic = patronymicEdit.Text;
                worker.Phone = phoneEdit.Text;
               
                    
                worker.Passport = passportEdit.Text;
            }
            else            
                MessageBox.Show("Вы не изменили данные!","Внимание", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                
        }

        /// <summary>
        /// Определяет изменены ли данные и если изменены записывает их в свойство EditData
        /// </summary>
        /// <param name="worker">Экземпляр работника</param>
        /// <returns></returns>
        private bool IsInfoChanged(IWorker worker)
        {
            if (((worker.Lastname != lastnameEdit.Text) || (worker.Name != nameEdit.Text) ||
                    (worker.Patronymic != patronymicEdit.Text) || (worker.Phone != phoneEdit.Text) ||
                    (worker.Passport != passportEdit.Text)) && (phoneEdit.Text.Length == 11))
            {
                if (worker is Consultant)
                    worker.EditWho = "Консультант";
                else
                    worker.EditWho = "Менеджер";

                worker.EditData = "";
                if ((worker.Lastname != lastnameEdit.Text) ||
                    (worker.Name != nameEdit.Text) || (worker.Patronymic != patronymicEdit.Text))
                    worker.EditData += "ФИО ";
                if (worker.Phone != phoneEdit.Text)
                    worker.EditData += "Номер ";
                if (worker.Passport != passportEdit.Text)
                    worker.EditData += "Паспорт ";

                worker.EditTime = DateTime.Now;

                worker.EditType = "Изменение";
                return true;
            }
            else if (phoneEdit.Text.Length < 11)
                MessageBox.Show("Неверный номер телефона!", "Внимание", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            return false;
        }

        private IWorker GetWorker()
        {
            IWorker worker;
            if (chooseWorker.SelectedValue.ToString() == "Консультант")
            {
                worker = new Consultant(clients.Clients[chooseClient.SelectedIndex]);
                lastnameEdit.IsReadOnly = true;
                nameEdit.IsReadOnly= true;
                patronymicEdit.IsReadOnly = true;
                passportEdit.IsReadOnly = true;
                inputMessage.Content = "Вы можете изменять только телефон!";
                addButton.Visibility = Visibility.Hidden;
            }
            else
            {
                worker = new Manager(clients.Clients[chooseClient.SelectedIndex]);
                lastnameEdit.IsReadOnly = false;
                nameEdit.IsReadOnly = false;
                patronymicEdit.IsReadOnly = false;
                passportEdit.IsReadOnly = false;
                inputMessage.Content = "";
                addButton.Visibility = Visibility.Visible;
            }
            return worker;
        }

        private void FillClientComboBox()
        {            
            for (int i = 0; i < clients.Clients.Count; i++)
            {
                chooseClient.Items.Add(clients.Clients[i]);
            }
        }

        private void RefreshClientComboBox()
        {
            int index = chooseClient.SelectedIndex;
            chooseClient.Items[index] = clients.Clients[index];
            chooseClient.Items.Refresh();
            chooseClient.SelectedIndex = index;
        }
        private void chooseClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (chooseClient.SelectedIndex != -1)
                RefreshInfo();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (clients.Clients.Exists(c => c.Phone == phoneEdit.Text))
                MessageBox.Show("Клиент с таким номером уже есть в базе!", "Внимание", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            else if(clients.Clients.Exists(c => c.Passport == passportEdit.Text))
                MessageBox.Show("Клиент с таким паспортом уже есть в базе!", "Внимание", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            else if(phoneEdit.Text.Length < 11)
                MessageBox.Show("Неверно введен номер телефона!", "Внимание", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            else
            {
                clients.Add(new Client(
                    lastnameEdit.Text,
                    nameEdit.Text,
                    patronymicEdit.Text,
                    phoneEdit.Text,
                    passportEdit.Text));
                chooseClient.Items.Add(clients.Clients[clients.Clients.Count() - 1]);
                chooseClient.SelectedIndex = clients.Clients.Count() - 1;
                clients.Save();
            }
            
        }
    }
}
