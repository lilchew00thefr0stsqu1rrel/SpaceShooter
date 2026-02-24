using UnityEngine;

namespace SpaceShooter
{
    public class Player : SingletonBase<Player>
    {
        public static SpaceShip SelectedSpaceShip;

        [SerializeField] private int m_NumLives;
        [SerializeField] private SpaceShip m_PlayerShipPrefab;
        public SpaceShip ActiveShip => m_Ship;

        private FollowCamera m_FollowCamera;
        private ShipInputController m_ShipInputController;
        private Transform m_SpawnPoint;

        public FollowCamera FollowCamera => m_FollowCamera;

        public void Construct(FollowCamera followCamera, ShipInputController shipInputController, Transform spawnPoint)
        {
            m_FollowCamera = followCamera;
            m_ShipInputController = shipInputController;
            m_SpawnPoint = spawnPoint;
        }

        private SpaceShip m_Ship;

        private int m_Score;
        private int m_NumKills;

        private int m_MaxNumLives;

        public int Score => m_Score;
        public int NumKills => m_NumKills;
        public int NumLives => m_NumLives;

        private Vector3 m_ShipPos;

        [SerializeField] private PlayerData m_PlayerData;
        public PlayerData UsedData => m_PlayerData;
        public SpaceShip ShipPrefab
        {
            get
            {
                if (SelectedSpaceShip == null)
                {
                    return m_PlayerShipPrefab;
                }
                else
                {
                    return SelectedSpaceShip;
                }
            }
        }

        void Start()
        {
            Debug.Log("Cinnamon");
          
            Respawn();

            ResetShipMaxHP();
            

            m_MaxNumLives = m_NumLives;

            m_PlayerData.HasRockets = false;
        }

        public void ResetShipMaxHP()
        {
            m_Ship.ResetMaxHitPoints();
        }

        private void OnShipDeath()
        {
            //m_ExplosionEffect.Explode(m_ShipPos);




            m_NumLives--;

          

            
                if (m_NumLives > 0)
                {
                    Respawn();
                    
                }

            if (NumLives == 0)
            {
                m_PlayerData.HasRockets = false;
            }


            

            Debug.Log(m_NumLives > 0);

            
        }

  
        private void Respawn()
        {
            Debug.Log("Ruu");


            var newPlayerShip = Instantiate(ShipPrefab, m_SpawnPoint.position, m_SpawnPoint.rotation);

            m_Ship = newPlayerShip.GetComponent<SpaceShip>();

            //m_ShipPos = newPlayerShip.transform.position;

            m_Ship.EventOnDeath.AddListener(OnShipDeath);  //

           

            if (m_PlayerData.HasRockets) m_Ship.LoadRocket();
            if (m_PlayerData.ShipMaxHitPoints > 0) m_Ship.SetMaxHitPoints(m_PlayerData.ShipMaxHitPoints);   
            

            m_FollowCamera.SetTarget(m_Ship.transform);
            m_ShipInputController.SetTargetShip(m_Ship);

            
        }




        public void AddKill()
        {
            m_NumKills += 1;
        }

        public void AddScore(int num)
        {
            m_Score += num;
        }

        //public void HideShip()
        //{
        //    m_Ship.gameObject.SetActive(false);
        //}


    }
}
