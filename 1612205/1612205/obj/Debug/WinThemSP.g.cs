﻿#pragma checksum "..\..\WinThemSP.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BDE1E8401434343E31D487AECBA13ED74E198FD5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using _1612205;


namespace _1612205 {
    
    
    /// <summary>
    /// WinThemSP
    /// </summary>
    public partial class WinThemSP : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\WinThemSP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbTenSanPham;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\WinThemSP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbGiaMua;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\WinThemSP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbGiaBan;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\WinThemSP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbSoLuong;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\WinThemSP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxLoaiSP;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\WinThemSP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImFileAnh;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\WinThemSP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnThem;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\WinThemSP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnHuy;
        
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
            System.Uri resourceLocater = new System.Uri("/1612205;component/winthemsp.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WinThemSP.xaml"
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
            
            #line 8 "..\..\WinThemSP.xaml"
            ((_1612205.WinThemSP)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txbTenSanPham = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txbGiaMua = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txbGiaBan = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txbSoLuong = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.cbxLoaiSP = ((System.Windows.Controls.ComboBox)(target));
            
            #line 25 "..\..\WinThemSP.xaml"
            this.cbxLoaiSP.Loaded += new System.Windows.RoutedEventHandler(this.cbxLoaiSP_Loaded);
            
            #line default
            #line hidden
            
            #line 25 "..\..\WinThemSP.xaml"
            this.cbxLoaiSP.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbxLoaiSP_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 30 "..\..\WinThemSP.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ImFileAnh = ((System.Windows.Controls.Image)(target));
            return;
            case 9:
            this.btnThem = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\WinThemSP.xaml"
            this.btnThem.Click += new System.Windows.RoutedEventHandler(this.btnThem_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnHuy = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\WinThemSP.xaml"
            this.btnHuy.Click += new System.Windows.RoutedEventHandler(this.btnHuy_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

