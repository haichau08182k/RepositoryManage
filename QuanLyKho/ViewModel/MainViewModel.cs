using QuanLyKho.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    public class MainViewModel:BaseViewModel
    {
        private ObservableCollection<WareHouse> _WareHouseList;
        public ObservableCollection<WareHouse> WareHouseList { get=> _WareHouseList; set { _WareHouseList = value;OnPropertyChanged(); } }
        public bool ILoaded = false;
        public ICommand LoadedWindowsCmd { get; set; }
        public ICommand UnitCmd { get; set; }
        public ICommand SuplierCmd { get; set; }
        public ICommand CustomerCmd { get; set; }
        public ICommand ObjectCmd { get; set; }
        public ICommand UserCmd { get; set; }
        public ICommand InputCmd { get; set; }
        public ICommand OutputCmd { get; set; }

        public MainViewModel()
        {
            LoadedWindowsCmd = new RelayCommand<Window>((p) => { return true; }, (p) => {
                    ILoaded = true;
                if (p == null)
                    return;
                    p.Hide();
                    LoginWindow loginWindow = new LoginWindow();
                    loginWindow.ShowDialog();
                if (loginWindow.DataContext == null)
                    return;
                var loginVN = loginWindow.DataContext as LoginViewModel;
                if (loginVN.IsLogin)
                {
                    p.Show();
                    LoadWareHouseData();
                }
                else
                {
                    p.Close();
                }

            });
            UnitCmd = new RelayCommand<object>((p) => { return true; }, (p) => { UnitWindow wnd = new UnitWindow(); wnd.ShowDialog();});
            SuplierCmd = new RelayCommand<object>((p) => { return true; }, (p) => { SuplierWindow wnd = new SuplierWindow(); wnd.ShowDialog(); });
            CustomerCmd = new RelayCommand<object>((p) => { return true; }, (p) => { CustomerWindow wnd = new CustomerWindow(); wnd.ShowDialog(); });
            ObjectCmd = new RelayCommand<object>((p) => { return true; }, (p) => { ObjectWindow wnd = new ObjectWindow(); wnd.ShowDialog(); });
            UserCmd = new RelayCommand<object>((p) => { return true; }, (p) => { UserWindow wnd = new UserWindow(); wnd.ShowDialog(); });
            InputCmd = new RelayCommand<object>((p) => { return true; }, (p) => { InputWindow wnd = new InputWindow(); wnd.ShowDialog(); });
            OutputCmd = new RelayCommand<object>((p) => { return true; }, (p) => { OutputWindow wnd = new OutputWindow(); wnd.ShowDialog(); });
        }
        void LoadWareHouseData()
        {
            WareHouseList = new ObservableCollection<WareHouse>();
            var objectList = DataProvider.Ins.DB.Objects;
            int i = 1;
            foreach (var item in objectList)
            {
                var inputList= DataProvider.Ins.DB.InputInfors.Where(p=>p.IdObject==item.Id);
                var outputList= DataProvider.Ins.DB.OutputInfors.Where(p => p.IdObject == item.Id);

                int sumInput = 0;
                int sumOutput = 0;
                if (inputList != null && inputList.Count()>0)
                {
                    sumInput = (int)inputList.Sum(p => p.Count);
                }
                if (outputList != null && outputList.Count() > 0)
                {
                    sumOutput = (int)outputList.Sum(p => p.Count);
                }
                WareHouse wareHouse = new WareHouse();
                wareHouse.STT = i;
                wareHouse.Count = sumInput - sumOutput;
                wareHouse.Object = item;

                WareHouseList.Add(wareHouse);
                i++;
            }
        }
    }
}
