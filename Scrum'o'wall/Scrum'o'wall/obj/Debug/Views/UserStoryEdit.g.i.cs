// Updated by XamlIntelliSenseFileGenerator 04.05.2020 11:24:27
#pragma checksum "..\..\..\Views\UserStoryEdit.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0D06E8828CFD8AAD8A4761980EFBD8907AEF7AB97D42DC17B9A4C0766280FD3D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Scrum_o_wall.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Scrum_o_wall.Views
{


    /// <summary>
    /// UserStoryEdit
    /// </summary>
    public partial class UserStoryEdit : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Scrum_o_wall;component/views/userstoryedit.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Views\UserStoryEdit.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.TextBox tbxDesc;
        internal System.Windows.Controls.TextBox tbxComplexity;
        internal System.Windows.Controls.DatePicker dtpckrDateLimit;
        internal System.Windows.Controls.Button btnCancel;
        internal System.Windows.Controls.ComboBox cbxPriority;
        internal System.Windows.Controls.ComboBox cbxType;
        internal System.Windows.Controls.Button btnFiles;
        internal System.Windows.Controls.Button btnComments;
        internal System.Windows.Controls.Button btnChecklists;
        internal System.Windows.Controls.Button btnActivities;
        internal System.Windows.Controls.Button btnUserAssigned;
        internal System.Windows.Controls.Button btnConfirm;
        internal System.Windows.Controls.TextBox tbxCompletedComplexity;
        internal System.Windows.Controls.CheckBox chckBxBlocked;
    }
}

