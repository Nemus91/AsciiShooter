using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiShooter.BasicClasses.Manager
{
    /// <summary>
    /// Applies Velocity to Position for all Moveable Objects and performs Collision Checks
    /// </summary>
    public class MoveableObjectManager
    {
        static DateTime Timer = new DateTime();
        static List<MoveableObject> Entities = new List<MoveableObject>();
        public static Map Collision;

        /// <summary>
        /// Adds Object to Manager
        /// </summary>
        /// <param name="obj">Object to add</param>
        public static void Add(MoveableObject obj)
        {
            Entities.Add(obj);
        }

        /// <summary>
        /// Removes Object from Manager
        /// </summary>
        /// <param name="obj">Object to Remove</param>
        public static void Remove(MoveableObject obj)
        {
            Entities.Remove(obj);
        }

        /// <summary>
        /// Updating Position of every managed Object depending on their velocity
        /// Only to be called by Update-loop
        /// </summary>
        public static void Update()
        {
            Vector2 PosShift;
            Timer = Timer.AddTicks(1);
            for (int i = 0; i < Entities.Count; i++)
            {
                PosShift = new Vector2 (0,0);
                if (Math.Abs(Entities[i].Velocity.X) > 0 && Timer.Ticks % (100 / Math.Abs(Entities[i].Velocity.X)) == 0)
                {
                    PosShift.X += Math.Sign(Entities[i].Velocity.X)*1;
                }
                if (Math.Abs(Entities[i].Velocity.Y) > 0 && Timer.Ticks % (100 / Math.Abs(Entities[i].Velocity.Y)) == 0)
                {
                    PosShift.Y += Math.Sign(Entities[i].Velocity.Y)*1;
                }

                //Only do, if something has changed
                if (PosShift.X != 0 || PosShift.Y != 0)
                {
                    Vector2 newPos = (Entities[i].Position += PosShift);
                    //Levelcollision
                    if (Collision != null)
                    {
                        if (Collision.Field[newPos.X, newPos.Y] != (char) 0)
                        {
                            newPos = Entities[i].LastPosition;
                        }
                    }
                    //Entity-Collision
                    foreach (MoveableObject Entity in Entities)
                    {
                        if (Entity != Entities[i] && Entity.Position.Equals(newPos))
                        {
                            if (Entity.hasCollision && Entities[i].hasCollision)
                            {
                                newPos = Entities[i].LastPosition;
                            }
                            Entity.OnCollide(Entities[i]);
                            Entities[i].OnCollide(Entity);
                        }
                    }
                    Entities[i].Position = newPos;
                }
            }
        }
    }
}

