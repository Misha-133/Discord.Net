using Discord.Net.V4.WebSocket.State.Handles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.WebSocket.Dispatchers
{
    internal class LegacyEventDispatcher<T> : IEventDispatcher<T>
        where T : Delegate
    {
        public async Task DispatchAsync(T func, params IEntityHandle[] entities)
        {
            var result = func.DynamicInvoke(entities);

            if(result is Task task)
            {
                await task;
            }
        }
    }
}
