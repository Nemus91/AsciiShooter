using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiShooter.BasicClasses.StaticClasses
{
    public static class Pathfinding
    {
        private static List<Node> Openlist = new List<Node>();
        private static List<Node> ClosedList = new List<Node>();

        public static Vector2 GetNextField(Vector2 start, Vector2 target, Map map)
        {
            Node StartNode = new Node(start, null, target);
            StartNode.G = 0;
            Openlist.Add(StartNode);

            Node NextNode = StartNode;

            while (Openlist.Count > 0)
            {
                //Get Node with smallest heuristic Value
                Node closestNode = StartNode;
                foreach (Node NodesToCheck in Openlist)
                {
                    if (NodesToCheck.F < closestNode.F)
                        closestNode = NodesToCheck;
                }
                //Check if target has been reached
                if (closestNode.NodePosition == target)
                    break;
                //Transfer Node to ClosedList
                Openlist.Remove(closestNode);
                ClosedList.Add(closestNode);

                //CheckNeighbours
                closestNode.InitNeighbours();
                foreach (Node OpenListCandidate in closestNode.Neighbours)
                {
                    bool iswalkable = map.Field[OpenListCandidate.NodePosition.X, OpenListCandidate.NodePosition.Y] == ' ';
                    if (iswalkable && !ClosedList.Contains(OpenListCandidate))
                    {
                        if (!Openlist.Contains(OpenListCandidate))
                        {
                            Openlist.Add(OpenListCandidate);
                            OpenListCandidate.PreviousNode = closestNode;
                            OpenListCandidate.G = closestNode.G + 1;
                        }
                        else
                        {
                            if (closestNode.G + 1 < OpenListCandidate.G)
                            {
                                OpenListCandidate.PreviousNode = closestNode;
                                OpenListCandidate.G = closestNode.G + 1;
                            }
                        }
                    }
                }
            }

            //Follow Path
            while (NextNode.PreviousNode != null)
            {
                NextNode = NextNode.PreviousNode;
            }
            
            //ClearLists
            Openlist.Clear();
            ClosedList.Clear();

            //return NextField
            Vector2 NextField = NextNode.NodePosition;
            return NextField;
        }
    }

    class Node
    {
        enum NeighbourPositions
        {
            TopLeft,
            Top,
            TopRight,
            Left,
            Right,
            BottomLeft,
            Bottom,
            BottomRight
        }

        public int F
        {
            get;
            private set;
        }
        private int mG;
        public int G
        {
            get
            {
                return mG;
            }
            set
            {
                mG = value;
                F = G + H;
            }
        }
        private int H;

        public Vector2 NodePosition;
        public Node PreviousNode;
        public Node[] Neighbours = new Node[8];
        private Vector2 Target;
        

        public Node(Vector2 Position, Node Previous, Vector2 TargetPosition)
        {
            NodePosition = Position;
            PreviousNode = Previous;
            Target = TargetPosition;
            H = Math.Abs((Position.X - TargetPosition.X) + (Position.Y - TargetPosition.Y));
        }

        public void InitNeighbours()
        {
            for (int i = 0; i < 8; i++)
            {
                Neighbours[i] = new Node(GetNeighbourPosition((NeighbourPositions)i), null, Target);
            }
        }

        private Vector2 GetNeighbourPosition(NeighbourPositions Pos)
        {
            Vector2 Position = new Vector2();
            switch (Pos)
            {
                case NeighbourPositions.TopLeft:
                    Position.X = NodePosition.X - 1;
                    Position.Y = NodePosition.Y - 1;
                    break;
                case NeighbourPositions.Top:
                    Position.X = NodePosition.X;
                    Position.Y = NodePosition.Y - 1;
                    break;
                case NeighbourPositions.TopRight:
                    Position.X = NodePosition.X + 1;
                    Position.Y = NodePosition.Y - 1;
                    break;
                case NeighbourPositions.Left:
                    Position.X = NodePosition.X - 1;
                    Position.Y = NodePosition.Y;
                    break;
                case NeighbourPositions.Right:
                    Position.X = NodePosition.X + 1;
                    Position.Y = NodePosition.Y;
                    break;
                case NeighbourPositions.BottomLeft:
                    Position.X = NodePosition.X - 1;
                    Position.Y = NodePosition.Y + 1;
                    break;
                case NeighbourPositions.Bottom:
                    Position.X = NodePosition.X;
                    Position.Y = NodePosition.Y + 1;
                    break;
                case NeighbourPositions.BottomRight:
                    Position.X = NodePosition.X + 1;
                    Position.Y = NodePosition.Y + 1;
                    break;
            }
            return Position;
        }
    }
}
