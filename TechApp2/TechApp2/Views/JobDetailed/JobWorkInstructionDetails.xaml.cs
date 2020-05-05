using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechApp2.Views.JobDetailed
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobWorkInstructionDetails : ContentPage
    {
        public JobWorkInstructionDetails(string WorkInstructionData)
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