using UnityEngine;
using Common;

namespace SpaceShooter
{
    public class EntitySpawner : MonoBehaviour
    {
        public enum SpawnMode
        {
            Start,
            Loop
        }

        [SerializeField] private Entity[] m_EntityPrefabs;

        [SerializeField] private CircleArea m_Area;

        [SerializeField] private SpawnMode m_SpawnMode;

        [SerializeField] private int m_NumSpawns;

        [SerializeField] private float m_RespawnTime;

        [SerializeField] private int m_TeamId;

        [SerializeField] private AIPointPatrol[] m_PatrolPoints;

        private float m_Timer;


        //[SerializeField] private EntitiesListManager m_Entities;

        private void Start()
        {
            if (m_SpawnMode == SpawnMode.Start)
            {
                SpawnEnities();
            }

            m_Timer = m_RespawnTime;
        }

        private void Update()
        {
            if (m_Timer > 0)
                m_Timer -= Time.deltaTime;

            if (m_SpawnMode == SpawnMode.Loop && m_Timer < 0)
            {
                SpawnEnities();

                m_Timer = m_RespawnTime;
            }
        }

        private void SpawnEnities()
        {
            for (int i = 0; i < m_NumSpawns; i++)
            {
                int index = Random.Range(0, m_EntityPrefabs.Length);

                GameObject e = Instantiate(m_EntityPrefabs[index].gameObject);

                e.transform.position = m_Area.GetRandomInsideZone();

                AIController cont = e.GetComponent<AIController>();

                if (cont != null)
                {
                    cont.SetPatrolPoints(m_PatrolPoints);
                }
            }
        }


    }
}
