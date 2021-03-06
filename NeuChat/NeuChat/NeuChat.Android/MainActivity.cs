﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using NeuChat.Services;
using Android.Content;

namespace NeuChat.Droid {
    [Activity(Label = "NeuChat", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : AndroidActivity, ILoginManager {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            // Configure AMS
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            Xamarin.Forms.Forms.Init(this, bundle);

            // Configure IOC
            Bootstrapper.Configure();
            App.LoginManager = this;

            SetPage(App.GetLoginPage());
        }

        public void Logout() {
            // Do nothing
        }

        public void ShowMainPage() {
            StartActivity(new Intent(this, typeof(ChatRoomActivity)));
            this.Finish();
        }
    }
}