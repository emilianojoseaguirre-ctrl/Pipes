
using System;
using Ucu.Poo.Discord;

namespace Ucu.Poo.PipesAndFilters.Pipes
{
    public class PipeDiscord : IPipe
    {
        public IPipe NextPipe { get; protected set; }

        public PipeDiscord(IPipe nextPipe)
        {
            this.NextPipe = nextPipe;
        }

        public IPicture Send(IPicture picture)
        {
            string token = Environment.GetEnvironmentVariable("DISCORD_BOT_TOKEN");
            string channel = Environment.GetEnvironmentVariable("CHANNEL_ID");

            if (string.IsNullOrWhiteSpace(token) ||
                string.IsNullOrWhiteSpace(channel))
            {
                throw new InvalidOperationException(
                    "Faltan las credenciales de Discord.");
            }

            PictureProvider provider = new PictureProvider();
            provider.SavePicture(picture, "discord_image.jpg");

            DiscordClient discord = new DiscordClient();
            discord.Login(token);

            ulong channelId = ulong.Parse(channel);
            discord.SendImage(
                channelId,
                "discord_image.jpg",
                "Imagen procesada con Pipes & Filters");

            return this.NextPipe.Send(picture);
        }
    }
}
