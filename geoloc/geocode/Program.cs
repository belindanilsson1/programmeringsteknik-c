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
        static readonly IEnumerable<ExtendedGeoName> _locationNames;
        static readonly ReverseGeoCode<ExtendedGeoName> _reverseGeoCodingService;
        static readonly (double Lat, double Lng) _gavle;
        static readonly (double Lat, double Lng) _uppsala;
        static readonly _formatProvider;
        static Program()
        {
            _locationNames = GeoFileReader.ReadExtendedGeoNames(".\\Resources\\SE.txt");
            _reverseGeoCodingService = new ReverseGeoCode<ExtendedGeoName>(_locationNames);
            _gavle = (60.674622, 17.141830);
            _uppsala = (59.858562, 17.638927);
            _formatProvider = CultureInfo.InvariantCulture;
        }

        static void Main(string[] args)
        {
            // 1. Hitta de 10 närmsta platserna till Gävle (60.674622, 17.141830), sorterat på namn.
            Console.WriteLine("1. Gävle");
            Console.WriteLine("------------");
            ListGavlePositions();
            // 2. Hitta alla platser inom 200 km radie till Uppsala (59.858562, 17.638927), sorterat på avstånd.
            Console.WriteLine("2. Uppsala");
            Console.WriteLine("------------");
            ListUppsalaPositions();
            // 3. Lista x platser baserat på användarinmatning.
            Console.WriteLine("3. User");
            Console.WriteLine("------------");
            ListUserPositions(args);

            Console.WriteLine();
        }

        static void ListUserPositions(string[] args)
        {
            double lat = double.Parse(args[0], _formatProvider);
            double lng = double.Parse(args[1], _formatProvider);

            var nearestUser = _reverseGeoCodingService.RadialSearch(lat, lng, 10);
            foreach (var position in nearestUser)
            {
                var userDistance = position.DistanceTo(lat, lng);
                Console.WriteLine($"{position.Name}, distance to Uppsala: {userDistance}");
            }
        }

        static void ListUppsalaPositions()
        {
            var radius = 200 * 1000;
            var nearUppsala = _reverseGeoCodingService.RadialSearch(_uppsala.Lat, _uppsala.Lng, radius, 50);

            nearUppsala = nearUppsala.OrderBy(x => x.DistanceTo(_uppsala.Lat, _uppsala.Lng));

            foreach (var position in nearUppsala)
            {
                var uppsalaDistance = position.DistanceTo(_uppsala.Lat, _uppsala.Lng);
                Console.WriteLine($"{position.Name}, distance to Uppsala: {uppsalaDistance:F1}");
            }
        }


        static void ListGavlePositions()
        {
            var nearLocation = _reverseGeoCodingService.RadialSearch(_gavle.Lat, _gavle.Lng, 10);
            nearLocation = nearLocation.OrderBy(p => p.Name);

            foreach (var location in nearLocation)
            {
                Console.WriteLine($"{location.Name}, lat: {location.Latitude}, lng {location.Longitude}");
            }
        }
    }
}
