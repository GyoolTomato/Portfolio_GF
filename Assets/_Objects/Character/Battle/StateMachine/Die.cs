using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Character.Battle.StateMachine
{
    public class Die : Base.StateMachineBase
    {
        private float m_delayTime = 3.0f;

        protected override void LoadAnimation()
        {
            if (!m_animator.GetBool(m_stringIsDie))
            {
                base.LoadAnimation();

                m_animator.speed = 1.0f;
                m_animator.SetBool(m_stringIsDie, true);
            }
        }

        public override void Action()
        {
            base.Action();

            if (m_delayTime <= 0)
            {
                MonoBehaviour.Destroy(m_characterBase.gameObject);
            }
            else
            {
                var collider = m_characterBase.gameObject.GetComponent<CapsuleCollider2D>();
                if (collider != null)
                    MonoBehaviour.Destroy(collider);
                m_characterBase.transform.tag = string.Empty;

                m_delayTime -= Time.deltaTime;
            }
        }
    }
}