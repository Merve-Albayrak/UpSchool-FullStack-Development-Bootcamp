
using Application.Common.Models.Dtos;
using Microsoft.AspNetCore.SignalR;

namespace WebAPI.Hubs
{
    public class OrderHub:Hub
    {
        //bağlı olan kullanıcılara bilgi yol
        //CLİENTLER BURADAKİ METODLARI ÇALIŞTIRABİLİR

        public async Task SendLogNotification(LogDto logDto)
        {

            await Clients.AllExcept(Context.ConnectionId).SendAsync("NewLog", logDto);

        }
    }
}
