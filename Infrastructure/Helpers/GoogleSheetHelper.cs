using Application.Helpers;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Helpers
{
	public class GoogleSheetHelper
	{
		public SheetsService Service { get; set; }
		private const string APPLICATION_NAME = "AsistenciaVial_Prueba";
		private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };

		public GoogleSheetHelper()
		{
			InicializeService();
		}

		private static GoogleCredential GetCredentialsFromFile()
		{
			GoogleCredential credential;
			using (var stream = new System.IO.FileStream("google_sheet_keys.json", FileMode.Open, FileAccess.ReadWrite))
			{
				credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
			}
			return credential;
		}

		private void InicializeService()
		{
			var credential = GetCredentialsFromFile();
			Service = new SheetsService(new BaseClientService.Initializer()
			{
				HttpClientInitializer = credential,
				ApplicationName = APPLICATION_NAME
			});
		}
	}
}
