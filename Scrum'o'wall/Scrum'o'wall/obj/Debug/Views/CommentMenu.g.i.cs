﻿#pragma checksum "..\..\..\Views\CommentMenu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "737285978C70716D5B31490C4F729733A4D54AAB6A15045568331ABAC55BF24B"
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
    /// CommentMenu
    /// </summary>
    public partial class CommentMenu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\Views\CommentMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lstComments;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Views\CommentMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Views\CommentMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddComment;
        
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
            System.Uri resourceLocater = new System.Uri("/Scrum_o_wall;component/views/commentmenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\CommentMenu.xaml"
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
            this.lstComments = ((System.Windows.Controls.ListView)(target));
            
            #line 27 "..\..\..\Views\CommentMenu.xaml"
            this.lstComments.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.LstComments_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 27 "..\..\..\Views\CommentMenu.xaml"
            this.lstComments.TouchUp += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.LstComments_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\Views\CommentMenu.xaml"
            this.btnCancel.TouchUp += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.BtnCancel_Click);
            
            #line default
            #line hidden
            
            #line 31 "..\..\..\Views\CommentMenu.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.BtnCancel_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnAddComment = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Views\CommentMenu.xaml"
            this.btnAddComment.TouchUp += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.BtnAddComment_Click);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\Views\CommentMenu.xaml"
            this.btnAddComment.Click += new System.Windows.RoutedEventHandler(this.BtnAddComment_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

