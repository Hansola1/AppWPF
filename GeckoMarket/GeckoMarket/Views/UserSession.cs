using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeckoMarket.Views
{
    public static class UserSession //Используйте Singleton или статический класс для хранения состояния пользователя. Чтоб вход в аккаунт был тру
    {
        public static bool IsLoggedIn { get; set; }
        public static bool Visitor {  get; set; }
        public static string CurrentUserLogin { get; set; }
    }
}
