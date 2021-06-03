using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace WCFExtensibilityLib
{
    public class ServerSideMessageInspector : IDispatchMessageInspector
    {
        
        public object AfterReceiveRequest(ref Message request, 
            IClientChannel channel, InstanceContext instanceContext)
        {
            int requestNumber = new Random().Next(1, 100);
            System.IO.StreamWriter wr = new System.IO.StreamWriter("servicemessagelog.txt",true);
            wr.WriteLine($"********************{requestNumber}*********************");
            wr.WriteLine(request.ToString());
            wr.Flush();
            wr.Close();
            return requestNumber;

        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            System.IO.StreamWriter wr = new System.IO.StreamWriter("servicemessagelog.txt",true);
            wr.WriteLine($"***************Reply For : {correlationState}*********************");
            wr.WriteLine(reply.ToString());
            wr.Flush();
            wr.Close();
        }
    }

    public class MessageInpectionEndpointBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            ServerSideMessageInspector _messageInspector = new ServerSideMessageInspector();
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(_messageInspector);
        }

        public void Validate(ServiceEndpoint endpoint)
        {
            
        }
    }

    public class MessageInspectionEndpointBehaviorExtensionElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get
            {
                return typeof(MessageInpectionEndpointBehavior);
            }
        }
        protected override object CreateBehavior()
        {
            return new MessageInpectionEndpointBehavior();
        }
    }
}
