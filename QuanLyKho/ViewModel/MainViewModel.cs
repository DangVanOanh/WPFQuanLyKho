using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    /// <summary>
    /// Dung de lam datacontext cho View Main
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        public bool Isload = false;
        public ICommand IsLoadCommand { set; get; }
        public ICommand UnitCommand { set; get; }
        public ICommand SuplierCommand { set; get; }

        public ICommand UserCommand { set; get; }
        

        public MainViewModel()
        {

            IsLoadCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Isload = true;
                p.Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();

                /// Khi no dang nhap thanh con moi hien thi main

                if (loginWindow.DataContext == null)
                    return;
                var loginModel = loginWindow.DataContext as LoginViewModel;

                if (loginModel.isLogin)
                {
                    p.Show();
                }
                else
                {
                    p.Close();
                }
            });

            UnitCommand = new RelayCommand<Window>((p) => true, (p) =>{ UnitWindow wd = new UnitWindow(); wd.ShowDialog();});
            SuplierCommand = new RelayCommand<Window>((p) => true, (p) => { SuplierWindow wd = new SuplierWindow(); wd.ShowDialog(); });
            UserCommand = new RelayCommand<Window>((p) => true, (p) => { UserWindow wd = new UserWindow(); wd.ShowDialog(); });
        }
    }
}
