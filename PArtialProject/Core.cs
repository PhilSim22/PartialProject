using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using Android.Locations;
using Android.App;
using Android.Runtime;
using Android.Content;
using System.Net;
using Com.Paypal.Android.Sdk.Payments;
using System.ComponentModel;
using System.Threading;

namespace PartialProject
{
	//Core class, contains properties and function that is used and need to remain between multiple activities.
	public static class Core
	{
		public static string Tokens = "N/A";		
		public static PayPalConfiguration Config = new PayPalConfiguration().Environment(PayPalConfiguration.EnvironmentNoNetwork).ClientId("AdZ_ohDTeIbI9eBTEH9MU61mRzDdvBAnqoWSy43p4ZT5UP5XLB4WILmbIc10");

	}
}

