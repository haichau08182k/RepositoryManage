using QuanLyKho.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    public class SuplierVM : BaseViewModel
    {
        private ObservableCollection<Suplier> _suplierList;
        public ObservableCollection<Suplier> suplierList { get => _suplierList; set { _suplierList = value; OnPropertyChanged(); } }
        private Suplier _SelectedItem;
        public Suplier SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); if (SelectedItem != null) 
                { 
                    DisplayName = SelectedItem.DisplayName;
                    Phone = SelectedItem.Phone;
                    Address = SelectedItem.Address;
                    Email = SelectedItem.Email;
                    MoreInfor = SelectedItem.MoreInfor;
                    ContractDate = SelectedItem.ContractDate;

                } } }
        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }

        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }

        private string _MoreInfor;
        public string MoreInfor { get => _MoreInfor; set { _MoreInfor = value; OnPropertyChanged(); } }

        private DateTime? _ContractDate;
        public DateTime? ContractDate { get => _ContractDate; set { _ContractDate = value; OnPropertyChanged(); } }

        public ICommand AddCmd { get; set; }
        public ICommand EditCmd { get; set; }

        public SuplierVM()
        {
            suplierList = new ObservableCollection<Suplier>(DataProvider.Ins.DB.Supliers);

            AddCmd = new RelayCommand<object>((p) =>
            {
                return true;
            },

            (p) =>
            {
                var suplier = new Suplier { DisplayName = DisplayName,Address=Address, Phone = Phone, Email=Email, MoreInfor=MoreInfor,ContractDate= ContractDate };
                DataProvider.Ins.DB.Supliers.Add(suplier);
                DataProvider.Ins.DB.SaveChanges();
                suplierList.Add(suplier);
            });

            EditCmd = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                {
                    return false;
                }
                var displayList = DataProvider.Ins.DB.Supliers.Where(x => x.Id == SelectedItem.Id);
                if (displayList != null || displayList.Count() != 0)
                { return true; }
                return false;
            },

            (p) =>
            {
                /*
                 *  Nếu Update lại Model
                 *  suplier:BaseViewModel
                 *  public string _DisplayName;
                 *  public string DisplayName { get=> _DisplayName; set { _DisplayName = value;OnPropertyChanged(); } }
                 */
                var suplier = DataProvider.Ins.DB.Supliers.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                suplier.DisplayName = DisplayName;
                suplier.Address = Address;
                suplier.Phone = Phone;
                suplier.Email = Email;
                suplier.MoreInfor = MoreInfor;
                suplier.ContractDate = ContractDate;
                DataProvider.Ins.DB.SaveChanges();
                SelectedItem.DisplayName = DisplayName;
            });
        }
    }
}
