using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 1f; 
    private bool isDestroyed = false;

    void Start()
    {
        Invoke(nameof(DestroySelf), _lifeTime);
    }

    void OnMouseDown()
    {
        if (isDestroyed) return;

        isDestroyed = true;

        GameManager.Instance.AddScore(1);

        Destroy(gameObject);
    }

    void DestroySelf()
    {
        if (isDestroyed) return;

        isDestroyed = true;

        Destroy(gameObject);
    }
}
