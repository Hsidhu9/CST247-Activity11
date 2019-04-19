using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HelloWorldService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]

        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "SayHello/")]

        string SayHello();

        [OperationContract]

        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetData/{value}")]

        string GetData(string value);

        [OperationContract]

        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetObjectModel/{id}")]

        CompositeType GetObjectModel(string id);



        //private string GetData(string value)
        //{
        //    throw new NotImplementedException();
        //}

        //public CompositeType GetObjectModel(string id)
        //{
        //    throw new NotImplementedException();
        //}

        //public string SayHello()
        //{
        //    throw new NotImplementedException();
        //}

        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        //// TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
