using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanganKananMandor
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public static class TelegramBotClient
    {
        private const string BotToken = "6385988071:AAHHhtaoNdvd2KCOQEgOjkTA5Uf5J2Sb99g";
        private const string BaseUrl = "https://api.telegram.org/bot";

        public static async Task SendMessageAsync(string chatId, string message)
        {
            string url = $"{BaseUrl}{BotToken}/sendMessage";

            using (HttpClient client = new HttpClient())
            {
                var parameters = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("chat_id", chatId),
                new KeyValuePair<string, string>("text", message)
            });

                await client.PostAsync(url, parameters);
            }
        }
        public static async Task<string> GetChatIdAsync()
        {
            string url = $"{BaseUrl}{BotToken}/getUpdates";

            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(url);
                // Parse the JSON response to get the chat ID
                // You can use a JSON parsing library like Newtonsoft.Json
                // to extract the necessary information from the response
                // Example: string chatId = ParseChatIdFromResponse(response);
                string chatId = "YOUR_CHAT_ID";
                return chatId;
            }
        }
    }

}
