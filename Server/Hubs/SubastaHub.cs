using System;
using System.Threading.Tasks;
using BlazorSubasta.Shared;
using Microsoft.AspNetCore.SignalR;

namespace BlazorSubasta.Server.Hubs
{
    public class SubastaHub : Hub
    {

        public async Task UnirseSubasta(string subastaId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, subastaId);
            await Clients.Group(subastaId).SendAsync("NuevoComprador", subastaId, Context.ConnectionId);
        }


        public async Task EnviarPuja(Puja puja)
        {
            puja.Id = Guid.NewGuid().ToString();
            puja.Fecha = DateTime.Now;
            await Clients.Group(puja.SubastaId).SendAsync("PujaEnviada", puja);
        }


        public async Task DejarSubasta(string subastaId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, subastaId);
            await Clients.Group(subastaId).SendAsync("SalioComprador");
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }



    }
}