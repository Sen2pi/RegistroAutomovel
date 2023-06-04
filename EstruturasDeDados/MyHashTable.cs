using RegistroAutomovel_V1.Modelo;

namespace RegistroAutomovel_V1.EstruturasDeDados;

using System;
using System.Collections.Generic;

public class MyHashTable<TKey, TValue>
{
    private const int tamanho = 10;
    private KeyValuePair<TKey, TValue>[] caixas;

    public MyHashTable()
    {
        caixas = new KeyValuePair<TKey, TValue>[tamanho];
    }

    public KeyValuePair<TKey, TValue>[] ObterTodos()
    {
        List<KeyValuePair<TKey, TValue>> lista = new List<KeyValuePair<TKey, TValue>>();

        foreach (KeyValuePair<TKey, TValue> par in caixas)
        {
            if (!EqualityComparer<TKey>.Default.Equals(par.Key, default(TKey)))
            {
                lista.Add(par);
            }
        }

        return lista.ToArray();
    }

    public void Adicionar(TKey key, TValue value)
    {
        int index = GetIndex(key);

        if (EqualityComparer<TKey>.Default.Equals(caixas[index].Key, default(TKey)))
        {
            caixas[index] = new KeyValuePair<TKey, TValue>(key, value);
        }
        else
        {
            throw new ArgumentException("An element with the same key already exists in the HashTable.");
        }
    }

    public bool Remover(TKey key)
    {
        int index = GetIndex(key);

        if (EqualityComparer<TKey>.Default.Equals(caixas[index].Key, default(TKey)))
        {
            return false;
        }
        else
        {
            caixas[index] = new KeyValuePair<TKey, TValue>();
            return true;
        }
    }

    public TValue Obter(TKey key)
    {
        int index = GetIndex(key);

        if (EqualityComparer<TKey>.Default.Equals(caixas[index].Key, default(TKey)))
        {
            throw new KeyNotFoundException("The specified key was not found in the HashTable.");
        }
        else
        {
            return caixas[index].Value;
        }
    }

    public bool ContainsKey(TKey key)
    {
        int index = GetIndex(key);
        return !EqualityComparer<TKey>.Default.Equals(caixas[index].Key, default(TKey));
    }

    private int GetIndex(TKey key)
    {
        int hash = key.GetHashCode();
        int index = Math.Abs(hash % caixas.Length);
        return index;
    }
}
