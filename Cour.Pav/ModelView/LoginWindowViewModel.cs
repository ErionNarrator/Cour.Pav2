using Cour.Pav.Model;
using Cour.Pav.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Cour.Pav.ModelView
{
    class LoginWindowViewModel : BaseClass
    {
        AucitonContext db = new AucitonContext();
        private ObservableCollection<Buyer> buyerList;
        public ObservableCollection<Buyer> BuyerList
        {
            get
            {
                return buyerList;
            }
            set
            {
                buyerList = value;
                OnPropertyChanged(nameof(buyerList));
            }
        }

        private ObservableCollection<Seller> sellerList;
        public ObservableCollection<Seller> SellerList
        {
            get
            {
                return sellerList;
            }
            set
            {
                sellerList = value;
                OnPropertyChanged(nameof(sellerList));
            }
        }

        public LoginWindow window;

        private Buyer? selectBuyer;
        public Buyer? SelectBuyer
        {
            get
            {
                return selectBuyer;
            }
            set
            {
                selectBuyer = value; OnPropertyChanged(nameof(selectBuyer));
            }
        }

        private Seller? selectSeller;
        public Seller? SelectSeller
        {
            get
            {
                return selectSeller;
            }

            set
            {
                selectSeller = value;
                OnPropertyChanged(nameof(selectSeller));
            }

        }

        public LoginWindowViewModel(LoginWindow w)
        {
            this.window = w;
            db.Buyers.Load();
            BuyerList = db.Buyers.Local.ToObservableCollection();
            this.window = w;
            db.Sellers.Load();
            SellerList = db.Sellers.Local.ToObservableCollection();

            LoginCommand = new RelayCommand(Login);
            CancelCommand = new RelayCommand(Cancel);

        }



        private RelayCommand? addCommands;
        public RelayCommand AddCommands
        {
            get
            {
                return addCommands ??
                    (addCommands = new RelayCommand(obj =>
                    {
                        AddEditBuyer window = new AddEditBuyer(new Buyer());
                        if (window.ShowDialog() == true)
                        {
                            Buyer buyer = window.Buyer;
                            db.Buyers.Add(buyer);
                            db.SaveChanges();
                        }
                    }
                        ));
            }
        }

        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        AddEditSeller window = new AddEditSeller(new Seller());
                        if (window.ShowDialog() == true)
                        {
                            Seller seller = window.Seller;
                            db.Sellers.Add(seller);
                            db.SaveChanges();
                        }
                    }
                    ));
            }
        }

        //Вход в акаун покупателя
        private string? loginBuyer;
        public string? LoginBuyer
        {
            get { return loginBuyer; }
            set
            {
                loginBuyer = value; OnPropertyChanged(nameof(LoginBuyer));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand CancelCommand { get; }
        public string? Amd = "Amd"; /*лог/пароль для админа*/

        private void Login(object parameter)
        {
            var passwordBox = parameter as System.Windows.Controls.PasswordBox;
            if (passwordBox == null)
                return;

            string password = passwordBox.Password;
            using (var context = new AucitonContext())
            {
                var userA = (Amd == LoginBuyer && Amd == password);
                if (userA = userA)
                {
                    OpenMainWindow();

                    CloseLoginWindow();
                }
                var user = context.Buyers.FirstOrDefault(u => u.LoginBuyer == LoginBuyer && u.PasswordBuyer == password);
                if (user != null)
                {

                    OpenUserWindow(); // Авторизация успешна, открываем основное окно

                    
                    CloseLoginWindow(); // Закрываем окно логина
                }
                var user1 = context.Sellers.FirstOrDefault(u => u.LoginSeller == LoginBuyer && u.PasswordSeller == password);
                if (user1 != null)
                {
                    OpenUserWindow(); // Авторизация успешна, открываем основное окно

                    CloseLoginWindow();  // Закрываем окно логина
                }
               
            }

        }
        private void OpenMainWindow()
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void OpenUserWindow()
        {
            var userWindow = new UserWindow();
            userWindow.Show();
        }
        private void CloseLoginWindow()
        {
            var loginWindow = Application.Current.Windows.OfType<LoginWindow>().SingleOrDefault();
            if (loginWindow != null)
            {
                loginWindow.Close();
            }
        }

        private void Cancel(object parameter)
        {
            
            Application.Current.Shutdown(); // Закрыть приложение
        }


    }
}
