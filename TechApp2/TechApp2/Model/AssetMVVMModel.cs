using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TechApp2.Model
{
  public partial class AssetMVVMModel :INotifyPropertyChanged
    {

        public string SSN
        {
            get => SSN;
            set
            {
                if (SSN == value) return;
                SSN = value;
                OnPropertyChanged();
            }
        }
        public string Make
        {
            get => Model;
            set
            {
                if (Model == value) return;
                Model = value;
                OnPropertyChanged();
            }
        }
        public string Model
        {
            get => Model;
            set
            {
                if (Model == value) return;
                Model = value;
                OnPropertyChanged();
            }
        }
        public string Grade
        {
            get => Grade;
            set
            {
                if (Grade == value) return;
                Grade = value;
                OnPropertyChanged();
            }
        }

        public string SerialNo
        {
            get => SerialNo;
            set
            {
                if (SerialNo == value) return;
                SerialNo = value;
                OnPropertyChanged();
            }
        }
        public string ClientPO
        {
            get => ClientPO;
            set
            {
                if (ClientPO == value) return;
                ClientPO = value;
                OnPropertyChanged();
            }
        }
        public string ClientRef
        {
            get => ClientRef;
            set
            {
                if (ClientRef == value) return;
                ClientRef = value;
                OnPropertyChanged();
            }
        }
        public string AssetStatusId
        {
            get => AssetStatusId;
            set
            {
                if (AssetStatusId == value) return;
                AssetStatusId = value;
                OnPropertyChanged();
            }
        }

        public string BuyPrice
        {
            get => BuyPrice;
            set
            {
                if (BuyPrice == value) return;
                BuyPrice = value;
                OnPropertyChanged();
            }
        }
        public string SellPrice
        {
            get => SellPrice;
            set
            {
                if (SellPrice == value) return;
                SellPrice = value;
                OnPropertyChanged();
            }
        }
        public string ProjectId
        {
            get => ProjectId;
            set
            {
                if (ProjectId == value) return;
                ProjectId = value;
                OnPropertyChanged();
            }
        }
        public string ItemTypeId
        {
            get => ItemTypeId;
            set
            {
                if (ItemTypeId == value) return;
                ItemTypeId = value;
                OnPropertyChanged();
            }
        }
        public string AssetTag
        {
            get => AssetTag;
            set
            {
                if (AssetTag == value) return;
                AssetTag = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string SSN = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(SSN));

        }


        //void SSNPropertyChanged(string SSN)
        //{
        //    _SSNPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(SSN));

        //}
        //void MakePropertyChanged(string Make)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Make));

        //}
        //void ModelPropertyChanged(string Model)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Model));

        //}
        //void GradePropertyChanged(string Grade)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Grade));

        //}
        //void SerialNoPropertyChanged(string SerialNo)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(SerialNo));

        //}
        //void ClientPOPropertyChanged(string ClientPO)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(ClientPO));

        //}
        //void ClientRefPropertyChanged(string ClientRef)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(ClientRef));

        //}
        //void AssetStatusIdPropertyChanged(string AssetStatusId)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(AssetStatusId));

        //}
        //void BuyPricePropertyChanged(string BuyPrice)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(BuyPrice));

        //}
        //void SellPricePropertyChanged(string SellPrice)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(SellPrice));

        //}
        //void ProjectIdPropertyChanged(string ProjectId)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(ProjectId));

        //}
        //void ItemTypeIdPropertyChanged(string ItemTypeId)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(ItemTypeId));

        //}
        //void AssetTagPropertyChanged(string AssetTag)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(AssetTag));

        //}
    }
}
