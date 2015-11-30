﻿using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class ExpediteDataManager : DataManager
    {
        protected override void OnDataLoaded()
        {
            this.OrderItems = base.Repository.Orders;
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
                    this.OnChanged();
                }

            }
        }

    }
}