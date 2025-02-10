using UnityEngine;

public class ennemy : MonoBehaviour
{
    public ContactPoint2D[] listContacts = new ContactPoint2D[1];
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetContacts(listContacts);

            if (listContacts[0].normal.y < -0.5f)
            {
                Debug.Log("Eliminé !");
                Destroy(gameObject);
            }



            else
            {
                playerhealth Health = other.gameObject.GetComponent<playerhealth>();
                Health.Hurt();
                Debug.Log("Touché");
            }
        }
    }
}
