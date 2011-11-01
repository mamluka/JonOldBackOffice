Public Class cls_mail

	Public _mail_webadmin As String
	Public _mail_accountants As String
	Public _mail_shipping As String
	Public _mail_ionadmin As String
	Public _mail_sales As String
	Public _mail_direct As String
	Public _smtpserver As String

	Sub New()
		Me._mail_accountants = "ion-accountants@twin-diamonds.com"
		Me._mail_shipping = "ion-webadmins@twin-diamonds.com"
		Me._mail_webadmin = "ion-shipping@twin-diamonds.com"
		Me._mail_ionadmin = "ion-admin@twin-diamonds.com"
		Me._mail_sales = "ion-sales@twin-diamonds.com"
		Me._mail_direct = "avi@twin-diamonds.com"
        Me._smtpserver = "127.0.0.1"
	End Sub

End Class
