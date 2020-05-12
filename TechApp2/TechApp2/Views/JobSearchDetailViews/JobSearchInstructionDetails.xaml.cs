using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechApp2.Views.JobSearchDetailViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobSearchInstructionDetails : ContentPage
    {
        public JobSearchInstructionDetails(string WorkInstructionData)
        {
            InitializeComponent();
            txtWorkInstruction.Text = WorkInstructionData;
            this.BindingContext = WorkInstructionData;
        }

        private async void BtnBackToJobDetails_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
       
    }
}