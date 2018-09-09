using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxZKFPEngXControl;
using ExclusiveGym.WinForms.Models;

class FingerPrint
{
    private static FingerPrint m_singleton;

    private AxZKFPEngX m_zkFprint;

    private List<Member> m_members;

    public static FingerPrint GetSingleton()
    {
        if (m_singleton == null)
            m_singleton = new FingerPrint();
        return m_singleton;
    }

    private FingerPrint()
    {
        m_zkFprint = new AxZKFPEngX();
        LoadMember();
    }

    private void LoadMember()
    {
        m_members = new List<Member>();
        try
        {
            using (var db = new ExclusiveGymContext())
            {
                m_members = db.Members.Select(x => x).ToList();
            }
        }
        catch
        {

        }
        
    }

    public void AddMember(Member m)
    {
        if (!m_members.Contains(m))
            m_members.Add(m);
    }

    public List<Member> GetMemberList()
    {
        return m_members;
    }

    public AxZKFPEngX GetFingerprint()
    {
        return m_zkFprint;
    }

    public void SetupFingerprintEvent(System.Windows.Forms.Control.ControlCollection Controls
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

    public void RemoveFingerprintEvent(System.Windows.Forms.Control.ControlCollection Controls
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
