﻿// Copyright © 2014 onwards, Andrew Whewell
// All rights reserved.
//
// Redistribution and use of this software in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
//    * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
//    * Neither the name of the author nor the names of the program's contributors may be used to endorse or promote products derived from this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE AUTHORS OF THE SOFTWARE BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VirtualRadar.Localisation;
using VirtualRadar.Resources;
using VirtualRadar.Interface.Settings;
using System.Net;
using VirtualRadar.WinForms.Controls;

namespace VirtualRadar.WinForms.SettingPage
{
    /// <summary>
    /// Allows configuration of the valid user list for the web site.
    /// </summary>
    public partial class PageWebServerAuthentication : Page
    {
        public override string PageTitle { get { return Strings.Users; } }

        public override Image PageIcon { get { return Images.Server16x16; } }

        public override bool PageUseFullHeight { get { return true; } }

        public PageWebServerAuthentication()
        {
            InitializeComponent();
        }

        protected override void CreateBindings()
        {
            base.CreateBindings();

            AddBinding(SettingsView, checkBoxEnabled, r => r.Configuration.WebServerSettings.AuthenticationScheme, r => r.Checked, format: Enabled_Format, parse: Enabled_Parse);

            listUsers.DataSource = CreateListBindingSource<IUser>(SettingsView.Users);
            listUsers.CheckedSubset = SettingsView.Configuration.WebServerSettings.BasicAuthenticationUserIds;
            listUsers.ExtractSubsetValue = (r) => ((IUser)r).UniqueId;
        }

        private void Enabled_Format(object sender, ConvertEventArgs args)
        {
            var scheme = (AuthenticationSchemes)args.Value;
            args.Value = scheme == AuthenticationSchemes.Basic;
        }

        private void Enabled_Parse(object sender, ConvertEventArgs args)
        {
            var enabled = (bool)args.Value;
            args.Value = enabled ? AuthenticationSchemes.Basic : AuthenticationSchemes.Anonymous;
        }

        private void listUsers_FetchRecordContent(object sender, BindingListView.RecordContentEventArgs e)
        {
            var user = e.Record as IUser;
            if(user != null) {
                e.ColumnTexts.Add(user.LoginName ?? "");
                e.ColumnTexts.Add(user.Enabled ? Strings.Yes : Strings.No);
                e.ColumnTexts.Add(user.Name ?? "");
            }
        }
    }
}