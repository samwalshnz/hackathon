using System;
using Android.App;
using hackathon.droid.Models.Cards;
using Android.OS;
using Newtonsoft.Json;
using Android.Widget;

namespace hackathon.droid
{
	[Activity(Label = "Card Description")]
	public class CardDescriptionActivity : Activity
	{
		public RuleMatchModel Details { get;set;}

		protected async override void OnCreate(Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.card_detail_view);

			var serializedRule = Intent.GetStringExtra ("cardDetails");
			var card = JsonConvert.DeserializeObject<RuleMatchModel> (serializedRule);

			var cardNumber = FindViewById<TextView> (Resource.Id.lbl_card_number);
			cardNumber.Text = card.Card.CardLetter;

			var cardName = FindViewById<TextView> (Resource.Id.lbl_card_name);
			cardName.Text = card.Rule.RuleName;

			var cardDescription = FindViewById<TextView> (Resource.Id.lbl_card_description);
			cardDescription.Text = card.Rule.CardDescription;

		}

	}
}

