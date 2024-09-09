using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
using System.Xml.Linq;

namespace WpfApp11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Lego> legos = new List<Lego>();

        private void LoadPage(string file)
        {
            XDocument xaml = XDocument.Load(file);
            foreach (var elem in xaml.Descendants("Item"))
            {
                string itemID = elem.Element("ItemID").Value;
                string itemName = elem.Element("ItemName").Value;
                string categoryName = elem.Element("CategoryName").Value;
                string colorName = elem.Element("ColorName").Value;
                int qty = int.Parse(elem.Element("Qty").Value);

                legos.Add(new Lego(itemID, itemName, categoryName, colorName, qty));
            } 

            dg_Legos.ItemsSource = legos; 
            cb_cat.ItemsSource = legos.Select(x=> x.CategoryName).Distinct().ToList();
            cb_color.ItemsSource = legos.Select(x => x.ColorName).Distinct().ToList();
            lbl_pieces.Content = $"Darabok száma: {legos.Count}";
        }

        private void FileSelect()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                LoadPage(openFileDialog.FileName);
            }
            else
            {
                MessageBox.Show("Hibás fájlmegadás");
            }
        }

        public MainWindow()
        {
            InitializeComponent(); 
        }

        private void SearchData()
        {
            dg_Legos.ItemsSource = legos.Where(x => x.ItemID.ToLower().StartsWith(tb_id.Text.ToLower()) && x.ItemName.ToLower().StartsWith(tb_name.Text.ToLower()) && x.CategoryName == cb_cat.Text && x.ColorName == cb_color.Text);
           
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            //Az Id magasabb prioritású mint a név, mivel az pontosabb
            if (tb_id.Text != "" || tb_name.Text != "" || cb_cat.Text != "")
            { 
                SearchData();
            }
            else
            { 
                dg_Legos.ItemsSource = legos;
            }
            lbl_pieces.Content = $"Darabok száma: {dg_Legos.Items.Count}";
        }

        private void btn_load_Click(object sender, RoutedEventArgs e)
        {
            FileSelect();
        }

        private void btn_cat_Click(object sender, RoutedEventArgs e)
        {
            cb_cat.Text = "";
            SearchData();
        }

        private void btn_color_Click(object sender, RoutedEventArgs e)
        {
            cb_color.Text = "";
            SearchData();
        }
    }
}
