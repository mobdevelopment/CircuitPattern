using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns1.Nodes;

namespace DesignPatterns1
{
    public class FileReader
    {
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
                    while ((line = file.ReadLine()) != null)
                    {
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
                            // Get node name
                            string nodeName = getNodeName(line);
                            // Get node connections
                            string[] nodeConnections = getNodeConnections(line);
                            List<Node> nodes = new List<Node>();
                            foreach (string connection in nodeConnections)
                            {
                                nodes.Add(nodeMap[connection]);
                            }
                            nodeMap[nodeName].addNexts(nodes);
                        }
                    } // end while
                    file.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Could not read file from disk. Original error: " + ex.Message);
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

            int nodeTypeStart = line.IndexOf("	");
            int nodeTypeEnd = line.IndexOf(";");
            if (nodeTypeStart > 0)
            {
                nodeType = line.Substring(nodeTypeStart + 1, nodeTypeEnd - (nodeTypeStart + 1));
            }
            return nodeType;
        }

        private String[] getNodeConnections(string line)
        {
            int nodeConnectStart = line.IndexOf("	");
            int nodeConnectEnd = line.IndexOf(";");

            //if (nodeConnectStart > 0)
            //{
                string nodeConnectAll = line.Substring(nodeConnectStart + 1, nodeConnectEnd - (nodeConnectStart + 1));
                string[] nodeConnections;
                if (nodeConnectAll.Contains(","))
                {
                    // Node has multiple connections
                    nodeConnections = nodeConnectAll.Split(',');
                    return nodeConnections;
                }
                else
                {
                    // Node has single connection
                    nodeConnections = new string[1];
                    nodeConnections[0] = nodeConnectAll;
                    return nodeConnections;
                }
            //}
            //return ;
        }

        public Dictionary<String, Node>getNodes()
        {
            return nodeMap;
        }

        private Boolean ValidateCircuit()
        {
            return true : false;
        }
    }
}
