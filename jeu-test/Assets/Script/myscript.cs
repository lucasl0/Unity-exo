using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Bonjour");
        
        // On précise qu'on retourne un entier avec int avant le nom de la fonction
        int Addition(int num1, int num2)
        {
            return num1 + num2;
            }
            int sum = Addition(5, 6);
            Debug.Log("Résultat somme : " + sum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
