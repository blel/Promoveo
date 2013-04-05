using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;


namespace ServiceClient

{
    public class WorkflowCommunicator
    {
        private WorkflowSoapClient _client;
        
        public string WorkflowName { get; set; }
        public WorkflowSoapClient WorkflowClient { get { return _client; } }

        public WorkflowCommunicator(string workflowAddress, string workflowName)
        {
            WorkflowName = workflowName;
            PromoveoAddin.ServiceClient.BasicHttpBindingFactory basicHttpBindingFactory = new PromoveoAddin.ServiceClient.BasicHttpBindingFactory();
            Binding testBinding = basicHttpBindingFactory.CreateBinding();
            //BasicHttpBinding binding = new BasicHttpBinding();
            //binding.CloseTimeout = new TimeSpan(0, 1, 0);
            //binding.OpenTimeout = new TimeSpan(0, 1, 0);
            //binding.ReceiveTimeout = new TimeSpan(0, 10, 0);
            //binding.SendTimeout = new TimeSpan(0, 1, 0);
            //binding.AllowCookies = false;
            //binding.BypassProxyOnLocal = false;
            //binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            //binding.MaxBufferPoolSize = 524288;
            //binding.MaxBufferSize = 65536;
            //binding.MaxReceivedMessageSize = 65536;
            //binding.TextEncoding = Encoding.UTF8;
            //binding.TransferMode = TransferMode.Buffered;
            //binding.UseDefaultWebProxy = true;
            //binding.MessageEncoding = WSMessageEncoding.Text;

            //System.Xml.XmlDictionaryReaderQuotas readerQuotas = new System.Xml.XmlDictionaryReaderQuotas();
            //readerQuotas.MaxDepth = 32;
            //readerQuotas.MaxStringContentLength = 8192;
            //readerQuotas.MaxArrayLength = 16384;
            //readerQuotas.MaxBytesPerRead = 4096;
            //readerQuotas.MaxNameTableCharCount = 16384;
            //binding.ReaderQuotas = readerQuotas;
            
            //BasicHttpSecurity security = new BasicHttpSecurity();
            //security.Mode = BasicHttpSecurityMode.Transport;
            
            //HttpTransportSecurity transportSecurity = new HttpTransportSecurity();
            //transportSecurity.ClientCredentialType = HttpClientCredentialType.Ntlm;
            //transportSecurity.ProxyCredentialType = HttpProxyCredentialType.None;
            //security.Transport = transportSecurity;

            //BasicHttpMessageSecurity messageSecurity = new BasicHttpMessageSecurity();
            //messageSecurity.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
            //messageSecurity.AlgorithmSuite = System.ServiceModel.Security.SecurityAlgorithmSuite.Default;
            //security.Message = messageSecurity;

            //binding.Security = security;

            EndpointAddress address = new EndpointAddress(workflowAddress);
             _client = new WorkflowSoapClient(testBinding, address);
        }

        public XmlElement StartSPDefaultApprovalWorkflow(string item, List<Person> assignees)
        {
            XmlElement workflowData = WorkflowClient.GetWorkflowDataForItem(item);
            WorkflowDataXmlOperator xmlOperator = new WorkflowDataXmlOperator(workflowData);
            Guid workflowguid = xmlOperator.GetWorkflowGuid(WorkflowName);
            XmlElement workflowParameter = xmlOperator.GetWorkflowParameters(WorkflowName);
            workflowParameter = xmlOperator.AddUsers(assignees, workflowParameter);
            return WorkflowClient.StartWorkflow(item, workflowguid, workflowParameter);
        }
    }
}
