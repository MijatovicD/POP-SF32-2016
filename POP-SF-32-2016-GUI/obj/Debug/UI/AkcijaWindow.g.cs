﻿#pragma checksum "..\..\..\UI\AkcijaWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DA8484C0FC8A4F9580D4FD44B6184AEC204B0CF7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using POP_SF_32_2016_GUI.UI;
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


namespace POP_SF_32_2016_GUI.UI {
    
    
    /// <summary>
    /// AkcijaWindow
    /// </summary>
    public partial class AkcijaWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\UI\AkcijaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgAkcija;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\UI\AkcijaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPretraga;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\UI\AkcijaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbSortiraj;
        
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
            System.Uri resourceLocater = new System.Uri("/POP-SF-32-2016-GUI;component/ui/akcijawindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UI\AkcijaWindow.xaml"
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
            this.dgAkcija = ((System.Windows.Controls.DataGrid)(target));
            
            #line 15 "..\..\..\UI\AkcijaWindow.xaml"
            this.dgAkcija.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.dgAkcija_AutoGeneratingColumn);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\UI\AkcijaWindow.xaml"
            this.dgAkcija.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.Akcija_broj);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbPretraga = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.cbSortiraj = ((System.Windows.Controls.ComboBox)(target));
            
            #line 17 "..\..\..\UI\AkcijaWindow.xaml"
            this.cbSortiraj.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbSortiraj_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 20 "..\..\..\UI\AkcijaWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DodajAkciju_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 29 "..\..\..\UI\AkcijaWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IzmeniAkciju_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 38 "..\..\..\UI\AkcijaWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ObrsiAkciju_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 47 "..\..\..\UI\AkcijaWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Zatvori_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 56 "..\..\..\UI\AkcijaWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

