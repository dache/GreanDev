using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FingerPrint
{
    private static FingerPrint m_singleton;

    public static FingerPrint GetSingleton()
    {
        if (m_singleton == null)
            m_singleton = new FingerPrint();
        return m_singleton;
    }

    private FingerPrint()
    {

    }


}
