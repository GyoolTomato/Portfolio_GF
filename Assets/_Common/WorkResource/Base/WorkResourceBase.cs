﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Common.WorkResource.Base
{
    public class WorkResourceBase
    {
        public Image Image { get; set; }
        public string Title { get; set; }
        public string DBName { get; set; }
        public int Amount { get; set; }
        public float ChargingVolume_Time { get; set; }
        public int ChargingVolume_Amount { get; set; }
    }
}