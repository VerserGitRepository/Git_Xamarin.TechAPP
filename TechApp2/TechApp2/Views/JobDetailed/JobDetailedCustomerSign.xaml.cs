using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechApp2.Views.JobDetailed
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobDetailedCustomerSign : ContentPage
    {
        public JobDetailedCustomerSign()
        {
            InitializeComponent();
        }

       

        private async void SaveBtn_Clicked(object sender, EventArgs e)
        {
            Stream CustomerJObSign = await MainSignaturePad.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Jpeg);
            Stream TechSignJOb = await TechSign.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Jpeg);
        }
    }
}