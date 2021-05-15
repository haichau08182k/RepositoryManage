using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    public class ControlBarVM:BaseViewModel
    {
        #region command
        public ICommand CloseWindowsCmd { get; set; }
        public ICommand MaximizeWindowsCmd { get; set; }
        public ICommand MinimizeWindowsCmd { get; set; }
        public ICommand MouseMoveWindowsCmd { get; set; }
        #endregion
        public ControlBarVM()
        {
            CloseWindowsCmd = new RelayCommand<UserControl>((p) => { return p==null? false:true; }, (p) => {
                FrameworkElement window = GetWindowParent(p);
                var w = window as Window;
                if (w != null)
                {
                    w.Close();
                }
            });

            MaximizeWindowsCmd = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                FrameworkElement window = GetWindowParent(p);
                var w = window as Window;
                if (w != null)
                {
                    if (w.WindowState != WindowState.Maximized)
                    {
                        w.WindowState = WindowState.Maximized;
                    }
                    else
                        w.WindowState = WindowState.Normal;
                }
            });

            MinimizeWindowsCmd = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                FrameworkElement window = GetWindowParent(p);
                var w = window as Window;
                if (w != null)
                {
                    if (w.WindowState != WindowState.Minimized)
                    {
                        w.WindowState = WindowState.Minimized;
                    }
                    else
                        w.WindowState = WindowState.Maximized;
                }
            });

            MouseMoveWindowsCmd = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                FrameworkElement window = GetWindowParent(p);
                var w = window as Window;
                if (w != null)
                {
                    w.DragMove();
                }
            });
        }
        FrameworkElement GetWindowParent(UserControl p)
        {
            FrameworkElement parent = p;
            while(parent.Parent!=null)
            {
                parent = parent.Parent as FrameworkElement;
            }
            return parent;
        }
        //comment

    }
}
