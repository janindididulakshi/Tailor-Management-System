using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace MalkiTailorShop
{
    public class ResponsiveUIHelper
    {
        private Form _form;
        private Size _originalFormSize;
        private Dictionary<Control, Rectangle> _originalBounds;
        private Dictionary<Control, float> _originalFontSizes;

        private ResponsiveUIHelper(Form form)
        {
            _form = form;
            _originalFormSize = form.ClientSize;
            _originalBounds = new Dictionary<Control, Rectangle>();
            _originalFontSizes = new Dictionary<Control, float>();

            CaptureOriginalBounds(form);
            WireUpNavigation(form);

            _form.Resize += Form_Resize;
        }

        public static void MakeResponsive(Form form)
        {
            new ResponsiveUIHelper(form);
            typeof(Form).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, form, new object[] { true });
            form.ClientSize = new Size(1500, 800);
        }

        private void WireUpNavigation(Form form)
        {
            AttachNavigationHandlers(form);
        }
        
        private void RemoveExistingClickHandlers(Button btn)
        {
            try
            {
                FieldInfo f1 = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
                object obj = f1.GetValue(btn);
                PropertyInfo pi = typeof(Component).GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
                EventHandlerList list = (EventHandlerList)pi.GetValue(btn, null);
                list.RemoveHandler(obj, list[obj]);
            }
            catch { }
        }

        private void AttachNavigationHandlers(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Button btn && parent.Name == "panel2")
                {
                    RemoveExistingClickHandlers(btn);
                    btn.Click += GlobalNavigation_Click;
                }

                if (control.HasChildren)
                {
                    AttachNavigationHandlers(control);
                }
            }
        }

        private void GlobalNavigation_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            string text = btn.Text.ToLower();
            string name = btn.Name.ToLower();

            Form nextForm = null;

            if (text.Contains("home") || name.Contains("home"))
            {
                if (Program.UserRole == "Tailor") nextForm = new TailerDashboard();
                else nextForm = new Home(); 
            }
            else if (text.Contains("customer") || name.Contains("customer") || name.Contains("cutomer"))
            {
                nextForm = new CustomerManagement();
            }
            else if (text.Contains("order") || name.Contains("order"))
            {
                nextForm = new OrderManagement();
            }
            else if (text.Contains("measurement") || name.Contains("measurement"))
            {
                nextForm = new Measurement();
            }
            else if (text.Contains("advance") || name.Contains("advanced") || text.Contains("advance payment"))
            {
                nextForm = new AdvancePayment();
            }
            else if (text.Contains("final payment") || name.Contains("finalpayment") || text.Contains("final"))
            {
                nextForm = new FinalPayment();
            }
            else if (text.Contains("employee") || name.Contains("employee"))
            {
                nextForm = new EmployeeManagement();
            }
            else if (text.Contains("report") || name.Contains("report"))
            {
                nextForm = new Report();
            }
            else if (text.Contains("logout") || name.Contains("logout"))
            {
                nextForm = new Login();
            }

            if (nextForm != null)
            {
                if (_form.GetType() == nextForm.GetType())
                {
                    nextForm.Dispose();
                    return;
                }
                _form.Hide();
                nextForm.Show();
            }
        }

        private void CaptureOriginalBounds(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                _originalBounds[control] = control.Bounds;
                _originalFontSizes[control] = control.Font.Size;

                Button btn = control as Button;
                if (btn != null)
                {
                    if (Program.UserRole == "Tailor" && 
                       (btn.Name.IndexOf("employee", StringComparison.OrdinalIgnoreCase) >= 0 || 
                        btn.Name.IndexOf("report", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        btn.Text.IndexOf("employee", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        btn.Text.IndexOf("report", StringComparison.OrdinalIgnoreCase) >= 0))
                    {
                        btn.Visible = false;
                    }
                }

                if (control.HasChildren)
                {
                    CaptureOriginalBounds(control);
                }
            }
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            if (_originalFormSize.Width == 0 || _originalFormSize.Height == 0) return;
            float widthRatio = (float)_form.ClientSize.Width / _originalFormSize.Width;
            float heightRatio = (float)_form.ClientSize.Height / _originalFormSize.Height;
            float fontRatio = Math.Min(widthRatio, heightRatio);
            _form.SuspendLayout();
            ScaleControls(_form, widthRatio, heightRatio, fontRatio);
            _form.ResumeLayout();
        }

        private void ScaleControls(Control parent, float widthRatio, float heightRatio, float fontRatio)
        {
            foreach (Control control in parent.Controls)
            {
                if (_originalBounds.ContainsKey(control))
                {
                    Rectangle origBounds = _originalBounds[control];
                    int newX = (int)Math.Round(origBounds.X * widthRatio);
                    int newY = (int)Math.Round(origBounds.Y * heightRatio);
                    int newWidth = (int)Math.Round(origBounds.Width * widthRatio);
                    int newHeight = (int)Math.Round(origBounds.Height * heightRatio);
                    control.Bounds = new Rectangle(newX, newY, newWidth, newHeight);

                    float origFontSize = _originalFontSizes[control];
                    float newFontSize = origFontSize * fontRatio;
                    if (newFontSize < 6f) newFontSize = 6f;

                    if (control.Font.Size != newFontSize)
                    {
                        control.Font = new Font(control.Font.FontFamily, newFontSize, control.Font.Style);
                    }
                }
                if (control.HasChildren)
                {
                    ScaleControls(control, widthRatio, heightRatio, fontRatio);
                }
            }
        }
    }
}
