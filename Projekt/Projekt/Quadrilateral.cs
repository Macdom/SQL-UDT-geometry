using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native)]
public struct Quadrilateral : INullable
{
    public override string ToString()
    {
        string res = "";
        res += ("A: " + A.ToString() + Environment.NewLine);
        res += ("B: " + B.ToString() + Environment.NewLine);
        res += ("C: " + C.ToString() + Environment.NewLine);
        res += ("D: " + D.ToString());

        return res;
    }

    public bool IsNull
    {
        get{
            Quadrilateral h = new Quadrilateral();
            h.m_Null = true;
            return m_Null;
        }
    }

    public static Quadrilateral Null
    {
        get
        {
            Quadrilateral h = new Quadrilateral();
            h.m_Null = true;
            return h;
        }
    }

    public static Quadrilateral Parse(SqlString s)
    {
        if (s.IsNull)
            return Null;
        Quadrilateral u = new Quadrilateral();
        string[] pointString = s.Value.Split('|');
        
        string[] a = pointString[0].Split(' ');
        u.A = new Point();
        u.A.setX(double.Parse(a[0]));
        u.A.setY(double.Parse(a[1]));

        string[] b = pointString[1].Split(' ');
        u.A = new Point();
        u.B.setX(double.Parse(b[0]));
        u.B.setY(double.Parse(b[1]));

        string[] c = pointString[2].Split(' ');
        u.C = new Point();
        u.C.setX(double.Parse(c[0]));
        u.C.setY(double.Parse(c[1]));

        string[] d = pointString[3].Split(' ');
        u.D = new Point();
        u.D.setX(double.Parse(d[0]));
        u.D.setY(double.Parse(d[1]));

        return u;
    }

    public string getA()
    {
        return A.ToString();
    }

    public string getB()
    {
        return B.ToString();
    }

    public string getC()
    {
        return C.ToString();
    }

    public string getD()
    {
        return D.ToString();
    }

    public double Area() 
    {
        Point[] points = new Point[5];
        points[0] = A;
        points[1] = B;
        points[2] = C;
        points[3] = D;
        points[4] = A;

        double area = 0;
        for (int i = 0; i < 4; i++)
        {
            area += (points[i].getX() * points[i+1].getY()) - (points[i + 1].getX() * points[i].getY());
        }
        return Math.Abs(area) / 2;
    }

    private static double DotProduct(double Ax, double Ay, double Bx, double By, double Cx, double Cy)
    {
        double BAx = Ax - Bx;
        double BAy = Ay - By;
        double BCx = Cx - Bx;
        double BCy = Cy - By;

        return (BAx * BCx + BAy * BCy);
    }

    private static double CrossProductLength(double Ax, double Ay, double Bx, double By, double Cx, double Cy)
    {
        double BAx = Ax - Bx;
        double BAy = Ay - By;
        double BCx = Cx - Bx;
        double BCy = Cy - By;

        return (BAx * BCy - BAy * BCx);
    }

    public static double GetAngle(double Ax, double Ay, double Bx, double By, double Cx, double Cy)
    {
        double dotProduct = DotProduct(Ax, Ay, Bx, By, Cx, Cy);
        double crossProduct = CrossProductLength(Ax, Ay, Bx, By, Cx, Cy);

        return (double)Math.Atan2(crossProduct, dotProduct);
    }

    public bool IsInside(Point P)
    {
        Point[] points = new Point[4];
        points[0] = A;
        points[1] = B;
        points[2] = C;
        points[3] = D;

        double totalAngle = GetAngle(points[3].getX(), points[3].getY(), P.getX(), P.getY(), points[0].getX(), points[0].getY());

        for (int i = 0; i < 3; i++) 
        {
            totalAngle += GetAngle(points[i].getX(), points[i].getY(), P.getX(), P.getY(), points[i + 1].getX(), points[i + 1].getY());
        }

        if (Math.Abs(totalAngle) > 1) return true;
        else return false;
    }

    private Point A;
    private Point B;
    private Point C;
    private Point D;

    private bool m_Null;
}


