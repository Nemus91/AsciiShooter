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
        static List<MoveableObject> EntitiesToDestroy = new List<MoveableObject>();
        public static Map Map
        {
            private get;
            set;
        }

        /// <summary>
        /// Adds Object to Manager
        /// </summary>
        /// <param name="obj">Object to add</param>
        public static void Add(MoveableObject obj)
        {
            Entities.Add(obj);
        }

        /// <summary>
        /// Adds Object to DestroyCandidates, which are removed every frame
        /// </summary>
        /// <param name="obj">Object to Remove</param>
        public static void Remove(MoveableObject obj)
        {
            EntitiesToDestroy.Add(obj);
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
                    Vector2 newPos = (Entities[i].Position + PosShift);
                    //Levelcollision
                    if (Map != null)
                    {
                         if (Map.Field[newPos.X, newPos.Y] != ' ')
                        {
                            Entities[i].OnCollide(null);
                            newPos = Entities[i].Position;
                        }
                    }
                    //Entity-Collision
                    foreach (MoveableObject Entity in Entities)
                    {
                        if (Entity != Entities[i] && Entity.Position.Equals(newPos))
                        {
                            if (Entity.hasCollision && Entities[i].hasCollision)
                            {
                                newPos = Entities[i].Position;
                            }
                            Entity.OnCollide(Entities[i]);
                            Entities[i].OnCollide(Entity);
                        }
                    }
                    Entities[i].Position = newPos;
                }
            }
            DestroyObjects();
        }

        /// <summary>
        /// Redraws Objects which have changed Position
        /// A moved Object will always be drawn on top
        /// For Objects that didn't moved, those who've been added first to the Entity list are drawn on top
        /// </summary>
        public static void Draw()
        {
            if (Map == null)
                return;
            for (int i = 0; i < Entities.Count; i++)
            {
                if (Entities[i].hasChanged)
                {
                    //Check if there was an Object behind the moved Entity and draw it.
                    bool isFieldEmpty = true;
                    Console.SetCursorPosition(Entities[i].LastPosition.X, Entities[i].LastPosition.Y);
                    foreach (MoveableObject Entity in Entities)
                    {
                        if (Entity.Position.Equals(Entities[i].LastPosition))
                        {
                            Console.Write(Entity.VisRepresentation);
                            isFieldEmpty = false;
                            break;
                        }
                    }
                    //if there's no other object to draw, write from Map
                    if (isFieldEmpty)
                    {
                        Console.Write(Map.Field[Console.CursorLeft, Console.CursorTop]);
                    }
                    //Draw Symbol of the moved Object at new Location
                    Console.SetCursorPosition(Entities[i].Position.X, Entities[i].Position.Y);
                    Console.Write(Entities[i].VisRepresentation);
                    Entities[i].hasChanged = false;
                }
            }
        }

        /// <summary>
        /// Removes Object from EntityList and Redraws Map at their Position
        /// </summary>
        private static void DestroyObjects()
        
        {
            //Redraw Position of Destroyed Object with Entity or MapData
            foreach (MoveableObject Obj in EntitiesToDestroy)
            {
                bool isFieldEmpty = true;
                Console.SetCursorPosition(Obj.Position.X, Obj.Position.Y);
                foreach (MoveableObject Entity in Entities)
                {
                    if (Entity.Position.Equals(Obj.Position) && !EntitiesToDestroy.Contains(Entity))
                    {                        
                        Console.Write(Entity.VisRepresentation);
                        isFieldEmpty = false;
                    }
                }
                if (isFieldEmpty)
                {
                    Console.Write(Map.Field[Console.CursorLeft, Console.CursorTop]);
                }
            }

            //Remove from EntityList
            foreach (MoveableObject Obj in EntitiesToDestroy)
            {
                Entities.Remove(Obj);
            }
            EntitiesToDestroy.Clear();
        }

        public static void Clear()
        {
            foreach (MoveableObject Entity in Entities)
            {
                if (Entity.GetType() != typeof(Player))
                    Entity.Destroy();
            }
        }

    }
}

