using UnityEngine;
using Physics2D.Entity;

namespace Physics2D.Utils {

    public static class Intersect2DUtils {

        public static bool IntersectAABB_AABB(AABBEntity aabbEntity,AABBEntity aabbEntity2) {
            if(aabbEntity.maxPos.x < aabbEntity2.minPos.x || aabbEntity2.maxPos.x < aabbEntity.minPos.x) {
                return false;
            }

            if(aabbEntity.maxPos.y < aabbEntity2.minPos.y || aabbEntity2.maxPos.y < aabbEntity.minPos.y) {
                return false;
            }

            return true;
        }

        public static bool IntersectSphere_Sphere(SphereEntity sphereEntity,SphereEntity sphereEntity2) {
            if(Mathf.Abs(sphereEntity.pos.x - sphereEntity2.pos.x) > (sphereEntity.radius + sphereEntity2.radius)) {
                return false;
            }

            if(Mathf.Abs(sphereEntity.pos.y - sphereEntity2.pos.y) > (sphereEntity.radius + sphereEntity2.radius)) {
                return false;
            }

            return true;
        }

        public static bool IntersectSphere_AABB(AABBEntity aabbEntity,SphereEntity sphereEntity) {
            var sqrDist = SqrDistFromPointToAABB(sphereEntity.pos,aabbEntity);
            return sqrDist <= sphereEntity.radius * sphereEntity.radius;
        }

        static float SqrDistFromPointToAABB(Vector2 point,AABBEntity entity) {
            float v = 0;
            if(point.x < entity.minPos.x) {
                v += (entity.minPos.x - point.x) * (entity.minPos.x - point.x);
            }

            if(point.x > entity.maxPos.x) {
                v += (point.x - entity.maxPos.x) * (point.x - entity.maxPos.x);
            }

            if(point.y < entity.minPos.y) {
                v += (entity.minPos.y - point.y) * (entity.minPos.y - point.y);
            }

            if(point.y > entity.maxPos.y) {
                v += (point.y - entity.maxPos.y) * (point.y - entity.maxPos.y);
            }
            return v;
        }
    }
}