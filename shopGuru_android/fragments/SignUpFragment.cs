using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using shopGuru_android.controller;

namespace shopGuru_android

{
    public class OnSignUpEventArgs : EventArgs
    {
        public OnSignUpEventArgs(string name, string email, string password, string confirmPassword)
        {
            Name = name;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class SignUpFragment : DialogFragment
    {
        private EditText _txtName;
        private EditText _txtEmail;
        private EditText _txtPassword;
        private EditText _txtConfirmPassword;
        private Button _btnSignUp;

        public event EventHandler<OnSignUpEventArgs> OnSignUpComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
           
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.fragment_signUp, container, false);

            _txtName = view.FindViewById<EditText>(Resource.Id.txtName);
            _txtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            _txtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            _txtConfirmPassword = view.FindViewById<EditText>(Resource.Id.txtConfirmPassword);
            _btnSignUp = view.FindViewById<Button>(Resource.Id.btnSignUp);

            _btnSignUp.Click += BtnSignUp_Click;
            
            return view;
        }

        void BtnSignUp_Click(object sender, EventArgs e)
        {
            if(DataController.RegisterDataSubmition(_txtName.Text, _txtPassword.Text, _txtEmail.Text, "86666666"))
            {
                this.Dismiss();
            }
            else
            {
                Toast.MakeText(this.Context, "register error", ToastLength.Long);
            }
        }
    }
}