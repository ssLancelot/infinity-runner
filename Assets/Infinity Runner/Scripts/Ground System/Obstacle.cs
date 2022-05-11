using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerController _player;

    private void Start()
    {
        _player = GameObject.FindObjectOfType<PlayerController>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
            _player.Die();
    }
}
