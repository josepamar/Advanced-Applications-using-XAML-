using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestaurantManager.Models
{
    public abstract class DataManager : INotifyPropertyChanged
    {
        protected RestaurantContext Repository { get; private set; }


        //INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnChanged([CallerMemberName] string propName = null)
        {
            if(PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        //
        public DataManager()
        {
            LoadData();
        }
        private async void LoadData()
        {
            this.Repository = new RestaurantContext();
            await this.Repository.InitializeContextAsync();
            OnDataLoaded();
        }

        protected abstract void OnDataLoaded();
    }
}
