using UnityEngine;
using Physics2D.Entity;

namespace Physics2D.Utils {

    public static class Intersect2DUtils {

        public static bool IntersectAABB_AABB(AABBEntity a,AABBEntity b) {
            if(a.maxPos.x < b.minPos.x || b.maxPos.x < a.minPos.x) {
                return false;
            }

            if(a.maxPos.y < b.minPos.y || b.maxPos.y < a.minPos.y) {
                return false;
            }

            return true;
        }

        
    }
}