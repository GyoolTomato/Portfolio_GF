using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Resources.Object
{
    public class PlatoonWindow : MonoBehaviour
    {
        private BigAlbum_TDoll m_bigAlbum_TDoll1;
        private BigAlbum_TDoll m_bigAlbum_TDoll2;
        private BigAlbum_TDoll m_bigAlbum_TDoll3;
        private BigAlbum_TDoll m_bigAlbum_TDoll4;

        private void Awake()
        {
            m_bigAlbum_TDoll1 = transform.Find("BigAlbum_TDoll1").GetComponent<BigAlbum_TDoll>();
            m_bigAlbum_TDoll2 = transform.Find("BigAlbum_TDoll2").GetComponent<BigAlbum_TDoll>();
            m_bigAlbum_TDoll3 = transform.Find("BigAlbum_TDoll3").GetComponent<BigAlbum_TDoll>();
            m_bigAlbum_TDoll4 = transform.Find("BigAlbum_TDoll4").GetComponent<BigAlbum_TDoll>();
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        public BigAlbum_TDoll BigAlbum_TDoll1()
        {
            return m_bigAlbum_TDoll1;
        }

        public BigAlbum_TDoll BigAlbum_TDoll2()
        {
            return m_bigAlbum_TDoll2;
        }

        public BigAlbum_TDoll BigAlbum_TDoll3()
        {
            return m_bigAlbum_TDoll3;
        }

        public BigAlbum_TDoll BigAlbum_TDoll4()
        {
            return m_bigAlbum_TDoll4;
        }
    }
}
