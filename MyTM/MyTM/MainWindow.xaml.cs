using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MyTM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private Hashtable hashtable = new Hashtable();
        public MainWindow()
        {
            ObservableCollection<Group> TreeDatas = new ObservableCollection<Group>()
            {
                new Group() {
                    Name = "MainPage",
                    Key = "MainPage",
                    Kind = "HomeCircleOutline",
                },
            
                new Group()
                {
                    Name = "TestStation",
                    Key = "TestStation",
                    Kind = "Sitemap",
                    Children = new ObservableCollection<Item>()
                    {
                        new Item()
                        {
                            Name = "NFBP",
                            Key = "NFBP",
                            Kind = "AlphaNCircleOutline",
                        },
                         new Item()
                        {
                            Name = "KYROL",
                            Key = "KYROL",
                            Kind = "AlphaKCircleOutline",
                        }
                    }
                },
                new Group()
                {
                    Name = "Setting",
                    Key = "Setting",
                    Kind = "Cog",
                    Children = new ObservableCollection<Item>()
                    {
                        new Item()
                        {
                            Name = "SysConfig",
                            Key = "SysConfig",
                            Kind = "FileCog",

                        },
                         new Item()
                        {
                            Name = "Account",
                            Key = "Account",
                            Kind = "AccountCog",
                        }
                    }
                }

            };
            InitializeComponent();
            DataContext = TreeDatas;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;

        }

        private void Max_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;

            }
        }


        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    
        private void navigationTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

            if (sender is TreeView)
            {
                var select = (sender as TreeView).SelectedItem;
                if (select is Group)
                {
                    CreatPages((select as Group).Key);
                }
                else if (select is Item)
                {
                    CreatPages((select as Item).Key);
                }
            }
           
        }

        private void CreatPages(string sKey)
        {
            if (string.IsNullOrEmpty(sKey))
            {
                return;
            }

            BasePage? page = null;
            if (hashtable.Contains(sKey))
            {
                page = hashtable[sKey] as BasePage;
            }
            else 
            {
                switch (sKey)
                {
                    case "MainPage":
                        page = new MainPage();
                        hashtable.Add(sKey, page);
                        break;
                    default:
                        page = new DefaultPage();
                        hashtable.Add(sKey, page);
                        break;
                }
               
            }

            if (page != null)
            {
                this.content.Children.Clear();
                this.content.Children.Add(page);
            }
        }

          
}

}
