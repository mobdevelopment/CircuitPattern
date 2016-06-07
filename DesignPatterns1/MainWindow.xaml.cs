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
using Microsoft.Win32;
using DesignPatterns1.Nodes;

namespace DesignPatterns1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileReader reader;
        //Dictionary<String, Node> nodeMap;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true) {
                Console.WriteLine("MainWindow - OpenFile:: File can be read");
                reader = new FileReader(openFileDialog.FileName);
            }

            loadNodeScreen();
        }

        private void ExitProgram(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void StartCircuit(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine((sender as MenuItem).Header.ToString());
            if (!(CircuitNodes.Count() > 0))
            {
                Console.WriteLine("Laad eerst een circuit in");
            } else
            {
                Console.WriteLine("Start Circuit");
                foreach (Node startPoint in CircuitNodes.Values)
                {
                    Type t = typeof(Input);
                    if (!(startPoint is Input)) continue;

                    Console.WriteLine(startPoint.getKey());
                }
                Console.WriteLine("Circuit afgelopen");
            }
        }

        private void loadNodeScreen()
        {
            circuitNodes = reader.getNodes();

            foreach (KeyValuePair<string, Node> node in CircuitNodes)
            {
                Console.WriteLine(node.Key);
            }
            DataContext = this;
        }

        //public ObserveableDictionary<String, Node> _CN { get; set; }

        Dictionary<String, Node> circuitNodes;

        public Dictionary<String, Node> CircuitNodes
        {
            get { return this.circuitNodes; }

        }
    }
}
