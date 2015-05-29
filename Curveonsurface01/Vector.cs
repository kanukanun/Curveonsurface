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
        private Curve crv;

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

        public void CreateCrv()
        {
            crv = Curve.CreateInterpolatedCurve(pop, 3);
        }

        private Vector3d NormalVector(double t1 , double t2)
        {
            Vector3d normvec , v1, v2;
            v1 = crv.CurvatureAt(t1);
            v2 = crv.CurvatureAt(t2);

            normvec = Vector3d.CrossProduct(v1 , v2);

            return normvec;
        }

        public void DecideCoplanar()
        {
            double angle = Vector3d.VectorAngle(NormalVector(10, 20), NormalVector(5, 2));

            if(RhinoMath.ToRadians(angle) == 0)
            {
                RhinoApp.WriteLine("curve is coplanar");
            }
        }
        
        public void Display(RhinoDoc _doc)
        {
                _doc.Objects.AddCurve(crv);
        }

    }
}
