using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Вода выталкивает тела и обладает сопротивлением движению.
    /// </summary>
    [RequireComponent(typeof(CircleCollider2D))]
    public class Water : MonoBehaviour
    {
        [SerializeField] private float m_BuoyantForce;
        [SerializeField] private GameObject m_PlanetVisualModel;
        [SerializeField] private float m_Drag;

        
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.attachedRigidbody == null) return;

            Rigidbody2D rigid = collision.attachedRigidbody;

            Vector2 dir = collision.transform.position - transform.position;         
            Vector2 buoyForce = dir.normalized * m_BuoyantForce;

            rigid.AddForce(buoyForce, ForceMode2D.Force);

            Vector2 dragForce = new Vector2(0, m_Drag);

            Vector2 linVel = rigid.linearVelocity;
            
            rigid.AddRelativeForce(linVel * (-dragForce) * Time.fixedDeltaTime, ForceMode2D.Force);
        }
    }
}

