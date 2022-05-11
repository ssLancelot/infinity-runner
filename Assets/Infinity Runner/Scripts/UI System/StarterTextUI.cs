using UnityEngine;

public class StarterTextUI : MonoBehaviour
{
    internal TMPro.TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    private void Start()
    {
        _text.text = "Press Any Key";
    }
}
