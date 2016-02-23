using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pigpo
{
    public class GameHub : Hub
    {
        public static Dictionary<string, Player> players = new Dictionary<string, Player>();

        public void moveOnAllClients(string name)
        {
            Clients.All.hello();
        }

        public void addPlayer(string name)
        {
            Player player = new Player();
            player.connectionId = Context.ConnectionId;
            player.name = name;
            player.position = new Position();
            player.position.x = 25;
            player.position.y = 25;
            player.left = 0;
            player.up = 0;
            player.right = 0;
            player.bottom = 0;

            players.Add(Context.ConnectionId, player);

            // Let all online players know about our new player
            Clients.Others.addPlayer(player.name, player.position.x, player.position.y);
        }

        public void getOtherPlayers()
        {
            // Get players on the map for the caller
            foreach(KeyValuePair<string, Player> player in players)
            {
                Clients.Caller.addPlayer(player.Value.name, player.Value.position.x, player.Value.position.y);
            }
        }

        public void updatePos(string name, string direction, int x, int y)
        {
            if (players.ContainsKey(Context.ConnectionId))
            {
                Player player = players[Context.ConnectionId];

                player.position.x = x;
                player.position.y = y;

                Clients.Others.movePlayer(player.name, direction);
            }
        }

        public void sayToAll(string name, string message)
        {
            Clients.All.sayToAll(name, message);
        }
    }
}