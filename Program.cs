using System.Diagnostics;

namespace TanganKananMandor
{
    internal class Program
    {
        private static Timer timer;
        private static bool keyPressed = false;
        public static async Task Main(string[] args)
        {

            timer = new Timer(TimerCallback, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));


            // Replace "YOUR_BOT_TOKEN" with your actual bot token
            //string botToken = "YOUR_BOT_TOKEN";

            // Replace "CHAT_ID" with the chat ID of the user or group you want to send the message to

            //string chatId = await TelegramBotClient.GetChatIdAsync();

            //Console.WriteLine($"Chat ID: {chatId}");

            //Console.ReadKey();
            Console.ReadKey(true);
            timer.Dispose();
            keyPressed = true;

            //string chatId = "-1001702913144";

            //string message = "Hello. I'm alive now.";

            //await TelegramBotClient.SendMessageAsync(chatId, message);
            //Console.ReadKey();
        }
        private static async void TimerCallback(object state)
        {
            if (!keyPressed)
            {
                var serviceDetector = new ServiceDetector();
                var listServiceState = serviceDetector.Execute();
                string chatId = "-1001702913144";

                await TelegramBotClient.SendMessageAsync(chatId, listServiceState);


                Console.WriteLine(listServiceState);
            }
        }

        //static void Main(string[] args)
        //{


        //    Process[] runningProcesses = Process.GetProcesses();

        //    foreach (Process process in runningProcesses)
        //    {
        //        Console.WriteLine($"Process Name: {process.ProcessName}, Process ID: {process.Id}");
        //    }
        //    Console.ReadKey();
        //}


    }
}