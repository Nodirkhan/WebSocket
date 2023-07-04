using Microsoft.AspNet.SignalR;
using SignalRServer.Services;

namespace SignalRServer.Hubs
{
    public class MainHub : Hub
    {
        public void StartSync()
        {
            ProcessService.StartAsync(5000,
                () => Clients.All.StartSync($"Main hub status: {ProcessService.GetState().ToString()}"));

            Clients.Caller.StartSync("MainHub is starting");
        }

        public void GetState()
        {
            Clients.Caller.GetState(ProcessService.GetState().ToString());
        }
    }
}
