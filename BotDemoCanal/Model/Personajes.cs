using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BotDemoCanal.Extension;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace BotDemoCanal.Model
{
    [Serializable]
    public class Personajes
    {
        public String Nombre { get; set; }
        public string Foto { get; set; }
        public string Bio { get; set; }
        public string Trabajo { get; set; }

        public Personajes() { }

        public Personajes(string nombre, string foto, string bio, string trabajo)
        {
            Nombre = nombre;
            Foto = foto.Image2Base64();
            Bio = bio;
            Trabajo = trabajo;
        }

        public Attachment ToAttachment(IDialogContext context)
        {
            HeroCard hc = new HeroCard()
            {
                Title = Nombre,
                Subtitle = Trabajo,
                Text = Bio,
                Images = new List<CardImage>()
        {
            new CardImage()
            {

                Url = Foto
            }
        }
            };

            return hc.ToAttachment();
        }
        public IMessageActivity ToMessage(IDialogContext context)
        {
            var reply = context.MakeMessage();
            reply.Attachments = new List<Attachment>
    {
            ToAttachment(context)
    };

            return reply;
        }
    }
}