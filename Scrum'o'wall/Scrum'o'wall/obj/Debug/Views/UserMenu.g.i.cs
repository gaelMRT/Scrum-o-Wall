﻿#pragma checksum "..\..\..\Views\UserMenu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FAF6857533F2E2D15E40F5925B34F223E6D436418C4D31DA46A385372C3E4C35"
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
    /// UserMenu
    /// </summary>
    public partial class UserMenu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Views\UserMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Quit;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Views\UserMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas cnvsStates;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Views\UserMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdStates;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Views\UserMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstPossibleUsers;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Views\UserMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddUser;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Views\UserMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstAssignedUsers;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Views\UserMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGoLeft;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Views\UserMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGoRight;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Views\UserMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
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
            System.Uri resourceLocater = new System.Uri("/Scrum_o_wall;component/views/usermenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\UserMenu.xaml"
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
            this.Quit = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 2:
            this.cnvsStates = ((System.Windows.Controls.Canvas)(target));
            return;
            case 3:
            this.grdStates = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.lstPossibleUsers = ((System.Windows.Controls.ListBox)(target));
            
            #line 34 "..\..\..\Views\UserMenu.xaml"
            this.lstPossibleUsers.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Lst_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnAddUser = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\Views\UserMenu.xaml"
            this.btnAddUser.TouchUp += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.BtnAddUser_Click);
            
            #line default
            #line hidden
            
            #line 37 "..\..\..\Views\UserMenu.xaml"
            this.btnAddUser.Click += new System.Windows.RoutedEventHandler(this.BtnAddUser_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lstAssignedUsers = ((System.Windows.Controls.ListBox)(target));
            
            #line 41 "..\..\..\Views\UserMenu.xaml"
            this.lstAssignedUsers.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Lst_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnGoLeft = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\Views\UserMenu.xaml"
            this.btnGoLeft.TouchUp += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.BtnGoLeft_Click);
            
            #line default
            #line hidden
            
            #line 51 "..\..\..\Views\UserMenu.xaml"
            this.btnGoLeft.Click += new System.Windows.RoutedEventHandler(this.BtnGoLeft_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnGoRight = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\Views\UserMenu.xaml"
            this.btnGoRight.TouchUp += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.BtnGoRight_Click);
            
            #line default
            #line hidden
            
            #line 52 "..\..\..\Views\UserMenu.xaml"
            this.btnGoRight.Click += new System.Windows.RoutedEventHandler(this.BtnGoRight_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\Views\UserMenu.xaml"
            this.btnSave.TouchUp += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.BtnSave_Click);
            
            #line default
            #line hidden
            
            #line 53 "..\..\..\Views\UserMenu.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.BtnSave_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

