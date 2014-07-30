PartialProject
==============
I am under a nondisclosure agreement with my employer so I cannot share any information that could allow other to find what the application is suppose to do so it have been stripped from all information not linked to the probleme. This is a partial, functionnal executable part of my application for my question on StackOverflow: http://stackoverflow.com/posts/25000040/edit

I am building a mobile app for android with Xamarin and I want to use paypal for the user to pay us. After the payment I want to sent the confirmation to our server to check that the payment is good and complet and made the modification relating to the purchased.

I used the Android SDK to create a Java Binding Library. I used the tutorial at: https://github.com/paypal/PayPal-Android-SDK/blob/master/docs/single_payment.md

PaymentConfirmation confirm = data.getParcelableExtra(PaymentActivity.EXTRA_RESULT_CONFIRMATION);

I turned it into C# as so:

PaymentConfirmation confirm = data.GetParcelableExtra(PaymentActivity.ExtraResultConfirmation);

This give me an exception saying that there exist an explicit cast so I add it:

PaymentConfirmation confirm = (PaymentConfirmation)data.GetParcelableExtra(PaymentActivity.ExtraResultConfirmation)

This gives the following exception: System.InvaliCastException: Cannot cast from source type to destination type.

I have tried all I could think of so I'm looking for help.
