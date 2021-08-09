using System;
using System.Threading.Tasks;
using WOLF.Net;
using WOLF.Net.Entities.API;
using WOLF.Net.Enums.API;

namespace TempProject
{
    public class Program
    {
        //-------- هنا سوينا البوت ----------
        public static WolfBot Bot = new WolfBot(new Configuration(false, true));
        //new Configuration(false, true) --- هنا يعني البوت راح يستخدم الاعدادات التالية:
        // false يعني استخدم لغة واحدة فقط
        // true تجاهل جميع البوتات الرسمية
        //------------------------------------

        public static void Main(string[] args)
            => new Program().Main().GetAwaiter().GetResult();

        public async Task Main()
        {
            // هنا اشتركنا في (حدث) الحدث هذا يتفعل لمن البوت يسجل دخول بنجاح راح يكتب لنا انه سجل دخول ويحط اسم البوت
            Bot.On.LoginSuccess += user => Console.WriteLine($"Logged in as {user.Nickname}");

            // هنا اشتركنا في (حدث) راح يتفعل لمن البوت يكون جاهز للاستخدام
            Bot.On.Ready += () => Console.WriteLine("Ready for use");

            // هنا الايميل والباسورد المراد ربط البوت به
            await Bot.LoginAsync("xyz@mail.com", "123", LoginDevice.ANDROID);
            await Task.Delay(-1);
        }
    }
}
