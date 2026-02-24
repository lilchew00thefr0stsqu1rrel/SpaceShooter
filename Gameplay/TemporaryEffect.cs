using SpaceShooter;
using UnityEngine;

public class TemporaryEffect : MonoBehaviour
{    
    [SerializeField] private SpaceShip m_Ship;

    [SerializeField] private Player m_Player;


    [SerializeField] private float m_EffectDuration;
    private float m_Timer;
    private bool isEffect;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        m_Timer += Time.deltaTime;

        if (m_Timer > m_EffectDuration)
        {
            m_Ship?.ResetSpeed();
            
            Destroy(gameObject);
           
        }
    }

    public void InitTimeCount(float duration, SpaceShip ship)
    {
        m_EffectDuration = duration;
        Debug.Log(ship.name + "Iriinihu");
        m_Ship = ship;
        Debug.Log(m_Ship.name + " Jahoda297");
    }

   
}
