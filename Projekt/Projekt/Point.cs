using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native)]
public struct Point : INullable
{
    public override string ToString()
    {
        return "(" + this.m_x.ToString() + " " + this.m_y.ToString() + ")";
    }

    public static Point Null
    {
        get
        {
            Point h = new Point();
            h.m_Null = true;
            return h;
        }
    }

    public static Point Parse(SqlString s)
    {
        if (s.IsNull)
            return Null;
        Point u = new Point();
            string[] coords = s.Value.Split(' ');

            u.m_x = double.Parse(coords[0]);
            u.m_y = double.Parse(coords[1]);
        return u;
    }

    public bool IsNull
    {
        get
        {
            return m_Null;
        }
    }

    public double getX()
    {
        return this.m_x;
    }

    public double getY()
    {
        return (this.m_y);
    }

    public void setX(double x)
    {
        m_x = x;
    }

    public void setY(double y)
    {
        m_y = y;
    }

    public double distance(Point a)
    {
        double x_a = a.getX();
        double y_a = a.getY();
        double x_b = this.m_x;
        double y_b = this.m_y;

        return Math.Sqrt(Math.Pow((x_b - x_a), 2) + Math.Pow((y_b - y_a), 2));
    }

    private double m_x;
    private double m_y;

    private bool m_Null;
}


