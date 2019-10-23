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
    public class ControlBarViewModel : BaseViewModel
    {
        #region command
        public ICommand CloseViewCommand { set; get; }
        public ICommand MaximizeViewCommand { set; get; }
        public ICommand MinimizeViewCommand { set; get; }
        public ICommand MoseMoveViewCommand { set; get; }
        public ControlBarViewModel()
        {
            CloseViewCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => { Window window = GetWindowParent(p);
                if (window != null)
                {
                    window.Close();
                }
            });

            MaximizeViewCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                Window window = GetWindowParent(p);
                if (window != null)
                {
                    if (window.WindowState != WindowState.Maximized)
                    {
                        window.WindowState = WindowState.Maximized;
                    }
                    else
                    {
                        window.WindowState = WindowState.Normal;
                    }
                }
            });

            MinimizeViewCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                Window window = GetWindowParent(p);
                if (window != null)
                {
                    if (window.WindowState != WindowState.Minimized)
                    {
                        window.WindowState = WindowState.Minimized;
                    }
                    else
                    {
                        window.WindowState = WindowState.Maximized;
                    }
                }
            });

            MoseMoveViewCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                Window window = GetWindowParent(p);
                if (window != null)
                {
                    window.DragMove();
                }
            });
        }

        /// <summary>
        /// Get paren window of form click
        /// </summary>
        /// <param name="control"></param>
        /// <returns> Form de thu hien close</returns>
        Window GetWindowParent(UserControl control)
        {
            Window parent = null;

            if (Window.GetWindow(control.Parent) != null)
            {
                parent = Window.GetWindow(control.Parent);
            }

            return parent;

        }
        #endregion
    }
}
