﻿#pragma checksum "..\..\InicioDeSesion.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "533FF3DFE9D0FF8D64DC359D187370536DE213F51A5ECF563CD25523A7B490B1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
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
using TiendaVinilos;


namespace TiendaVinilos {
    
    
    /// <summary>
    /// InicioDeSesion
    /// </summary>
    public partial class InicioDeSesion : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\InicioDeSesion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxEmail;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\InicioDeSesion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pbxContraseña;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\InicioDeSesion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogin;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\InicioDeSesion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblUsuario;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\InicioDeSesion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblContraseña;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\InicioDeSesion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblRecordarContraseña;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\InicioDeSesion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblEstado;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\InicioDeSesion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image FotoLogoTienda;
        
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
            System.Uri resourceLocater = new System.Uri("/TiendaVinilos;component/iniciodesesion.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\InicioDeSesion.xaml"
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
            this.tbxEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.pbxContraseña = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 28 "..\..\InicioDeSesion.xaml"
            this.pbxContraseña.KeyUp += new System.Windows.Input.KeyEventHandler(this.mostrarLetraPulsada);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnLogin = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\InicioDeSesion.xaml"
            this.btnLogin.Click += new System.Windows.RoutedEventHandler(this.comprobarInformacion);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lblUsuario = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lblContraseña = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lblRecordarContraseña = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lblEstado = ((System.Windows.Controls.Label)(target));
            
            #line 33 "..\..\InicioDeSesion.xaml"
            this.lblEstado.KeyUp += new System.Windows.Input.KeyEventHandler(this.mostrarLetraPulsada);
            
            #line default
            #line hidden
            return;
            case 8:
            this.FotoLogoTienda = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

