using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WOLF.Net.Commands.Attributes;
using WOLF.Net.Commands.Commands;
using WOLF.Net.Enums.Messages;

namespace TempProject.Commands
{
    //-------- هنا سوينا الامر حقنا الاساسي اللي هو !تجربة ----------
    [Command("!تجربة"), RequiredMessageType(MessageType.GROUP)]
    //-------- RequiredMessageType(MessageType.GROUP) - هنا نقول للبوت هذا الاوامر في العام فقط
    //-------- RequiredMessageType(MessageType.PRIVATE) - يمكنك استبدالها بهذا السطر لجعل البوت يستقبل الاوامر في الخاص فقط
    //-------- RequiredMessageType(MessageType.BOTH) - يمكنك استبدالها بهذا السطر لجعل البوت يستقبل الاوامر في العام والخاص بنفس الوقت
    //------------------------------------
    class Main : CommandContext
    {
        //-------- [Command] تعني انه سيقوم البوت بالرد على اي شخص يقوم بارسال !تجربة برسالة المساعدة هذه ----------
        [Command]
        //-------- Default هذا اسم الفنكشن(function) - ملاحظة قد يتم اعادة تسميتها لأي اسم اخر ----------
        public async Task Default()
        {
            await ReplyAsync("هذه قائمة المساعدة لأول بوت لك :X" +
                 "\n\n!تجربة مساعدة - لعرض هذه الرسالة" +
                   "\n\n!تجربة قل <الكلمة> - سيقوم البوت بارسال الكلمة في العام" +
                     "\n\n!تجربة عدد <الرقم الاول> - لتجربة تحويل الارقام لعدد صحيح");
        }

        //-------- هنا سوينا امر فرعي اسمه مساعدة, سيتفعل الامر عند كتابة !تجربة مساعدة ----------
        [Command("مساعدة")]
        public async Task Help()
        {
            await ReplyAsync("هذه قائمة المساعدة لأول بوت لك :X" +
                  "\n\n!تجربة مساعدة - لعرض هذه الرسالة" +
                    "\n\n!تجربة قل <الكلمة> - سيقوم البوت بارسال الكلمة في العام" +
                      "\n\n!تجربة عدد <الرقم الاول> - لتجربة تحويل الارقام لعدد صحيح");
        }


        //-------- هنا سوينا امر فرعي اسمه قل, سيتفعل الامر عند كتابة !تجربة قل ----------
        [Command("قل")]
        public async Task Say()
        {
            // Command.Argument هذا يحتوي على اي نص مكتوب بعد كلمة قل
            // مثال: !تجربة قل مرحبا
            // Command.Argument - ستكون مرحبا

            // هنااضفنا شرط تحقق ما إذا كان المستخدم لم يقم بكتابة نص او رقم
            if (string.IsNullOrEmpty(Command.Argument) || string.IsNullOrWhiteSpace(Command.Argument))
            {
                // سيقوم البوت بالرد بهذه الرسالة عند تحقق الشرط
                await ReplyAsync("(N) عذراً لم تقم بادخال اي نص");
            }
            // اذا المستخدم ادخل نص او عدد سيتفعل السطر الذي بالاسفل
            else
            {
                // سيقوم البوت بكتابة نفس النص المدخل عند كتابة امر قل
                await ReplyAsync($"{Command.Argument}");
            }
        }

        //-------- هنا سوينا امر فرعي اسمه عدد, لمن يكتب شخص !تجربة عدد سيتفعل NumberSplit ----------
        [Command("عدد")]
        public async Task NumberSplit()
        {

            // هنااضفنا شرط تحقق ما إذا كان المستخدم لم يقم بكتابة عدد او رقم
            if (string.IsNullOrEmpty(Command.Argument) || string.IsNullOrWhiteSpace(Command.Argument))
            {
                // سيقوم البوت بالرد بهذه الرسالة عند تحقق الشرط
                await ReplyAsync("الرجاء ادخال رقم صحيح");
            }
            // اذا المستخدم ادخل عدد او نص سيتفعل السطر الذي بالاسفل
            else
            {
                // هنا اضفنا امر شرطي للتحقق ما إذا كان النص المدخل هو فعلا عدد صحيح
                if (int.TryParse(Command.Argument,out int result))
                {
                    await ReplyAsync($"{result} ادخال صحيح (Y)");
                }
                else
                {
                    // سيقوم البوت بالرد بهذه الرسالة عند عدم تحقق الشرط
                    await ReplyAsync("الرجاء ادخال رقم صحيح");
                }
            }
        }
    }
}
