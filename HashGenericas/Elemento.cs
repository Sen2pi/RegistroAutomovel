using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RegistroAutomovel_V1.HashGenericas {
    public class Elemento<T>
    {
        private T valor;
        private Elemento<T> proximo;

        public Elemento() { }

        public T Valor { get => valor; set => valor = value; }
        public Elemento<T> Proximo { get => proximo; set => proximo = value; }

        public override string ToString()
        {
            return valor.ToString();
        }
    }
}
