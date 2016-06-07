using System;
using System.Collections.Generic;
using System.IO;
using DesignPatterns1.Nodes;
using System.ComponentModel;

namespace DesignPatterns1
{
    public class FileReader : INotifyPropertyChanged
    {
        Circuit circuit;
        // VALIDATE METHOD
        private Dictionary<String, Node> nodeMap = new Dictionary<String, Node>();

        public FileReader(String fileName)
        {
            try
            {
                using (StreamReader file = new StreamReader(fileName))
                {
                    // Read and display lines from the file until the end of the file is reached.
                    string line;
                    bool connectNode = false;
                    int i = 0;
                    while ((line = file.ReadLine()) != null)
                    {
                        Console.WriteLine(i + ":: " +line);
                        i++;
                        if (!connectNode)
                        {
                            if (!line.StartsWith("#") && line != String.Empty)
                            {
                                // Get node name
                                string nodeName = getNodeName(line);
                                // Get Node type
                                string nodeType = getNodeType(line);
                                nodeMap.Add(nodeName, Node.create(nodeType));
                            }
                            else if (line == String.Empty)
                            {
                                connectNode = true;
                            }
                        }
                        else
                        {// start connecting nodes
                            if (!line.StartsWith("#") && line != String.Empty)
                            {
                                // Get node name
                                string nodeName = getNodeName(line);
                                // Get node connections
                                setNodeConnections(line);
                                string[] nodeConnections = getNodeConnections();
                                List<Node> nodes = new List<Node>();
                                foreach (string connection in nodeConnections)
                                {
                                    nodes.Add(nodeMap[connection]);
                                }
                                nodeMap[nodeName].addNexts(nodes);
                            }
                        }
                    } // end while
                    file.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Could not read file from disk. Original error: " + ex.Message);
            }
            finally
            {
                circuit = new Circuit(getNodes());
                bool a = circuit.validateCircuit();
            }
        }

        private String getNodeName(string line)
        {
            string nodeName = "";

            int nodeNameEnd = line.IndexOf(":");
            if (nodeNameEnd > 0)
            {
                nodeName = line.Substring(0, nodeNameEnd);
            }
            return nodeName;
        }

        private String getNodeType(string line)
        {
            string nodeType = "";

            int nodeTypeStart = line.LastIndexOf("	");
            int nodeTypeEnd = line.IndexOf(";");
            if (nodeTypeStart > 0)
            {
                nodeType = line.Substring(nodeTypeStart + 1, nodeTypeEnd - (nodeTypeStart + 1));
            }
            return nodeType;
        }

        private void setNodeConnections(string line)
        {
            string[] nodeConnections;
            int nodeConnectStart = line.LastIndexOf("	");
            int nodeConnectEnd = line.IndexOf(";");

            if (nodeConnectStart > 0)
            {
                string nodeConnectAll = line.Substring(nodeConnectStart + 1, nodeConnectEnd - (nodeConnectStart + 1));
                
                if (nodeConnectAll.Contains(","))
                {
                    // Node has multiple connections
                    nodeConnections = nodeConnectAll.Split(',');
                    nodeConn = nodeConnections;
                }
                else
                {
                    // Node has single connection
                    nodeConnections = new string[1];
                    nodeConnections[0] = nodeConnectAll;
                    nodeConn = nodeConnections;
                }
            }
        }

        public Dictionary<String, Node> getNodes()
        {
            return nodeMap;
        }

        string[] nodeConn;

        public event PropertyChangedEventHandler PropertyChanged;

        public String[] getNodeConnections()
        {
            return nodeConn;
        }
    }
}
