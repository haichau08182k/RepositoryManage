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
    public class UnitVM: BaseViewModel
    {
        private ObservableCollection<Unit> _UnitList;
        public ObservableCollection<Unit> UnitList { get => _UnitList; set { _UnitList = value; OnPropertyChanged(); } }
        private Unit _SelectedItem;
        public Unit SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged();if (SelectedItem != null) { DisplayName = SelectedItem.DisplayName; } } }
        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }
        public ICommand AddCmd { get; set; }
        public ICommand EditCmd { get; set; }

        public UnitVM()
        {
            UnitList = new ObservableCollection<Unit>(DataProvider.Ins.DB.Units);

            AddCmd = new RelayCommand<object>((p) => 
            {
                if(string.IsNullOrEmpty(DisplayName))
                {
                    return false;
                }
                var displayList = DataProvider.Ins.DB.Units.Where(x => x.DisplayName == DisplayName);
                if(displayList==null||displayList.Count()!=0)
                { return false; }
                return true;
            },
                
            (p) => 
            {
                var unit = new Unit { DisplayName = DisplayName };
                DataProvider.Ins.DB.Units.Add(unit);
                DataProvider.Ins.DB.SaveChanges();
                UnitList.Add(unit);
            });

            EditCmd = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName)||SelectedItem==null)
                {
                    return false;
                }
                var displayList = DataProvider.Ins.DB.Units.Where(x => x.DisplayName == DisplayName);
                if (displayList == null || displayList.Count() != 0)
                { return false; }
                return true;
            },

            (p) =>
            {
                /*
                 *  Nếu Update lại Model
                 *  Unit:BaseViewModel
                 *  public string _DisplayName;
                 *  public string DisplayName { get=> _DisplayName; set { _DisplayName = value;OnPropertyChanged(); } }
                 */
                var unit = DataProvider.Ins.DB.Units.Where(x=>x.Id==SelectedItem.Id).SingleOrDefault();
                unit.DisplayName = DisplayName;
                DataProvider.Ins.DB.SaveChanges();
                SelectedItem.DisplayName = DisplayName;
             });
        }
    }
}
