using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    //Só pode ser herdada - Todos Herdam dela
    public abstract class Base
    {
        public long Id{ get; set; }

        internal List<string> _errors;

        //Apenas consegue leros Errors pq ele reflete o _errors O cara que acessar por fora só vai conseguir ler
        public IReadOnlyCollection<string> Errors => _errors;  

        public abstract bool Validate();
    }
}
