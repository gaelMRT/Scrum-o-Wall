﻿#pragma checksum "..\..\..\Views\ProjectEdit.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3E19D64F89D012B07A62E951C4D541B17DA1416E610CFDD4D2B87FDD762358ED"
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


namespace Scrum_o_wall.Views {
    
    
    /// <summary>
    /// ProjectEdit
    /// </summary>
    public partial class ProjectEdit : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\Views\ProjectEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxName;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Views\ProjectEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxDesc;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Views\ProjectEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtpckrDateBegin;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Views\ProjectEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnStates;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Views\ProjectEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUsers;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Views\ProjectEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Views\ProjectEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Views\ProjectEdit.xaml"
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
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Scrum_o_wall;component/views/projectedit.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ProjectEdit.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.tbxName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tbxDesc = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.dtpckrDateBegin = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.btnStates = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\Views\ProjectEdit.xaml"
            this.btnStates.TouchUp += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.BtnStates_Click);
            
            #line default
            #line hidden
            
            #line 44 "..\..\..\Views\ProjectEdit.xaml"
            this.btnStates.Click += new System.Windows.RoutedEventHandler(this.BtnStates_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnUsers = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\Views\ProjectEdit.xaml"
            this.btnUsers.TouchUp += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.BtnUsers_Click);
            
            #line default
            #line hidden
            
            #line 45 "..\..\..\Views\ProjectEdit.xaml"
            this.btnUsers.Click += new System.Windows.RoutedEventHandler(this.BtnUsers_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\Views\ProjectEdit.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.BtnCancel_Click);
            
            #line default
            #line hidden
            
            #line 53 "..\..\..\Views\ProjectEdit.xaml"
            this.btnCancel.TouchUp += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.BtnCancel_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\Views\ProjectEdit.xaml"
            this.btnDelete.Click += new System.Windows.RoutedEventHandler(this.BtnDelete_Click);
            
            #line default
            #line hidden
            
            #line 54 "..\..\..\Views\ProjectEdit.xaml"
            this.btnDelete.TouchUp += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.BtnDelete_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnConfirm = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\Views\ProjectEdit.xaml"
            this.btnConfirm.Click += new System.Windows.RoutedEventHandler(this.BtnConfirm_Click);
            
            #line default
            #line hidden
            
            #line 55 "..\..\..\Views\ProjectEdit.xaml"
            this.btnConfirm.TouchUp += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.BtnConfirm_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

