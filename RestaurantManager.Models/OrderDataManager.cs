using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class OrderDataManager : DataManager
    {       
        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new List<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5]
            };
        }

        private List<MenuItem> menuItems;

        private List<MenuItem> currentlySelectedMenuItems;

        public List<MenuItem> MenuItems
        {
            get
            {
                return menuItems;
            }

            set
            {
                if(this.menuItems != value)
                {
                    this.menuItems = value;
                    this.OnChanged();
                }
                
            }
        }

        public List<MenuItem> CurrentlySelectedMenuItems
        {
            get
            {
                return currentlySelectedMenuItems;
            }

            set
            {
                if(currentlySelectedMenuItems != value)
                {
                    currentlySelectedMenuItems = value;
                    OnChanged();
                }
                
            }
        }
    }
    
}
