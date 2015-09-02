using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DinerMax3000Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MenuService" in both code and config file together.
    public class MenuService : IMenuService
    {
        public DinerMax3000Menus GetMenus()
        {
            DinerMax3000Menus menus = new DinerMax3000Menus();
            menus.Menus = DinerMax3000.Business.Menu.GetAllMenus().ToArray();
            return menus; 
        }
    }
}
