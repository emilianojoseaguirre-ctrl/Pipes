//------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------
using Ucu.Poo.PipesAndFilters.Filters;
using Ucu.Poo.PipesAndFilters.Pipes;

namespace Ucu.Poo.PipesAndFilters
{
    /// <summary>
    /// Programa principal.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {

            PipeNull pipeNull = new PipeNull();

            // Camino TRUE: escala de grises
            PipeSave saveTrue = new PipeSave(pipeNull, "con_cara.jpg");
            PipeSerial truePipe = new PipeSerial(new FilterGrayscale(), saveTrue);

            // Camino FALSE: negativo
            PipeSave saveFalse = new PipeSave(pipeNull, "sin_cara.jpg");
            PipeSerial falsePipe = new PipeSerial(new FilterNegative(), saveFalse);

            // Filtro que evalúa la condición
            FilterFace faceFilter = new FilterFace();

            // Pipe que decide qué camino seguir
            PipeConditional conditional = new PipeConditional(
                faceFilter,
                truePipe,
                falsePipe);

            // Cargar imagen y ejecutar
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");

            conditional.Send(picture);
        }

        // PipeNull pipeNull = new PipeNull();
        // PipeDiscord discord = new PipeDiscord(pipeNull);
        // PipeSave save2 = new PipeSave(pipeNull, "save2.jpg");
        // PipeSerial pipeSerial2 = new PipeSerial(new FilterNegative(), save2);
        // PipeSave save1 = new PipeSave(pipeSerial2, "save1.jpg");
        // PipeSerial pipeSerial1 = new PipeSerial(new FilterGrayscale(), save1);

        // PictureProvider provider = new PictureProvider();
        // IPicture picture = provider.GetPicture(@"luke.jpg");

        // IPicture result = pipeSerial1.Send(picture);
        // provider.SavePicture(result, "PathToNewImage.jpg");

    }
}
