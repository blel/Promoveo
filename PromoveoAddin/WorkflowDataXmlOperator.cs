using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace ServiceClient
{
    public class WorkflowDataXmlOperator
    {
       
        private XmlDocument  _mainXml;
        private XmlNamespaceManager _namespaceManager;

        public WorkflowDataXmlOperator(XmlDocument mainXml)
        {
            _mainXml = mainXml;
            _namespaceManager = GetDefaultNamespace();

        }

        public WorkflowDataXmlOperator(System.Xml.Linq.XElement mainXml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(mainXml.ToString());
            _mainXml = doc;
            _namespaceManager = GetDefaultNamespace();
        }

        public WorkflowDataXmlOperator(XmlElement mainXml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(mainXml.OuterXml);
            _mainXml = doc;
            _namespaceManager = GetDefaultNamespace();
        }

        public WorkflowDataXmlOperator(string mainXml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(mainXml);
            _mainXml = doc;
            _namespaceManager = GetDefaultNamespace();
            
        }

        private XmlNamespaceManager GetDefaultNamespace()
        {
            XmlNamespaceManager namespaceMng = new XmlNamespaceManager(_mainXml.NameTable);
            namespaceMng.AddNamespace("x",_mainXml.DocumentElement.NamespaceURI);
            return namespaceMng;
        }

        private string GetGuid(string workflowName)
        {
            XmlNode node = _mainXml.SelectSingleNode("//x:WorkflowTemplate[@Name=\"" + workflowName + "\"]/x:WorkflowTemplateIdSet", _namespaceManager);
            XmlAttribute attribute = node.Attributes["TemplateId"];
            return attribute.InnerText;
        }

        public Guid GetWorkflowGuid(string workflowName)
        {
            return new Guid(GetGuid(workflowName));
        }

        public XmlElement GetWorkflowParameters(string workflowName)
        {
            XmlNode node = _mainXml.SelectSingleNode("//x:WorkflowTemplate[@Name=\"" + workflowName + "\"]/x:AssociationData/x:string", _namespaceManager);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(node.InnerText);
            return doc.DocumentElement;
        }

        public System.Xml.Linq.XElement GetWorkflowParametersX(string workflowName)
        {
            return  System.Xml.Linq.XElement.Parse(workflowName);
        
        }

        public string GetElementByXPath(string xPath)
        {
            return _mainXml.SelectSingleNode(xPath, _namespaceManager).Name;
        }

        public XmlElement StringToXmlElement(string xmlString)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);
            return doc.DocumentElement;
        }

        public string AddUser(Person user, string workflowName)
        {
            XmlElement workflowParameterElement = GetWorkflowParameters(workflowName);
            XmlDocument workflowParameterDocument = new XmlDocument();
            workflowParameterDocument.LoadXml(workflowParameterElement.OuterXml);
            XmlNamespaceManager mngr = new XmlNamespaceManager(workflowParameterDocument.NameTable);
            mngr.AddNamespace("d", "http://schemas.microsoft.com/office/infopath/2009/WSSList/dataFields");
            XmlNode assigneeNode = workflowParameterElement.SelectSingleNode("//d:Assignee", mngr);
                        
            XmlSerializer serialiser = new XmlSerializer(typeof(Person));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("pc", "http://schemas.microsoft.com/office/infopath/2007/PartnerControls");
            
            StringBuilder builder = new StringBuilder();
            using (StringWriter writer = new StringWriter(builder))
            {
                serialiser.Serialize(writer, user,namespaces);
            }
            XmlDocument newUserDocument = new XmlDocument();
            newUserDocument.LoadXml(builder.ToString());
            XmlNamespaceManager mngr1 = new XmlNamespaceManager(newUserDocument.NameTable);
            mngr1.AddNamespace("pc", "http://schemas.microsoft.com/office/infopath/2007/PartnerControls");
            XmlNode importedNode = assigneeNode.OwnerDocument.ImportNode(newUserDocument.SelectSingleNode("/pc:Person",mngr1), true);

            assigneeNode.AppendChild(importedNode);
            

            return assigneeNode.OwnerDocument.OuterXml ;
        }

        public XmlElement AddUsers(List<Person> users, XmlElement workflowParameters)
        {
            //get the Assignee node
            XmlNamespaceManager mngr = new XmlNamespaceManager(workflowParameters.OwnerDocument.NameTable);
            mngr.AddNamespace("d", "http://schemas.microsoft.com/office/infopath/2009/WSSList/dataFields");
            XmlNode assigneeNode = workflowParameters.SelectSingleNode("//d:Assignee", mngr);

            //setup the xml serializer
            XmlSerializer serialiser = new XmlSerializer(typeof(Person));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("pc", "http://schemas.microsoft.com/office/infopath/2007/PartnerControls");
            if (users != null)
            {
                foreach (Person user in users)
                {
                    StringBuilder builder = new StringBuilder();
                    using (StringWriter writer = new StringWriter(builder))
                    {
                        serialiser.Serialize(writer, user, namespaces);
                    }
                    XmlDocument newUserDocument = new XmlDocument();
                    newUserDocument.LoadXml(builder.ToString());
                    XmlNamespaceManager mngr1 = new XmlNamespaceManager(newUserDocument.NameTable);
                    mngr1.AddNamespace("pc", "http://schemas.microsoft.com/office/infopath/2007/PartnerControls");
                    XmlNode importedNode = assigneeNode.OwnerDocument.ImportNode(newUserDocument.SelectSingleNode("/pc:Person", mngr1), true);
                    assigneeNode.AppendChild(importedNode);
                }
            }
            return assigneeNode.OwnerDocument.DocumentElement;
        }
    }
}
