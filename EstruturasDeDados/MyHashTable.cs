using System.Collections.Generic;
using System.Text;

namespace RegistroAutomovel_V1.EstruturasDeDados
{
    public class MyHashTable<TKey, TValue>
    {
        private const int tam = 10;
        private const int proxPrimo = 11;
        private MyLinkedList<KeyValuePair<TKey, TValue>>[] entradas;

        public MyHashTable()
        {
            // Inicializar as entradas da tabela de hash
            entradas = new MyLinkedList<KeyValuePair<TKey, TValue>>[tam];
            for (int i = 0; i < tam; i++)
                entradas[i] = new MyLinkedList<KeyValuePair<TKey, TValue>>();
        }

        
        public void Adicionar(TKey chave, TValue valor)
        {
            int pos = Hash(chave);
            entradas[pos].AdicionarFinal(new KeyValuePair<TKey, TValue>(chave, valor));
        }

        public TValue Obter(TKey chave)
        {
            int pos = Hash(chave);
            MyLinkedList<KeyValuePair<TKey, TValue>> listaEncadeada = entradas[pos];
            foreach (KeyValuePair<TKey, TValue> par in listaEncadeada)
            {
                if (par.Key.Equals(chave))
                    return par.Value;
            }
            throw new KeyNotFoundException($"A chave '{chave}' não foi encontrada na tabela de hash.");
        }

        public KeyValuePair<TKey, TValue>[] ObterTodos()
        {
            List<KeyValuePair<TKey, TValue>> lista = new List<KeyValuePair<TKey, TValue>>();
            foreach (MyLinkedList<KeyValuePair<TKey, TValue>> listaEncadeada in entradas)
            {
                foreach (KeyValuePair<TKey, TValue> par in listaEncadeada)
                {
                    lista.Add(par);
                }
            }
            return lista.ToArray();
        }

        public bool Remover(TKey chave)
        {
            int pos = Hash(chave);
            MyLinkedList<KeyValuePair<TKey, TValue>> listaEncadeada = entradas[pos];
            bool removido = listaEncadeada.Remover(par => par.Key.Equals(chave));
            return removido;
        }

        public bool Contem(TKey chave)
        {
            int pos = Hash(chave);
            MyLinkedList<KeyValuePair<TKey, TValue>> listaEncadeada = entradas[pos];
            bool contem = listaEncadeada.Contem(par => par.Key.Equals(chave));
            return contem;
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

        private int Hash(TKey chave)
        {
            int hashCode = chave.GetHashCode();
            return (hashCode % proxPrimo) % tam;
        }
    }
}
