using EthScanNet.Lib;
using EthScanNet.Lib.Models.EScan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDetective
{
	class TxParser
	{
		public EScanClient client;
		public HashSet<String> addressesForParsing;

		public TxParser(string explorerUrl, string apiKey, string[] addressesOfContracts)
		{
			EScanNetwork eScanNetwork = new EScanNetwork(explorerUrl, false);
			client = new EScanClient(eScanNetwork, apiKey, null);
			addressesForParsing = new HashSet<String>();
			foreach (String address in addressesOfContracts)
			{
				addressesForParsing.Add(address);
			}
		}

		public void Parse()
		{
			foreach (var contractAddress in addressesForParsing)
			{
				EScanAddress eScanAddress = new EScanAddress(contractAddress);
				var result = client.Accounts.GetNormalTransactionsAsync(eScanAddress).Result;
				foreach (var tx in result.Transactions)
				{
					Console.WriteLine($"{tx.From}\t{tx.ContractAddress}\t{tx.BlockNumber}\t{tx.To}\t{tx.Input}");
				}
			}
		}
	}
}
