using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxZKFPEngXControl;
using ExclusiveGym.WinForms.Models;

public class FingerPrint
{
    private static FingerPrint m_singleton;

    private static AxZKFPEngX m_zkFprint;

    private List<Member> m_members;

    public static FingerPrint GetSingleton()
    {
        if (m_singleton == null)
            m_singleton = new FingerPrint();
        return m_singleton;
    }

    private FingerPrint()
    {
    }
    
    public AxZKFPEngX GetFingerprint()
    {
        if(m_zkFprint == null)
        {
            m_zkFprint = new AxZKFPEngX();
        }
        return m_zkFprint;
    }

    public async Task SetupFingerprintEvent(System.Windows.Forms.Control.ControlCollection Controls
        , IZKFPEngXEvents_OnFeatureInfoEventHandler OnFeatureInfo,
        IZKFPEngXEvents_OnImageReceivedEventHandler OnImageReceived,
        IZKFPEngXEvents_OnEnrollEventHandler OnEnroll,
        IZKFPEngXEvents_OnCaptureEventHandler OnCapture)
    {
        Controls.Add(m_zkFprint);
        m_zkFprint.OnCapture += OnCapture;
        m_zkFprint.OnImageReceived += OnImageReceived;
        m_zkFprint.OnFeatureInfo += OnFeatureInfo;
        m_zkFprint.OnEnroll += OnEnroll;
        m_zkFprint.BeginCapture();
    }

    public async Task RemoveFingerprintEvent(System.Windows.Forms.Control.ControlCollection Controls
        , IZKFPEngXEvents_OnFeatureInfoEventHandler OnFeatureInfo,
        IZKFPEngXEvents_OnImageReceivedEventHandler OnImageReceived,
        IZKFPEngXEvents_OnEnrollEventHandler OnEnroll,
        IZKFPEngXEvents_OnCaptureEventHandler OnCapture)
    {
        Controls.Remove(m_zkFprint);

        m_zkFprint.OnCapture -= OnCapture;
        m_zkFprint.OnImageReceived -= OnImageReceived;
        m_zkFprint.OnFeatureInfo -= OnFeatureInfo;
        m_zkFprint.OnEnroll -= OnEnroll;
        m_zkFprint.CancelCapture();
        m_zkFprint.CancelEnroll();
    }
}
