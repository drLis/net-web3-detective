using System;

namespace NDetective
{
	class Program
	{
		static void Main(string[] args)
		{
			var indexOfExplorerParam = Array.IndexOf(args, "--explorer") + 1;
			String explorerUrl = args[indexOfExplorerParam];
			var indexOfAddresses = Array.IndexOf(args, "--contract-addresses") + 1;
			String addressesOdContracts = args[indexOfAddresses];
			var addresses = addressesOdContracts.Split(',');
			var indexOfApiKey = Array.IndexOf(args, "--api-key") + 1;
			String apiKey = args[indexOfApiKey];

			TxParser parser = new TxParser(explorerUrl, apiKey, addresses);
			parser.Parse();
		}
	}
}
