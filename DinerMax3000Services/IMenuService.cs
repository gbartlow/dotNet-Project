using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DinerMax3000Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMenuService" in both code and config file together.
    [ServiceContract]
    public interface IMenuService
    {
        [OperationContract]
        DinerMax3000Menus GetMenus(); 
    }

    [DataContract]
    public class DinerMax3000Menus
    {
        [DataMember]
        public DinerMax3000.Business.Menu[] Menus { get; set; }
    }
}
