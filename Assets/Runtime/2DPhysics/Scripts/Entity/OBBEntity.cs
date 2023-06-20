using UnityEngine;

namespace Physics2D.Entity
{

    public struct OBBEntity
    {
        public Vector2 pos;
        public Vector2 size;
        public Quaternion rot;
        public Vector2 xAxis;
        public Vector2 yAxis;
        public Vector2[] vertexArray;

        public void Init(Vector2 pos,Vector2 size,Quaternion rot)
        {
            this.pos = pos;
            this.size = size;
            this.rot = rot;
            this.xAxis = rot * Vector2.right;
            this.yAxis = rot * Vector2.up;

            vertexArray = new Vector2[4];
            vertexArray[0] = pos + this.xAxis * size.x + yAxis * size.y;
            vertexArray[1] = pos + this.xAxis * size.x - yAxis * size.y;
            vertexArray[2] = pos - this.xAxis * size.x + yAxis * size.y;
            vertexArray[3] = pos - this.xAxis * size.x - yAxis * size.y;
        }
    }
}