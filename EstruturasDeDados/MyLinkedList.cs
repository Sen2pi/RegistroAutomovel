using System.Collections;
using RegistroAutomovel_V1.EstruturasDeDados;

namespace RegistroAutomovel_V1.EstruturasDeDados
{
    public class MyLinkedList<T> : IEnumerable
    {
        public Nódulo<T> cabeca;
        public Nódulo<T> cauda;
        private int contador;

        public int Contador
        {
            get { return contador; }
        }
        
        // Metodo que Adiciona um elemento no final da lista.
        public void AdicionarFinal(T data)
        {
            Nódulo<T> novoNódulo = new Nódulo<T>(data);

            if (cabeca == null)
            {
                cabeca = novoNódulo;
                cauda = novoNódulo;
            }
            else
            {
                cauda.Proximo = novoNódulo;
                novoNódulo.Anterior = cauda;
                cauda = novoNódulo;
            }

            contador++;
        }
        
        // Metodo que Adiciona um elemento antes de um elemento existente na lista.
        public void AdicionarAntes(T data, T existingData)
        {
            Nódulo<T> novoNódulo = new Nódulo<T>(data);
            Nódulo<T> atual = cabeca;

            while (atual != null)
            {
                if (atual.Data.Equals(existingData))
                {
                    if (atual.Anterior != null)
                    {
                        atual.Anterior.Proximo = novoNódulo;
                        novoNódulo.Anterior = atual.Anterior;
                    }
                    else
                    {
                        cabeca = novoNódulo;
                    }

                    novoNódulo.Proximo = atual;
                    atual.Anterior = novoNódulo;

                    contador++;
                    return;
                }

                atual = atual.Proximo;
            }

            throw new ArgumentException("Existing data not found in the list.");
        }
        
        // Adiciona um elemento após um elemento existente na lista.
        public void AdicionarDepois(T data, T existingData)
        {
            Nódulo<T> novoNódulo = new Nódulo<T>(data);
            Nódulo<T> atual = cabeca;

            while (atual != null)
            {
                if (atual.Data.Equals(existingData))
                {
                    if (atual.Proximo != null)
                    {
                        atual.Proximo.Anterior = novoNódulo;
                        novoNódulo.Proximo = atual.Proximo;
                    }
                    else
                    {
                        cauda = novoNódulo;
                    }

                    novoNódulo.Anterior = atual;
                    atual.Proximo = novoNódulo;

                    contador++;
                    return;
                }

                atual = atual.Proximo;
            }

            throw new ArgumentException("Existing data not found in the list.");
        }
        
        // Remove a primeira ocorrência de um elemento da lista.
        public bool Remover(Func<T, bool> predicate)
        {
            Nódulo<T> atual = cabeca;

            while (atual != null)
            {
                if (predicate(atual.Data))
                {
                    if (atual.Anterior != null)
                    {
                        atual.Anterior.Proximo = atual.Proximo;
                    }
                    else
                    {
                        cabeca = atual.Proximo;
                    }

                    if (atual.Proximo != null)
                    {
                        atual.Proximo.Anterior = atual.Anterior;
                    }
                    else
                    {
                        cauda = atual.Anterior;
                    }

                    contador--;
                    return true;
                }

                atual = atual.Proximo;
            }

            return false;
        }
        
        
        // Verifica se a lista contém um determinado elemento.
        public bool Contem(Func<T, bool> predicate)
        {
            Nódulo<T> atual = cabeca;

            while (atual != null)
            {
                if (predicate(atual.Data))
                {
                    return true;
                }

                atual = atual.Proximo;
            }

            return false;
        }
        
        // Metodo que adiciona um elemento no inicio da Lista
        public void AdicionarInicio(T data)
        {
            Nódulo<T> novoNódulo = new Nódulo<T>(data);

            if (cabeca == null)
            {
                cabeca = novoNódulo;
                cauda = novoNódulo;
            }
            else
            {
                novoNódulo.Proximo = cabeca;
                cabeca.Anterior = novoNódulo;
                cabeca = novoNódulo;
            }

            contador++;
        }

        // Remove todos os elementos da lista.
        public void Limpar()
        {
            cabeca = null;
            cauda = null;
            contador = 0;
        }
        
        // Obtém o primeiro elemento da lista que corresponde ao predicado fornecido
        public T Obter(Func<T, bool> predicado)
        {
            Nódulo<T> atual = cabeca;

            while (atual != null)
            {
                if (predicado(atual.Data))
                {
                    return atual.Data;
                }

                atual = atual.Proximo;
            }

            throw new InvalidOperationException("Element not found in the list.");
        }
        

        public IEnumerator GetEnumerator()
        {
            Nódulo<T> atual = cabeca;
            while (atual != null)
            {
                yield return atual.Data;
                atual = atual.Proximo;
            }
        }
    }
}