﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using shopGuru_android.adapters;
using shopGuru_android.interfaces;
using shopGuru_android.authenticator;
using Android.Support.V7.Widget;
using Android.Support.Design.Widget;
using Android.Views.InputMethods;

namespace shopGuru_android.fragments
{
    public class ItemListFragment : Android.Support.V4.App.Fragment, View.IOnTouchListener
    {
        private RecyclerView _recyclerView;
        private RelativeLayout _subfragContainer;
        private EditText _editText;
        private Button _cfmButton;
        private Button _delButton;
        private FloatingActionButton _sendButton;
        private List<IItem> itemList;
        private int tempPos;
        private float _lastPosY;

        public ItemListFragment(List<IItem> itemList)
        {
            this.itemList = itemList;
        }


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View view = inflater.Inflate(Resource.Layout.fragment_itemList, container, false);

            _recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
          
            _subfragContainer = view.FindViewById<RelativeLayout>(Resource.Id.subfragContainer);

            _editText = view.FindViewById<EditText>(Resource.Id.itemEditField);
            _cfmButton = view.FindViewById<Button>(Resource.Id.cfmButton);
            _delButton = view.FindViewById<Button>(Resource.Id.delButton);
            _sendButton = view.FindViewById<FloatingActionButton>(Resource.Id.sendButton);


            var layoutManager = new LinearLayoutManager(this.Activity);
            var itemAdapter = new ItemViewAdapter(itemList, this.Activity);

            itemAdapter.itemClick += (object sender, int position) =>
            {
                if (_subfragContainer.TranslationY + 2 >= _subfragContainer.Height)
                {
                    MoveEditContainer(true, _subfragContainer);
                }
                _sendButton.Visibility = ViewStates.Invisible;
                tempPos = position;
                _editText.Text = itemList.ElementAt(tempPos).Name;
            };

            _recyclerView.SetLayoutManager(layoutManager);
            _recyclerView.SetAdapter(itemAdapter);

            _cfmButton.Click += (object sender, EventArgs e) =>
            {
                itemList.ElementAt(tempPos).Name = _editText.Text;
                itemAdapter.UpdateItemList(itemList);
                itemAdapter.NotifyItemChanged(tempPos);
                MoveEditContainer(false, _subfragContainer);
                _sendButton.Visibility = ViewStates.Visible;
            };

            _delButton.Click += (object sender, EventArgs e) =>
            {
                itemList.RemoveAt(tempPos);
                itemAdapter.UpdateItemList(itemList);
                itemAdapter.NotifyItemRemoved(tempPos);
                MoveEditContainer(false, _subfragContainer);
                _sendButton.Visibility = ViewStates.Visible;
            };

            _sendButton.Click += (object sender, EventArgs e) =>
            {

                ((MainActivity)Activity).StartNewFragment(new ConfirmedItemListFragment(itemList));

            };
            _subfragContainer.SetOnTouchListener(this);
            return view;
        }

        public void MoveEditContainer(bool moveUp, RelativeLayout layout)
        {
            InputMethodManager inputManager = (InputMethodManager)this.Activity.GetSystemService(Context.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.Activity.CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);

            var interpolator = new Android.Views.Animations.OvershootInterpolator(1);
            var moveDist = layout.Height;

            if (moveUp) moveDist = -moveDist;

            layout.Animate().SetInterpolator(interpolator)
                .TranslationYBy(moveDist)
                .SetDuration(500);
        }

        public bool OnTouch(View v, MotionEvent e)
        {
            switch (e.Action)
            {
                case MotionEventActions.Down:

                    _lastPosY = e.GetY();
                    return true;

                case MotionEventActions.Move:

                    var currentPosition = e.GetY();
                    var deltaY = _lastPosY - currentPosition;

                    var transY = v.TranslationY;

                    transY -= deltaY;

                    if (transY < 0)
                    {
                        transY = 0;
                    }

                    v.TranslationY = transY;

                    return true;

                default:
                    return v.OnTouchEvent(e);
            }
        }

    }
}