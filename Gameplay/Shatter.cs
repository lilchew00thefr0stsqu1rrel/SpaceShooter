using UnityEngine;

namespace SpaceShooter
{
    public class Shatter : MonoBehaviour
    {
        [SerializeField] private Transform m_ShardPrefab;
        [SerializeField] private int m_ShardAmount;
        [SerializeField] private float m_ShardOffset;

        private int m_HitPoints;



        /// <summary>
        /// Надо: OnZeroHitpoints
        /// </summary>
        public void SpawnShards()
        {
            Debug.Log("Shatter!!!");
            for (int i = 0; i < m_ShardAmount; i++)
            {
                Instantiate(m_ShardPrefab, transform.position + new Vector3((i - (m_ShardAmount - 1) / 2) * m_ShardOffset,
                   -Mathf.Abs((m_ShardAmount - 1) / 2) * m_ShardOffset,
                    0), Quaternion.identity);
            }

        }
    }
}

