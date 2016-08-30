using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WcfServices_AlibabaShop.exception
{
    [DataContract]
    public class AlibabaShopFaultedException
    {
        [DataMember]
        public string message { get; set; }
        [DataMember]
        public string errorCode { get; set; }
    }
}
