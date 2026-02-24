using System;
using UnityEngine;

namespace SpaceShooter
{

    [Obsolete]    
    public class ExplosionEffect : MonoBehaviour
    {
        [SerializeField] private GameObject m_ExplosionPrefab;
        [SerializeField] private float m_ExplosionDuration;

        private GameObject m_Explosion;
       

        private void Start()
        {
            
        }

        public void InitDamage(int damage)
        {
            
        }

        public void Doll()
        {
            m_Explosion = Instantiate(m_ExplosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(m_Explosion, m_ExplosionDuration);
        }

        public void Explode(Vector3 position, Destructible source, int damage = 0)
        {

            m_Explosion = Instantiate(m_ExplosionPrefab, position, Quaternion.identity);
            Explosion explosion = m_Explosion.GetComponent<Explosion>();
            explosion.SetSourceShip(source);
            explosion.SetDamage(damage);
            //Destroy(m_Explosion, m_ExplosionDuration);
        }

        

        public void Explode(Vector3 position, int damage = 0)
        {
            m_Explosion = Instantiate(m_ExplosionPrefab, position, Quaternion.identity);                       
            Destroy(m_Explosion, m_ExplosionDuration);
        }
    }
}

