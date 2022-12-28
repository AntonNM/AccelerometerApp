using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{




    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
        public const double MyBorderWidth = 3.5;

        public Page1 ()
		{
			InitializeComponent ();

			var content = (StackLayout) this.Content;

			btnOK.Clicked += (sender, e) => { Debug.WriteLine("Clicked!"); };
		}
	}
}