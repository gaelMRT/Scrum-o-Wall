﻿#pragma checksum "..\..\..\Views\MindmapMenu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "ECD301F6CFDBF0B6A0C578B373EB7F252A17DBC4C42042582070BFD8FDEDF110"
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
    /// MindmapMenu
    /// </summary>
    public partial class MindmapMenu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Views\MindmapMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem CreateNode;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Views\MindmapMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Modify;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Views\MindmapMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Quit;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Views\MindmapMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer scrllVwr;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Views\MindmapMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdMindMap;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Views\MindmapMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddNode;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Views\MindmapMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReturn;
        
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
            System.Uri resourceLocater = new System.Uri("/Scrum_o_wall;component/views/mindmapmenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\MindmapMenu.xaml"
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
            this.CreateNode = ((System.Windows.Controls.MenuItem)(target));
            
            #line 17 "..\..\..\Views\MindmapMenu.xaml"
            this.CreateNode.Click += new System.Windows.RoutedEventHandler(this.CreateNode_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Modify = ((System.Windows.Controls.MenuItem)(target));
            
            #line 18 "..\..\..\Views\MindmapMenu.xaml"
            this.Modify.Click += new System.Windows.RoutedEventHandler(this.Modify_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Quit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 20 "..\..\..\Views\MindmapMenu.xaml"
            this.Quit.Click += new System.Windows.RoutedEventHandler(this.Quit_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.scrllVwr = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 5:
            this.grdMindMap = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.btnAddNode = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Views\MindmapMenu.xaml"
            this.btnAddNode.TouchUp += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.CreateNode_Click);
            
            #line default
            #line hidden
            
            #line 36 "..\..\..\Views\MindmapMenu.xaml"
            this.btnAddNode.Click += new System.Windows.RoutedEventHandler(this.CreateNode_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnReturn = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\Views\MindmapMenu.xaml"
            this.btnReturn.TouchUp += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.Quit_Click);
            
            #line default
            #line hidden
            
            #line 43 "..\..\..\Views\MindmapMenu.xaml"
            this.btnReturn.Click += new System.Windows.RoutedEventHandler(this.Quit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
