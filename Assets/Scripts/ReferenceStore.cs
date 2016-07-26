using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class ReferenceStore
    {
        private static ReferenceStore instance;
        public Color color;

        private ReferenceStore() { color = new Color(0, 0, 0); }

        public static ReferenceStore Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReferenceStore();
                }
                return instance;
            }
        }
    }
}
