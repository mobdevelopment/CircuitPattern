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
using System.ComponentModel;

namespace DesignPatterns1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window/*, INotifyPropertyChanged*/
    {
        FileReader reader;
        Circuit circuit;

        public MainWindow()
        {
            InitializeComponent();
            circuit = Circuit.Instance();
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true) {
                Console.WriteLine("MainWindow - OpenFile:: File can be read");
                reader = new FileReader(openFileDialog.FileName);
            }
            if (openFileDialog.FileName != "")
                loadNodeScreen();
        }

        private void ExitProgram(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        //public event PropertyChangedEventHandler PropertyChanged;

        //private string _circuitCheck;
        //public String CircuitCheck
        //{
        //    get { return _circuitCheck; }
        //    set
        //    {
        //        if (value != _circuitCheck)
        //        {
        //            _circuitCheck = value;
        //            OnPropertyChanged("CircuitCheck");
        //        }
        //    }
        //}



        // inhoud moet naar circuit
        private void StartCircuit(object sender, RoutedEventArgs e)
        {
            if (!(CircuitNodes != null))
            {
                Console.WriteLine("Laad eerst een circuit in");
            } else
            {
                Console.WriteLine("Start Circuit");
                circuit.startCircuit();
                Console.WriteLine("Circuit afgelopen");
            }
            Console.WriteLine("Start Circuit");

        }
        // alles moet naar circuit notifier
        private void loadNodeScreen()
        {
            DataContext = circuit;
            circuit.loadScreen();
        }

        //public ObserveableDictionary<String, Node> _CN { get; set; }
        // verplaatsen
        private Dictionary<String, Node> _circuitNodes;

        public Dictionary<String, Node> CircuitNodes
        {
            get
            {
                return this._circuitNodes;
            }
            set
            {
                this._circuitNodes = value;
            }

        }
    }
}
