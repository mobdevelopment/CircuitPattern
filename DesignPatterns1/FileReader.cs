using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    public class FileReader
    {
        public FileReader(String fileName)
        {
            List<String> circuit;
            try
            {
                using (StreamReader file = new StreamReader(fileName))
                {
                    // Read and display lines from the file until the end of the file is reached.
                    string line;
                    bool connectNode = false;
                    while ((line = file.ReadLine()) != null)
                    {
                        string thing = "";
                        if (!connectNode)
                        {
                            thing = "Node";
                            if (!line.StartsWith("#") && line != String.Empty)
                            {
                                // Get node name
                                string nodeName = getNodeName(line);
                                // Get Node type beginning and ending
                                string nodeType = getNodeType(line);
                            }
                            else if (line == String.Empty)
                            {
                                connectNode = true;
                            }
                        }
                        else
                        {// start connecting nodes
                            thing = "Connection";

                            // Get node name
                            string nodeName = getNodeName(line);
                            // Get node connections
                            string[] nodeConnections = getNodeConnections(line);
                        }
                        // add node array to circuit array (String name, String type, array connections

                    } // end while
                    file.Close();
                    Console.Write("END READING FILE");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
            finally
            {
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
    }
}
