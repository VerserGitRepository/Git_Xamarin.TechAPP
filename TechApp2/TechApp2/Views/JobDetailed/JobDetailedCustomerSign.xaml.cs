using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechApp2.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechApp2.Views.JobDetailed
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobDetailedCustomerSign : ContentPage
    {
        private UpdateTechJobDto updateModel = new UpdateTechJobDto();
        public JobDetailedCustomerSign()
        {
            InitializeComponent();
        }

       

        private async void SaveBtn_Clicked(object sender, EventArgs e)
        {
            Stream CustomerJObSign = await MainSignaturePad.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Jpeg);
            Stream TechSignJOb = await TechSign.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Jpeg);

            byte[] image = new byte[CustomerJObSign.Length];
            byte[] Techimage = new byte[TechSignJOb.Length];//declare arraysize
            CustomerJObSign.Read(image, 0, image.Length);
            TechSignJOb.Read(Techimage, 0, Techimage.Length);
            updateModel.CustomerSignatureVector = image;
            updateModel.TechnicianSignatureVector = Techimage;

        }
    }
}