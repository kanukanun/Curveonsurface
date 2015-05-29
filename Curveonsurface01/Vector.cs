using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rhino;
using Rhino.Geometry;

namespace _5.Classes
{
    class CrvonSrf
    {
        private int number;
        private int width;
        private int height;
        private List<Point3d> pop = new List<Point3d>();

        public CrvonSrf(
            int _number,
            int _width,
            int _height
            
        )
        {
            number = _number;
            width = _width;
            height = _height; 
        }

        public void MakePoint()
        {
            Random rnd = new Random();

            for(int i = 0; i < number; i++)
            {
                double wid = rnd.Next(0, width);
                double hei = rnd.Next(0, height);
                pop.Add(new Point3d(wid, hei, 0));
            }
        }

        
        //private double TriangleArea(Point3d p0 , Point3d p1 , Point3d p2)
        //{
        //    double s;
        //    double half;
        //    Line l1 , l2 , l3;

        //    l1 = new Line(p0 , p1);
        //    l2 = new Line(p1 , p2);
        //    l3 = new Line(p2 , p0);
        //    half = (l1.Length + l2.Length + l3.Length) / 2;
        //    s = Math.Sqrt(half * (half - l1.Length) * (half - l2.Length) * (half - l3.Length));
            
        //    return s;
        //}
        //private Vector3d NormalVector()//get normal vector in surface
        //{
        //    Vector3d normvec , ab , ad , cd , cb;
        //    a1 = srf.PointAt(0 , 0);
        //    b1 = srf.PointAt(100 , 0);
        //    c1 = srf.PointAt(100 , 200);
        //    d1 = srf.PointAt(0 , 200);

        //    double s1 = TriangleArea(a1 , b1 , d1);
        //    double s2 = TriangleArea(c1 , d1 , b1);

        //    double sum = s1 + s2;

        //    ab = new Vector3d(b1) - new Vector3d(a1);
        //    ad = new Vector3d(d1) - new Vector3d(a1);
        //    cd = new Vector3d(d1) - new Vector3d(c1);
        //    cb = new Vector3d(b1) - new Vector3d(c1);

        //    normvec = Vector3d.CrossProduct(ab , ad) * (s1 / sum);
        //    normvec += Vector3d.CrossProduct(cd, cb) * (s2 / sum);
            
        //    return normvec / normvec.Length;
        //}

        //private Point3d Center()
        //{
        //    Point3d center = srf.PointAt(50 , 100);
        //    return center;
        //}

        //public void MoveSrf(int num)//pile of brick
        //{
        //    double ang = RhinoMath.ToRadians((angle / (num - 1)) * id);

        //    bool flag2 = srf.Rotate(ang , NormalVector(), Center());

        //    bool flag3 = srf.Rotate(ang, new Vector3d(0, 1, 0), Center());
        //}
        
        public void Display(RhinoDoc _doc)
        {
            for (int i = 0; i < number; i++)
            {
                _doc.Objects.AddPoint(pop[i]);
            }
        }

    }
}
