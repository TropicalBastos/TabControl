using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace MyNamespace
{

    public enum Statuses { Inactive = 0, Active = 1 }

    public class Tab : Label, INotifyPropertyChanged
    {
        
        protected Color prevColor;

        public Tab()
        {
            prevColor = this.BackgroundColor;
            if(Status == (int)Statuses.Active){
                BackgroundColor = Color.FromHex(ActiveBackgroundColor);
                TextColor = Color.FromHex(ActiveTextColor);
            }

            GestureRecognizers.Add(new TapGestureRecognizer{
                Command = new Command(() => OnSelected())
            });
        }

        protected readonly BindableProperty StatusProperty =
            BindableProperty.Create("Status", typeof(int), typeof(Tab), 0);

        public int Status
        {
            get { return (int)GetValue(this.StatusProperty); }
            set 
            { 
                SetValue(StatusProperty, value);
                OnPropertyChanged(nameof(Status));
            }
        }

        protected readonly BindableProperty ActiveBackgroundColorProperty =
            BindableProperty.Create("ActiveBackgroundColor", typeof(string),
                                    typeof(Tab), "#FFFFFF");

        public string ActiveBackgroundColor
        {
            get { return (string)GetValue(ActiveBackgroundColorProperty); }
            set 
            { 
                SetValue(ActiveBackgroundColorProperty, value); 
                OnPropertyChanged(nameof(Status));
            }
        }

        protected readonly BindableProperty NavPageProperty =
            BindableProperty.Create("NavPage", typeof(string),
                            typeof(Tab), null);

        public string NavPage{
            get { return (string)GetValue(NavPageProperty); }
            set 
            { 
                SetValue(NavPageProperty, value);
                OnPropertyChanged(nameof(NavPage));
            }
        }

        protected readonly BindableProperty ActiveTextColorProperty =
            BindableProperty.Create("ActiveTextColor", typeof(string),
                                    typeof(Tab), "#FFFFFF");

        public string ActiveTextColor{
            get { return (string)GetValue(ActiveTextColorProperty); }
            set 
            { 
                SetValue(ActiveTextColorProperty, value); 
                OnPropertyChanged(nameof(ActiveTextColor));
            }
        }

        public void Navigate(){
            Page p = (Page)Activator.CreateInstance(Type.GetType(NavPage));
            Navigation.PushAsync(p);
        }

		protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
            base.OnPropertyChanged(propertyName);
            if(propertyName == nameof(Status)){
                if (this.Status == (int)Statuses.Active)
                {
                    BackgroundColor = Color.FromHex(ActiveBackgroundColor);
                    TextColor = Color.FromHex(ActiveTextColor);
                }
                else
                {
                    BackgroundColor = prevColor;
                }
            }
		}

        protected void OnSelected(){
            Status = 1;
            Navigate();
        }

	}
}