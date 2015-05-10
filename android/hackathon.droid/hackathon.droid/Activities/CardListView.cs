using Android.App;
using Android.OS;
using hackathon.droid.ListAdapters;
using hackathon.droid.Services.Concrete;
using System;
using Android.Widget;
using hackathon.droid.Models.Cards;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using Android.Content;

namespace hackathon.droid.Activities
{
	[Activity(Label = "Bla")]
    public class CardListView : Activity
    {
        protected async override void OnCreate(Bundle bundle)
        {

			try {
				base.OnCreate(bundle);
				SetContentView(Resource.Layout.card_list_view);

				var cardAdapter = new CardListAdapter (this);
					
				var listView = FindViewById<ListView> (Resource.Id.list_cards);
				listView.Adapter = cardAdapter;
				string content;

				using (StreamReader sr = new StreamReader (Assets.Open ("card-data.txt")))
				{
					content = sr.ReadToEnd ();
				}

				var data = JsonConvert.DeserializeObject<GamePlayRoot>(content);

				if(data != null) {
					var test = data.GamePlay.RuleSet.RuleMatches.ToList();
					cardAdapter.Cards = test;
				}

				listView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
	
					var item = cardAdapter.Cards[e.Position];

					var myIntent = new Intent(this, typeof(CardDescriptionActivity));
					myIntent.PutExtra("cardDetails",JsonConvert.SerializeObject(item));

					StartActivity(myIntent);
				};


			}
			catch(Exception ex) {
				throw;
			}
            

        }
    }
}