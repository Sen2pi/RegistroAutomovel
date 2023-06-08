using System.Text;
using RegistroAutomovel_V1.HashGenericas;

public class ListaLigadaSimples<T>
    {
        public Elemento<T> cabeca;

        public ListaLigadaSimples()
        {
            cabeca = null;
        }

        public void AdicionarFinal(T nova)
        {
            if (cabeca == null)
                cabeca = new Elemento<T> { Valor = nova, Proximo = null };
            else
            {
                Elemento<T> aux = cabeca;
                while (aux.Proximo != null)
                    aux = aux.Proximo;
                aux.Proximo = new Elemento<T> { Valor = nova, Proximo = null };
            }
        }

        public bool Remover(T coisa)
        {
            if (cabeca != null)
            {
                if (cabeca.Valor.Equals(coisa)) // if found (first element)
                {
                    cabeca = cabeca.Proximo;
                    return true;
                }
                else
                {
                    Elemento<T> ant = cabeca;
                    Elemento<T> aux = ant.Proximo;
                    while (aux != null && !aux.Valor.Equals(coisa))
                    {
                        ant = aux;
                        aux = aux.Proximo;
                    }
                    if (aux != null) // if found (in the middle or end)
                    {
                        ant.Proximo = aux.Proximo;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.AppendLine("-------------- inicio -------------");
            Elemento<T> aux = cabeca;
            while (aux != null)
            {
                res.AppendLine(aux.Valor.ToString());
                aux = aux.Proximo;
            }
            res.AppendLine("-------------- fim -------------");
            return res.ToString();
        }
    }