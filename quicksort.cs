using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 7, 5, 3, 8, 2, 6, 9, 1, 4 };
        QuickSort(arr, 0, arr.Length - 1);
        Console.WriteLine("Sorted array:");
        for (int i = 0; i < arr.Length; ++i)
            Console.Write(arr[i] + " ");
    }

    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high) // si la liste contient plus d'un élément
        {
            int pivotIndex = Partition(arr, low, high); // partitionne la liste autour d'un pivot
            QuickSort(arr, low, pivotIndex - 1); // trie la partie gauche du pivot
            QuickSort(arr, pivotIndex + 1, high); // trie la partie droite du pivot
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivotValue = arr[high]; // sélectionne le dernier élément de la liste comme pivot
        Dictionary<int, int> map = new Dictionary<int, int>(); // crée un HashMap pour stocker le nombre d'occurrences de chaque élément
        for (int i = low; i < high; ++i)
        {
            if (!map.ContainsKey(arr[i])) 
                map[arr[i]] = 0; 
            map[arr[i]]++; 
        }
        for (int i = low; i < high; ++i)
        {
            if (arr[i] < pivotValue) // si l'élément courant est inférieur au pivot
            {
                if (map[arr[i]] == 1) // si l'élément est unique dans la liste
                    arr[low++] = arr[i]; // déplace l'élément à la position de gauche du pivot
                else 
                    map[arr[i]]--; 
        }
        int pivotIndex = low; // détermine la position finale du pivot
        arr[high] = arr[low]; // place le pivot à sa position finale
        arr[low] = pivotValue;
        return pivotIndex; // retourne la position finale du pivot
    }
}
