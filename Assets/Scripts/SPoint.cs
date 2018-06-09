

using UnityEngine;

[System.Serializable]
public struct SPoint
{
    public int m_iX;
    public int m_iY;

    //constructors
    public SPoint(int ix, int iy)
    {
        m_iX = ix;
        m_iY = iy;
    }

    public SPoint(Vector2 v2Coord)
    {
        m_iX = (int)v2Coord.x;
        m_iY = (int)v2Coord.y;
    }


    //operator overloading
    public static bool operator== (SPoint lValue, SPoint rValue )
         {
            return lValue.m_iX == rValue.m_iX && lValue.m_iY == rValue.m_iY;
        }

    public static bool operator!= (SPoint lValue, SPoint rValue)
    {
        return !(lValue.m_iX == rValue.m_iX && lValue.m_iY == rValue.m_iY);
    }
    
    //to make positioning syntax less awkward
    public static explicit operator Vector3( SPoint p)
    {
        return new Vector3(p.m_iX, p.m_iY, 0);
    }

    public override bool Equals(object obj)
    {
        if ( ! (obj is SPoint) )
        {
            return false;
        }

        return this == (SPoint)obj;
    }

    public override int GetHashCode()
    {
        return m_iX | m_iY;
    }

    public override string ToString()
    {
        return string.Format("{0} , {1}", this.m_iX, this.m_iY);
    }
}
