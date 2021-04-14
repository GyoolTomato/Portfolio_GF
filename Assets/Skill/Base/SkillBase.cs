using System;
using UnityEngine;
using Assets.Character.Battle.Base;

namespace Assets.Skill.Base
{
    public class SkillBase : MonoBehaviour
    {
        [SerializeField]
        protected GameObject m_explosionObject;

        protected bool m_isInit;
        protected bool m_isBoom;
        protected bool m_isInstanceBoom;
        protected float m_speed;
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

                m_isBoom = false;
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

                    if (!m_isBoom)
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

        public virtual void Initialize(GameObject master, GameObject target, int damage, bool isInstanceBoom = false)
        {
            m_master = master;
            m_target = target;
            m_damage = damage;
            m_isInstanceBoom = isInstanceBoom;

            m_masterPosition = new Vector3(m_master.transform.position.x, m_master.transform.position.y, m_master.transform.position.z);
            m_targetPosition = new Vector3(m_target.transform.position.x, m_target.transform.position.y + 0.3f, m_target.transform.position.z);

            var angle = Vector3.SignedAngle(transform.up, m_targetPosition - m_masterPosition, transform.forward);
            m_imageTransform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, angle));

            transform.tag = master.transform.tag;

            if (m_isInstanceBoom)            
                transform.position = m_targetPosition;
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject == m_target || transform.tag != collision.transform.tag)
            {
                var characterBase = collision.gameObject.GetComponent<CharacterBase>();

                if (characterBase != null)
                {
                    
                    characterBase.ApplyDamage(m_damage);

                    Boom(collision.transform);
                }                
            }
        }

        private void Boom(Transform collisionTransform)
        {
            m_imageTransform.gameObject.SetActive(false);
            m_isBoom = true;            

            if (m_explosionObject != null)
            {
                var explosionObject = Instantiate(m_explosionObject, transform.position, Quaternion.identity);

                if (m_isInstanceBoom)
                {
                    explosionObject.transform.position = m_targetPosition;
                }
                
                explosionObject.transform.parent = transform;
            }            

            Invoke("InvokeDestroy", 2);
        }

        private void InvokeDestroy()
        {
            Destroy(gameObject);
        }
    }
}