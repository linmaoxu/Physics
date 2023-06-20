using UnityEngine;
using Physics2D.Entity;

namespace Physics2D.Utils
{

    public static class Intersect2DUtils
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

            return true;
        }

        public static bool IntersectSphere_Sphere(SphereEntity sphereEntity, SphereEntity sphereEntity2)
        {
            if (Mathf.Abs(sphereEntity.pos.x - sphereEntity2.pos.x) > (sphereEntity.radius + sphereEntity2.radius))
            {
                return false;
            }

            if (Mathf.Abs(sphereEntity.pos.y - sphereEntity2.pos.y) > (sphereEntity.radius + sphereEntity2.radius))
            {
                return false;
            }

            return true;
        }

        public static bool IntersectSphere_AABB(SphereEntity sphereEntity, AABBEntity aabbEntity)
        {
            float sqrDist = GetSqrDistFromPointToAABB(sphereEntity.pos, aabbEntity);
            return sqrDist <= sphereEntity.radius * sphereEntity.radius;
        }


        public static bool IntersectOBB_OBB(OBBEntity obbEntity, OBBEntity obbEntity2)
        {
            return !(IsNotIntersectInAxis(obbEntity.vertexArray, obbEntity2.vertexArray, obbEntity.xAxis) ||
                    IsNotIntersectInAxis(obbEntity.vertexArray, obbEntity2.vertexArray, obbEntity.yAxis) ||
                    IsNotIntersectInAxis(obbEntity.vertexArray, obbEntity2.vertexArray, obbEntity2.xAxis) ||
                    IsNotIntersectInAxis(obbEntity.vertexArray, obbEntity2.vertexArray, obbEntity2.yAxis));
        }

        public static bool IntersectOBB_Sphere(OBBEntity obbEntity, SphereEntity sphereEntity)
        {
            Vector2 dist = obbEntity.pos - sphereEntity.pos;
            Quaternion inverseRot = Quaternion.Inverse(obbEntity.rot);
            Vector2 inverseDir = inverseRot * dist;

            float absX = Mathf.Max(inverseDir.x,-inverseDir.x);
            float absY = Mathf.Max(inverseDir.y,-inverseDir.y);
            Vector2 absDist = new Vector2(absX,absY);

            Vector2 realDist = Vector2.Max(absDist - obbEntity.size,Vector2.zero);
            return realDist.sqrMagnitude <= sphereEntity.radius * sphereEntity.radius;
        }

        static float GetSqrDistFromPointToAABB(Vector2 point, AABBEntity entity)
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
            return v;
        }

        static bool IsNotIntersectInAxis(Vector2[] vertexArray, Vector2[] vertexArray2, Vector2 axis)
        {
            float[] rangeA = GetRange(vertexArray, axis);
            float[] rangeB = GetRange(vertexArray2, axis);

            return (rangeA[1] < rangeB[0] || rangeB[1] < rangeA[0]);
        }

        static float[] GetRange(Vector2[] vertexArray, Vector2 axis)
        {
            //[0]:存储投影最小值，[1]:存储投影最大值
            float[] range = new float[2] { float.MaxValue, float.MinValue };
            for (int i = 0; i < vertexArray.Length; i++)
            {
                float dot = Vector2.Dot(vertexArray[i], axis);
                range[0] = Mathf.Min(range[0], dot);
                range[1] = Mathf.Max(range[1], dot);
            }
            return range;
        }
    }
}