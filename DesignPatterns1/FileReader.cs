using System;
using System.Collections.Generic;
using System.IO;
using DesignPatterns1.Nodes;
using System.ComponentModel;

namespace DesignPatterns1
{
    public class FileReader
    {
        //FileReader reader;
        Circuit circuit;
        // VALIDATE METHOD
        private Dictionary<String, Node> nodeMap = new Dictionary<String, Node>();

        private static FileReader instance;
        public static FileReader Instance()
        {
            if (instance == null)
                instance = new FileReader();

            return instance;
        }

        private FileReader()
        {
        }

        public void readCircuitFile(String fileName)
        {
            if(nodeMap.Count > 0)
            {
                nodeMap.Clear();
            }
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
                        // Print file line content
                        //Console.WriteLine(i + ":: " + line);
                        i++;
                        if (!connectNode)
                        {
                            if (!line.StartsWith("#") && line != String.Empty)
                            {
                                // Get node name
                                string nodeName = getNodeName(line);
                                // Get Node type
                                string nodeType = getNodeType(line);
                                // create node in factory and add to dictionary
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
                circuit = Circuit.Instance();
                //if (circuit.Nodes != null)
                //{
                //    // circuit.Nodes is filled with previous circuit. Clear old circuit data.
                //    circuit.Nodes.Clear();
                //}
                circuit.Nodes = getNodes();
                circuit.ValidCircuit = circuit.validateCircuit();
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

        public String[] getNodeConnections()
        {
            return nodeConn;
        }

        public Dictionary<String, Node> getNodes()
        {
            return nodeMap;
        }

        string[] nodeConn;

        //public event PropertyChangedEventHandler PropertyChanged;

    }
}
