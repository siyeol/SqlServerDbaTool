using System;
using System.Threading;
using System.Windows.Forms;

namespace HaTool.Config
{
   public partial class FormInitScriptVerify : Form
   {

      private static readonly Lazy<FormInitScriptVerify> lazy =
          new Lazy<FormInitScriptVerify>(() => new FormInitScriptVerify(), LazyThreadSafetyMode.ExecutionAndPublication);

      public static FormInitScriptVerify Instance { get { return lazy.Value; } }

      public FormInitScriptVerify()
      {
         InitializeComponent();
      }

      public string UserData
      {
         set { fastColoredTextBoxUserData.Text = value; }
      }

      public string PowerShellContensts
      {
         set { fastColoredTextBoxPowerShellScriptContents.Text = value; }
      }

      private void buttonClose_Click(object sender, EventArgs e)
      {
         Close();
      }
   }
}
