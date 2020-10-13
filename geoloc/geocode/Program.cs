using geocode.Extensions;
using NGeoNames;
using NGeoNames.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace geocode
{
    class Program
    {
        const string _resourcePath = ".\\Resources\\SE.txt";

        static readonly IEnumerable<ExtendedGeoName> _locationNames;
        static readonly ReverseGeoCode<ExtendedGeoName> _reverseGeoCodingService;

        static Program()
        {
            _locationNames = GeoFileReader.ReadExtendedGeoNames(_resourcePath);
            _reverseGeoCodingService = new ReverseGeoCode<ExtendedGeoName>(_locationNames);
        }

        static void Main(string[] args)
        {
            // 1. Hitta de 10 närmsta platserna till Gävle (60.674622, 17.141830), sorterat på namn.
            // 2. Hitta alla platser inom 200 km radie till Uppsala (59.858562, 17.638927), sorterat på avstånd.
            // 3. Lista x platser baserat på användarinmatning.
        }
    }
}
