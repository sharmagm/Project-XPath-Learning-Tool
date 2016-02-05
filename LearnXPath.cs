#region About
/*
 <fileinfo>
	<file name="LearnXPath.cs"></file>
	<namespace name="XMLAssignment1">
	<class name="LearnXPath">
	<revisions>
		<created date="10/15/2015" author="Garima Sharma">It helps a user to learn about XPaths by dynamically generating majority of possible XPaths for any XML file chosen using Recursions.</created>
		<changed date="" author=""></changed>
	</revisions>
	</class>
	</namespace>
 </fileinfo>
*/
#endregion About

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace XMLAssignment1
{
    /// <summary>
    /// It helps a user to learn about XPaths by dynamically generating majority of possible XPaths for any XML file chosen using Recursions.
    /// </summary>
    public partial class LearnXPath : Form
    {
        #region Private Variables
        private List<string> xPathList = new List<string>();
        private List<string> xPathFinalList = new List<string>();
        #endregion

        #region Public Methods
        /// <summary>
        /// Intializes components like textboxes, file upload controls and comboboxes.
        /// </summary>
        public LearnXPath()
        {
            InitializeComponent();
            this.Text = "XML to XPath Navigator";
            comboBoxXPath.DataSource = xPathFinalList;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Browse an XML File to generate XPaths.
        /// </summary>
        private void BrowseFile(object sender, EventArgs e)
        {
            DialogResult result;
            try
            {
                result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    textBoxFileUpload.Text = openFileDialog.FileName;
                    textBoxFileContent.Text = string.Empty;
                    textBoxXPathResult.Text = string.Empty;
                    comboBoxXPath.DataSource = null;
                    comboBoxXPath.Items.Clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// This method reads an XML file, find all the child and sibling nodes, 
        /// dynamically generates XPaths from it and provides xml node corresponding to first xpath.
        /// </summary>
        private void ReadXMLGenerateXPath(object sender, EventArgs e)
        { 
            XmlDocument xDoc = null;
            List<string> xPathDistinctList = null;
            XmlElement rootElement;
            string rootElementName = string.Empty;
            XmlNode childNode;
            XmlReader rdr;
            
            xPathFinalList = new List<string>();
            xPathList = new List<string>();
            try
            {
                if (textBoxFileUpload.Text != "")
                {
                    xDoc = new XmlDocument();
                    xDoc.Load(textBoxFileUpload.Text);
                    textBoxFileContent.Text = xDoc.OuterXml;
                    xPathDistinctList = new List<string>();
                    rootElement = xDoc.DocumentElement;
                    rootElementName = "/" + rootElement.Name;
                    childNode = xDoc.DocumentElement.FirstChild.FirstChild;
                    rdr = XmlReader.Create(new System.IO.StringReader(textBoxFileContent.Text));
                    textBoxXPathResult.Text = "";

                    while (rdr.Read())
                    {
                        if (rdr.NodeType == XmlNodeType.Element)
                        {
                            XmlNode node = xDoc.ReadNode(rdr);
                            FindNodes(node);

                            xPathDistinctList = xPathList.Distinct().ToList();
                            xPathFinalList.Add(rootElementName + "/*");

                            foreach (string distinctXPath in xPathDistinctList)
                            {
                                xPathFinalList.Add(rootElementName + distinctXPath);
                            }

                            xPathFinalList.Sort();
                            comboBoxXPath.DataSource = null;
                            comboBoxXPath.Items.Clear();
                            comboBoxXPath.DataSource = xPathFinalList;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please browse a file.");
                }
            }
            catch(XmlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch(ArgumentNullException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch(NullReferenceException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                xDoc = null;
                rootElementName = null;
            }
        }

        /// <summary>
        /// This method generates XPaths for the provided XML node.
        /// </summary>
        /// <param name="element"></param>
        private void FindNodes(XmlNode element)
        {
            string xPathVal = string.Empty;
            try
            {
                if (!element.HasChildNodes)
                {
                    xPathVal = FindXPath(element);
                    findXPathTemp(xPathVal);
                    removePredicates(xPathVal, element);
                }
                else
                {
                    foreach (XmlNode x in element.ChildNodes)
                    {
                        xPathVal = FindXPath(x);
                        findXPathTemp(xPathVal);
                        removePredicates(xPathVal, x);
                        FindNodes(x);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                xPathVal = null;
            }
        }
        
        /// <summary>
        /// It generates all the possible XPaths throuh Recursion.
        /// </summary>
        /// <param name="node">XML node</param>
        /// <returns>XPath</returns>
        private string FindXPath(XmlNode node)
        {
            int iIndex = 1;
            XmlNode xnIndex = node;
            if (node.NodeType == XmlNodeType.Attribute)
            {          
                return String.Format("{0}/@{1}", FindXPath(((XmlAttribute)node).OwnerElement), node.Name);
            }

            if (node.ParentNode == null)
            {
                return "";
            }
            
            while (xnIndex.PreviousSibling != null && xnIndex.PreviousSibling.Name == xnIndex.Name)
            {
                iIndex++;
                xnIndex = xnIndex.PreviousSibling;
            }         

            return String.Format("{0}/{1}[{2}]", FindXPath(node.ParentNode), node.Name, iIndex);
        } 

        /// <summary>
        /// It removes unwanted text from the XPath.
        /// </summary>
        /// <param name="xPathVal">XPath created</param>
        private void findXPathTemp(string xPathVal)
        {
            string xPathTemp = string.Empty;
            xPathTemp = xPathVal;
            if (xPathTemp.Contains("/#text"))
            {
                xPathTemp = xPathTemp.Replace("/#text", "");
            }

            if (xPathTemp.Contains("]["))
            {
                xPathTemp = xPathTemp.Substring(xPathTemp.Length - 3);
            }

            xPathList.Add(xPathTemp);
        }

        /// <summary>
        /// It removes unnecessary predicates added to XPath to form most desirable XPath possibe providing the same result. 
        /// </summary>
        /// <param name="xPath">XPath with undesirable predicates</param>
        /// <param name="element">Child node for which undesirable XPath is created</param>
        private void removePredicates(string xPath, XmlNode element)
        {
            try
            {
                if (xPath.Contains("["))
                {
                    int firstChar = xPath.LastIndexOf('[');
                    int lastChar = xPath.LastIndexOf(']');
                    xPath = xPath.Remove(firstChar, (lastChar - firstChar + 1));
                    removePredicates(xPath, element);
                }
                else
                {
                    if (xPath.Contains("/#text"))
                    {
                        xPath = xPath.Replace("/#text", "");
                    }
                    else
                    {
                        addAttributeToXPath(xPath, element);
                    }

                    xPathList.Add(xPath);
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            
        }
        
        /// <summary>
        /// It add attributes to XPaths wherever necessary to promote better XPath creation and hence better learning.
        /// </summary>
        /// <param name="xPath">XPath to which attributes are added</param>
        /// <param name="node">XML node for which XPath is created</param> 
        private void addAttributeToXPath(string xPath, XmlNode node)
        {
            XmlAttributeCollection attCollection;
            String xPathInitial = string.Empty;
            String xPathComplete = xPath;
            try
            {
                attCollection = node.Attributes;
                foreach (XmlAttribute attribute in attCollection)
                {
                    xPathInitial = xPath;
                    xPathComplete = xPathInitial + "[@" + attribute.Name + "]";
                    xPathList.Add(xPathInitial + "[@" + attribute.Name + "='" + attribute.Value + "']");
                }
                xPathList.Add(xPathComplete);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                xPathInitial = null;
                xPathComplete = null;
            }
        }
        
        /// <summary>
        /// When the user selects XPaths from the drop down,
        /// it displays the resulting XML node.
        /// </summary>
        private void DisplayXNodeForSelectedXPath(object sender, EventArgs e)
        {
            XPathDocument document = null;
            XPathNavigator navigator = null;
            XPathNodeIterator nodes = null;
            try
            {
                if (textBoxFileUpload.Text != null || textBoxFileUpload.Text != "")
                {
                    document = new XPathDocument(textBoxFileUpload.Text);
                    navigator = document.CreateNavigator();
                    if (comboBoxXPath.SelectedItem != null)
                    {
                        nodes = navigator.Select(comboBoxXPath.SelectedItem.ToString());
                        textBoxXPathResult.Text = string.Empty;
                        while (nodes.MoveNext())
                        {
                            textBoxXPathResult.Text = textBoxXPathResult.Text + nodes.Current.OuterXml + Environment.NewLine;
                        }
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                document = null;
                navigator = null;
                nodes = null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxXPath.DataSource = xPathFinalList;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBoxXPathResult.Multiline = true;
            textBoxXPathResult.ScrollBars = ScrollBars.Vertical;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBoxFileContent.Multiline = true;
            textBoxFileContent.ScrollBars = ScrollBars.Vertical;
        }
        #endregion
    }
}
