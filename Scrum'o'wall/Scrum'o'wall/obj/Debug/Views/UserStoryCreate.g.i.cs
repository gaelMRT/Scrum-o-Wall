﻿#pragma checksum "..\..\..\Views\UserStoryCreate.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F6DCBACEB1442FEBC99975D586CA1CA47558CC56FB70083C85A7CDBE438B43B1"
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
    /// UserStoryCreate
    /// </summary>
    public partial class UserStoryCreate : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\Views\UserStoryCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Views\UserStoryCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxDesc;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Views\UserStoryCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxTime;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Views\UserStoryCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxComplexity;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Views\UserStoryCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddProject;
        
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
            System.Uri resourceLocater = new System.Uri("/Scrum_o_wall;component/views/userstorycreate.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\UserStoryCreate.xaml"
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
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\Views\UserStoryCreate.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbxDesc = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbxTime = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\..\Views\UserStoryCreate.xaml"
            this.tbxTime.KeyDown += new System.Windows.Input.KeyEventHandler(this.tbxTime_KeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbxComplexity = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\..\Views\UserStoryCreate.xaml"
            this.tbxComplexity.KeyDown += new System.Windows.Input.KeyEventHandler(this.tbxComplexity_KeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnAddProject = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\Views\UserStoryCreate.xaml"
            this.btnAddProject.Click += new System.Windows.RoutedEventHandler(this.btnAddProject_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

