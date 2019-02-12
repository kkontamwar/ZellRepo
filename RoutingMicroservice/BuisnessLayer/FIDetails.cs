using RoutingMicroservice.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoutingMicroservice.BuisnessLayer
{
	public static class FIDetails
	{
		public static string GetFIURIByName(string fiName)
		{
			switch (fiName)
			{
				case "8871085":
					return ConstantValues.FI1_URL;
				case "8871086":
					return ConstantValues.FI2_URL;
				default:
					return ConstantValues.FI1_URL;
			}
		}

	}
}