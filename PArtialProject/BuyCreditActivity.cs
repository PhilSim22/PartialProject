
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
using Com.Paypal.Android.Sdk.Payments;

namespace PartialProject
{
	[Activity (Label = "BuyCreditActivity")]			
	public class BuyCreditActivity : Activity
	{
		int creditbought= 0;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.BuyCreditLayout);

			Button BuySmall = this.FindViewById<Button> (Resource.Id.BuySmall);
			Button BuyMedium = this.FindViewById<Button> (Resource.Id.BuyMedium);
			Button BuyLarge = this.FindViewById<Button> (Resource.Id.BuyLarge);

			Intent ServiceIntent = new Intent(this, typeof(PayPalService));

			ServiceIntent.PutExtra(PayPalService.ExtraPaypalConfiguration, Core.Config);

			StartService(ServiceIntent);
		
			BuySmall.Click += (sender, e) => 
			{
				creditbought = 5;
				PayPalPayment payment = new PayPalPayment(new Java.Math.BigDecimal("1.75"), "CAD", "Small Token Package", PayPalPayment.PaymentIntentSale);

				Intent intent = new Intent(this, typeof(PaymentActivity));

				intent.PutExtra(PaymentActivity.ExtraPayment, payment);

				StartActivityForResult(intent, 0);
			};

			BuyMedium.Click += (sender, e) => 
			{
				creditbought = 10;

				PayPalPayment payment = new PayPalPayment(new Java.Math.BigDecimal("2.75"), "CAD", "Medium Token Package", PayPalPayment.PaymentIntentSale);

				Intent intent = new Intent(this, typeof(PaymentActivity));

				intent.PutExtra(PaymentActivity.ExtraPayment, payment);

				StartActivityForResult(intent, 0);
			};

			BuyLarge.Click += (sender, e) => 
			{
				creditbought = 25;
				PayPalPayment payment = new PayPalPayment(new Java.Math.BigDecimal("3.75"), "CAD", "Large Token Package", PayPalPayment.PaymentIntentSale);

				Intent intent = new Intent(this, typeof(PaymentActivity));

				intent.PutExtra(PaymentActivity.ExtraPayment, payment);

				StartActivityForResult(intent, 0);
			};
		}

		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult (requestCode, resultCode, data);
			//RESULT_OK
			if (resultCode == Result.Ok) 
			{
				PaymentConfirmActivity confirm	= (PaymentConfirmActivity)data.GetParcelableExtra(PaymentActivity.ExtraResultConfirmation);
				if (confirm != null)
				{
					//Here I need to have the PaymentConfirmation and confirm that the payment was complete and valid
				}
				int token;
				if(int.TryParse(Core.Tokens,out token))
				{
					Core.Tokens = (token + creditbought).ToString();
				}
				else
				{
					Core.Tokens = creditbought.ToString();
				}
				this.Finish();
			}
		}

	}
}

