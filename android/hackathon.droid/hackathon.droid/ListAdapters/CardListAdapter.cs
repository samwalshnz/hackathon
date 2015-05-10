using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using hackathon.droid.Models.Cards;

namespace hackathon.droid.ListAdapters
{
	public class CardListAdapter : BaseAdapter<RuleMatchModel>
    {
        public List<RuleMatchModel> Cards { get; set; } 
		private Activity _activity;

		public CardListAdapter(Activity activity) 
		{
			_activity = activity;
			Cards = new List<RuleMatchModel>();
		}


		public override RuleMatchModel this[int position]
        {
            get { return Cards[position]; }
        }

        public override int Count
        {
            get { return Cards.Count; }
        }

        public override long GetItemId(int position)
        {
			return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
			var view = convertView;
			if (convertView == null) {
				view = _activity.LayoutInflater.Inflate (Resource.Layout.card_list_item, null);
			}

			var card = Cards [position];

			var number = view.FindViewById<TextView> (Resource.Id.card_number);
			number.Text = card.Card.CardLetter;

			var description = view.FindViewById<TextView> (Resource.Id.card_description);
			description.Text = card.Rule.RuleName;

			return view;
        }
    }
}