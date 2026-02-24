using Common;
using UnityEngine;

namespace SpaceShooter
{
    public class Projectile : ProjectileBase
    {

        [SerializeField] private ImpactEffect m_ImpactEffectPrefab;
        protected override void OnHit(DestructibleBase destructibleBase)
        {
            
            if (m_Parent == Player.Instance.ActiveShip)
            {
               
                Player.Instance.AddScore(((Destructible) destructibleBase).ScoreValue);

                if (destructibleBase is SpaceShip)
                {
                    if (destructibleBase.HitPoints <= 0)
                        Player.Instance.AddKill();


                }
                
            }
        }

        protected override void OnProjectileLifeEnd(Collider2D col, Vector2 pos)
        {
            

            if (m_ImpactEffectPrefab != null)
            {
                

                ImpactEffect impact = Instantiate(m_ImpactEffectPrefab, pos, Quaternion.identity);

                
                Explosion explosion = impact.GetComponent<Explosion>();
                explosion.SetSourceShip((Destructible)m_Parent);
                explosion.SetDamage(m_Damage);
            }
                

            

            Destroy(gameObject, 0);

            
        }


  
    } 


}

