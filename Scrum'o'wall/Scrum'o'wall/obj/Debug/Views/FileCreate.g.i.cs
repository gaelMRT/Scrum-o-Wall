// Updated by XamlIntelliSenseFileGenerator 22.05.2020 13:39:41
#pragma checksum "..\..\..\Views\FileCreate.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B35F536B802CFFD0037AC6D7284B8D5A5F8261205675F6BBB3058BB7770E982C"
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
    /// FileCreate
    /// </summary>
    public partial class FileCreate : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 24 "..\..\..\Views\FileCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxFileName;

#line default
#line hidden


#line 25 "..\..\..\Views\FileCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFileSearch;

#line default
#line hidden


#line 26 "..\..\..\Views\FileCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxDescription;

#line default
#line hidden


#line 32 "..\..\..\Views\FileCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;

#line default
#line hidden


#line 33 "..\..\..\Views\FileCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConfirm;

#line default
#line hidden

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
            System.Uri resourceLocater = new System.Uri("/Scrum_o_wall;component/views/filecreate.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Views\FileCreate.xaml"
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
            switch (connectionId)
            {
                case 1:
                    this.tbxFileName = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 2:
                    this.btnFileSearch = ((System.Windows.Controls.Button)(target));

#line 25 "..\..\..\Views\FileCreate.xaml"
                    this.btnFileSearch.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btnFileSearch_Click);

#line default
#line hidden

#line 25 "..\..\..\Views\FileCreate.xaml"
                    this.btnFileSearch.Click += new System.Windows.RoutedEventHandler(this.btnFileSearch_Click);

#line default
#line hidden
                    return;
                case 3:
                    this.tbxDescription = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 4:
                    this.cbxFileTypes = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 5:
                    this.btnCancel = ((System.Windows.Controls.Button)(target));

#line 32 "..\..\..\Views\FileCreate.xaml"
                    this.btnCancel.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btnCancel_Click);

#line default
#line hidden

#line 32 "..\..\..\Views\FileCreate.xaml"
                    this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);

#line default
#line hidden
                    return;
                case 6:
                    this.btnConfirm = ((System.Windows.Controls.Button)(target));

#line 33 "..\..\..\Views\FileCreate.xaml"
                    this.btnConfirm.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btnConfirm_Click);

#line default
#line hidden

#line 33 "..\..\..\Views\FileCreate.xaml"
                    this.btnConfirm.Click += new System.Windows.RoutedEventHandler(this.btnConfirm_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }
    }
}

