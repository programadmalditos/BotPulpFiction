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
    public class Ubicaciones
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Foto { get; set; }

        public Ubicaciones() { }

        public Ubicaciones(string nombre, string foto, string descripcion)
        {
            Nombre = nombre;
            Foto = foto.Image2Base64();
            Descripcion = descripcion;
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
        public Attachment ToAttachment(IDialogContext context)
        {
            HeroCard hc = new HeroCard()
            {
                Title = Nombre,
                Text = Descripcion,
                Images = new List<CardImage>()
        {
            new CardImage()
            {

                Url =   Foto
            }
        }
            };

            return hc.ToAttachment();
        }

    }
}