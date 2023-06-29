using Microsoft.AspNetCore.SignalR;

namespace jurni_web_app_api;

public class SignalRHub : Hub
{
    public async Task UpdateBlogLikes(int blogId, int likes)
    {
        await Clients.All.SendAsync("BlogLikesUpdated", blogId, likes);
    }
}