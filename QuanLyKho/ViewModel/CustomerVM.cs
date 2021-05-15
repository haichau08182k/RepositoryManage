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
    public class CustomerVM:BaseViewModel
    {
        private ObservableCollection<Customer> _CustomerList;
        public ObservableCollection<Customer> CustomerList { get => _CustomerList; set { _CustomerList = value; OnPropertyChanged(); } }
        private Customer _SelectedItem;
        public Customer SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged(); if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName;
                    Phone = SelectedItem.Phone;
                    Address = SelectedItem.Address;
                    Email = SelectedItem.Email;
                    MoreInfor = SelectedItem.MoreInfor;
                    ContractDate = SelectedItem.ContractDate;

                }
            }
        }
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

        public CustomerVM()
        {
            CustomerList = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customers);

            AddCmd = new RelayCommand<object>((p) =>
            {
                return true;
            },

            (p) =>
            {
                var Customer = new Customer { DisplayName = DisplayName, Address = Address, Phone = Phone, Email = Email, MoreInfor = MoreInfor, ContractDate = ContractDate };
                DataProvider.Ins.DB.Customers.Add(Customer);
                DataProvider.Ins.DB.SaveChanges();
                CustomerList.Add(Customer);
            });

            EditCmd = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                {
                    return false;
                }
                var displayList = DataProvider.Ins.DB.Customers.Where(x => x.Id == SelectedItem.Id);
                if (displayList != null || displayList.Count() != 0)
                { return true; }
                return false;
            },

            (p) =>
            {
                /*
                 *  Nếu Update lại Model
                 *  Customer:BaseViewModel
                 *  public string _DisplayName;
                 *  public string DisplayName { get=> _DisplayName; set { _DisplayName = value;OnPropertyChanged(); } }
                 */
                var Customer = DataProvider.Ins.DB.Customers.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                Customer.DisplayName = DisplayName;
                Customer.Address = Address;
                Customer.Phone = Phone;
                Customer.Email = Email;
                Customer.MoreInfor = MoreInfor;
                Customer.ContractDate = ContractDate;
                DataProvider.Ins.DB.SaveChanges();
                SelectedItem.DisplayName = DisplayName;
            });
        }
    }
}
