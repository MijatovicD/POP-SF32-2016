﻿#pragma checksum "..\..\..\UI\DodavanjeIzmenaNamestaja.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E367D7B404BF035E6A4831AFFBEDC425"
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
    /// DodavanjeIzmenaNamestaja
    /// </summary>
    public partial class DodavanjeIzmenaNamestaja : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\UI\DodavanjeIzmenaNamestaja.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNaziv;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\UI\DodavanjeIzmenaNamestaja.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSifra;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\UI\DodavanjeIzmenaNamestaja.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbCena;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\UI\DodavanjeIzmenaNamestaja.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbKolicina;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\UI\DodavanjeIzmenaNamestaja.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbAkcija;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\UI\DodavanjeIzmenaNamestaja.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbTip;
        
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
            System.Uri resourceLocater = new System.Uri("/POP-SF-32-2016-GUI;component/ui/dodavanjeizmenanamestaja.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UI\DodavanjeIzmenaNamestaja.xaml"
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
            this.tbNaziv = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tbSifra = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbCena = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbKolicina = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.cbAkcija = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.cbTip = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            
            #line 36 "..\..\..\UI\DodavanjeIzmenaNamestaja.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SacuvajIzmene);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 37 "..\..\..\UI\DodavanjeIzmenaNamestaja.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Zatvori);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

