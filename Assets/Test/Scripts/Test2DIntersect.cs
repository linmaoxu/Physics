using UnityEngine;
using Physics2D.Entity;
using Physics2D.Utils;

namespace Physics2D.Test
{

    public class Test2DIntersect : MonoBehaviour
    {
        public GameObject AABBGO1;
        public GameObject AABBGO2;
        public GameObject SphereGO1;
        public GameObject SphereGO2;
        public GameObject ObbGO1;
        public GameObject ObbGO2;


        AABBEntity aabb1;
        AABBEntity aabb2;
        SphereEntity sphere1;
        SphereEntity sphere2;
        OBBEntity obb1;
        OBBEntity obb2;

        public void Awake()
        {

        }

        public void Init()
        {
            //Init
            aabb1 = new AABBEntity();
            aabb1.size = new Vector2((float)AABBGO1.transform.localScale.x / 2, (float)AABBGO1.transform.localScale.y / 2);
            aabb1.pos = AABBGO1.transform.position;
            aabb1.minPos = aabb1.pos - aabb1.size;
            aabb1.maxPos = aabb1.pos + aabb1.size;

            aabb2 = new AABBEntity();
            aabb2.size = new Vector2((float)AABBGO2.transform.localScale.x / 2, (float)AABBGO2.transform.localScale.y / 2);
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
            var pos = ObbGO1.transform.position;
            var size = new Vector2((float)ObbGO1.transform.localScale.x / 2, (float)ObbGO1.transform.localScale.y / 2);
            var rot = ObbGO1.transform.rotation;
            obb1.Init(pos, size, rot);

            obb2 = new OBBEntity();
            pos = ObbGO2.transform.position;
            size = new Vector2((float)ObbGO2.transform.localScale.x / 2, (float)ObbGO2.transform.localScale.y / 2);
            rot = ObbGO2.transform.rotation;
            obb2.Init(pos, size, rot);
        }

        public void OnDrawGizmos()
        {
            Init();
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(AABBGO1.transform.position, AABBGO1.transform.localScale);
            Gizmos.DrawWireCube(AABBGO2.transform.position, AABBGO2.transform.localScale);
            Gizmos.DrawWireSphere(SphereGO1.transform.position, SphereGO1.transform.localScale.x);
            Gizmos.DrawWireSphere(SphereGO2.transform.position, SphereGO2.transform.localScale.x);

            //Draw OBB
            Gizmos.matrix = Matrix4x4.TRS(ObbGO1.transform.position, ObbGO1.transform.rotation, ObbGO1.transform.localScale);
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
            Gizmos.matrix = Matrix4x4.TRS(ObbGO2.transform.position, ObbGO2.transform.rotation, ObbGO2.transform.localScale);
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
            Gizmos.matrix = Matrix4x4.identity;

            if (Intersect2DUtils.IntersectSphere_AABB(sphere1, aabb1))
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(AABBGO1.transform.position, AABBGO1.transform.localScale);
                Gizmos.DrawWireSphere(SphereGO1.transform.position, SphereGO1.transform.localScale.x);
            }

            if (Intersect2DUtils.IntersectSphere_AABB(sphere2, aabb1))
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(AABBGO1.transform.position, AABBGO1.transform.localScale);
                Gizmos.DrawWireSphere(SphereGO2.transform.position, SphereGO2.transform.localScale.x);
            }

            if (Intersect2DUtils.IntersectAABB_AABB(aabb1, aabb2))
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(AABBGO1.transform.position, AABBGO1.transform.localScale);
                Gizmos.DrawWireCube(AABBGO2.transform.position, AABBGO2.transform.localScale);
            }

            if (Intersect2DUtils.IntersectSphere_Sphere(sphere2, sphere1))
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(SphereGO1.transform.position, SphereGO1.transform.localScale.x);
                Gizmos.DrawWireSphere(SphereGO2.transform.position, SphereGO2.transform.localScale.x);
            }

            if (Intersect2DUtils.IntersectOBB_OBB(obb1, obb2))
            {
                Gizmos.color = Color.red;
                Gizmos.matrix = Matrix4x4.TRS(ObbGO1.transform.position, ObbGO1.transform.rotation, ObbGO1.transform.localScale);
                Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
                Gizmos.matrix = Matrix4x4.TRS(ObbGO2.transform.position, ObbGO2.transform.rotation, ObbGO2.transform.localScale);
                Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
            }

            if (Intersect2DUtils.IntersectOBB_Sphere(obb1, sphere1))
            {
                Gizmos.color = Color.red;
                Gizmos.matrix = Matrix4x4.TRS(ObbGO1.transform.position, ObbGO1.transform.rotation, ObbGO1.transform.localScale);
                Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
                Gizmos.matrix = Matrix4x4.identity;
                Gizmos.DrawWireSphere(SphereGO1.transform.position, SphereGO1.transform.localScale.x);

            }
        }


    }
}
