using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinerMax3000.Business.dsDinerMax3000TableAdapters; 

namespace DinerMax3000.Business
{
    public class Menu
    {
        public string Name { get; set; }
        public List<MenuItem> Items { get; set; }

        public int DatabaseId
        {
            get
            {
                return _databaseId;
            }

            set
            {
                _databaseId = value;
            }
        }

        private int _databaseId; 

        public Menu()
        {
            Items = new List<MenuItem>(); 

        }

        public static List<Menu> GetAllMenus()
        {
            MenuTableAdapter taMenu = new MenuTableAdapter();
            var dtMenu = taMenu.GetData();
            List<Menu> allMenus = new List<Menu>();
            MenuItemTableAdapter taMenuItem = new MenuItemTableAdapter(); 

            foreach(dsDinerMax3000.MenuRow menuRow in dtMenu.Rows)
            {
                Menu currentMenu = new Menu();
                currentMenu.Name = menuRow.Name;
                currentMenu.DatabaseId = menuRow.Id; 
                allMenus.Add(currentMenu);

                var dtMenuItems = taMenuItem.GetMenuItemsByMenuId(menuRow.Id); 
                foreach(dsDinerMax3000.MenuItemRow menuItemRow in dtMenuItems.Rows)
                {
                    currentMenu.AddMenuItem(menuItemRow.Name, menuItemRow.Description, menuItemRow.Price); 
                }
            }
            return allMenus; 
        }

        public void SaveNewMenuItem(string Name, string Description, double Price)
        {
            MenuItemTableAdapter taMenuItem = new MenuItemTableAdapter();
            taMenuItem.InsertNewMenuItem(Name, Description, Price, DatabaseId); 
        }

        public void AddMenuItem(string Title, string Description, double Price)
        {
            MenuItem m = new MenuItem();
            m.Title = Title;
            m.Description = Description;
            m.Price = Price;
            Items.Add(m); 
        }
    }
}
