using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monscript : MonoBehaviour
{
    string DireBonjour(string nom)
{
    return "Bonjour " + nom;  // Retourne "Bonjour" + nom
}
    // Start is called before the first frame update
    void Start()
    {
        float monDecimal = 3.14f;  // Nombre décimal
        Debug.Log(monDecimal);
        string maChaine = "Bonjour Unity!";  // Chaîne de caractères
        Debug.Log(maChaine);
        int[] tableau = { 1, 2, 3, 4, 5 };  // Tableau de nombres
        Debug.Log(tableau); 
         string message = DireBonjour("Lucas");  // Appel de la fonction
         Debug.Log(message);  // Affiche le message
    }

    // Update is called once per frame
    void Update()
{
    if (Input.GetKeyDown(KeyCode.Space))  // Si la touche Espace est pressée
    {
        Debug.Log("Touche appuyée !");
    }
}

}
