using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] GameData gameData;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null) { Destroy(gameObject); return; }

        if (!other.gameObject.CompareTag("Player")) return;

        GameManager._instance.IncrementScore();
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(0, 0, gameData._coinTurnSpeed * Time.deltaTime);
    }
}
