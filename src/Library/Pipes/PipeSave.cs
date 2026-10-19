//------------------------------------------------------------------------------
// <copyright file="PipeNull.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------
namespace Ucu.Poo.PipesAndFilters.Pipes
{
    public class PipeSave : IPipe
    {
        public PipeSave(IPipe nextPipe, string path)
        {
            this.NextPipe = nextPipe;
            this.Path = path;
        }
        public IPipe NextPipe { get; protected set; }
        public string Path { get; protected set; }

        public IPicture Send(IPicture picture)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(picture, Path);
            return this.NextPipe.Send(picture);
        }
    }
}