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
        if (m_zkFprint == null)
        {
            BeginInit();
        }
        return m_zkFprint;
    }

    public void BeginInit()
    {
        m_zkFprint = new AxZKFPEngX();
        m_zkFprint.OnCapture += zkFprint_OnCapture;
        m_zkFprint.OnImageReceived += zkFprint_OnImageReceived;
        m_zkFprint.OnFeatureInfo += zkFprint_OnFeatureInfo;
        m_zkFprint.OnEnroll += zkFprint_OnEnroll;
    }
    private void zkFprint_OnImageReceived(object sender, IZKFPEngXEvents_OnImageReceivedEvent e)
    {
        Console.WriteLine("zkFprint_OnImageReceived");
        m_currentOnImageReceived(sender, e);
    }
    private void zkFprint_OnFeatureInfo(object sender, IZKFPEngXEvents_OnFeatureInfoEvent e)
    {
        Console.WriteLine("zkFprint_OnFeatureInfo");
        m_currentOnFeatureInfo(sender, e);
    }
    private void zkFprint_OnEnroll(object sender, IZKFPEngXEvents_OnEnrollEvent e)
    {
        Console.WriteLine("zkFprint_OnEnroll");
        m_currentOnEnroll(sender, e);
    }
    private void zkFprint_OnCapture(object sender, IZKFPEngXEvents_OnCaptureEvent e)
    {
        Console.WriteLine("zkFprint_OnCapture");
        m_currentOnCapture(sender, e);
    }
    
    private IZKFPEngXEvents_OnCaptureEventHandler m_currentOnCapture;
    private IZKFPEngXEvents_OnFeatureInfoEventHandler m_currentOnFeatureInfo;
    private IZKFPEngXEvents_OnImageReceivedEventHandler m_currentOnImageReceived;
    private IZKFPEngXEvents_OnEnrollEventHandler m_currentOnEnroll;

    public void SetupFingerprintEvent(System.Windows.Forms.Control.ControlCollection Controls
    , IZKFPEngXEvents_OnFeatureInfoEventHandler OnFeatureInfo,
    IZKFPEngXEvents_OnImageReceivedEventHandler OnImageReceived,
    IZKFPEngXEvents_OnEnrollEventHandler OnEnroll,
    IZKFPEngXEvents_OnCaptureEventHandler OnCapture)
    {
        Controls.Add(m_zkFprint);
        m_currentOnCapture = OnCapture;
        m_currentOnImageReceived = OnImageReceived;
        m_currentOnFeatureInfo = OnFeatureInfo;
        m_currentOnEnroll = OnEnroll;
        m_zkFprint.BeginCapture();
    }

    public void RemoveFingerprintEvent(System.Windows.Forms.Control.ControlCollection Controls)
    {
        Controls.Remove(m_zkFprint);

        m_currentOnCapture = null;
        m_currentOnImageReceived = null;
        m_currentOnFeatureInfo = null;
        m_currentOnEnroll = null;
        m_zkFprint.CancelCapture();
        m_zkFprint.CancelEnroll();
    }
}
