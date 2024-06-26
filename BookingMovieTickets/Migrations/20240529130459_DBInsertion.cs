﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingMovieTickets.Migrations
{
    /// <inheritdoc />
    public partial class DBInsertion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
table: "FilmCategory",
columns: new[] { "FilmCategoryId", "Name" },
values: new object[,]
{
                 {1,"Hành động"},
                 {2,"Phiêu lưu" },
                 {3,"Khoa học viễn tưởng" },
                 {4,"Kinh dị"},
                 {5,"Hài"},
                 {6,"Tâm lý" },
                 {7,"Hoạt hình" },
                 {8,"Phiêu bạt"},
                 {9,"Tình cảm"},
                 {10,"Hành động phiêu lưu" },
                 {11,"Giả tưởng"},
                 {12,"Gia đình"},
                 {13,"Hành động khoa học viễn tưởng"},
                 {14,"Tội phạm"},
                 {15,"Thần thoại"}
});
            migrationBuilder.InsertData(
                table: "Theatres",
                columns: new[] { "TheatreId", "Name", "Location" },
                values: new object[,]
                {
                 {1,"InfinityCinema Quận 7","Lầu 9 Crescent Mall, 101 Đường Tôn Dật Tiên, Phường Tân Phú, Quận 7, Thành phố Hồ Chí Minh" }
                });
            migrationBuilder.InsertData(
                table: "TheatreRooms",
                columns: new[] { "TheatreRoomId", "TheatreId", "RoomName" },
                values: new object[,]
                {
                 {1,1,"A01"},
                 {2,1,"A02"},
                 {3,1,"A03"},
                 {4,1,"A04"},
                 {5,1,"A05"},
                 {6,1,"A06"},
                 {7,1,"A07"},
                 {8,1,"A08"},
                 {9,1,"A09"},
                 {10,1,"A10"}
                });
            var startTime = TimeSpan.FromHours(8); // 8:00 AM
            var endTime = new TimeSpan(23, 55, 0); // 11:00 PM
            var interval = TimeSpan.FromMinutes(5); // 5-minute interval

            int id = 1;
            for (var time = startTime; time <= endTime; time += interval)
            {
                migrationBuilder.InsertData(
                    table: "ScheduleDescriptions",
                    columns: new[] { "ScheduleDescriptionId", "Description" },
                    values: new object[] { id++, time.ToString(@"hh\:mm\:ss") }
                );
            }
            migrationBuilder.InsertData(
table: "Seats",
columns: new[] { "SeatId", "TheatreRoomId", "SeatNumber", "SeatPrice", "IsBooked" },
values: new object[,]
{
                    {1, 1, "A01-01", 50000, false},
                    {2, 1, "A01-02", 50000, false},
                    {3, 1, "A01-03", 50000, false},
                    {4, 1, "A01-04", 50000, false}, {5, 1, "A01-05", 50000, false},
                    {6, 1, "A01-06", 50000, false}, {7, 1, "A01-07", 50000, false},
                    {8, 1, "A01-08", 50000, false}, {9, 1, "A01-09", 50000, false},
                    {10, 1, "A01-10", 50000, false}, {11, 1, "A01-11", 50000, false},
                    {12, 1, "A01-12", 50000, false}, {13, 1, "A01-13", 50000, false},
                    {14, 1, "A01-14", 50000, false}, {15, 1, "A01-15", 50000, false},
                    {16, 1, "A01-16", 50000, false}, {17, 1, "A01-17", 50000, false},
                    {18, 1, "A01-18", 50000, false}, {19, 1, "A01-19", 50000, false},
                    {20, 1, "A01-20", 50000, false}, {21, 1, "A01-21", 50000, false},
                    {22, 1, "A01-22", 50000, false}, {23, 1, "A01-23", 50000, false},
                    {24, 1, "A01-24", 50000, false}, {25, 1, "A01-25", 50000, false},
                    {26, 1, "A01-26", 50000, false}, {27, 1, "A01-27", 50000, false},
                    {28, 1, "A01-28", 50000, false}, {29, 1, "A01-29", 50000, false},
                    {30, 1, "A01-30", 50000, false}, {31, 1, "A01-31", 50000, false},
                    {32, 1, "A01-32", 50000, false}, {33, 1, "A01-33", 50000, false},
                    {34, 1, "A01-34", 50000, false}, {35, 1, "A01-35", 50000, false},
                    {36, 1, "A01-36", 50000, false}, {37, 1, "A01-37", 50000, false},
                    {38, 1, "A01-38", 50000, false}, {39, 1, "A01-39", 50000, false},
                    {40, 1, "A01-40", 50000, false}, {41, 1, "A01-41", 50000, false},
                    {42, 1, "A01-42", 50000, false}, {43, 1, "A01-43", 50000, false},
                    {44, 1, "A01-44", 50000, false}, {45, 1, "A01-45", 50000, false},

                    {46, 2, "A02-01", 50000, false}, {47, 2, "A02-02", 50000, false},
                    {48, 2, "A02-03", 50000, false}, {49, 2, "A02-04", 50000, false},
                            {50, 2, "A02-05", 50000, false}, {51, 2, "A02-06", 50000, false},
                            {52, 2, "A02-07", 50000, false}, {53, 2, "A02-08", 50000, false},
                            {54, 2, "A02-09", 50000, false}, {55, 2, "A02-10", 50000, false},
                            {56, 2, "A02-11", 50000, false}, {57, 2, "A02-12", 50000, false},
                            {58, 2, "A02-13", 50000, false}, {59, 2, "A02-14", 50000, false},
                            {60, 2, "A02-15", 50000, false}, {61, 2, "A02-16", 50000, false},
                            {62, 2, "A02-17", 50000, false}, {63, 2, "A02-18", 50000, false},
                            {64, 2, "A02-19", 50000, false}, {65, 2, "A02-20", 50000, false},
                            {66, 2, "A02-21", 50000, false}, {67, 2, "A02-22", 50000, false},
                            {68, 2, "A02-23", 50000, false}, {69, 2, "A02-24", 50000, false},
                            {70, 2, "A02-25", 50000, false}, {71, 2, "A02-26", 50000, false},
                            {72, 2, "A02-27", 50000, false}, {73, 2, "A02-28", 50000, false},
                            {74, 2, "A02-29", 50000, false}, {75, 2, "A02-30", 50000, false},
                            {76, 2, "A02-31", 50000, false}, {77, 2, "A02-32", 50000, false},
                            {78, 2, "A02-33", 50000, false}, {79, 2, "A02-34", 50000, false},
                            {80, 2, "A02-35", 50000, false}, {81, 2, "A02-36", 50000, false},
                            {82, 2, "A02-37", 50000, false}, {83, 2, "A02-38", 50000, false},
                            {84, 2, "A02-39", 50000, false}, {85, 2, "A02-40", 50000, false},
                            {86, 2, "A02-41", 50000, false}, {87, 2, "A02-42", 50000, false},
                            {88, 2, "A02-43", 50000, false}, {89, 2, "A02-44", 50000, false},
                            {90, 2, "A02-45", 50000, false},


                    {91, 3, "A03-01", 50000, false}, {92, 3, "A03-02", 50000, false},
                            {93, 3, "A03-03", 50000, false}, {94, 3, "A03-04", 50000, false},
                            {95, 3, "A03-05", 50000, false}, {96, 3, "A03-06", 50000, false},
                            {97, 3, "A03-07", 50000, false}, {98, 3, "A03-08", 50000, false},
                            {99, 3, "A03-09", 50000, false}, {100, 3, "A03-10", 50000, false},
                            {101, 3, "A03-11", 50000, false}, {102, 3, "A03-12", 50000, false},
                            {103, 3, "A03-13", 50000, false}, {104, 3, "A03-14", 50000, false},
                            {105, 3, "A03-15", 50000, false}, {106, 3, "A03-16", 50000, false},
                            {107, 3, "A03-17", 50000, false}, {108, 3, "A03-18", 50000, false},
                            {109, 3, "A03-19", 50000, false}, {110, 3, "A03-20", 50000, false},
                            {111, 3, "A03-21", 50000, false}, {112, 3, "A03-22", 50000, false},
                            {113, 3, "A03-23", 50000, false}, {114, 3, "A03-24", 50000, false},
                            {115, 3, "A03-25", 50000, false}, {116, 3, "A03-26", 50000, false},
                            {117, 3, "A03-27", 50000, false}, {118, 3, "A03-28", 50000, false},
                            {119, 3, "A03-29", 50000, false}, {120, 3, "A03-30", 50000, false},
                            {121, 3, "A03-31", 50000, false}, {122, 3, "A03-32", 50000, false},
                            {123, 3, "A03-33", 50000, false}, {124, 3, "A03-34", 50000, false},
                            {125, 3, "A03-35", 50000, false}, {126, 3, "A03-36", 50000, false},
                            {127, 3, "A03-37", 50000, false}, {128, 3, "A03-38", 50000, false},
                            {129, 3, "A03-39", 50000, false}, {130, 3, "A03-40", 50000, false},
                            {131, 3, "A03-41", 50000, false}, {132, 3, "A03-42", 50000, false},
                            {133, 3, "A03-43", 50000, false}, {134, 3, "A03-44", 50000, false},
                            {135, 3, "A03-45", 50000, false},

        {136, 4, "A04-01", 50000, false}, {137, 4, "A04-02", 50000, false},
        {138, 4, "A04-03", 50000, false}, {139, 4, "A04-04", 50000, false},
        {140, 4, "A04-05", 50000, false}, {141, 4, "A04-06", 50000, false},
        {142, 4, "A04-07", 50000, false}, {143, 4, "A04-08", 50000, false},
        {144, 4, "A04-09", 50000, false}, {145, 4, "A04-10", 50000, false},
        {146, 4, "A04-11", 50000, false}, {147, 4, "A04-12", 50000, false},
        {148, 4, "A04-13", 50000, false}, {149, 4, "A04-14", 50000, false},
        {150, 4, "A04-15", 50000, false}, {151, 4, "A04-16", 50000, false},
        {152, 4, "A04-17", 50000, false}, {153, 4, "A04-18", 50000, false},
        {154, 4, "A04-19", 50000, false}, {155, 4, "A04-20", 50000, false},
        {156, 4, "A04-21", 50000, false}, {157, 4, "A04-22", 50000, false},
        {158, 4, "A04-23", 50000, false}, {159, 4, "A04-24", 50000, false},
        {160, 4, "A04-25", 50000, false}, {161, 4, "A04-26", 50000, false},
        {162, 4, "A04-27", 50000, false}, {163, 4, "A04-28", 50000, false},
        {164, 4, "A04-29", 50000, false}, {165, 4, "A04-30", 50000, false},
        {166, 4, "A04-31", 50000, false}, {167, 4, "A04-32", 50000, false},
        {168, 4, "A04-33", 50000, false}, {169, 4, "A04-34", 50000, false},
        {170, 4, "A04-35", 50000, false}, {171, 4, "A04-36", 50000, false},
        {172, 4, "A04-37", 50000, false}, {173, 4, "A04-38", 50000, false},
        {174, 4, "A04-39", 50000, false}, {175, 4, "A04-40", 50000, false},
        {176, 4, "A04-41", 50000, false}, {177, 4, "A04-42", 50000, false},
        {178, 4, "A04-43", 50000, false}, {179, 4, "A04-44", 50000, false},
        {180, 4, "A04-45", 50000, false},

 {181,5,"A05-01",50000,false },{182,5,"A05-02",50000,false },{183,5,"A05-03",50000, false },{184,5,"A05-04",50000,false },{185,5,"A05-05",50000,false },
 {186,5,"A05-06",50000,false },{187,5,"A05-07",50000,false },{188,5,"A05-08",50000,false },{189,5,"A05-09",50000,false },{190,5,"A05-10",50000,false },
 {191,5,"A05-11",50000,false },{192,5,"A05-12",50000,false },{193,5,"A05-13",50000,false },{194,5,"A05-14",50000,false },{195,5,"A05-15",50000,false },
 {196,5,"A05-16",50000,false },{197,5,"A05-17",50000, false },{198,5,"A05-18",50000,false },{199,5,"A05-19",50000,false },{200,5,"A05-20",50000,false },
 {201,5,"A05-21",50000, false },{202,5,"A05-22",50000,false },{203,5,"A05-23",50000,false },{204,5,"A05-24",50000,false },{205,5,"A05-25",50000,false },
 {206,5,"A05-26",50000,false },{207,5,"A05-27",50000,false },{208,5,"A05-28",50000,false },{209,5,"A05-29",50000,false },{210,5,"A05-30",50000,false },
 {211,5,"A05-31",50000,false },{212,5,"A05-32",50000,false },{213,5,"A05-33",50000,false },{214,5,"A05-34",50000,false },{215,5,"A05-35",50000,false },
 {216,5,"A05-36",50000,false },{217,5,"A05-37",50000,false },{218,5,"A05-38",50000,false },{219,5,"A05-39",50000,false },{220,5,"A05-40",50000,false },
 {221,5,"A05-41",50000,false },{222,5,"A05-42",50000,false },{223,5,"A05-43",50000,false },{224,5,"A05-44",50000,false },{225,5,"A05-45",50000,false },

  {226,6,"A06-01",50000, false },{227,6,"A06-02",50000,false },{228,6,"A06-03",50000,false },{229,6,"A06-04",50000,false },{230,6,"A06-05",50000,false },
 {231,6,"A06-06",50000,false },{232,6,"A06-07",50000,false },{233,6,"A06-08",50000, false },{234,6,"A06-09",50000, false },{235,6,"A06-10",50000, false },
 {236,6,"A06-11",50000, false },{237,6,"A06-12",50000, false },{238,6,"A06-13", 50000,false },{239,6,"A06-14",50000, false },{240,6,"A06-15",50000,false },
 {241,6,"A06-16",50000, false },{242,6,"A06-17",50000, false },{243,6,"A06-18",50000, false },{244,6,"A06-19",       50000, false },{245,6,"A06-20",50000, false },
 {246,6,"A06-21",50000,false },{247,6,"A06-22",50000, false },{248,6,"A06-23",50000,false },{249,6,"A06-24",50000, false },{250,6,"A06-25",50000, false },
 {251,6,"A06-26",50000, false },{252,6,"A06-27",50000, false },{253,6,"A06-28",50000, false },{254,6,"A06-29",50000, false },{255,6,"A06-30",50000, false },
 {256,6,"A06-31",50000, false },{257,6,"A06-32",50000, false },{258,6,"A06-33",50000, false },{259,6,"A06-34",50000, false },{260,6,"A06-35",50000, false },
 {261,6,"A06-36",50000,false },{262,6,"A06-37",50000, false },{263,6,"A06-38",   50000, false },{264,6,"A06-39",50000, false },{265,6,"A06-40",50000, false },
 {266,6,"A06-41",50000, false },{267,6,"A06-42",50000, false },{268,6,"A06-43",50000, false },{269,6,"A06-44",50000, false },{270,6,"A06-45",50000, false },

 {271, 7, "A07-01", 50000, false}, {272, 7, "A07-02", 50000, false},
        {273, 7, "A07-03", 50000, false}, {274, 7, "A07-04", 50000, false},
        {275, 7, "A07-05", 50000, false}, {276, 7, "A07-06", 50000, false},
        {277, 7, "A07-07", 50000, false}, {278, 7, "A07-08", 50000, false},
        {279, 7, "A07-09", 50000, false}, {280, 7, "A07-10", 50000, false},
        {281, 7, "A07-11", 50000, false}, {282, 7, "A07-12", 50000, false},
        {283, 7, "A07-13", 50000, false}, {284, 7, "A07-14", 50000, false},
        {285, 7, "A07-15", 50000, false}, {286, 7, "A07-16", 50000, false},
        {287, 7, "A07-17", 50000, false}, {288, 7, "A07-18", 50000, false},
        {289, 7, "A07-19", 50000, false}, {290, 7, "A07-20", 50000, false},
        {291, 7, "A07-21", 50000, false}, {292, 7, "A07-22", 50000, false},
        {293, 7, "A07-23", 50000, false}, {294, 7, "A07-24", 50000, false},
        {295, 7, "A07-25", 50000, false}, {296, 7, "A07-26", 50000, false},
        {297, 7, "A07-27", 50000, false}, {298, 7, "A07-28", 50000, false},
        {299, 7, "A07-29", 50000, false}, {300, 7, "A07-30", 50000, false},
        {301, 7, "A07-31", 50000, false}, {302, 7, "A07-32", 50000, false},
        {303, 7, "A07-33", 50000, false}, {304, 7, "A07-34", 50000, false},
        {305, 7, "A07-35", 50000, false}, {306, 7, "A07-36", 50000, false},
        {307, 7, "A07-37", 50000, false}, {308, 7, "A07-38", 50000, false},
        {309, 7, "A07-39", 50000, false}, {310, 7, "A07-40", 50000, false},
        {311, 7, "A07-41", 50000, false}, {312, 7, "A07-42", 50000, false},
        {313, 7, "A07-43", 50000, false}, {314, 7, "A07-44", 50000, false},
        {315, 7, "A07-45", 50000, false},

 {316,8,"A08-01",50000,false },{317,8,"A08-02",50000,false },{318,8,"A08-03",50000, false },{319,8,"A08-04",50000, false },{320,8,"A08-05",50000, false },
 {321,8,"A08-06",50000, false },{322,8,"A08-07",50000, false },{323,8,"A08-08",50000, false },{324,8,"A08-09",50000, false },{325,8,"A08-10",50000, false },
 {326,8,"A08-11",50000,  false },{327,8,"A08-12",50000,false },{328,8,"A08-13",50000,false },{329,8,"A08-14" , 50000,  false },{330,8,"A08-15",50000, false },
 {331,8,"A08-16",50000, false },{332,8,"A08-17",50000, false },{333,8,"A08-18",50000, false },{334,8,"A08-19",50000,false },{335,8,"A08-20",50000, false },
 {336,8,"A08-21",50000, false },{337,8,"A08-22",50000, false },{338,8,"A08-23",50000, false },{339,8,"A08-24",50000,   false },{340,8,"A08-25",50000,false },
 {341,8,"A08-26",50000, false },{342,8,"A08-27",50000, false },{343,8,"A08-28",50000, false },{344,8,"A08-29",50000, false },{345,8,"A08-30",50000, false },
 {346,8,"A08-31",50000, false },{347,8,"A08-32",50000, false },{348,8,"A08-33",50000, false },{349,8,"A08-34",50000, false },{350,8,"A08-35",50000, false },
 {351,8,"A08-36",50000, false },{352,8,"A08-37",50000, false },{353,8,"A08-38",50000, false },{354,8,"A08-39",50000, false },{355,8,"A08-40",50000, false },
 {356,8,"A08-41",50000, false },{357,8,"A08-42",50000, false },{358,8,"A08-43",50000, false },{359,8,"A08-44",50000, false },{360,8,"A08-45",50000, false },

{361, 9, "A09-01", 50000, false}, {362, 9, "A09-02", 50000, false},
        {363, 9, "A09-03", 50000, false}, {364, 9, "A09-04", 50000, false},
        {365, 9, "A09-05", 50000, false}, {366, 9, "A09-06", 50000, false},
        {367, 9, "A09-07", 50000, false}, {368, 9, "A09-08", 50000, false},
        {369, 9, "A09-09", 50000, false}, {370, 9, "A09-10", 50000, false},
        {371, 9, "A09-11", 50000, false}, {372, 9, "A09-12", 50000, false},
        {373, 9, "A09-13", 50000, false}, {374, 9, "A09-14", 50000, false},
        {375, 9, "A09-15", 50000, false}, {376, 9, "A09-16", 50000, false},
        {377, 9, "A09-17", 50000, false}, {378, 9, "A09-18", 50000, false},
        {379, 9, "A09-19", 50000, false}, {380, 9, "A09-20", 50000, false},
        {381, 9, "A09-21", 50000, false}, {382, 9, "A09-22", 50000, false},
        {383, 9, "A09-23", 50000, false}, {384, 9, "A09-24", 50000, false},
        {385, 9, "A09-25", 50000, false}, {386, 9, "A09-26", 50000, false},
        {387, 9, "A09-27", 50000, false}, {388, 9, "A09-28", 50000, false},
        {389, 9, "A09-29", 50000, false}, {390, 9, "A09-30", 50000, false},
        {391, 9, "A09-31", 50000, false}, {392, 9, "A09-32", 50000, false},
        {393, 9, "A09-33", 50000, false}, {394, 9, "A09-34", 50000, false},
        {395, 9, "A09-35", 50000, false}, {396, 9, "A09-36", 50000, false},
        {397, 9, "A09-37", 50000, false}, {398, 9, "A09-38", 50000, false},
        {399, 9, "A09-39", 50000, false}, {400, 9, "A09-40", 50000, false},
        {401, 9, "A09-41", 50000, false}, {402, 9, "A09-42", 50000, false},
        {403, 9, "A09-43", 50000, false}, {404, 9, "A09-44", 50000, false},
        {405, 9, "A09-45", 50000, false},

  {406,10,"A10-01",50000,false },{407,10,"A10-02",50000, false },{408,10,"A10-03",50000, false },{409,10,"A10-04",50000, false },{410,10,"A10-05",50000, false },
 {411,10,"A10-06",50000, false },{412,10,"A10-07",50000, false },{413,10,"A10-08",50000, false },{414,10,"A10-09",50000, false },{415,10,"A10-10",50000, false },
 {416,10,"A10-11",50000, false },{417,10,"A10-12",50000, false },{418,10,"A10-13",50000, false },{419,10,"A10-14",50000, false },{420,10,"A10-15",50000, false },
 {421,10,"A10-16",50000, false },{422,10,"A10-17",50000, false },{423,10,"A10-18",50000, false },{424,10,"A10-19",50000, false },{425,10,"A10-20",50000, false },
 {426,10,"A10-21",50000, false },{427,10,"A10-22",  50000,false },{428,10,"A10-23",50000, false },{429,10,"A10-24",50000, false },{430,10,"A10-25",50000, false },
 {431,10,"A10-26",50000, false },{432,10,"A10-27",50000, false },{433,10,"A10-28", 50000,false },{434,10,"A10-29",50000, false },{435,10,"A10-30",50000, false },
 {436,10,"A10-31",50000, false },{437,10,"A10-32",50000, false },{438,10,"A10-33",50000, false },{439,10,"A10-34",50000, false },{440,10,"A10-35",50000, false },
 {441,10,"A10-36",50000, false },{442,10,"A10-37",50000, false },{443,10,"A10-38",50000, false },{444,10,"A10-39",50000, false },{445,10,"A10-40",50000, false },
 {446,10,"A10-41",50000, false },{447,10,"A10-42",50000, false },{448,10,"A10-43",50000, false },{449,10,"A10-44",50000, false },{450,10,"A10-45",50000, false }


});

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "FilmId", "NameFilm", "Description", "PosterUrl", "TrailerUrl",
             "DirectorName","Language","FilmRated","FilmDuration","Actors", "FilmCategoryId","StartTime"},
                values: new object[,]
                {
 {1, "LẬT MẶT 7: MỘT ĐIỀU ƯỚC",
     "Một câu chuyện lần đầu được kể bằng tất cả tình yêu, và từ tất cả những hồi ức xao xuyến nhất của đấng sinh thành",
     "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/l/a/lat-mat-7.jpg",
     "https://youtu.be/d1ZHdosjNX8?si=f6_pea9cJ5HtvnJy",
      "Lý Hải","Tiếng Việt - Phụ đề Tiếng Anh","K - Phim được phổ biến đến người xem dưới 13 tuổi và có người bảo hộ đi kèm",138,
                        "Thanh Hiền, Trương Minh Cường, Đinh Y Nhung, Quách Ngọc Tuyên, Trâm Anh, Trần Kim Hải,...",12, new DateTime(2024, 4, 26, 10, 15, 0)},

 {2,"GODZILLA X KONG: ĐẾ CHẾ MỚI",
 "Kong và Godzilla - hai sinh vật vĩ đại huyền thoại, hai kẻ thủ truyền kiếp sẽ cùng bắt tay thực thi một sứ mệnh chung mang tính sống còn để bảo vệ nhân loại, và trận chiến gắn kết chúng với loài người mãi mãi sẽ bắt đầu.",
 "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/p/o/poster_payoff_godzilla_va_kong_3_1_.jpg",
 "https://youtu.be/RXc2bs_aBuA",
 "Adam Wingard","Tiếng Anh - Phụ đề Tiếng Việt, Tiếng Hàn","K - Phim được phổ biến đến người xem dưới 13 tuổi và có người bảo hộ đi kèm",115,
                        "Rebecca Hall; Brian Tyree Henry; Dan Stevens; Kaylee Hottle; Alex Ferns; Fala Chen,...",1,new DateTime(2024,3,29, 10, 15, 0)},

 {3,"KUNG FU PANDA 4",
 "Sau khi Po được chọn trở thành Thủ lĩnh tinh thần của Thung lũng Bình Yên, Po cần tìm và huấn luyện một Chiến binh Rồng mới, trong khi đó một mụ phù thủy độc ác lên kế hoạch triệu hồi lại tất cả những kẻ phản diện mà Po đã đánh bại về cõi linh hồn.",
 "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/4/7/470x700-kungfupanda4.jpg",
 "https://youtu.be/egkeFvm26pc",
 "Mike Mitchell","Tiếng Anh - Phụ đề Tiếng Việt; Lồng tiếng","P - Phim được phép phổ biến đến người xem ở mọi độ tuổi.",94,"Jack Black, Dustin Hoffman, James Hong, Awkwafina, ...",7,new DateTime(2024,3,8, 10, 15, 0)},

 {4,"THANH XUÂN 18x2: LỮ TRÌNH HƯỚNG VỀ EM",
 "Ký ức tình đầu ùa về khi Jimmy nhận được tấm bưu thiếp từ Ami. Cậu quyết định một mình bước lên chuyến tàu đến Nhật Bản gặp lại người con gái cậu đã bỏ lỡ 18 năm trước. Mối tình day dứt thời thanh xuân, liệu sẽ có một kết cục nào tốt đẹp khi đoàn tụ?",
 "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/4/0/406x600-18x2.jpg",
 "https://youtu.be/8Pq08VsVUFk",
 "Fujii Michihito","Tiếng Nhật & Tiếng Trung Quốc với phụ đề Tiếng Việt và Tiếng Anh","T13 - Phim được phổ biến đến người xem từ đủ 13 tuổi trở lên (13+)",123,
                        " Greg Hsu, Kaya Kiyohara, Chang Chen, Kuroki Hitomi, Michieda Shunsuke,...",9,new DateTime(2024,4,12, 10, 15, 0)},

 {5,"EXHUMA: QUẬT MỘ TRÙNG MA",
 "Hai pháp sư, một thầy phong thuỷ và một chuyên gia khâm liệm cùng hợp lực khai quật ngôi mộ bị nguyền rủa của một gia đình giàu có, nhằm cứu lấy sinh mạng hậu duệ cuối cùng trong dòng tộc. Bí mật hắc ám của tổ tiên được đánh thức.",
 "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/1800x/71252117777b696995f01934522c402d/7/0/700x1000-exhuma.jpg",
 "https://youtu.be/7LH-TIcPqks",
"Jang Jae Hyun","Tiếng Hàn - Phụ đề Tiếng Anh & Tiếng Việt","T16 - Phim được phổ biến đến người xem từ đủ 16 tuổi trở lên (16+)",133,"Choi Min Sik, Yoo Hai Jin, Kim Go Eun, Lee Do Hyun,...",4,new DateTime(2024,3,15,10, 15,0)},

 {6,"KẺ TRỘM MẶT TRĂNG 4",
 "Gru phải đối mặt với kẻ thù mới là Maxime Le Mal và Valentina đang lên kế hoạch trả thù anh, buộc gia đình anh phải lẩn trốn đi nơi khác. Bên cạnh việc đấu tranh bảo vệ gia đình, Gru đồng thời còn phải tìm ra điểm chung với thành viên mới nhất trong nhà đó là Gru Jr.",
 "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/d/m/dm4_teaser_700x1000.jpg",
 "https://youtu.be/GTupBD8M3yw",
"Chris Renaud","Tiếng Anh - Phụ đề Tiếng Việt; Lồng tiếng","PG - Cha mẹ nên có hướng dẫn cho con khi xem ",0,"Steve Carell, Kristen Wiig, Joey King,...",7,new DateTime(2024,7,5,10, 15,0)},

 {7,"PHIM ĐIỆN ẢNH DORAEMON: NOBITA VÀ BẢN GIAO HƯỞNG ĐỊA CẦU",
 "TÁC PHẨM KỶ NIỆM 90 NĂM FUJIKO F FUJIO Chuẩn bị cho buổi hòa nhạc ở trường, Nobita đang tập thổi sáo - nhạc cụ mà cậu dở tệ. Thích thú trước nốt \"No\" lạc quẻ của Nobita, Micca - cô bé bí ẩn đã mời Doraemon, Nobita cùng nhóm bạn đến \"Farre\" - Cung điện âm nhạc tọa lạc trên một hành tinh nơi âm nhạc sẽ hóa thành năng lượng. Nhằm cứu cung điện này, Micca đang tìm kiếm \"virtuoso\" - bậc thầy âm nhạc sẽ cùng mình biểu diễn! Với bảo bối thần kì \"chứng chỉ chuyên viên âm nhạc\", Doraemon và các bạn đã chọn nhạc cụ, cùng Micca hòa tấu, từng bước khôi phục cung điện. Tuy nhiên, một vật thể sống đáng sợ sẽ xóa số âm nhạc khỏi thế giới đang đến gần, Trái Đất đang rơi vào nguy hiểm... ! Liệu những người bạn nhỏ có thể cứu được \"tương lai âm nhạc\" và cả địa cầu này?",
 "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/1800x/71252117777b696995f01934522c402d/m/a/main_poster_-_dmmovie2023_1.jpg",
 "https://youtu.be/Yug8gbDd5EQ",
 "Kazuaki Imai","Tiếng Nhật - Phụ đề Tiếng Việt; Lồng tiếng","G - Phim dành cho mọi lứa tuổi",115,"Wasabi Mizuta, Megumi Ôhara, Yumi Kakazu...",7,new DateTime(2024,5,24,10, 15,0)},

 {8,"TAROT 2024",
 "Bộ phim sẽ là hành trình theo chân một nhóm bạn đại học sau khi sử dụng một bộ bài tarot bí ẩn, từng người trong nhóm đã ra đi theo những cách kì lạ và có liên quan đến lá bài mà họ bốc. Trước khi hết thời gian, họ đã cùng nhau hợp tác để khám phá ra bí ẩn đằng sau bộ bài kí bí ấy. Bạn sẽ nhìn thấy ai khi trút hơi thở cuối cùng?",
 "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/7/0/700x1000-tarot.jpg",
 "https://youtu.be/mqiEnk8Lrco",
"Spenser Cohen","Tiếng Anh - Phụ đề Tiếng Việt","T18 - Phim được phổ biến đến người xem từ đủ 18 tuổi trở lên (18+)",160,"Avantika, Jacob Batalon, Olwen Fouéré,...",4,new DateTime(2024,5,3,10, 15,0)},

 {9,"CÁI GIÁ CỦA HẠNH PHÚC",
 "Bà Dương và ông Thoại luôn cố gắng để xây dựng một hình ảnh gia đình tài giỏi và danh giá trong mắt mọi người. Tuy nhiên dưới lớp vỏ bọc hào nhoáng ấy là những biến cố và lục đục gia đình đầy sóng gió. Nhìn kĩ hơn một chút bức tranh gia đình hạnh phúc ấy, rất nhiều \"khuyết điểm\" sẽ lộ ra gây bất ngờ.",
 "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/7/0/700x1000-cghp-min.jpg",
 "https://youtu.be/79BznZKQwIQ",
"Nguyễn Ngọc Lâm","Tiếng Việt - Phụ đề Tiếng Anh","T18 - Phim được phổ biến đến người xem từ đủ 18 tuổi trở lên (18+)",115,
                        " Xuân Lan, Thái Hoà, Lâm Thanh Nhã, Uyển Ân, Hữu Châu, Trâm Anh, Trương Thanh Long, Quang Minh, Bé Quyên,...",9,new DateTime(2024,4,29, 10, 15,0)},

 {10,"MAI",
 "\"Mai\" xoay quanh cuộc đời của một người phụ nữ đẹp tên Mai có số phận rất đặc biệt. Bởi làm nghề mát xa, Mai thường phải đối mặt với ánh nhìn soi mói, phán xét từ những người xung quanh. Và rồi Mai gặp Dương - chàng trai đào hoa lãng tử. Những tưởng bản thân không còn thiết tha yêu đương và mưu cầu hạnh phúc cho riêng mình thì khao khát được sống một cuộc đời mới trong Mai trỗi dậy khi Dương tấn công cô không khoan nhượng. Họ cho mình những khoảnh khắc tự do, say đắm và tràn đầy tiếng cười. Liệu cặp đôi ấy có nắm giữ được niềm hạnh phúc đó dài lâu khi miệng đời lắm khi cay nghiệt, bất công? \"Mai\" - một câu chuyện tâm lý, tình cảm pha lẫn nhiều tràng cười vui nhộn với sự đầu tư mạnh tay nhất trong ba phim của Trấn Thành hứa hẹn sẽ đem đến cho khán giả những phút giây thật sự ý nghĩa trong mùa Tết năm nay.",
 "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/m/a/mai_teaser_poster_digital_1_.jpg",
 "https://youtu.be/HXWRTGbhb4U",
"Trấn Thành","Tiếng Việt - Phụ đề Tiếng Anh","T18 - Phim được phổ biến đến người xem từ đủ 18 tuổi trở lên (18+)",131,
 "Phương Anh Đào, Tuấn Trần, Trấn Thành, Uyển Ân, Hồng Đào, NSND Việt Anh, NSND Ngọc Giàu, Khả Như, Quốc Khánh, Anh Thư, Lý Hạo Mạnh Quỳnh, Anh Đức, Anh Phạm, Lộ Lộ, Kiều Linh, Ngọc Nga, Thanh Hằng, Ngọc Nguyễn, Hoàng Mèo, Mạnh Lân,...",6,new DateTime(2024,2,10,10, 15,0)},

 {11,"NGÀY TÀN CỦA ĐẾ QUỐC",
 "Trong một tương lai gần, một nhóm các phóng viên chiến trường quả cảm phải đấu tranh với thời gian và bom đạn nguy hiểm để đến kịp Nhà Trắng giữa bối cảnh nội chiến Hoa Kỳ đang tiến đến cao trào.",
 "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/1800x/71252117777b696995f01934522c402d/k/t/kt_facebook.jpg",
 "https://youtu.be/QGlgPf9jGMA",
"Alex Garland","Tiếng Anh - Phụ đề Tiếng Việt","T18 - Phim được phổ biến đến người xem từ đủ 18 tuổi trở lên (18+)",109,"Kirsten Dunst, Wagner Moura, Cailee Spaeny,…",1,new DateTime(2024,4,12,10, 15,0)},

 {12,"MÙA HÈ CỦA LUCA",
 "\"Mùa Hè Của Luca\" kể về chuyến hành trình của cậu bé Luca tại hòn đảo Portorosso thuộc vùng biển Địa Trung Hải ở Ý tuyệt đẹp. Ở đây cậu đã làm quen và kết thân với những người bạn nhỏ mới và tận hưởng mùa hè đầy nắng, kem Gelato và cả món mì Ý trứ danh. Tuy nhiên có một điều không ổn lắm, Luca là một THỦY QUÁI và những người dân trên hòn đảo này lại không thích điều này chút nào.",
 "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/r/s/rsz_1200x1800_2.jpg",
 "https://youtu.be/FzV3gRevq4Q",
"Enrico Casarosa","Tiếng Anh với phụ đề tiếng Việt, lồng tiếng","P - Phim được phép phổ biến đến người xem ở mọi độ tuổi.",99,
                        "(Lồng tiếng): Jacob Tremblay, Jack Dylan Grazer, Emma Berman, Saverio Raimondo, Maya Rudolph, Marco Barricelli, Jim Gaffigan, Sandy Martin,...",7,new DateTime(2024,4,18,10, 15,0)},
 {13,"NHỮNG GÃ TRAI HƯ: CHƠI HAY BỊ XƠI - BAD BOY 4",
 "Chuyện phim mới kể về những diễn biến đầy hành động của thám tử Miami-Dade Mike Lowrey (Will Smith) và Marcus Burnett (Martin Lawrence). Giờ đây, Lowrey và Burnett phải hợp tác để tiêu diệt tên Đại úy Conrad Howard, người đang bị buộc tội hoạt động cùng băng đảng ma túy.",
 "https://cdn.galaxycine.vn/media/2024/4/12/bad-boy-500_1712891792541.jpg",
 "https://youtu.be/RGnBFA_g0rg?si=WianLCSq3iavyafs",
"Adil El Arbi, Bilall Fallah","Tiếng Anh với phụ đề tiếng Việt","R  - Người dưới 17 tuổi trở xuống cần có cha mẹ hoặc người giám hộ đi cùng do có thể gây hoảng loạn hoặc ảnh hưởng xấu đến tư duy, đạo đức của trẻ em.",124,
                        "Will Smith, Martin Lawrence, Vanessa Hudgens,Alexander Ludwig,Tasha Smith,,Paola Núñez,Jacob Scipio...",1,new DateTime(2024,6  ,27,10, 15,0)},
  {14,"Deadpool 3: DEADPOOL & WOLVERINE",
 "Deadpool & Wolverine lấy bối cảnh sau các sự việc trong phần hai, Wade Wilson/Deadpool (Ryan Reynolds đóng) chọn sống cuộc đời bình thường với những người yêu quý. Thế nhưng, đội đặc vụ thuộc Cơ quan Phương sai Thời gian (TVA) xuất hiện, bắt cóc Deadpool và đưa nhân vật chính vào MCU.",
 "https://cdn.marvel.com/content/1x/dp3_1sht_digital_srgb_ka_swords_v5_resized.jpg",
 "https://youtu.be/73_1biulkYk?si=x-_OomknrtTOXTwA",
"Shawn Levy","Tiếng Anh với phụ đề tiếng Việt","R  - Người dưới 17 tuổi trở xuống cần có cha mẹ hoặc người giám hộ đi cùng do có thể gây hoảng loạn hoặc ảnh hưởng xấu đến tư duy, đạo đức của trẻ em.",127,
                        "Ryan Reynolds, Hugh Jackman, Emma Corrin, Morena Baccarin, Rob Delaney, Leslie Uggams, Karan Soni,...",1,new DateTime(2024,7  ,26,10, 15,0)},
                });

            migrationBuilder.InsertData(
                table: "FilmSchedules",
                columns: new[] { "FilmScheduleId", "FilmId", "TheatreRoomId", "ScheduleDescriptionId" },
                values: new object[,]
                {
             {1,1,1,31},
             {2,1,1,55},
             {3,1,1,94},
             {4,1,1,121},
             {5,1,1,150},
             {6,2,2,28},
             {7,2,2,72},
             {8,2,2,96},
             {9,2,2,142},
             {10,2,2,162},
             {11,3,3,26},
             {12,3,3,56},
             {13,3,3,85},
             {14,3,3,119},
             {15,3,3,146},
             {16,3,3,181},
             {17,4,4,31},
             {18,4,4,72},
             {19,4,4,99},
             {20,4,4,142},
             {21,4,4,192},
             {22,5,5,26},
             {23,5,5,64},
             {24,5,5,104 },
             {25,5,5,137},
             {26,5,5,172},
             {27,9,6,22},
             {28,9,6,56},
             {29,9,6,96},
             {30,9,6,118},
             {31,9,6,145},
             {32,9,6,182},
             {33,10,7,23 },
             {34,10,7,63},
             {35,10,7,97 },
             {36,10,7,122 },
             {37,10,7,152 },
             {38,11,8,25},
             {39,11,8,59},
             {40,11,8,84},
             {41,11,8,109},
             {42,11,8,132},
             {43,11,8,154},
             {44,11,8,185 },
             {45,8, 9,35},
             {46,8,9,76},
             {47,8,9,106 },
             {48,8,9,128 },
             {49,8,9,157},
             {50,12,10,33},
             {51,12,10,60 },
             {52,12,10,90},
             {53,12,10,109},
             {54,12,10,136},
             {55,12,10,159 },
             {56,12,10,188}
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
