
using System;
using Ucu.Poo.Cognitive;

namespace Ucu.Poo.PipesAndFilters.Filters
{
    public class FilterFace : IConditionalFilter
    {
        public bool Result { get; private set; }

        public IPicture Filter(IPicture picture)
        {
            // Guardamos la imagen para que CognitiveFace pueda leerla.
            PictureProvider provider = new PictureProvider();
            string path = "imagen_para_reconocer.jpg";
            provider.SavePicture(picture, path);

            // Obtenemos la clave de Azure.
            string subscriptionKey = Environment.GetEnvironmentVariable(
                "AZURE_FACE_SUBSCRIPTION_KEY");

            if (string.IsNullOrWhiteSpace(subscriptionKey))
            {
                throw new InvalidOperationException(
                    "Falta la clave de Azure Face.");
            }

            // Analizamos la imagen.
            CognitiveFace faceApi = new CognitiveFace();
            CognitiveFace.RecognitionResult result =
                faceApi.Recognize(path, true);

            // Guardamos el resultado de la condición.
            this.Result = result.Success && result.FaceFound;

            // Devolvemos la imagen para continuar el pipeline.
            return picture;
        }
    }
}
