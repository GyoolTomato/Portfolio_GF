using System;
using UnityEngine;
using Assets.Character.Battle.Base;

namespace Assets.Skill.Base
{
    public class SkillBase : MonoBehaviour
    {            
        [SerializeField]
        protected GameObject m_explosionObject;
        [SerializeField]
        protected float m_speed;

        protected bool m_isInit;
        protected Transform m_imageTransform;
        protected GameObject m_master;
        protected GameObject m_target;
        protected Vector3 m_masterPosition;
        protected Vector3 m_targetPosition;        
        protected int m_damage;

        private void Awake()
        {
            m_imageTransform = transform.Find("Image");
        }

        private void Start()
        {
            try
            {
                var objects = GameObject.Find("BattleField").transform.Find("Objects");
                transform.parent = objects;
            }
            catch
            {

            }
        }

        private void Update()
        {
            if (m_isInit)
            {
                try
                {                   
                    var direction = m_targetPosition - m_masterPosition;
                    direction.Normalize();

                    //if (m_master.GetComponent<CharacterBase>().GetTeam() == CharacterBase.E_Team.Enemy)
                    //{
                    //    var temp = direction;
                    //    temp.x *= -1;
                    //    direction = temp;
                    //}

                    transform.Translate(direction * Time.deltaTime * m_speed);

                    if (transform.position.x > Screen.width || transform.position.x < -Screen.width)
                    {
                        Destroy(gameObject);
                    }
                }
                catch
                {
                    Destroy(gameObject);
                }
            }            
        }

        public virtual void Initialize(GameObject master, GameObject target, int damage)
        {
            m_master = master;
            m_target = target;
            m_damage = damage;

            m_masterPosition = new Vector3(m_master.transform.position.x, m_master.transform.position.y, m_master.transform.position.z);
            m_targetPosition = new Vector3(m_target.transform.position.x, m_target.transform.position.y + 0.5f, m_target.transform.position.z);

            var angle = Vector3.SignedAngle(transform.up, m_targetPosition - m_masterPosition, transform.forward);
            m_imageTransform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, angle));
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {            
            if (collision.gameObject == m_target)
            {
                var characterBase = collision.gameObject.GetComponent<CharacterBase>();
                characterBase.ApplyDamage(m_damage);

                Destroy(gameObject);
            }
        }

        
    }
}