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
    public partial class MainWindow : Window
    {
        FileReader reader;
        Circuit circuit;

        public MainWindow()
        {
            // initialize instances
            InitializeComponent();
            reader = FileReader.Instance();
            circuit = Circuit.Instance();
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            // check if there are nodes loaded
            if(CircuitNodes != null)
            {
                // CircuitNodes is filled with previous circuit. Clear old circuit data .
                CircuitNodes.Clear();
            }
            // file chooses
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true) {
                Console.WriteLine("MainWindow - OpenFile:: File can be read");
                reader.readCircuitFile(openFileDialog.FileName);
            }
            if (openFileDialog.FileName != "")
            {
                //loadNodeScreen();
                if(reader.getNodes() != null)
                {
                    // set nodes from the file reader
                    CircuitNodes = reader.getNodes();
                }
            }
        }

        private void ExitProgram(object sender, RoutedEventArgs e)
        {
            // exit the application
            Application.Current.Shutdown();
        }

        private void StartCircuit(object sender, RoutedEventArgs e)
        {
            // check to see if an circuit is loaded
            if (CircuitNodes == null)
            {
                Console.WriteLine("Laad eerst een circuit in");
            }
            else
            {
                //start circuit if circuit is runnable
                if (circuit.ValidCircuit)
                {
                    Console.WriteLine("Start Circuit");
                    // ask for Input nodes inputs
                    circuit.inputValue();
                    // run circuit
                    circuit.startCircuit();
                    Console.WriteLine("Circuit afgelopen");
                }
                else
                {
                    Console.WriteLine("This circuit can't run, it contains an error!");
                }
            }
        }
        // method is outdated
        private void loadNodeScreen()
        {
            //load the screen with data
            DataContext = circuit;
            circuit.loadScreen();
        }

        private Dictionary<String, Node> _circuitNodes;
        // collection of nodes
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
