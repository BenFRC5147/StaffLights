using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StaffLights
{
    public  class Config : IConfig
    {
        [Description("Is the plugin enabled:")]
        public bool IsEnabled { get; set; } = true;

        [Description("Are debug logs enabled:")]
        public bool Debug { get; set; }

        [Description("Visible range of the light:")]
        public float Range { get; set; } = 30f;

        [Description("Visible intensity of the light:")]
        public float Intensity { get; set; } = 18.75f;

        [Description("Visible color of the light:")]
        public Color Color { get; set; } = Color.cyan;
    }
}
