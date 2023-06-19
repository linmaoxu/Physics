using UnityEngine;

namespace Physics2D.Entity {
    
    public struct OBBEntity {
        public Vector2 minPos;
        public Vector2 maxPos;
        public Vector2 pos;
        public Vector2 size;
        public Quaternion rot;            
    }
}