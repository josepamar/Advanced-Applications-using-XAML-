using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Microsoft.Xaml.Interactivity;
using Windows.UI.Xaml.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace Extensions
{
    public class RightClickMessageDialogBehavior : DependencyObject, IBehavior
    {
        public DependencyObject AssociatedObject { get; private set; }
        public string Message { get; set; }
        public string Title { get; set; }

        public void Attach(DependencyObject associatedObject)
        {
            this.AssociatedObject = associatedObject;
            if((this.AssociatedObject as Page) != null)
            {
                (this.AssociatedObject as Page).RightTapped += RightClickMessageDialogBehavior_RightTapped;
            }
        }

        private void RightClickMessageDialogBehavior_RightTapped(object sender, RoutedEventArgs e)
        {
            new MessageDialog(this.Message, this.Title).ShowAsync();
        }

        public void Detach()
        {
            if ((this.AssociatedObject as Page) != null)
            {
                (this.AssociatedObject as Page).RightTapped -= RightClickMessageDialogBehavior_RightTapped;
            }
        }
    }
}
