using UnityEngine;

public class limitemap : MonoBehaviour
{
    public GameManagerScript GameManager;
    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            Destroy(other.gameObject);
            GameManager.gameOver();

            
            Debug.Log("El jugador ha sido destruido.");
        }
    }
}
