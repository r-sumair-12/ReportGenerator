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
using System.IO;


namespace ReportGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameBox.Text;
            string fname = FnameBox.Text;
            string phone = PhoneBox.Text;
            string gender = (GenderBox.SelectedItem as ComboBoxItem).Content.ToString();

            if (name.Equals("") || fname.Equals("") || phone.Equals("") || 
                gender.Equals("") || gender.Equals("Select Gender"))
            {
                MessageBox.Show("Please fill all details", "Invalid details", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            string path = @"E:\Report.csv";
            string data = name + "," + fname + "," + gender + "," + phone+"\n";

            try
            {
                File.AppendAllText(path, data);
                NameBox.Text = "";
                FnameBox.Text = "";
                PhoneBox.Text = "";
                GenderBox.SelectedIndex = 0;
                MessageBox.Show("Data generate in file!", "Data generated", MessageBoxButton.OK,
                        MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "File Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

        }
    }
}
