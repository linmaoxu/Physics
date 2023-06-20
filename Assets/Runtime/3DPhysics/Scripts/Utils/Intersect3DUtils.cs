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
            float sqrDist = (sphereEntity.pos - sphereEntity2.pos).sqrMagnitude;
            float r = sphereEntity.radius + sphereEntity2.radius;
            float comparison = r * r;
            return sqrDist < comparison;
        }

        public static bool IntersectSphere_AABB(SphereEntity sphereEntity, AABBEntity aabbEntity)
        {
            float sqrDist = GetSqrDistFromPointToAABB(sphereEntity.pos, aabbEntity);
            float radiusSqr = sphereEntity.radius * sphereEntity.radius * sphereEntity.radius;
            return sqrDist <= radiusSqr;
        }

        public static bool IntersectOBB_OBB(OBBEntity obbEntity, OBBEntity obbEntity2)
        {
            return !(IsNotIntersectInAxis(obbEntity.vertexArray,obbEntity2.vertexArray,obbEntity.xAxis) ||
                     IsNotIntersectInAxis(obbEntity.vertexArray,obbEntity2.vertexArray,obbEntity.yAxis) ||
                     IsNotIntersectInAxis(obbEntity.vertexArray,obbEntity2.vertexArray,obbEntity.zAxis) ||
                     IsNotIntersectInAxis(obbEntity.vertexArray,obbEntity2.vertexArray,obbEntity2.xAxis) ||
                     IsNotIntersectInAxis(obbEntity.vertexArray,obbEntity2.vertexArray,obbEntity2.yAxis) ||
                     IsNotIntersectInAxis(obbEntity.vertexArray,obbEntity2.vertexArray,obbEntity2.zAxis) ||
                     IsNotIntersectInAxis(obbEntity.vertexArray,obbEntity2.vertexArray,Vector3.Cross(obbEntity.xAxis,obbEntity2.xAxis)) ||
                     IsNotIntersectInAxis(obbEntity.vertexArray,obbEntity2.vertexArray,Vector3.Cross(obbEntity.xAxis,obbEntity2.yAxis)) ||
                     IsNotIntersectInAxis(obbEntity.vertexArray,obbEntity2.vertexArray,Vector3.Cross(obbEntity.xAxis,obbEntity2.zAxis)) ||
                     IsNotIntersectInAxis(obbEntity.vertexArray,obbEntity2.vertexArray,Vector3.Cross(obbEntity.yAxis,obbEntity2.xAxis)) ||
                     IsNotIntersectInAxis(obbEntity.vertexArray,obbEntity2.vertexArray,Vector3.Cross(obbEntity.yAxis,obbEntity2.yAxis)) ||
                     IsNotIntersectInAxis(obbEntity.vertexArray,obbEntity2.vertexArray,Vector3.Cross(obbEntity.yAxis,obbEntity2.zAxis)) ||
                     IsNotIntersectInAxis(obbEntity.vertexArray,obbEntity2.vertexArray,Vector3.Cross(obbEntity.zAxis,obbEntity2.xAxis)) ||
                     IsNotIntersectInAxis(obbEntity.vertexArray,obbEntity2.vertexArray,Vector3.Cross(obbEntity.zAxis,obbEntity2.yAxis)) ||
                     IsNotIntersectInAxis(obbEntity.vertexArray,obbEntity2.vertexArray,Vector3.Cross(obbEntity.zAxis,obbEntity2.zAxis)));
        }

        public static bool IntersectOBB_Sphere(OBBEntity obbEntity,SphereEntity sphereEntity) {
            Vector3 dist = obbEntity.pos - sphereEntity.pos;
            Quaternion inverseRot = Quaternion.Inverse(obbEntity.rot);
            Vector3 inverseDist = inverseRot * dist;

            float absX = Mathf.Max(inverseDist.x,-inverseDist.x);
            float absY = Mathf.Max(inverseDist.y,-inverseDist.y);
            float absZ = Mathf.Max(inverseDist.z,-inverseDist.z);
            Vector3 absDist = new Vector3(absX,absY,absZ);

            Vector3 realDist = Vector3.Max(absDist - obbEntity.halfSzie,Vector3.zero);

            return realDist.sqrMagnitude <= sphereEntity.radius * sphereEntity.radius;
        }

        static bool IsNotIntersectInAxis(Vector3[] vertexArray, Vector3[] vertexArray2, Vector3 axis)
        {
            float[] range1 = GetRange(vertexArray, axis);
            float[] range2 = GetRange(vertexArray2, axis);
            return (range1[1] < range2[0] || range2[1] < range1[0]);
        }

        static float[] GetRange(Vector3[] vertexArray, Vector3 axis)
        {
            float[] range = new float[2] { float.MaxValue, float.MinValue };
            for (int i = 0; i < vertexArray.Length; i++)
            {
                float value = Vector3.Dot(vertexArray[i], axis);
                range[0] = Mathf.Min(range[0], value);
                range[1] = Mathf.Max(range[1], value);
            }
            return range;
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