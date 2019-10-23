using QuanLyKho.Model;
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
    public class LoginViewModel : BaseViewModel
    {

        private string _UserName;
        private string _Password;

        public bool isLogin { set; get; }
        public ICommand CloseCommand { set; get; }
        public ICommand LoginCommand { set; get; }

        public ICommand PasswordChangeCommand { get; set; }

        public string UserName { get => _UserName; set { _UserName = value; OnPropetyChange(); } }
        public string Password { get => _Password; set { _Password = value; OnPropetyChange(); } }

        public LoginViewModel()
        {
            isLogin = false;
            CloseCommand = new RelayCommand<object>(p => true, p =>
            {
                if (p != null)
                {
                    (p as Window).Close();
                }
            });

            LoginCommand = new RelayCommand<object>(p => true, p =>
            {

                Login(p);
                if (isLogin == false)
                {
                    MessageBox.Show("Đặng nhập không thành công!!!");
                }
            });

            PasswordChangeCommand = new RelayCommand<PasswordBox>(p => { return true; }, p =>
            {
                Password = p.Password;
            });
        }


        public void Login(object p)
        {
            if (p == null)
                return;

            var entity = DataProvider.Instance.DB;

            if (entity == null)
                return;

            var checkUserName = entity.Users.Where(m => m.UserName.Equals(this.UserName) && m.Password.Equals(this.Password)).Count();

            if (checkUserName > 0)
            {
                isLogin = true;
                (p as Window).Close();
            }
        }
    }
}
