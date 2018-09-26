using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

class FormManager
{
    private static FormManager m_singleton;


    public static FormManager GetSingleton()
    {
        if (m_singleton == null)
            m_singleton = new FormManager();
        return m_singleton;
    }

    private FormManager()  { }

    private Form m_mainForm;

    private Form m_currentFocusForm;

    public void SetMainForm(Form f) { m_mainForm = f; }

    public void SetCurrentFocusForm(Form f) { m_currentFocusForm = f; Console.WriteLine("Current is "+f.Name); }

    public Form GetMainForm() { return m_mainForm; }

    public Form GetCurrentFocusForm() { return m_currentFocusForm; }
}

