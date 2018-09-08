using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxZKFPEngXControl;

class FingerPrint
{
    private static FingerPrint m_singleton;

    private AxZKFPEngX m_zkFprint = new AxZKFPEngX();

    public static FingerPrint GetSingleton()
    {
        if (m_singleton == null)
            m_singleton = new FingerPrint();
        return m_singleton;
    }

    private FingerPrint()
    {

    }

    public AxZKFPEngX GetSDK()
    {
        return m_zkFprint;
    }
}
