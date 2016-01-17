using System.Collections.Generic;
using RestaurantManager.Models;
using System.Collections.ObjectModel;
using Extensions;
using System.Windows.Input;
using System;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {       
        public OrderViewModel()
        {
            AddItemCommand = new DelegateCommand<object>(AddItem);
            SubmitOrderCommand = new DelegateCommand<object>(SubmitOrder);
        }

        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5]
            };
        }

        private List<MenuItem> menuItems;
        private ObservableCollection<MenuItem> currentlySelectedMenuItems;
        private MenuItem selectedMenuItem;
        private string spRequests;

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
                    this.NotifyPropertyChanged();
                }
            }
        }

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems
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
                    NotifyPropertyChanged();
                }
            }
        }
        public MenuItem SelectedMenuItem
        {
            get { return selectedMenuItem; }
            set
            {
                if(selectedMenuItem != value)
                {
                    selectedMenuItem = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string SpRequests
        {
            get { return spRequests; }
            set
            {
                if(spRequests != value)
                {
                    spRequests = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ICommand AddItemCommand { get; private set; }
        public ICommand SubmitOrderCommand { get; private set; }

        private void AddItem(object parameter)
        {
            this.CurrentlySelectedMenuItems.Add(this.SelectedMenuItem);
        }

        private void SubmitOrder(object obj)
        {
            var Expedite = new ExpediteViewModel();
            var order = new Order
            {
                Complete = false,
                Expedite = false,
                SpecialRequests = SpRequests,
                Table = new Table { Description = "Back-Corner Two Top" },
                Items = new List<MenuItem>(CurrentlySelectedMenuItems)
            };
            Expedite.OrderItems.Add(order);
        }
    }
    
}
