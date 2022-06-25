using UnityEngine;

public class BallController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var point = collision.transform.GetComponent<PointCenterController>();
        
        if (point != null)
        {
            point.OnHit();
        }

        if (collision.gameObject.CompareTag($"DeadCollider"))
        {
            GameManager.Instance.OnGameOver();
        }
    }
}