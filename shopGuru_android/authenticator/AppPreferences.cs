using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace shopGuru_android.authenticator
{
    public class AppPreferences
    {
        private ISharedPreferences mSharedPrefs;
        private ISharedPreferencesEditor mPrefsEditor;
        private Context mContext;

        private static String PREFERENCE_ACCESS_KEY = "PREFERENCE_ACCESS_KEY";
        private static String PREFERENCE_USER_NAME_KEY = "username";

        public AppPreferences(Context context)
        {
            this.mContext = context;
            mSharedPrefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            mPrefsEditor = mSharedPrefs.Edit();
        }

        public void saveAccessKey(string key)
        {
            mPrefsEditor.PutString(PREFERENCE_ACCESS_KEY, key);
            mPrefsEditor.Commit();
        }

        public string getAccessKey()
        {
            return mSharedPrefs.GetString(PREFERENCE_ACCESS_KEY, "");
        }

        public void SaveUserName(string username)
        {
            mPrefsEditor = mSharedPrefs.Edit();
            mPrefsEditor.PutString(PREFERENCE_USER_NAME_KEY, username);
            mPrefsEditor.Commit();
        }
        public string GetUserName()
        {
            return mSharedPrefs.GetString(PREFERENCE_USER_NAME_KEY, "");
        }
    }
}