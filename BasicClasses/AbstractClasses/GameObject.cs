using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiShooter
{
    public abstract class GameObject
    {
        public virtual void Update()
        {

        }

        public GameObject()
        {
            Program.AddObject(this);
        }

        public virtual void Destroy()
        {
            Program.RemoveObject(this);
        }
    }
}
