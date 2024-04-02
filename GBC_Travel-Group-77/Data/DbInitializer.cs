using GBC_Travel_Group_77.Data;
using GBC_Travel_Group_77.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GBC_Travel_Group_77.Data
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            AppDbContext context = applicationBuilder.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<AppDbContext>();

            if (!context.Cars.Any())
            {

                // Seed Cars
                var carList = new List<Car>
                {
                    new Car
                    {
                        category="car",
                        make = "Toyota",
                        model = "Corolla",
                        type = "Sedan",
                        yearManufactured = 2018,
                        color = "Black",
                        licensePlate = "ABC123",
                        seatCapacity = 5,
                        isAvailable = true,
                        price = 100.00,
                        isHotDeal = false,
                        shortDescription = "Reliable sedan for everyday use",
                        longDescription = "The Toyota Corolla is a compact sedan known for its reliability and fuel efficiency.",
                        imageUrl = "~/img/cars/car1.jpg"
                    },
                    new Car
                    {
                         category="car",
                        make = "Honda",
                        model = "Accord",
                        type = "Sedan",
                        yearManufactured = 2019,
                        color = "Silver",
                        licensePlate = "DEF456",
                        seatCapacity = 5,
                        isAvailable = true,
                        price = 120.00,
                        isHotDeal = false,
                        shortDescription = "Comfortable sedan with modern features",
                        longDescription = "The Honda Accord offers a spacious interior, advanced safety features, and a smooth ride.",
                        imageUrl = "~/img/cars/car2.jpg"
                    },
                    new Car
                    { category="car",

                        make = "Ford",
                        model = "Escape",
                        type = "SUV",
                        yearManufactured = 2020,
                        color = "White",
                        licensePlate = "GHI789",
                        seatCapacity = 5,
                        isAvailable = true,
                        price = 80.00,
                        isHotDeal = true,
                        shortDescription = "Versatile SUV for urban and off-road adventures",
                        longDescription = "The Ford Escape combines practicality with capability, making it a great choice for both city driving and outdoor adventures.",
                        imageUrl = "~/img/cars/car3.jpg"
                    },
                    new Car
                    {
                         category="car",
                        make = "Chevrolet",
                        model = "Tahoe",
                        type = "SUV",
                        yearManufactured = 2021,
                        color = "Red",
                        licensePlate = "JKL101",
                        seatCapacity = 8,
                        isAvailable = true,
                        price = 180.00,
                        isHotDeal = false,
                        shortDescription = "Spacious SUV with room for the whole family",
                        longDescription = "The Chevrolet Tahoe offers ample space, advanced technology, and impressive towing capacity, making it perfect for family road trips.",
                        imageUrl = "~/img/cars/car4.jpg"
                    },
                    new Car
                    {
                         category="car",
                        make = "BMW",
                        model = "X5",
                        type = "SUV",
                        yearManufactured = 2019,
                        color = "Blue",
                        licensePlate = "MNO202",
                        seatCapacity = 5,
                        isAvailable = true,
                        price = 200.00,
                        isHotDeal = false,
                        shortDescription = "Luxurious SUV with powerful performance",
                        longDescription = "The BMW X5 combines luxury, performance, and versatility, making it a top choice for discerning drivers.",
                        imageUrl = "~/img/cars/car5.jpg"
                    },
                    new Car
                    {
                         category="car",
                        make = "Audi",
                        model = "A4",
                        type = "Sedan",
                        yearManufactured = 2020,
                        color = "Gray",
                        licensePlate = "PQR303",
                        seatCapacity = 5,
                        isAvailable = true,
                        price = 200.00,
                        isHotDeal = false,
                        shortDescription = "Premium sedan with elegant design",
                        longDescription = "The Audi A4 offers a blend of luxury, performance, and cutting-edge technology, setting new standards in its class.",
                        imageUrl = "~/img/cars/car6.jpg"
                    },
                    new Car
                    {
                         category="car",
                        make = "Nissan",
                        model = "Altima",
                        type = "Sedan",
                        yearManufactured = 2021,
                        color = "Black",
                        licensePlate = "STU404",
                        seatCapacity = 5,
                        isAvailable = true,
                        price = 90.00,
                        isHotDeal = true,
                        shortDescription = "Efficient sedan with modern styling",
                        longDescription = "The Nissan Altima boasts a spacious cabin, fuel-efficient engine options, and a host of advanced safety features.",
                        imageUrl = "~/img/cars/car7.jpg"
                    },
                    new Car
                    {
                         category="car",
                        make = "Volkswagen",
                        model = "Golf",
                        type = "Hatchback",
                        yearManufactured = 2020,
                        color = "White",
                        licensePlate = "VWX505",
                        seatCapacity = 5,
                        isAvailable = true,
                        price = 130.00,
                        isHotDeal = false,
                        shortDescription = "Sporty hatchback with agile handling",
                        longDescription = "The Volkswagen Golf offers a perfect blend of performance, comfort, and practicality, making it a top choice among hatchbacks.",
                        imageUrl = "~/img/cars/car8.jpg"
                    },
                    new Car
                    {
                         category="car",
                        make = "Hyundai",
                        model = "Elantra",
                        type = "Sedan",
                        yearManufactured = 2019,
                        color = "Red",
                        licensePlate = "YZA606",
                        seatCapacity = 5,
                        isAvailable = true,
                        price = 120.00,
                        isHotDeal = false,
                        shortDescription = "Affordable sedan with modern features",
                        longDescription = "The Hyundai Elantra offers a spacious interior, smooth ride, and advanced technology at an affordable price.",
                        imageUrl = "~/img/cars/car9.jpg"
                    },
                    new Car
                    {
                         category="car",
                        make = "Mercedes-Benz",
                        model = "E-Class",
                        type = "Sedan",
                        yearManufactured = 2022,
                        color = "Silver",
                        licensePlate = "BCD707",
                        seatCapacity = 5,
                        isAvailable = true,
                        price =150.00,
                        isHotDeal = true,
                        shortDescription = "Luxury sedan with cutting-edge technology",
                        longDescription = "The Mercedes-Benz E-Class sets the standard for luxury sedans with its elegant design, refined interior, and advanced features.",
                        imageUrl = "~/img/cars/car10.jpg"
                    },
                    new Car
                    {
                         category="car",
                        make = "Toyota",
                        model = "Rav4",
                        type = "SUV",
                        yearManufactured = 2020,
                        color = "Blue",
                        licensePlate = "EFG808",
                        seatCapacity = 5,
                        isAvailable = true,
                        price = 120.00,
                        isHotDeal = false,
                        shortDescription = "Compact SUV for urban adventures",
                        longDescription = "The Toyota Rav4 combines versatility with fuel efficiency, making it perfect for city driving and outdoor adventures.",
                        imageUrl = "~/img/cars/car11.jpg"
                    },
                    new Car
                    { category="car",

                        make = "Honda",
                        model = "CR-V",
                        type = "SUV",
                        yearManufactured = 2019,
                        color = "Gray",
                        licensePlate = "HIJ909",
                        seatCapacity = 5,
                        isAvailable = true,
                        price = 130.00,
                        isHotDeal = false,
                        shortDescription = "Spacious SUV with advanced safety features",
                        longDescription = "The Honda CR-V offers a comfortable ride, ample cargo space, and a range of advanced safety features for peace of mind.",
                        imageUrl = "~/img/cars/car12.jpg"
                    },
                    new Car
                    { category="car",

                        make = "Ford",
                        model = "Mustang",
                        type = "Coupe",
                        yearManufactured = 2021,
                        color = "Red",
                        licensePlate = "KLM101",
                        seatCapacity = 4,
                        isAvailable = true,
                        price = 170.00,
                        isHotDeal = false,
                        shortDescription = "Iconic sports car with powerful performance",
                        longDescription = "The Ford Mustang is a legendary sports car known for its muscular styling, exhilarating performance, and iconic heritage.",
                        imageUrl = "~/img/cars/car13.jpg"
                    },
                    new Car
                    { category="car",

                        make = "Chevrolet",
                        model = "Camaro",
                        type = "Coupe",
                        yearManufactured = 2020,
                        color = "Black",
                        licensePlate = "NOP202",
                        seatCapacity = 4,
                        isAvailable = true,
                        price = 220.00,
                        isHotDeal = false,
                        shortDescription = "Muscle car with timeless appeal",
                        longDescription = "The Chevrolet Camaro combines classic American muscle car styling with modern technology and performance for an unforgettable driving experience.",
                        imageUrl = "~/img/cars/car14.jpg"
                    },
                    new Car
                    {
                         category="car",
                        make = "BMW",
                        model = "3 Series",
                        type = "Sedan",
                        yearManufactured = 2022,
                        color = "White",
                        licensePlate = "QRS303",
                        seatCapacity = 5,
                        isAvailable = true,
                        price = 220.00,
                        isHotDeal = false,
                        shortDescription = "Premium sedan with dynamic performance",
                        longDescription = "The BMW 3 Series offers a perfect balance of luxury, performance, and advanced technology, setting new standards in its class.",
                        imageUrl = "~/img/cars/car15.jpg"
                    }
                };
                context.AddRange(carList.ToArray());
                context.SaveChanges();
            }


            if (!context.Flights.Any())
            {

                // Seed Flights
                var flightList = new List<Flight>
                {

                    new Flight
                    { category="flight",

                        company = "Delta Airlines",
                        departureAirport = "JFK",
                        departureGate = "A1",
                        departureDate = "2024-02-17",
                        arrivalAirport = "LAX",
                        arrivalGate = "B3",
                        arrivalDate = "2024-02-17",
                        flightDuration = 360, // minutes
                        totalSeats = 200,
                        availableSeats = 180,
                        flightStatus = "On-time",
                        price = 500,
                        isHotDeal = false,
                        shortDescription = "Direct flight from JFK to LAX",
                        longDescription = "This flight offers a direct route from John F. Kennedy International Airport to Los Angeles International Airport."
                    },
                    new Flight
                    {

                        category="flight",
                        company = "American Airlines",
                        departureAirport = "LHR",
                        departureGate = "C2",
                        departureDate = "2024-02-18",
                        arrivalAirport = "CDG",
                        arrivalGate = "D5",
                        arrivalDate = "2024-02-18",
                        flightDuration = 180, // minutes
                        totalSeats = 150,
                        availableSeats = 120,
                        flightStatus = "Delayed",
                        price = 450,
                        isHotDeal = true,
                        shortDescription = "Connecting flight from London to Paris",
                        longDescription = "This flight provides a connecting route from London Heathrow Airport to Charles de Gaulle Airport in Paris."
                    },
                    new Flight
                    {
                        category="flight",
                        company = "Emirates",
                        departureAirport = "DXB",
                        departureGate = "E7",
                        departureDate = "2024-02-19",
                        arrivalAirport = "IST",
                        arrivalGate = "F2",
                        arrivalDate = "2024-02-19",
                        flightDuration = 270, // minutes
                        totalSeats = 300,
                        availableSeats = 250,
                        flightStatus = "On-time",
                        price = 700,
                        isHotDeal = false,
                        shortDescription = "Direct flight from Dubai to Istanbul",
                        longDescription = "Experience luxury travel with Emirates from Dubai International Airport to Istanbul Airport."
                    },
                    new Flight
                    {
                        category="flight",
                        company = "Qantas",
                        departureAirport = "SYD",
                        departureGate = "G4",
                        departureDate = "2024-02-20",
                        arrivalAirport = "MEL",
                        arrivalGate = "H1",
                        arrivalDate = "2024-02-20",
                        flightDuration = 90, // minutes
                        totalSeats = 180,
                        availableSeats = 150,
                        flightStatus = "On-time",
                        price = 300,
                        isHotDeal = false,
                        shortDescription = "Quick flight from Sydney to Melbourne",
                        longDescription = "Fly with Qantas for a short and comfortable trip from Sydney Kingsford Smith Airport to Melbourne Airport."
                    },
                    new Flight
                    {category="flight",

                        company = "Air India",
                        departureAirport = "BOM",
                        departureGate = "I3",
                        departureDate = "2024-02-21",
                        arrivalAirport = "DEL",
                        arrivalGate = "J6",
                        arrivalDate = "2024-02-21",
                        flightDuration = 150, // minutes
                        totalSeats = 250,
                        availableSeats = 200,
                        flightStatus = "On-time",
                        price = 400,
                        isHotDeal = false,
                        shortDescription = "Flight from Mumbai to Delhi",
                        longDescription = "Enjoy the hospitality of Air India on your journey from Chhatrapati Shivaji Maharaj International Airport to Indira Gandhi International Airport."
                    },
                    new Flight
                    {category="flight",

                        company = "LATAM Airlines",
                        departureAirport = "GRU",
                        departureGate = "K5",
                        departureDate = "2024-02-22",
                        arrivalAirport = "GIG",
                        arrivalGate = "L2",
                        arrivalDate = "2024-02-22",
                        flightDuration = 120, // minutes
                        totalSeats = 160,
                        availableSeats = 130,
                        flightStatus = "On-time",
                        price = 250,
                        isHotDeal = true,
                        shortDescription = "Short flight from Sao Paulo to Rio de Janeiro",
                        longDescription = "Experience the vibrant culture of Brazil with LATAM Airlines from Sao Paulo-Guarulhos International Airport to Rio de Janeiro-Galeão International Airport."
                    },
                    new Flight
                    {
                        category="flight",
                        company = "Air Canada",
                        departureAirport = "YYZ",
                        departureGate = "M3",
                        departureDate = "2024-02-23",
                        arrivalAirport = "YVR",
                        arrivalGate = "N4",
                        arrivalDate = "2024-02-23",
                        flightDuration = 300, // minutes
                        totalSeats = 220,
                        availableSeats = 180,
                        flightStatus = "On-time",
                        price = 600,
                        isHotDeal = false,
                        shortDescription = "Flight from Toronto to Vancouver",
                        longDescription = "Travel comfortably with Air Canada from Toronto Pearson International Airport to Vancouver International Airport."
                    },
                    new Flight
                    {
                        category="flight",
                        company = "Singapore Airlines",
                        departureAirport = "SIN",
                        departureGate = "O2",
                        departureDate = "2024-02-24",
                        arrivalAirport = "BKK",
                        arrivalGate = "P8",
                        arrivalDate = "2024-02-24",
                        flightDuration = 180, // minutes
                        totalSeats = 180,
                        availableSeats = 160,
                        flightStatus = "On-time",
                        price = 550,
                        isHotDeal = false,
                        shortDescription = "Flight from Singapore to Bangkok",
                        longDescription = "Experience the exceptional service of Singapore Airlines from Singapore Changi Airport to Suvarnabhumi Airport in Bangkok."
                    },
                    new Flight
                    {category="flight",

                        company = "Cathay Pacific",
                        departureAirport = "HKG",
                        departureGate = "Q5",
                        departureDate = "2024-02-25",
                        arrivalAirport = "PVG",
                        arrivalGate = "R3",
                        arrivalDate = "2024-02-25",
                        flightDuration = 150, // minutes
                        totalSeats = 200,
                        availableSeats = 170,
                        flightStatus = "On-time",
                        price = 480,
                        isHotDeal = false,
                        shortDescription = "Flight from Hong Kong to Shanghai",
                        longDescription = "Fly with Cathay Pacific from Hong Kong International Airport to Shanghai Pudong International Airport for a seamless journey."
                    },
                    new Flight
                    {
                        category="flight",
                        company = "KLM",
                        departureAirport = "AMS",
                        departureGate = "S7",
                        departureDate = "2024-02-26",
                        arrivalAirport = "TXL",
                        arrivalGate = "T1",
                        arrivalDate = "2024-02-26",
                        flightDuration = 120, // minutes
                        totalSeats = 150,
                        availableSeats = 120,
                        flightStatus = "On-time",
                        price = 400,
                        isHotDeal = true,
                        shortDescription = "Flight from Amsterdam to Berlin",
                        longDescription = "Enjoy a smooth journey with KLM from Amsterdam Airport Schiphol to Berlin Tegel Airport."
                    },
                    new Flight
                    {category="flight",

                        company = "Iberia",
                        departureAirport = "BCN",
                        departureGate = "U8",
                        departureDate = "2024-02-27",
                        arrivalAirport = "MAD",
                        arrivalGate = "V2",
                        arrivalDate = "2024-02-27",
                        flightDuration = 90, // minutes
                        totalSeats = 160,
                        availableSeats = 140,
                        flightStatus = "On-time",
                        price = 300,
                        isHotDeal = false,
                        shortDescription = "Flight from Barcelona to Madrid",
                        longDescription = "Experience the warmth of Spain with Iberia from Barcelona-El Prat Airport to Adolfo Suárez Madrid–Barajas Airport."
                    },
                    new Flight
                    {
                        category="flight",
                        company = "South African Airways",
                        departureAirport = "JNB",
                        departureGate = "W6",
                        departureDate = "2024-02-28",
                        arrivalAirport = "CPT",
                        arrivalGate = "X3",
                        arrivalDate = "2024-02-28",
                        flightDuration = 120, // minutes
                        totalSeats = 200,
                        availableSeats = 170,
                        flightStatus = "On-time",
                        price = 350,
                        isHotDeal = false,
                        shortDescription = "Flight from Johannesburg to Cape Town",
                        longDescription = "Discover the beauty of South Africa with South African Airways from O.R. Tambo International Airport to Cape Town International Airport."
                    },
                    new Flight
                    {
                        category="flight",
                        company = "Alitalia",
                        departureAirport = "FCO",
                        departureGate = "Y1",
                        departureDate = "2024-03-01",
                        arrivalAirport = "ATH",
                        arrivalGate = "Z4",
                        arrivalDate = "2024-03-01",
                        flightDuration = 150, // minutes
                        totalSeats = 180,
                        availableSeats = 150,
                        flightStatus = "On-time",
                        price = 400,
                        isHotDeal = false,
                        shortDescription = "Flight from Rome to Athens",
                        longDescription = "Experience the rich history of Italy and Greece with Alitalia from Leonardo da Vinci–Fiumicino Airport to Athens International Airport."
                    },
                    new Flight
                    {
                        category="flight",
                        company = "LATAM Airlines",
                        departureAirport = "EZE",
                        departureGate = "A9",
                        departureDate = "2024-03-02",
                        arrivalAirport = "SCL",
                        arrivalGate = "B7",
                        arrivalDate = "2024-03-02",
                        flightDuration = 180, // minutes
                        totalSeats = 200,
                        availableSeats = 180,
                        flightStatus = "On-time",
                        price = 450,
                        isHotDeal = false,
                        shortDescription = "Flight from Buenos Aires to Santiago",
                        longDescription = "Fly with LATAM Airlines from Ministro Pistarini International Airport to Arturo Merino Benítez International Airport for a pleasant journey."
                    },
                    new Flight
                    {
                        category="flight",
                        company = "Virgin Atlantic",
                        departureAirport = "LAX",
                        departureGate = "C7",
                        departureDate = "2024-03-03",
                        arrivalAirport = "JFK",
                        arrivalGate = "D9",
                        arrivalDate = "2024-03-03",
                        flightDuration = 360, // minutes
                        totalSeats = 220,
                        availableSeats = 200,
                        flightStatus = "On-time",
                        price = 550,
                        isHotDeal = false,
                        shortDescription = "Flight from Los Angeles to New York",
                        longDescription = "Enjoy the comfort and style of Virgin Atlantic from Los Angeles International Airport to John F. Kennedy International Airport."
                    }
                };
                context.AddRange(flightList.ToArray());
                context.SaveChanges();
            };


            if (!context.Hotels.Any())
            {
                // Seed Hotels


                var hotelList = new List<Hotel>
                {
                    new Hotel
                    {
                        category="hotel",
                        name = "Grand Hyatt",
                        address = "123 Main Street",
                        city = "New York",
                        country = "USA",
                        starRating = 5,
                        description = "Luxury hotel in the heart of New York City",

                        totalRooms = 200,
                        availableRooms = 50,
                        roomTypes = "Standard, Deluxe, Suite",
                        contactInfo = "Phone: 123-456-7890, Email: reservations@grandhyatt.com",
                        price = 300,
                        isHotDeal = false,
                        shortDescription = "Luxury hotel in the heart of NYC",
                        longDescription = "The Grand Hyatt offers luxurious accommodations, world-class dining, and impeccable service in the heart of New York City.",
                        imageUrl = "~/img/hotels/hotel1.jpg"
                    },
                    new Hotel
                    {
                        category="hotel",
                        name = "Hilton Garden Inn",
                        address = "456 Elm Street",
                        city = "Los Angeles",
                        country = "USA",
                        starRating = 4,
                        description = "Modern hotel near popular attractions",

                        totalRooms = 150,
                        availableRooms = 100,
                        roomTypes = "Standard, King, Queen",
                        contactInfo = "Phone: 555-123-4567, Email: info@hiltongardeninn.com",
                        price = 200,
                        isHotDeal = false,
                        shortDescription = "Modern hotel near LA attractions",
                        longDescription = "The Hilton Garden Inn offers comfortable accommodations and convenient amenities near popular attractions in Los Angeles.",
                        imageUrl = "~/img/hotels/hotel2.jpg"
                    },
                    new Hotel
                    {category="hotel",


                        name = "Marriott Marquis",
                        address = "789 Broadway",
                        city = "San Francisco",
                        country = "USA",
                        starRating = 5,
                        description = "Luxury hotel with stunning views of the bay",

                        totalRooms = 300,
                        availableRooms = 200,
                        roomTypes = "Standard, Executive, Suite",
                        contactInfo = "Phone: 111-222-3333, Email: reservations@marriottmarquis.com",
                        price = 400,
                        isHotDeal = true,
                        shortDescription = "Luxury hotel with stunning bay views",
                        longDescription = "The Marriott Marquis offers luxurious accommodations, breathtaking views, and exceptional service in the heart of San Francisco.",
                        imageUrl = "~/img/hotels/hotel3.jpg"
                    },
                    new Hotel
                    {
                        category="hotel",
                        name = "Radisson Blu",
                        address = "101 Park Avenue",
                        city = "Chicago",
                        country = "USA",
                        starRating = 4,
                        description = "Contemporary hotel in downtown Chicago",

                        totalRooms = 250,
                        availableRooms = 150,
                        roomTypes = "Standard, Business Class, Suite",
                        contactInfo = "Phone: 444-555-6666, Email: reservations@radissonblu.com",
                        price = 250,
                        isHotDeal = false,
                        shortDescription = "Contemporary hotel in downtown Chicago",
                        longDescription = "The Radisson Blu offers stylish accommodations, modern amenities, and a prime location in downtown Chicago.",
                        imageUrl = "~/img/hotels/hotel4.jpg"
                    },
                    new Hotel
                    {
                        category="hotel",
                        name = "Sheraton Grand",
                        address = "222 Maple Street",
                        city = "Orlando",
                        country = "USA",
                        starRating = 4,
                        description = "Family-friendly resort near Disney World",

                        totalRooms = 400,
                        availableRooms = 300,
                        roomTypes = "Standard, Deluxe, Suite",
                        contactInfo = "Phone: 777-888-9999, Email: info@sheratongrand.com",
                        price = 300,
                        isHotDeal = false,
                        shortDescription = "Family-friendly resort near Disney World",
                        longDescription = "The Sheraton Grand offers spacious accommodations, fun activities, and easy access to Disney World and other Orlando attractions.",
                        imageUrl = "~/img/hotels/hotel5.jpg"
                    },
                    new Hotel
                    {
                        category="hotel",
                        name = "Hyatt Regency",
                        address = "333 Oak Street",
                        city = "Miami",
                        country = "USA",
                        starRating = 4,
                        description = "Upscale hotel in downtown Miami",

                        totalRooms = 300,
                        availableRooms = 200,
                        roomTypes = "Standard, Deluxe, Suite",
                        contactInfo = "Phone: 999-000-1111, Email: reservations@hyattregency.com",
                        price = 280,
                        isHotDeal = true,
                        shortDescription = "Upscale hotel in downtown Miami",
                        longDescription = "The Hyatt Regency offers luxurious accommodations, fine dining, and stunning views of downtown Miami and Biscayne Bay.",
                        imageUrl = "~/img/hotels/hotel6.jpg"
                    },
                    new Hotel
                    {
                        category="hotel",
                        name = "Holiday Inn Express",
                        address = "444 Pine Avenue",
                        city = "Seattle",
                        country = "USA",
                        starRating = 3,
                        description = "Affordable hotel near downtown Seattle",

                        totalRooms = 150,
                        availableRooms = 100,
                        roomTypes = "Standard, Queen",
                        contactInfo = "Phone: 222-333-4444, Email: info@holidayinnexpress.com",
                        price = 150,
                        isHotDeal = false,
                        shortDescription = "Affordable hotel near downtown Seattle",
                        longDescription = "The Holiday Inn Express offers comfortable accommodations, complimentary breakfast, and a convenient location near downtown Seattle.",
                        imageUrl = "~/img/hotels/hotel7.jpg"
                    },
                    new Hotel
                    {
                        category="hotel",
                        name = "Marriott Courtyard",
                        address = "555 Elm Avenue",
                        city = "Boston",
                        country = "USA",
                        starRating = 3,
                        description = "Modern hotel in downtown Boston",

                        totalRooms = 200,
                        availableRooms = 150,
                        roomTypes = "Standard, Executive",
                        contactInfo = "Phone: 333-444-5555, Email: reservations@marriottcourtyard.com",
                        price = 200,
                        isHotDeal = false,
                        shortDescription = "Modern hotel in downtown Boston",
                        longDescription = "The Marriott Courtyard offers contemporary accommodations, a fitness center, and a convenient location near downtown Boston attractions.",
                        imageUrl = "~/img/hotels/hotel8.jpg"
                    },
                    new Hotel
                    {category="hotel",


                        name = "Best Western",
                        address = "666 Oak Lane",
                        city = "Las Vegas",
                        country = "USA",
                        starRating = 3,
                        description = "Comfortable hotel near the Vegas Strip",

                        totalRooms = 300,
                        availableRooms = 200,
                        roomTypes = "Standard, Suite",
                        contactInfo = "Phone: 666-777-8888, Email: info@bestwestern.com",
                        price = 180,
                        isHotDeal = false,
                        shortDescription = "Comfortable hotel near the Vegas Strip",
                        longDescription = "The Best Western offers comfortable accommodations, a pool, and easy access to the Vegas Strip and nearby attractions.",
                        imageUrl = "~/img/hotels/hotel9.jpg"
                    },
                    new Hotel
                    {category="hotel",


                        name = "Ritz-Carlton",
                        address = "777 Pine Street",
                        city = "San Diego",
                        country = "USA",
                        starRating = 5,
                        description = "Luxury hotel with ocean views",

                        totalRooms = 250,
                        availableRooms = 150,
                        roomTypes = "Standard, Suite, Penthouse",
                        contactInfo = "Phone: 999-111-2222, Email: reservations@ritzcarlton.com",
                        price = 500,
                        isHotDeal = false,
                        shortDescription = "Luxury hotel with ocean views",
                        longDescription = "The Ritz-Carlton offers luxurious accommodations, impeccable service, and stunning ocean views in the heart of San Diego.",
                        imageUrl = "~/img/hotels/hotel10.jpg"
                    },
                    new Hotel
                    {
                  category="hotel",
                        name = "Fairmont",
                        address = "888 Maple Avenue",
                        city = "Toronto",
                        country = "Canada",
                        starRating = 4,
                        description = "Historic hotel in downtown Toronto",

                        totalRooms = 200,
                        availableRooms = 100,
                        roomTypes = "Standard, Suite",
                        contactInfo = "Phone: 888-999-0000, Email: info@fairmont.com",
                        price = 350,
                        isHotDeal = false,
                        shortDescription = "Historic hotel in downtown Toronto",
                        longDescription = "The Fairmont offers elegant accommodations, fine dining, and a convenient location near downtown Toronto attractions.",
                        imageUrl = "~/img/hotels/hotel11.jpg"
                    },
                    new Hotel
                    {category="hotel",

                        name = "Westin",
                        address = "999 Oak Street",
                        city = "Vancouver",
                        country = "Canada",
                        starRating = 4,
                        description = "Modern hotel with mountain views",

                        totalRooms = 300,
                        availableRooms = 200,
                        roomTypes = "Standard, Deluxe, Suite",
                        contactInfo = "Phone: 222-333-4444, Email: reservations@westin.com",
                        price = 400,
                        isHotDeal = false,
                        shortDescription = "Modern hotel with mountain views",
                        longDescription = "The Westin offers contemporary accommodations, stunning mountain views, and easy access to downtown Vancouver and outdoor activities.",
                        imageUrl = "~/img/hotels/hotel12.jpg"
                    },
                    new Hotel
                    {
                        category="hotel",
                        name = "Delta Hotels",
                        address = "123 Elm Avenue",
                        city = "Montreal",
                        country = "Canada",
                        starRating = 3,
                        description = "Comfortable hotel in downtown Montreal",

                        totalRooms = 150,
                        availableRooms = 100,
                        roomTypes = "Standard, Executive",
                        contactInfo = "Phone: 555-666-7777, Email: info@deltahotels.com",
                        price = 250,
                        isHotDeal = true,
                        shortDescription = "Comfortable hotel in downtown Montreal",
                        longDescription = "The Delta Hotels offers comfortable accommodations, a fitness center, and a convenient location near downtown Montreal attractions.",
                        imageUrl = "~/img/hotels/hotel13.jpg"
                    },
                    new Hotel
                    {
                        category="hotel",
                        name = "Four Seasons",
                        address = "456 Pine Street",
                        city = "Paris",
                        country = "France",
                        starRating = 5,
                        description = "Luxury hotel in the heart of Paris",

                        totalRooms = 200,
                        availableRooms = 100,
                        roomTypes = "Standard, Suite, Penthouse",
                        contactInfo = "Phone: +33-1-2345-6789, Email: reservations@fourseasons.com",
                        price = 600,
                        isHotDeal = false,
                        shortDescription = "Luxury hotel in the heart of Paris",
                        longDescription = "The Four Seasons offers luxurious accommodations, fine dining, and a prime location in the heart of Paris.",
                        imageUrl = "~/img/hotels/hotel14.jpg"
                    },
                    new Hotel
                    {
                        category="hotel",
                        name = "Marriott Courtyard",
                        address = "789 Oak Avenue",
                        city = "Chicago",
                        country = "USA",
                        starRating = 3,
                        description = "Comfortable hotel with convenient location",

                        totalRooms = 100,
                        availableRooms = 80,
                        roomTypes = "Standard, Executive",
                        contactInfo = "Phone: 888-456-7890, Email: reservations@marriottcourtyard.com",
                        price = 150,
                        isHotDeal = false,
                        shortDescription = "Comfortable hotel in downtown Chicago",
                        longDescription = "The Marriott Courtyard offers comfortable accommodations and a convenient location in downtown Chicago, making it ideal for business and leisure travelers alike.",
                        imageUrl = "~/img/hotels/hotel15.jpg"
                    }
                };
                context.AddRange(hotelList.ToArray());
                context.SaveChanges();
            }
        }
    }
}
