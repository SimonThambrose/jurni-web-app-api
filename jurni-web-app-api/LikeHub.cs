using Microsoft.AspNetCore.SignalR;

namespace jurni_web_app_api;

public class LikeHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
    
    public async Task UpdateLikesCount(int blogId, int likesCount)
    {
        await Clients.All.SendAsync("LikesCountUpdated", blogId, likesCount);
    }
}