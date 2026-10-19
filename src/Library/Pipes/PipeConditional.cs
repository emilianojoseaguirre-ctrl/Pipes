//------------------------------------------------------------------------------
// <copyright file="PipeNull.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------
using Ucu.Poo.PipesAndFilters.Filters;

namespace Ucu.Poo.PipesAndFilters.Pipes
{
    public class PipeConditional : IPipe
    {
        public IConditionalFilter Filter { get; protected set; }

        public IPipe TruePipe { get; protected set; }

        public IPipe FalsePipe { get; protected set; }

        public PipeConditional(
            IConditionalFilter filter,
            IPipe truePipe,
            IPipe falsePipe)
        {
            this.Filter = filter;
            this.TruePipe = truePipe;
            this.FalsePipe = falsePipe;
        }

        public IPicture Send(IPicture picture)
        {
            IPicture result = this.Filter.Filter(picture);

            if (this.Filter.Result)
            {
                return this.TruePipe.Send(result);
            }
            else
            {
                return this.FalsePipe.Send(result);
            }
        }
    }
}