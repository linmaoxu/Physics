using UnityEngine;

namespace Physics3D.Entity {

    public struct OBBEntity {

        public Vector3 pos;
        public Quaternion rot;
        public Vector3[] vertexArray;
        public Vector3 size;
        public Vector3 halfSzie;
        public Vector3 xAxis;
        public Vector3 yAxis;
        public Vector3 zAxis;
        public void Init(Vector3 pos,Quaternion rot,Vector3 size,Vector3 xAxis,Vector3 yAxis,Vector3 zAxis) {
            this.pos = pos;
            this.rot = rot;
            this.size = size;
            halfSzie = size/2;
            this.xAxis = xAxis;
            this.yAxis = yAxis;
            this.zAxis = zAxis;

            vertexArray = new Vector3[8];

            vertexArray[0] = pos + rot*(new Vector3(halfSzie.x,halfSzie.y,halfSzie.z));
            vertexArray[1] = pos + rot*(new Vector3(-halfSzie.x,halfSzie.y,halfSzie.z));
            vertexArray[2] = pos + rot*(new Vector3(halfSzie.x,-halfSzie.y,halfSzie.z));
            vertexArray[3] = pos + rot*(new Vector3(halfSzie.x,halfSzie.y,-halfSzie.z));
            vertexArray[4] = pos + rot*(new Vector3(-halfSzie.x,-halfSzie.y,halfSzie.z));
            vertexArray[5] = pos + rot*(new Vector3(-halfSzie.x,halfSzie.y,-halfSzie.z));
            vertexArray[6] = pos + rot*(new Vector3(halfSzie.x,-halfSzie.y,-halfSzie.z));
            vertexArray[7] = pos + rot*(new Vector3(-halfSzie.x,-halfSzie.y,-halfSzie.z));
        }
    }
}