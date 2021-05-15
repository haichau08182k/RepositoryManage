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
    public class ObjectVM: BaseViewModel
    {
        private ObservableCollection<Model.Object> _ObjectList;
        public ObservableCollection<Model.Object> ObjectList { get => _ObjectList; set { _ObjectList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.Unit> _UnitList;
        public ObservableCollection<Model.Unit> UnitList { get => _UnitList; set { _UnitList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.Suplier> _SuplierList;
        public ObservableCollection<Model.Suplier> SuplierList { get => _SuplierList; set { _SuplierList = value; OnPropertyChanged(); } }

        private Model.Object _SelectedItem;
        public Model.Object SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName;
                    QRCode = SelectedItem.QRCode;
                    BarCode = SelectedItem.BarCode;
                    SelectedUnit = SelectedItem.Unit;
                    SelectedSuplier = SelectedItem.Suplier;
                }
            }
        }
        private Model.Unit _SelectedUnit;
        public Model.Unit SelectedUnit
        {
            get => _SelectedUnit;
            set
            {
                _SelectedUnit = value;
                OnPropertyChanged();
            }
        }

        private Model.Suplier _SelectedSuplier;
        public Model.Suplier SelectedSuplier
        {
            get => _SelectedSuplier;
            set
            {
                _SelectedSuplier = value;
                OnPropertyChanged();
            }
        }

        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        private string _QRCode;
        public string QRCode { get => _QRCode; set { _QRCode = value; OnPropertyChanged(); } }

        private string _BarCode;
        public string BarCode { get => _BarCode; set { _BarCode = value; OnPropertyChanged(); } }


        public ICommand AddCmd { get; set; }
        public ICommand EditCmd { get; set; }

        public ObjectVM()
        {
            ObjectList = new ObservableCollection<Model.Object>(DataProvider.Ins.DB.Objects);
            UnitList = new ObservableCollection<Unit>(DataProvider.Ins.DB.Units);
            SuplierList = new ObservableCollection<Suplier>(DataProvider.Ins.DB.Supliers);
            AddCmd = new RelayCommand<object>((p) =>
            {
                if (SelectedSuplier == null || SelectedUnit == null)
                    return false;
                return true;
            },

            (p) =>
            {
                var Object = new Model.Object { DisplayName = DisplayName, BarCode=BarCode,QRCode=QRCode,IdSuplier=SelectedSuplier.Id,IdUnit=SelectedUnit.Id,Id=Guid.NewGuid().ToString() };
                DataProvider.Ins.DB.Objects.Add(Object); 
                DataProvider.Ins.DB.SaveChanges();
                ObjectList.Add(Object);
            });

            EditCmd = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null||SelectedSuplier == null || SelectedUnit == null)
                {
                    return false;
                }
                var displayList = DataProvider.Ins.DB.Objects.Where(x => x.Id == SelectedItem.Id);
                if (displayList != null || displayList.Count() != 0)
                { return true; }
                return false;
            },

            (p) =>
            {
                /*
                 *  Nếu Update lại Model
                 *  Object:BaseViewModel
                 *  public string _DisplayName;
                 *  public string DisplayName { get=> _DisplayName; set { _DisplayName = value;OnPropertyChanged(); } }
                 */
                var Object = DataProvider.Ins.DB.Objects.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                Object.DisplayName = DisplayName;
                Object.BarCode = BarCode;
                Object.QRCode = QRCode;
                Object.IdSuplier = SelectedSuplier.Id;
                Object.IdUnit = SelectedUnit.Id;
                DataProvider.Ins.DB.SaveChanges();
                SelectedItem.DisplayName = DisplayName;
            });
        }
    }
}
