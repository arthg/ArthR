using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ArthR.Hubs
{
    public sealed class Broadcaster : Hub
    {
        public Task Send(string data)
        {
            return Clients.All.InvokeAsync("Send", data);
        }
    }
}
