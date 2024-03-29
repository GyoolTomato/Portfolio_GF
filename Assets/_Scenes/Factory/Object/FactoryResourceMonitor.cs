﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.Factory.Object
{
    public class FactoryResourceMonitor : MonoBehaviour
    {
        private Image m_image;
        private Text m_title;
        private Text m_amount;

        public FactoryResourceMonitor()
        {
        }

        private void Awake()
        {
            m_image = transform.Find("Image").GetComponent<Image>();
            m_title = transform.Find("Title").GetComponent<Text>();
            m_amount = transform.Find("Amount").GetComponent<Text>();
        }

        private void Start()
        {

        }

        private void Update()
        {

        }

        public void ApplyData(Assets.Common.WorkResource.Base.OthersResource othersResource)
        {
            m_image.sprite = othersResource.ImageSprite;
            m_title.text = othersResource.Title;
            m_amount.text = othersResource.Amount.ToString();
        }
    }
}