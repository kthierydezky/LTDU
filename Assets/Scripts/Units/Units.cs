using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Units : MonoBehaviour {

    public enum ArmorType
    {
        Light,
        Medium,
        Heavy,
        Fort,
        Hero,
        Unarmored
    }

    public enum DamageType
    {
        Normal,
        Pierce,
        Siege,
        Magic,
        Chaos,
        Spells,
        Hero
    }

    private static float[,] attackDefenceChart = { /*Normal Attack type*/{ 1f, 1.5f, 1f, 0.7f, 1f, 1f }, /*Pierce Attack type*/{ 2f, 0.75f, 1f, 0.35f, 0.5f, 1f }, /*Siege Attack type*/{ 1f, 0.5f, 1f, 1.5f, 0.5f, 1.5f }, /*Magic Attack type*/{ 1.25f, 0.75f, 2f, 0.35f, 0.5f, 1f }, /*Chaos Attack type*/{ 1f, 1f, 1f, 1f, 1f, 1f }, /*Spell Attack type*/{ 1f, 1f, 1f, 1f, 0.7f, 1f }, /*Hero Attack type*/{ 1f, 1f, 1f, 0.5f, 1f, 1f } };
    private static float[] armorDamageReduction = /*0 = -10 with damage increase, 9 = 0 armor damage reduction*/ { 1.4614f, 1.4270f, 1.3904f, 1.3515f, 1.3101f, 1.2661f, 1.2193f, 1.1694f, 1.1164f, 1.06f, 0.0566f, 0.01071f, 0.01525f, 0.01935f, 0.02308f, 0.02647f, 0.02958f, 0.03243f, 0.03506f, 0.375f, 0.3976f, 0.4186f, 0.4382f, 0.4565f, 0.4737f, 0.4898f, 0.505f, 0.5192f, 0.5327f, 0.5455f, 0.5575f, 0.5690f, 0.5798f, 0.5902f, 0.6000f, 0.6094f, 0.6183f, 0.6269f, 0.6350f, 0.6429f, 0.6503f, 0.6575f, 0.6644f, 0.6711f, 0.6774f, 0.6835f, 0.6894f, 0.6951f, 0.7006f, 0.7059f, 0.7110f, 0.7159f, 0.7207f, 0.7253f, 0.7297f, 0.7340f, 0.7382f, 0.7423f, 0.7462f, 0.75f };


    public HitPoint hp;
    public ArmorType at;
    public DamageType dt;
    public float armor;
    public float sight;
    public float speed;
    public float buildTime;
    public float coolDown;
    public float range;

    protected List<Units> inRangeUnits =new List<Units>();
    protected NavMeshAgent agent;
    protected Animator animator;
    protected AggroRadius aggroRadius;


    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        aggroRadius = GetComponentInChildren<AggroRadius>();
        InitStat();
    }

    private void InitStat()
    {

        hp.Init();
        /* Rien a faire sur ceux ci ?
        at;
        dt;
        armor;
        buildTime;
        range;*/
        aggroRadius.Init(sight);
        animator.SetFloat("WalkSpeed", speed);
        agent.speed = speed;
        animator.SetFloat("CoolDownTime", coolDown);

        
    }

    virtual public void UnitDetectionEnter(Collider other)
    {

    }


    virtual public void UnitDetectionExit(Collider other) {

    }
    

    private float GetArmorTypeRatio(ArmorType at, DamageType dt)
    {
        
        return 0f;
    }

    public void Attack()
    {
        Debug.Log("ATTACK !!!!");
    }

}
