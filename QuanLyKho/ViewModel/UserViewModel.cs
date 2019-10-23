using QuanLyKho.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    public class UserViewModel : BaseViewModel
    {
        private ObservableCollection<Users> _List;
        public ObservableCollection<Users> List { get => _List; set { _List = value; OnPropetyChange(); } }

        private ObservableCollection<UsersRole> _ListUserRole;
        public ObservableCollection<UsersRole> ListUserRole { get => _ListUserRole; set { _ListUserRole = value; OnPropetyChange(); } }

        private string _DisplayName;
        private string _UserName;
        private int _RoleId;

        private Users _SelectedItem;

        private QuanLyKhoEntities Entity = DataProvider.Instance.DB;
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand SelectedChangeCommand { get; set; }

        public Users SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value;
                OnPropetyChange();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName;
                    UserName = SelectedItem.UserName;
                    RoleId = SelectedItem.IdRole;
                }
            }
        }

        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropetyChange(); } }
        public string UserName { get => _UserName; set { _UserName = value; OnPropetyChange(); } }
        public int RoleId { get => _RoleId; set { _RoleId = value; OnPropetyChange(); } }

        public UserViewModel()
        {
            LoadUserList();
            GetListUserRole();

            AddCommand = new RelayCommand<object>(p =>
            {

                if (string.IsNullOrEmpty(UserName))
                {
                    return false;
                }

                var userList = Entity.Users.Where(x => x.UserName.Equals(UserName));

                if (userList == null || userList.Count() != 0)
                {
                    return false;
                }

                return true;

            }, (p) =>
            {

                var user = new Users() { DisplayName = this.DisplayName, UserName = this.UserName, IdRole = this.RoleId };

                Entity.Users.Add(user);
                Entity.SaveChanges();
                List.Add(user);
            });

            SelectedChangeCommand = new RelayCommand<ComboBox>((p) => true, (p) =>
            {
                this.RoleId = p.SelectedIndex + 1;
            });


            EditCommand = new RelayCommand<ComboBox>((p) =>
            {
                if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(DisplayName))
                {
                    return false;
                }

                return true;
            }, (p) =>
            {
                var userEdit = Entity.Users.Find(SelectedItem.Id);
                userEdit.DisplayName = this.DisplayName;
                userEdit.UserName = this.UserName;
                Entity.SaveChanges();
                SelectedItem.DisplayName = this.DisplayName;
                SelectedItem.UserName = this.UserName;
            });

        }
        private void LoadUserList()
        {
            List = new ObservableCollection<Users>();

            var listUser = Entity.Users.ToList();
            Users user;
            foreach (var item in listUser)
            {
                user = new Users();
                user.DisplayName = item.DisplayName;
                user.UserName = item.UserName;
                user.IdRole = item.IdRole;
                user.Id = item.Id;
                List.Add(user);
            }
        }

        private void GetListUserRole()
        {
            ListUserRole = new ObservableCollection<UsersRole>();
            var listRole = Entity.UsersRole.ToList();

            foreach (var item in listRole)
            {
                ListUserRole.Add(item);
            }
        }
    }
}
