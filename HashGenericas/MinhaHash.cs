using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAutomovel_V1.HashGenericas {
    public class MinhaHash<T>
    {
        const int tam = 6;
        const int proxPrimo = 11;
        private ListaLigadaSimples<T>[] entradas;

        public MinhaHash()
        {
            entradas = new ListaLigadaSimples<T>[tam];
            for (int i = 0; i < tam; i++)
                entradas[i] = new ListaLigadaSimples<T>();
        }

        public bool Adicionar(T novo)
        {
            int pos = hash(novo.GetHashCode());
            entradas[pos].AdicionarElementoFim(novo);
            return false;
        }

        public bool Procurar(T item)
        {
            int pos = hash(item.GetHashCode());
            Elemento<T> aux = entradas[pos].cabeca;
            while (aux != null)
            {
                if (aux.Valor.Equals(item))
                    return true;
                aux = aux.Proximo;
            }
            return false;
        }

        public void ObterTodos()
        {
            for (int i = 0; i < tam; i++)
            {
                Console.WriteLine($"==> {i}");
                Console.WriteLine(entradas[i].ToString());
            }
        }

        public bool Remover(T item)
        {
            int pos = hash(item.GetHashCode());
            return entradas[pos].RetirarDaFila(item);
        }
        
        public bool Contem(T item)
        {
            int pos = hash(item.GetHashCode());
            Elemento<T> aux = entradas[pos].cabeca;
            while (aux != null)
            {
                if (aux.Valor.Equals(item))
                    return true;
                aux = aux.Proximo;
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            for (int i = 0; i < tam; i++)
            {
                res.AppendLine($" ==> {i}");
                res.AppendLine(entradas[i].ToString());
            }
            return res.ToString();
        }

        private int hash(int chave)
        {
            return (chave % proxPrimo) % tam;
        }
    }
}
    

