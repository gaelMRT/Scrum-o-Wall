﻿#pragma checksum "..\..\..\Views\StateMenu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2921EE0E7A101C1DD926DA2DDCC3BB870E125D7E9AFD1E5ADC5F5A4BA2F161B4"
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
    /// StateMenu
    /// </summary>
    public partial class StateMenu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Views\StateMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Quit;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Views\StateMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas cnvsStates;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Views\StateMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdStates;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Views\StateMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstPossibleStates;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Views\StateMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddState;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Views\StateMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstAssignedStates;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Views\StateMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGoLeft;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Views\StateMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGoRight;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Views\StateMenu.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Scrum_o_wall;component/views/statemenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\StateMenu.xaml"
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
            
            #line 13 "..\..\..\Views\StateMenu.xaml"
            this.Quit.Click += new System.Windows.RoutedEventHandler(this.Quit_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cnvsStates = ((System.Windows.Controls.Canvas)(target));
            return;
            case 3:
            this.grdStates = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.lstPossibleStates = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.btnAddState = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\Views\StateMenu.xaml"
            this.btnAddState.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btnAddState_TouchDown);
            
            #line default
            #line hidden
            
            #line 37 "..\..\..\Views\StateMenu.xaml"
            this.btnAddState.Click += new System.Windows.RoutedEventHandler(this.btnAddState_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lstAssignedStates = ((System.Windows.Controls.ListBox)(target));
            return;
            case 7:
            this.btnGoLeft = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\Views\StateMenu.xaml"
            this.btnGoLeft.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btnGoLeft_TouchDown);
            
            #line default
            #line hidden
            
            #line 51 "..\..\..\Views\StateMenu.xaml"
            this.btnGoLeft.Click += new System.Windows.RoutedEventHandler(this.btnGoLeft_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnGoRight = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\Views\StateMenu.xaml"
            this.btnGoRight.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btnGoRight_TouchDown);
            
            #line default
            #line hidden
            
            #line 52 "..\..\..\Views\StateMenu.xaml"
            this.btnGoRight.Click += new System.Windows.RoutedEventHandler(this.btnGoRight_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\Views\StateMenu.xaml"
            this.btnSave.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btnSave_TouchDown);
            
            #line default
            #line hidden
            
            #line 53 "..\..\..\Views\StateMenu.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

