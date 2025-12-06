using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    private bool scored = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (scored) return;
        if (other.CompareTag("Player"))
        {
            scored = true;
            Debug.Log("+1 to score");
        }
    }
}
