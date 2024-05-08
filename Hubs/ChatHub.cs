using Microsoft.AspNetCore.SignalR;
using SignalrD1.Models;
namespace SignalrD1.Hubs
{
    /*public interface IChatHub { }*/

    public class ChatHub:Hub
    {
        ITIContext db;
        public ChatHub(ITIContext db)
        {
            this.db = db; 
        }

        #region day1
        public async Task sendmessage(chatmessage mess)
        {
            //broadcasting to all online clients
            await Clients.All.SendAsync("newmessage",mess);
            
            await db.chatmessages.AddAsync(mess);
            await db.SaveChangesAsync();
        }
        #endregion


        public async Task joingroup(string groupname, string username)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupname);
            await Clients.OthersInGroup(groupname)
                         .SendAsync("newmemberjoinednotification", username, groupname);
        }
        
        public async Task sendmessagetogroup(string groupname, chatmessage chatmessage)
        {
            await Clients.Group(groupname).SendAsync("sendmessagetomygroup",groupname, chatmessage);
        }
    }
}
