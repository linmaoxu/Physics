using UnityEngine;
using Physics3D.Entity;

namespace Physics3D.Utils
{

    public static class Intersect3DUtils
    {

        public static bool IntersectAABB_AABB(AABBEntity aabbEntity, AABBEntity aabbEntity2)
        {
            if (aabbEntity.maxPos.x < aabbEntity2.minPos.x || aabbEntity2.maxPos.x < aabbEntity.minPos.x)
            {
                return false;
            }

            if (aabbEntity.maxPos.y < aabbEntity2.minPos.y || aabbEntity2.maxPos.y < aabbEntity.minPos.y)
            {
                return false;
            }

            if (aabbEntity.maxPos.z < aabbEntity2.minPos.z || aabbEntity2.maxPos.z < aabbEntity.minPos.z)
            {
                return false;
            }

            return true;
        }

        public static bool IntersectSphere_Sphere(SphereEntity sphereEntity, SphereEntity sphereEntity2)
        {
            float x = Mathf.Abs(sphereEntity.pos.x - sphereEntity2.pos.x);
            float y = Mathf.Abs(sphereEntity.pos.y - sphereEntity2.pos.y);
            float z = Mathf.Abs(sphereEntity.pos.z - sphereEntity2.pos.z);

            float sqrDist = x * x + y * y + z * z;
            float comparison = sphereEntity.radius * sphereEntity.radius + sphereEntity2.radius * sphereEntity2.radius;
            return sqrDist < comparison;
        }

        public static bool IntersectSphere_AABB(SphereEntity sphereEntity, AABBEntity aabbEntity)
        {
            float sqrDist = GetSqrDistFromPointToAABB(sphereEntity.pos,aabbEntity);
            float radiusSqr = sphereEntity.radius * sphereEntity.radius * sphereEntity.radius;
            return sqrDist <= radiusSqr;
        }

        static float GetSqrDistFromPointToAABB(Vector3 point, AABBEntity entity)
        {
            float v = 0;
            if (point.x < entity.minPos.x)
            {
                v += (entity.minPos.x - point.x) * (entity.minPos.x - point.x);
            }

            if (point.x > entity.maxPos.x)
            {
                v += (point.x - entity.maxPos.x) * (point.x - entity.maxPos.x);
            }

            if (point.y < entity.minPos.y)
            {
                v += (entity.minPos.y - point.y) * (entity.minPos.y - point.y);
            }

            if (point.y > entity.maxPos.y)
            {
                v += (point.y - entity.maxPos.y) * (point.y - entity.maxPos.y);
            }


            if (point.z < entity.minPos.z)
            {
                v += (entity.minPos.z - point.z) * (entity.minPos.z - point.z);
            }

            if (point.z > entity.maxPos.z)
            {
                v += (point.z - entity.maxPos.z) * (point.z - entity.maxPos.z);
            }
            return v;
        }

    }
}