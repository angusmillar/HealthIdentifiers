using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthIdentifiers.Identifiers.Australian.DepartmentVeteransAffairs
{
    public class DVANumberGenerator : IDVANumberGenerator
    {
        private readonly Dictionary<string, string> _warCodeDictionary;
        private readonly string[] _validStateCodes = { "N", "V", "Q", "W", "S", "T" };

        public DVANumberGenerator()
        {
            _warCodeDictionary = GetWarCodeDictionary();
        }

        public string Generate()
        {
            Random random = new Random();

            int stateCodesIndex = random.Next(0, 5);
            string stateCode = _validStateCodes[stateCodesIndex];
            string warCode = _warCodeDictionary.ElementAt(random.Next(0, _warCodeDictionary.Count)).Key;

            string number = string.Empty;
            int numberLength = 7 - warCode.Length;
            for (int i = 0; i < numberLength; i++)
            {
                number += random.Next(0, 9).ToString();
            }

            string fileNumber = warCode + number;
            
            int segmentLinkPercent = random.Next(1, 100);
            
            //Only add segment links on 15% of those generated
            string segmentLink = String.Empty;
            if (segmentLinkPercent < 15)
            {
                segmentLink = RandomAlphas(1);    
            }
             
            return $"{stateCode}{fileNumber}{segmentLink}";
        }

        private static string RandomAlphas(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private static Dictionary<string, string> GetWarCodeDictionary()
        {
            return new Dictionary<string, string>()
            {
                { "A", "Allied Forces" },
                { "AFG", "Australian - War on Terrorism" },
                { "AGX", "Act of Grace" },
                { "ALX", "Algeria - World War 2" },
                { "ARG", "Argentina - Gulf War" },
                { "ARX", "Argentina - World War 2" },
                { "BAG", "Bahrain - Gulf War" },
                { "BAL", "Peacekeeping - Balkans" },
                { "BCG", "Bangladesh - Gulf War" },
                { "BG", "Belgium - World War 1" },
                { "BGG", "Belgium - Gulf War" },
                { "BGK", "Belgium - Korean War" },
                { "BGX", "Belgium - World War 2" },
                { "BRX", "Brazil - World War 2" },
                { "BUG", "Bulgaria - Gulf War" },
                { "BUR", "Burma" },
                { "BUX", "Bulgaria - World War 2" },
                { "CAM", "Australian - Cambodian Service" },
                { "CCG", "Canadian - Gulf War" },
                { "CHX", "China - World War 2" },
                { "CIX", "Chile - World War 2" },
                { "CLK", "Colombia - Korean War" },
                { "CN", "Canadian - World War 1" },
                { "CNK", "Canadian - Korean War" },
                { "CNS", "Canadian - Other Service" },
                { "CNX", "Canadian - World War 2" },
                { "CON", "Peacekeeping - Congo" },
                { "CYP", "Peacekeeping - Cyprus" },
                { "CZG", "Czechoslovakia - Gulf War" },
                { "CZX", "Czechoslovakia - World War 2" },
                { "DEG", "Denmark - Gulf War" },
                { "DNK", "Denmark - Korean War" },
                { "DNX", "Denmark - World War 2" },
                { "EGG", "Egypt - Gulf War" },
                { "EGX", "Egypt - World War 2" },
                { "EGY", "Peacekeeping - Egypt" },
                { "ESX", "Estonia - World War 2" },
                { "ET", "Australian - East Timor Service" },
                { "ETK", "Ethiopia - Korean War" },
                { "ETX", "Ethiopia - World War 2" },
                { "FIJ", "Fiji" },
                { "FIX", "Finland - World War 2" },
                { "FR", "France - World War 1" },
                { "FRG", "France - Gulf War" },
                { "FRK", "France - Korean War" },
                { "FRX", "France - World War 2" },
                { "FW", "Australian - World War 1" },
                { "GHA", "Ghana" },
                { "GR", "Greece - World War 1" },
                { "GRE", "Peacekeeping - Greece" },
                { "GRG", "Greece - Gulf War" },
                { "GRK", "Greece - Korean War" },
                { "GRX", "Greece - World War 2" },
                { "GW", "Australian - Gulf War Service" },
                { "HKS", "Hong Kong" },
                { "HKX", "Hong Kong - World War 2" },
                { "HLG", "Netherlands - Gulf War" },
                { "HLK", "Netherlands - Korea" },
                { "HLX", "Netherlands - World War 2" },
                { "HUX", "Hungary - World War 2" },
                { "IDA", "Peacekeeping - Indonesia" },
                { "IND", "India" },
                { "IQ", "Australian - War in Iraq" },
                { "ISR", "Peacekeeping - Israel" },
                { "IT", "Italy - World War 1" },
                { "ITG", "Italy - Gulf War" },
                { "ITK", "Italy - Korean War" },
                { "ITX", "Italy - World War 2" },
                { "IV", "Indigenous Veterans of PNG" },
                { "JA", "Japan - World War 1" },
                { "KM", "Australian - Korean/Malayan Service" },
                { "KO", "South Korea - Korean War" },
                { "KOS", "South Korea - Vietnam War" },
                { "KSH", "Peacekeeping - Kashmir" },
                { "KUG", "Kuwait - Gulf War" },
                { "KYA", "Kenya" },
                { "LAX", "Latvia - World War 2" },
                { "LBX", "Liberia - World War 2" },
                { "LXK", "Luxembourg - Korean War" },
                { "MAL", "Malaysian Pensioners" },
                { "MAR", "Allied Mariner- World War 2" },
                { "MAU", "Mauritius" },
                { "MLS", "Malaysia/Singapore" },
                { "MO", "Montenegro - World War 1" },
                { "MOG", "Morocco - Gulf War" },
                { "MTX", "Malta - World War 2" },
                { "MWI", "Malawi" },
                { "N", "New Zealand - World War 1" },
                { "NBA", "Australian - Namibian Service" },
                { "NCG", "New Zealand - Gulf War" },
                { "NF", "Newfoundland" },
                { "NG", "New Guinea Civilians" },
                { "NGR", "Nigeria" },
                { "NIG", "Niger - Gulf War" },
                { "NK", "New Zealand - Korean War" },
                { "NRD", "Northern Zimbabwe (Rhodesia)" },
                { "NSM", "New Zealand - Serving Member" },
                { "NSS", "New Zealand Special O'seas Service" },
                { "NSW", "New Zealand Merchant Mariner - WW2" },
                { "NWG", "Norway - Gulf War" },
                { "NWK", "Norway - Korean War" },
                { "NWX", "Norway - World War 2" },
                { "NX", "New Zealand - World War 2" },
                { "OMG", "Oman - Gulf War" },
                { "P", "British - World War 1" },
                { "PAD", "British Admiralty" },
                { "PAG", "Pakistan - Gulf War" },
                { "PAL", "Peacekeeping - Palestine" },
                { "PAM", "British Air Ministry" },
                { "PAX", "Panama - World War 2" },
                { "PCA", "British Crown Agents" },
                { "PCG", "British - Gulf War" },
                { "PCR", "British Ministry O'seas Development" },
                { "PCV", "British Civilians" },
                { "PHK", "Philippines - Korean War" },
                { "PHS", "Philippines - Vietnam War" },
                { "PHX", "Philippines - World War 2" },
                { "PK", "British - Korean/Malayan Service" },
                { "PLG", "Poland - Gulf War" },
                { "PLX", "Poland - World War 2" },
                { "PMS", "British Merchant Mariner - WW1" },
                { "PO", "Portugal - World War 1" },
                { "PSM", "British Serving Member" },
                { "PSW", "British Merchant Mariner - WW2" },
                { "PWO", "British War Office" },
                { "PX", "British - World War 2" },
                { "QAG", "Qatar - Gulf War" },
                { "RD", "Zimbabwe (Rhodesia) - World War 1" },
                { "RDX", "Zimbabwe (Rhodesia) - World War 2" },
                { "RM", "Romania - World War 1" },
                { "RU", "Russia - World War 1" },
                { "RUG", "Russia - Gulf War" },
                { "RUX", "Russia - World War 2" },
                { "SA", "South Africa - World War 1" },
                { "SAG", "Saudi Arabia - Gulf War" },
                { "SAX", "South Africa - World War 2" },
                { "SCG", "Sierra Leone - Gulf War" },
                { "SE", "Serbia - World War 1" },
                { "SEG", "Senegal - Gulf War" },
                { "SIN", "Peacekeeping - Sinai" },
                { "SL", "Sierra Leone" },
                { "SM", "Australian - Serving Member" },
                { "SO", "Australian - Somalian Service" },
                { "SPG", "Spain - Gulf War" },
                { "SR", "Australian - Malayan Emergency" },
                { "SS", "Australian Special Overseas Service" },
                { "SUD", "Sudan" },
                { "SWK", "Sweden - Korean War" },
                { "SWP", "Australian Merchant Mariner - WW2" },
                { "SYG", "Syria - Gulf War" },
                { "SYR", "Peacekeeping - Syria" },
                { "SYX", "Syria - World War 2" },
                { "THK", "Thailand - Korean War" },
                { "THS", "Thailand - Vietnam War" },
                { "TRG", "Turkey - Gulf War" },
                { "TRK", "Turkey - Korean War" },
                { "TZA", "Tanzania (Tanzanyika/Zanzibar)" },
                { "UAG", "United Arab Emirates - Gulf War" },
                { "UB", "Australian - Ubon 1965-68" },
                { "URX", "Uruguay - World War 2" },
                { "US", "United States - World War 1" },
                { "USG", "United States - Gulf War" },
                { "USK", "United States - Korean War" },
                { "USS", "United States - Vietnam War" },
                { "USX", "United States - World War 2" },
                { "V", "Australian - Serving Member" },
                { "VEX", "Venezuela - World War 2" },
                { "VNS", "South Vietnam - Vietnam War" },
                { "X", "Australian - World War 2" },
                { "YEM", "Peacekeeping - Yemen" },
                { "YGX", "Yugoslavia - World War 2" },
                { "YU", "Australian - Yugoslavian Service" },
                { "ZIM", "Peacekeeping - Zimbabwe" },
            };
        }
    }
}