﻿#pragma checksum "..\..\..\Views\StateEdit.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FB4D70227C299A5FF7784953A075348FA4A3519E5ADBFB107DDA824C6C6F5861"
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
    /// StateEdit
    /// </summary>
    public partial class StateEdit : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\Views\StateEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxStateName;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Views\StateEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Views\StateEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Views\StateEdit.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Scrum_o_wall;component/views/stateedit.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\StateEdit.xaml"
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
            this.tbxStateName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Views\StateEdit.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.BtnCancel_Click);
            
            #line default
            #line hidden
            
            #line 28 "..\..\..\Views\StateEdit.xaml"
            this.btnCancel.TouchUp += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.BtnCancel_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\Views\StateEdit.xaml"
            this.btnDelete.Click += new System.Windows.RoutedEventHandler(this.BtnDelete_Click);
            
            #line default
            #line hidden
            
            #line 29 "..\..\..\Views\StateEdit.xaml"
            this.btnDelete.TouchUp += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.BtnDelete_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnConfirm = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\Views\StateEdit.xaml"
            this.btnConfirm.Click += new System.Windows.RoutedEventHandler(this.BtnConfirm_Click);
            
            #line default
            #line hidden
            
            #line 30 "..\..\..\Views\StateEdit.xaml"
            this.btnConfirm.TouchUp += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.BtnConfirm_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

