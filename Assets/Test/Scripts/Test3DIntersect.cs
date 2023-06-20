using UnityEngine;
using Physics3D.Entity;
using Physics3D.Utils;

namespace Physics3D.Test
{

    public class Test3DIntersect : MonoBehaviour
    {
        public GameObject AABBGO1;
        public GameObject AABBGO2;
        public GameObject SphereGO1;
        public GameObject SphereGO2;
        public GameObject OBBGO1;
        public GameObject OBBGO2;


        AABBEntity aabb1;
        AABBEntity aabb2;
        SphereEntity sphere1;
        SphereEntity sphere2;
        OBBEntity obb1;
        OBBEntity obb2;

        public void Init()
        {
            //Init
            aabb1 = new AABBEntity();
            aabb1.size = new Vector3((float)AABBGO1.transform.localScale.x / 2, (float)AABBGO1.transform.localScale.y / 2, (float)AABBGO1.transform.localScale.z / 2);
            aabb1.pos = AABBGO1.transform.position;
            aabb1.minPos = aabb1.pos - aabb1.size;
            aabb1.maxPos = aabb1.pos + aabb1.size;

            aabb2 = new AABBEntity();
            aabb2.size = new Vector3((float)AABBGO2.transform.localScale.x / 2, (float)AABBGO2.transform.localScale.y / 2, (float)AABBGO2.transform.localScale.z / 2);
            aabb2.pos = AABBGO2.transform.position;
            aabb2.minPos = aabb2.pos - aabb2.size;
            aabb2.maxPos = aabb2.pos + aabb2.size;

            sphere1 = new SphereEntity();
            sphere1.pos = SphereGO1.transform.position;
            sphere1.radius = (float)SphereGO1.transform.localScale.x;

            sphere2 = new SphereEntity();
            sphere2.pos = SphereGO2.transform.position;
            sphere2.radius = (float)SphereGO2.transform.localScale.x;

            obb1 = new OBBEntity();
            obb1.Init(OBBGO1.transform.position, OBBGO1.transform.rotation, OBBGO1.transform.lossyScale, OBBGO1.transform.right, OBBGO1.transform.up, OBBGO1.transform.forward);

            obb2 = new OBBEntity();
            obb2.Init(OBBGO2.transform.position, OBBGO2.transform.rotation, OBBGO2.transform.lossyScale, OBBGO2.transform.right, OBBGO2.transform.up, OBBGO2.transform.forward);
        }

        public void OnDrawGizmos()
        {
            Init();
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(AABBGO1.transform.position, AABBGO1.transform.localScale);
            Gizmos.DrawWireCube(AABBGO2.transform.position, AABBGO2.transform.localScale);
            Gizmos.DrawWireSphere(SphereGO1.transform.position, SphereGO1.transform.localScale.x);
            Gizmos.DrawWireSphere(SphereGO2.transform.position, SphereGO2.transform.localScale.x);
            Gizmos.matrix = Matrix4x4.TRS(obb1.pos, obb1.rot, obb1.size);
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
            Gizmos.matrix = Matrix4x4.TRS(obb2.pos, obb2.rot, obb2.size);
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
            Gizmos.matrix = Matrix4x4.identity;

            if (Intersect3DUtils.IntersectSphere_AABB(sphere1, aabb1))
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(AABBGO1.transform.position, AABBGO1.transform.localScale);
                Gizmos.DrawWireSphere(SphereGO1.transform.position, SphereGO1.transform.localScale.x);
            }

            if (Intersect3DUtils.IntersectSphere_AABB(sphere2, aabb1))
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(AABBGO1.transform.position, AABBGO1.transform.localScale);
                Gizmos.DrawWireSphere(SphereGO2.transform.position, SphereGO2.transform.localScale.x);
            }

            if (Intersect3DUtils.IntersectAABB_AABB(aabb1, aabb2))
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(AABBGO1.transform.position, AABBGO1.transform.localScale);
                Gizmos.DrawWireCube(AABBGO2.transform.position, AABBGO2.transform.localScale);
            }

            if (Intersect3DUtils.IntersectSphere_Sphere(sphere2, sphere1))
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(SphereGO1.transform.position, SphereGO1.transform.localScale.x);
                Gizmos.DrawWireSphere(SphereGO2.transform.position, SphereGO2.transform.localScale.x);
            }

            if (Intersect3DUtils.IntersectOBB_OBB(obb1, obb2))
            {
                Gizmos.color = Color.red;
                Gizmos.matrix = Matrix4x4.TRS(obb1.pos, obb1.rot, obb1.size);
                Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
                Gizmos.matrix = Matrix4x4.TRS(obb2.pos, obb2.rot, obb2.size);
                Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
                Gizmos.matrix = Matrix4x4.identity;
            }

            if (Intersect3DUtils.IntersectOBB_Sphere(obb1, sphere1))
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(SphereGO1.transform.position, SphereGO1.transform.localScale.x);
                Gizmos.matrix = Matrix4x4.TRS(obb1.pos, obb1.rot, obb1.size);
                Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
                Gizmos.matrix = Matrix4x4.identity;
            }
        }


    }
}
