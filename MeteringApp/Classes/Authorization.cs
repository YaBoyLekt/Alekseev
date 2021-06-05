using MeteringApp.General;
using MeteringApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MeteringApp.Classes
{
    class Authorization
    {
        public static void Login(string login, string password)
        {
            using (MeteringAppEntities db = new MeteringAppEntities())
            {
                bool successfull = false;
                foreach (var user in MeteringAppEntities.GetContext().Users)
                {
                    if (login == user.Username && password == user.Password)
                    {
                        successfull = true;
                        DateTime datetime = new DateTime();
                        datetime = DateTime.Now;
                        LoginHistory history = new LoginHistory();
                        history.Datetime = datetime;
                        history.Username = login;
                        history.Successfull = successfull;
                        db.LoginHistory.Add(history);
                        db.SaveChanges();
                        if (user.UserType == 1)
                        {
                            Manager.MainFrame.Navigate(new AdminPage());
                        }
                        else
                        {
                            Manager.MainFrame.Navigate(new AccountantPage());
                        }
                    }
                }
                if (successfull == false)
                {
                    DateTime datetime = new DateTime();
                    datetime = DateTime.Now;
                    LoginHistory history = new LoginHistory();
                    history.Datetime = datetime;
                    history.Username = login;
                    history.Successfull = successfull;
                    db.LoginHistory.Add(history);
                    db.SaveChanges();
                    MessageBox.Show("Введены неверные данные");
                }
            }

        }
    }
}
