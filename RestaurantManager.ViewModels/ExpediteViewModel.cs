using System.Collections.Generic;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        protected override void OnDataLoaded()
        {
            this.OrderItems = Repository.Orders;
        }

        private List<Order> orderItems;

        public List<Order> OrderItems
        {
            get
            {
                return orderItems;
            }

            set
            {
                if (this.orderItems != value)
                {
                    this.orderItems = value;
                    this.NotifyPropertyChanged();
                }

            }
        }

    }
}