using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingMovieTickets.Migrations
{
    /// <inheritdoc />
    public partial class DataInsertion : Migration
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
            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "SeatId", "TheatreRoomId", "SeatNumber", "IsBooked" },
                values: new object[,]
                {
 {1,1,"A01-01",false}, {2,1,"A01-02",false},{3,1,"A01-03",false}, {4,1,"A01-04", false},{5,1,"A01-05", false},
 {6,1,"A01-06", false},{7,1,"A01-07", false}, {8,1,"A01-08", false},{9,1,"A01-09", false}, {10,1,"A01-10", false},
 {11,1,"A01-11", false}, {12,1,"A01-12", false}, {13,1,"A01-13", false}, {14,1,"A01-14", false},{15,1,"A01-15", false}, {16,1,"A01-16", false},
 {17,1,"A01-17", false}, {18,1,"A01-18", false}, {19,1,"A01-19", false}, {20,1,"A01-20", false}, {21,1,"A01-21", false}, {22,1,"A01-22", false},
 {23,1,"A01-23", false}, {24,1,"A01-24", false}, {25,1,"A01-25", false}, {26,1,"A01-26", false}, {27,1,"A01-27", false}, {28,1,"A01-28", false},
 {29,1,"A01-29", false}, {30,1,"A01-30", false}, {31,1,"A01-31", false}, {32,1,"A01-32", false}, {33,1,"A01-33", false},
 {34,1,"A01-34", false}, {35,1,"A01-35", false}, {36,1,"A01-36", false}, {37,1,"A01-37", false},{38,1,"A01-38", false},
 {39,1,"A01-39", false },{40,1,"A01-40", false},{41,1,"A01-41", false}, {42,1,"A01-42", false}, {43,1,"A01-43", false},
 {44,1,"A01-44", false},{45,1,"A01-45", false},

 {46,2,"A02-01",false}, {47,2,"A02-02",false}, {48,2,"A02-03",false},
 {49,2,"A02-04",false}, {50,2,"A02-05",false}, {51,2,"A02-06",false},
 {52,2,"A02-07",false}, {53,2,"A02-08",false}, {54,2,"A02-09",false},
 {55,2,"A02-10",false}, {56,2,"A02-11",false}, {57,2,"A02-12",false},
 {58,2,"A02-13",false}, {59,2,"A02-14",false}, {60,2,"A02-15",false},
 {61,2,"A02-16",false}, {62,2,"A02-17",false}, {63,2,"A02-18",false},
 {64,2,"A02-19",false}, {65,2,"A02-20",false}, {66,2,"A02-21",false},
 {67,2,"A02-22",false}, {68,2,"A02-23",false}, {69,2,"A02-24",false},
 {70,2,"A02-25",false}, {71,2,"A02-26",false}, {72,2,"A02-27",false},
 {73,2,"A02-28",false}, {74,2,"A02-29",false}, {75,2,"A02-30",false},
 {76,2,"A02-31",false}, {77,2,"A02-32",false}, {78,2,"A02-33",false},
 {79,2,"A02-34",false}, {80,2,"A02-35",false}, {81,2,"A02-36",false},
 {82,2,"A02-37",false}, {83,2,"A02-38",false}, {84,2,"A02-39",false},
 {85,2,"A02-40",false}, {86,2,"A02-41",false}, {87,2,"A02-42",false},
 {88,2,"A02-43",false}, {89,2,"A02-44",false}, {90,2,"A02-45",false},


 {91,3,"A03-01",false },{92,3,"A03-02",false },{93,3,"A03-03",false },{94,3,"A03-04",false },{95,3,"A03-05",false },
 {96,3,"A03-06",false },{97,3,"A03-07",false },{98,3,"A03-08",false },{99,3,"A03-09",false },{100,3,"A03-10",false },
 {101,3,"A03-11",false },{102,3,"A03-12",false},
 {103,3,"A03-13",false },{104,3,"A03-14",false },{105,3,"A03-15",false },{106,3,"A03-16",false },{107,3,"A03-17",false },
 {108,3,"A03-18",false },{109,3,"A03-19",false },{110,3,"A03-20",false },{111,3,"A03-21",false },{112,3,"A03-22",false },
 {113,3,"A03-23",false },{114,3,"A03-24",false },{115,3,"A03-25",false },{116,3,"A03-26",false },{117,3,"A03-27",false },
 {118,3,"A03-28",false },{119,3,"A03-29",false },
 {120,3,"A03-30",false },{121,3,"A03-31",false },{122,3,"A03-32",false },{123,3,"A03-33",false },{124,3,"A03-34",false },
 {125,3,"A03-35",false },{126,3,"A03-36",false },{127,3,"A03-37",false },{128,3,"A03-38",false },{129,3,"A03-39",false },
 {130,3,"A03-40",false },{131,3,"A03-41",false },{132,3,"A03-42",false },{133,3,"A03-43",false },{134,3,"A03-44",false },{135,3,"A03-45",false },

 {136,4,"A04-01",false },{137,4,"A04-02",false },{138,4,"A04-03",false },{139,4,"A04-04",false },{140,4,"A04-05",false },
 {141,4,"A04-06",false },{142,4,"A04-07",false },{143,4,"A04-08",false },{144,4,"A04-09",false },{145,4,"A04-10",false },
 {146,4,"A04-11",false },{147,4,"A04-12",false },{148,4,"A04-13",false },{149,4,"A04-14",false },{150,4,"A04-15",false },
 {151,4,"A04-16",false },{152,4,"A04-17",false },{153,4,"A04-18",false },{154,4,"A04-19",false },{155,4,"A04-20",false },
 {156,4,"A04-21",false },{157,4,"A04-22",false },{158,4,"A04-23",false },{159,4,"A04-24",false },{160,4,"A04-25",false },
 {161,4,"A04-26",false },{162,4,"A04-27",false },{163,4,"A04-28",false },{164,4,"A04-29",false },{165,4,"A04-30",false },
 {166,4,"A04-31",false },{167,4,"A04-32",false },{168,4,"A04-33",false },{169,4,"A04-34",false },{170,4,"A04-35",false },
 {171,4,"A04-36",false },{172,4,"A04-37",false },{173,4,"A04-38",false },{174,4,"A04-39",false },{175,4,"A04-40",false },
 {176,4,"A04-41",false },{177,4,"A04-42",false },{178,4,"A04-43",false },{179,4,"A04-44",false },{180,4,"A04-45",false },

 {181,5,"A05-01",false },{182,5,"A05-02",false },{183,5,"A05-03",false },{184,5,"A05-04",false },{185,5,"A05-05",false },
 {186,5,"A05-06",false },{187,5,"A05-07",false },{188,5,"A05-08",false },{189,5,"A05-09",false },{190,5,"A05-10",false },
 {191,5,"A05-11",false },{192,5,"A05-12",false },{193,5,"A05-13",false },{194,5,"A05-14",false },{195,5,"A05-15",false },
 {196,5,"A05-16",false },{197,5,"A05-17",false },{198,5,"A05-18",false },{199,5,"A05-19",false },{200,5,"A05-20",false },
 {201,5,"A05-21",false },{202,5,"A05-22",false },{203,5,"A05-23",false },{204,5,"A05-24",false },{205,5,"A05-25",false },
 {206,5,"A05-26",false },{207,5,"A05-27",false },{208,5,"A05-28",false },{209,5,"A05-29",false },{210,5,"A05-30",false },
 {211,5,"A05-31",false },{212,5,"A05-32",false },{213,5,"A05-33",false },{214,5,"A05-34",false },{215,5,"A05-35",false },
 {216,5,"A05-36",false },{217,5,"A05-37",false },{218,5,"A05-38",false },{219,5,"A05-39",false },{220,5,"A05-40",false },
 {221,5,"A05-41",false },{222,5,"A05-42",false },{223,5,"A05-43",false },{224,5,"A05-44",false },{225,5,"A05-45",false },

  {226,6,"A06-01",false },{227,6,"A06-02",false },{228,6,"A06-03",false },{229,6,"A06-04",false },{230,6,"A06-05",false },
 {231,6,"A06-06",false },{232,6,"A06-07",false },{233,6,"A06-08",false },{234,6,"A06-09",false },{235,6,"A06-10",false },
 {236,6,"A06-11",false },{237,6,"A06-12",false },{238,6,"A06-13",false },{239,6,"A06-14",false },{240,6,"A06-15",false },
 {241,6,"A06-16",false },{242,6,"A06-17",false },{243,6,"A06-18",false },{244,6,"A06-19",false },{245,6,"A06-20",false },
 {246,6,"A06-21",false },{247,6,"A06-22",false },{248,6,"A06-23",false },{249,6,"A06-24",false },{250,6,"A06-25",false },
 {251,6,"A06-26",false },{252,6,"A06-27",false },{253,6,"A06-28",false },{254,6,"A06-29",false },{255,6,"A06-30",false },
 {256,6,"A06-31",false },{257,6,"A06-32",false },{258,6,"A06-33",false },{259,6,"A06-34",false },{260,6,"A06-35",false },
 {261,6,"A06-36",false },{262,6,"A06-37",false },{263,6,"A06-38",false },{264,6,"A06-39",false },{265,6,"A06-40",false },
 {266,6,"A06-41",false },{267,6,"A06-42",false },{268,6,"A06-43",false },{269,6,"A06-44",false },{270,6,"A06-45",false },

  {271,7,"A07-01",false },{272,7,"A07-02",false },{273,7,"A07-03",false },{274,7,"A07-04",false },{275,7,"A07-05",false },
 {276,7,"A07-06",false },{277,7,"A07-07",false },{278,7,"A07-08",false },{279,7,"A07-09",false },{280,7,"A07-10",false },
 {281,7,"A07-11",false },{282,7,"A07-12",false },{283,7,"A07-13",false },{284,7,"A07-14",false },{285,7,"A07-15",false },
 {286,7,"A07-16",false },{287,7,"A07-17",false },{288,7,"A07-18",false },{289,7,"A07-19",false },{290,7,"A07-20",false },
 {291,7,"A07-21",false },{292,7,"A07-22",false },{293,7,"A07-23",false },{294,7,"A07-24",false },{295,7,"A07-25",false },
 {296,7,"A07-26",false },{297,7,"A07-27",false },{298,7,"A07-28",false },{299,7,"A07-29",false },{300,7,"A07-30",false },
 {301,7,"A07-31",false },{302,7,"A07-32",false },{303,7,"A07-33",false },{304,7,"A07-34",false },{305,7,"A07-35",false },
 {306,7,"A07-36",false },{307,7,"A07-37",false },{308,7,"A07-38",false },{309,7,"A07-39",false },{310,7,"A07-40",false },
 {311,7,"A07-41",false },{312,7,"A07-42",false },{313,7,"A07-43",false },{314,7,"A07-44",false },{315,7,"A07-45",false },

 {316,8,"A08-01",false },{317,8,"A08-02",false },{318,8,"A08-03",false },{319,8,"A08-04",false },{320,8,"A08-05",false },
 {321,8,"A08-06",false },{322,8,"A08-07",false },{323,8,"A08-08",false },{324,8,"A08-09",false },{325,8,"A08-10",false },
 {326,8,"A08-11",false },{327,8,"A08-12",false },{328,8,"A08-13",false },{329,8,"A08-14",false },{330,8,"A08-15",false },
 {331,8,"A08-16",false },{332,8,"A08-17",false },{333,8,"A08-18",false },{334,8,"A08-19",false },{335,8,"A08-20",false },
 {336,8,"A08-21",false },{337,8,"A08-22",false },{338,8,"A08-23",false },{339,8,"A08-24",false },{340,8,"A08-25",false },
 {341,8,"A08-26",false },{342,8,"A08-27",false },{343,8,"A08-28",false },{344,8,"A08-29",false },{345,8,"A08-30",false },
 {346,8,"A08-31",false },{347,8,"A08-32",false },{348,8,"A08-33",false },{349,8,"A08-34",false },{350,8,"A08-35",false },
 {351,8,"A08-36",false },{352,8,"A08-37",false },{353,8,"A08-38",false },{354,8,"A08-39",false },{355,8,"A08-40",false },
 {356,8,"A08-41",false },{357,8,"A08-42",false },{358,8,"A08-43",false },{359,8,"A08-44",false },{360,8,"A08-45",false },

 {361,9,"A09-01",false },{362,9,"A09-02",false },{363,9,"A09-03",false },{364,9,"A09-04",false },{365,9,"A09-05",false },
 {366,9,"A09-06",false },{367,9,"A09-07",false },{368,9,"A09-08",false },{369,9,"A09-09",false },{370,9,"A09-10",false },
 {371,9,"A09-11",false },{372,9,"A09-12",false },{373,9,"A09-13",false },{374,9,"A09-14",false },{375,9,"A09-15",false },
 {376,9,"A09-16",false },{377,9,"A09-17",false },{378,9,"A09-18",false },{379,9,"A09-19",false },{380,9,"A09-20",false },
 {381,9,"A09-21",false },{382,9,"A09-22",false },{383,9,"A09-23",false },{384,9,"A09-24",false },{385,9,"A09-25",false },
 {386,9,"A09-26",false },{387,9,"A09-27",false },{388,9,"A09-28",false },{389,9,"A09-29",false },{390,9,"A09-30",false },
 {391,9,"A09-31",false },{392,9,"A09-32",false },{393,9,"A09-33",false },{394,9,"A09-34",false },{395,9,"A09-35",false },
 {396,9,"A09-36",false },{397,9,"A09-37",false },{398,9,"A09-38",false },{399,9,"A09-39",false },{400,9,"A09-40",false },
 {401,9,"A09-41",false },{402,9,"A09-42",false },{403,9,"A09-43",false },{404,9,"A09-44",false },{405,9,"A09-45",false },

  {406,10,"A10-01",false },{407,10,"A10-02",false },{408,10,"A10-03",false },{409,10,"A10-04",false },{410,10,"A10-05",false },
 {411,10,"A10-06",false },{412,10,"A10-07",false },{413,10,"A10-08",false },{414,10,"A10-09",false },{415,10,"A10-10",false },
 {416,10,"A10-11",false },{417,10,"A10-12",false },{418,10,"A10-13",false },{419,10,"A10-14",false },{420,10,"A10-15",false },
 {421,10,"A10-16",false },{422,10,"A10-17",false },{423,10,"A10-18",false },{424,10,"A10-19",false },{425,10,"A10-20",false },
 {426,10,"A10-21",false },{427,10,"A10-22",false },{428,10,"A10-23",false },{429,10,"A10-24",false },{430,10,"A10-25",false },
 {431,10,"A10-26",false },{432,10,"A10-27",false },{433,10,"A10-28",false },{434,10,"A10-29",false },{435,10,"A10-30",false },
 {436,10,"A10-31",false },{437,10,"A10-32",false },{438,10,"A10-33",false },{439,10,"A10-34",false },{440,10,"A10-35",false },
 {441,10,"A10-36",false },{442,10,"A10-37",false },{443,10,"A10-38",false },{444,10,"A10-39",false },{445,10,"A10-40",false },
 {446,10,"A10-41",false },{447,10,"A10-42",false },{448,10,"A10-43",false },{449,10,"A10-44",false },{450,10,"A10-45",false }


                });
            migrationBuilder.InsertData(
               table: "PremiereTimes",
               columns: new[] { "PremiereTimeId", "StartTime" },
               values: new object[,]
               {
            {1,new DateTime(2024, 4, 26, 10, 15, 0) },
            {2,new DateTime(2024,3,29, 10, 15, 0) },
            {3,new DateTime(2024,3,8, 10, 15, 0)},
            {4,new DateTime(2024,4,12, 10, 15, 0)},
            {5,new DateTime(2024,3,15,10, 15,0)},
            {6,new DateTime(2024,7,5,10, 15,0)},
            {7,new DateTime(2024,5,24,10, 15,0)},
            {8,new DateTime(2024,5,3,10, 15,0)},
            {9,new DateTime(2024,4,29, 10, 15,0)},
            {10,new DateTime(2024,2,10,10, 15,0)},
            {11,new DateTime(2024,4,12,10, 15,0)},
            {12,new DateTime(2024,4,18,10, 15,0)}
               }
            );
            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "FilmId", "NameFilm", "Description", "PosterUrl", "TrailerUrl", "PremiereTimeId",
             "DirectorName","Language","FilmRated","FilmDuration","Actors", "FilmCategoryId"},
                values: new object[,]
                {
 {1, "LẬT MẶT 7: MỘT ĐIỀU ƯỚC",
     "Một câu chuyện lần đầu được kể bằng tất cả tình yêu, và từ tất cả những hồi ức xao xuyến nhất của đấng sinh thành",
     "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/l/a/lat-mat-7.jpg",
     "https://youtu.be/d1ZHdosjNX8?si=f6_pea9cJ5HtvnJy",
      1,"Lý Hải","Tiếng Việt - Phụ đề Tiếng Anh","K - Phim được phổ biến đến người xem dưới 13 tuổi và có người bảo hộ đi kèm",138,"Thanh Hiền, Trương Minh Cường, Đinh Y Nhung, Quách Ngọc Tuyên, Trâm Anh, Trần Kim Hải,...",12},

 {2,"GODZILLA X KONG: ĐẾ CHẾ MỚI",
 "Kong và Godzilla - hai sinh vật vĩ đại huyền thoại, hai kẻ thủ truyền kiếp sẽ cùng bắt tay thực thi một sứ mệnh chung mang tính sống còn để bảo vệ nhân loại, và trận chiến gắn kết chúng với loài người mãi mãi sẽ bắt đầu.",
 "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/p/o/poster_payoff_godzilla_va_kong_3_1_.jpg",
 "https://youtu.be/RXc2bs_aBuA",
 2,"Adam Wingard","Tiếng Anh - Phụ đề Tiếng Việt, Tiếng Hàn","K - Phim được phổ biến đến người xem dưới 13 tuổi và có người bảo hộ đi kèm",115,"Rebecca Hall; Brian Tyree Henry; Dan Stevens; Kaylee Hottle; Alex Ferns; Fala Chen,...",1},

 {3,"KUNG FU PANDA 4",
 "Sau khi Po được chọn trở thành Thủ lĩnh tinh thần của Thung lũng Bình Yên, Po cần tìm và huấn luyện một Chiến binh Rồng mới, trong khi đó một mụ phù thủy độc ác lên kế hoạch triệu hồi lại tất cả những kẻ phản diện mà Po đã đánh bại về cõi linh hồn.",
 "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/4/7/470x700-kungfupanda4.jpg",
 "https://youtu.be/egkeFvm26pc",
 3,"Mike Mitchell","Tiếng Anh - Phụ đề Tiếng Việt; Lồng tiếng","P - Phim được phép phổ biến đến người xem ở mọi độ tuổi.",94,"Jack Black, Dustin Hoffman, James Hong, Awkwafina, ...",7},

 {4,"THANH XUÂN 18x2: LỮ TRÌNH HƯỚNG VỀ EM",
 "Ký ức tình đầu ùa về khi Jimmy nhận được tấm bưu thiếp từ Ami. Cậu quyết định một mình bước lên chuyến tàu đến Nhật Bản gặp lại người con gái cậu đã bỏ lỡ 18 năm trước. Mối tình day dứt thời thanh xuân, liệu sẽ có một kết cục nào tốt đẹp khi đoàn tụ?",
 "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/7/0/700x1000_exhuma-min.jpg",
 "https://youtu.be/8Pq08VsVUFk",
 4,"Fujii Michihito","Tiếng Nhật & Tiếng Trung Quốc với phụ đề Tiếng Việt và Tiếng Anh","T13 - Phim được phổ biến đến người xem từ đủ 13 tuổi trở lên (13+)",123," Greg Hsu, Kaya Kiyohara, Chang Chen, Kuroki Hitomi, Michieda Shunsuke,...",9},

 {5,"EXHUMA: QUẬT MỘ TRÙNG MA",
 "Hai pháp sư, một thầy phong thuỷ và một chuyên gia khâm liệm cùng hợp lực khai quật ngôi mộ bị nguyền rủa của một gia đình giàu có, nhằm cứu lấy sinh mạng hậu duệ cuối cùng trong dòng tộc. Bí mật hắc ám của tổ tiên được đánh thức.",
 "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/p/o/poster_payoff_godzilla_va_kong_3_1_.jpg",
 "https://youtu.be/7LH-TIcPqks",
 5,"Jang Jae Hyun","Tiếng Hàn - Phụ đề Tiếng Anh & Tiếng Việt","T16 - Phim được phổ biến đến người xem từ đủ 16 tuổi trở lên (16+)",133,"Choi Min Sik, Yoo Hai Jin, Kim Go Eun, Lee Do Hyun,...",4},

 {6,"KẺ TRỘM MẶT TRĂNG 4",
 "Gru phải đối mặt với kẻ thù mới là Maxime Le Mal và Valentina đang lên kế hoạch trả thù anh, buộc gia đình anh phải lẩn trốn đi nơi khác. Bên cạnh việc đấu tranh bảo vệ gia đình, Gru đồng thời còn phải tìm ra điểm chung với thành viên mới nhất trong nhà đó là Gru Jr.",
 "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/d/m/dm4_teaser_700x1000.jpg",
 "https://youtu.be/GTupBD8M3yw",
 6,"Chris Renaud","Tiếng Anh - Phụ đề Tiếng Việt; Lồng tiếng","PG - Cha mẹ nên có hướng dẫn cho con khi xem ",0,"Steve Carell, Kristen Wiig, Joey King,...",7},

 {7,"PHIM ĐIỆN ẢNH DORAEMON: NOBITA VÀ BẢN GIAO HƯỞNG ĐỊA CẦU",
 "TÁC PHẨM KỶ NIỆM 90 NĂM FUJIKO F FUJIO Chuẩn bị cho buổi hòa nhạc ở trường, Nobita đang tập thổi sáo - nhạc cụ mà cậu dở tệ. Thích thú trước nốt \"No\" lạc quẻ của Nobita, Micca - cô bé bí ẩn đã mời Doraemon, Nobita cùng nhóm bạn đến \"Farre\" - Cung điện âm nhạc tọa lạc trên một hành tinh nơi âm nhạc sẽ hóa thành năng lượng. Nhằm cứu cung điện này, Micca đang tìm kiếm \"virtuoso\" - bậc thầy âm nhạc sẽ cùng mình biểu diễn! Với bảo bối thần kì \"chứng chỉ chuyên viên âm nhạc\", Doraemon và các bạn đã chọn nhạc cụ, cùng Micca hòa tấu, từng bước khôi phục cung điện. Tuy nhiên, một vật thể sống đáng sợ sẽ xóa số âm nhạc khỏi thế giới đang đến gần, Trái Đất đang rơi vào nguy hiểm... ! Liệu những người bạn nhỏ có thể cứu được \"tương lai âm nhạc\" và cả địa cầu này?",
 "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/1800x/71252117777b696995f01934522c402d/m/a/main_poster_-_dmmovie2023_1.jpg",
 "https://youtu.be/Yug8gbDd5EQ",
 7,"Kazuaki Imai","Tiếng Nhật - Phụ đề Tiếng Việt; Lồng tiếng","G - Phim dành cho mọi lứa tuổi",115,"Wasabi Mizuta, Megumi Ôhara, Yumi Kakazu...",7},

 {8,"TAROT 2024",
 "Bộ phim sẽ là hành trình theo chân một nhóm bạn đại học sau khi sử dụng một bộ bài tarot bí ẩn, từng người trong nhóm đã ra đi theo những cách kì lạ và có liên quan đến lá bài mà họ bốc. Trước khi hết thời gian, họ đã cùng nhau hợp tác để khám phá ra bí ẩn đằng sau bộ bài kí bí ấy. Bạn sẽ nhìn thấy ai khi trút hơi thở cuối cùng?",
 "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/7/0/700x1000-tarot.jpg",
 "https://youtu.be/mqiEnk8Lrco",
8,"Spenser Cohen","Tiếng Anh - Phụ đề Tiếng Việt","T18 - Phim được phổ biến đến người xem từ đủ 18 tuổi trở lên (18+)",160,"Avantika, Jacob Batalon, Olwen Fouéré,...",4},

 {9,"CÁI GIÁ CỦA HẠNH PHÚC",
 "Bà Dương và ông Thoại luôn cố gắng để xây dựng một hình ảnh gia đình tài giỏi và danh giá trong mắt mọi người. Tuy nhiên dưới lớp vỏ bọc hào nhoáng ấy là những biến cố và lục đục gia đình đầy sóng gió. Nhìn kĩ hơn một chút bức tranh gia đình hạnh phúc ấy, rất nhiều \"khuyết điểm\" sẽ lộ ra gây bất ngờ.",
 "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/7/0/700x1000-cghp-min.jpg",
 "https://youtu.be/79BznZKQwIQ",
9,"Nguyễn Ngọc Lâm","Tiếng Việt - Phụ đề Tiếng Anh","T18 - Phim được phổ biến đến người xem từ đủ 18 tuổi trở lên (18+)",115," Xuân Lan, Thái Hoà, Lâm Thanh Nhã, Uyển Ân, Hữu Châu, Trâm Anh, Trương Thanh Long, Quang Minh, Bé Quyên,...",9},

 {10,"MAI",
 "\"Mai\" xoay quanh cuộc đời của một người phụ nữ đẹp tên Mai có số phận rất đặc biệt. Bởi làm nghề mát xa, Mai thường phải đối mặt với ánh nhìn soi mói, phán xét từ những người xung quanh. Và rồi Mai gặp Dương - chàng trai đào hoa lãng tử. Những tưởng bản thân không còn thiết tha yêu đương và mưu cầu hạnh phúc cho riêng mình thì khao khát được sống một cuộc đời mới trong Mai trỗi dậy khi Dương tấn công cô không khoan nhượng. Họ cho mình những khoảnh khắc tự do, say đắm và tràn đầy tiếng cười. Liệu cặp đôi ấy có nắm giữ được niềm hạnh phúc đó dài lâu khi miệng đời lắm khi cay nghiệt, bất công? \"Mai\" - một câu chuyện tâm lý, tình cảm pha lẫn nhiều tràng cười vui nhộn với sự đầu tư mạnh tay nhất trong ba phim của Trấn Thành hứa hẹn sẽ đem đến cho khán giả những phút giây thật sự ý nghĩa trong mùa Tết năm nay.",
 "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/m/a/mai_teaser_poster_digital_1_.jpg",
 "https://youtu.be/HXWRTGbhb4U",
10,"Trấn Thành","Tiếng Việt - Phụ đề Tiếng Anh","T18 - Phim được phổ biến đến người xem từ đủ 18 tuổi trở lên (18+)",131,"Phương Anh Đào, Tuấn Trần, Trấn Thành, Uyển Ân, Hồng Đào, NSND Việt Anh, NSND Ngọc Giàu, Khả Như, Quốc Khánh, Anh Thư, Lý Hạo Mạnh Quỳnh, Anh Đức, Anh Phạm, Lộ Lộ, Kiều Linh, Ngọc Nga, Thanh Hằng, Ngọc Nguyễn, Hoàng Mèo, Mạnh Lân,...",6},

 {11,"NGÀY TÀN CỦA ĐẾ QUỐC",
 "Trong một tương lai gần, một nhóm các phóng viên chiến trường quả cảm phải đấu tranh với thời gian và bom đạn nguy hiểm để đến kịp Nhà Trắng giữa bối cảnh nội chiến Hoa Kỳ đang tiến đến cao trào.",
 "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/1800x/71252117777b696995f01934522c402d/k/t/kt_facebook.jpg",
 "https://youtu.be/QGlgPf9jGMA",
 11,"Alex Garland","Tiếng Anh - Phụ đề Tiếng Việt","T18 - Phim được phổ biến đến người xem từ đủ 18 tuổi trở lên (18+)",109,"Kirsten Dunst, Wagner Moura, Cailee Spaeny,…",1},

 {12,"MÙA HÈ CỦA LUCA",
 "\"Mùa Hè Của Luca\" kể về chuyến hành trình của cậu bé Luca tại hòn đảo Portorosso thuộc vùng biển Địa Trung Hải ở Ý tuyệt đẹp. Ở đây cậu đã làm quen và kết thân với những người bạn nhỏ mới và tận hưởng mùa hè đầy nắng, kem Gelato và cả món mì Ý trứ danh. Tuy nhiên có một điều không ổn lắm, Luca là một THỦY QUÁI và những người dân trên hòn đảo này lại không thích điều này chút nào.",
 "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/r/s/rsz_1200x1800_2.jpg",
 "https://youtu.be/FzV3gRevq4Q",
 12,"Enrico Casarosa","Tiếng Anh với phụ đề tiếng Việt, lồng tiếng","P - Phim được phép phổ biến đến người xem ở mọi độ tuổi.",99,"(Lồng tiếng): Jacob Tremblay, Jack Dylan Grazer, Emma Berman, Saverio Raimondo, Maya Rudolph, Marco Barricelli, Jim Gaffigan, Sandy Martin,...",7}
                });

            migrationBuilder.InsertData(
                table: "FilmSchedules",
                columns: new[] { "FilmScheduleId", "FilmId", "TheatreRoomId", "FilmScheduleDescription" },
                values: new object[,]
                {
             {1,1,1,"10:30"},
             {2,1,1,"12:30"},
             {3,1,1,"15:45"},
             {4,1,1,"18:00"},
             {5,1,1,"20:25"},
             {6,2,2,"10:15"},
             {7,2,2,"13:55"},
             {8,2,2,"15:55"},
             {9,2,2,"19:45"},
             {10,2,2,"21:25"},
             {11,3,3,"10:05"},
             {12,3,3,"12:35"},
             {13,3,3,"15:00"},
             {14,3,3,"17:55"},
             {15,3,3,"20:05"},
             {16,3,3,"23:00"},
             {17,4,4,"10:30"},
             {18,4,4,"13:55"},
             {19,4,4,"16:10"},
             {20,4,4,"19:45"},
             {21,4,4,"23:55"},
             {22,5,5,"10:05"},
             {23,5,5,"13:15"},
             {24,5,5,"16:35" },
             {25,5,5,"19:20"},
             {26,5,5,"22:15"},
             {27,9,6,"9:45"},
             {28,9,6,"12:35"},
             {29,9,6,"15:55"},
             {30,9,6,"17:45"},
             {31,9,6,"20:00"},
             {32,9,6,"22:55"},
             {33,10,7,"9:55" },
             {34,10,7,"13:10"},
             {35,10,7,"15:55" },
             {36,10,7,"18:00" },
             {37,10,7,"20:30" },
             {38,11,8,"10:00"},
             {39,11,8,"12:55" },
             {40,11,8,"14:55" },
             {41,11,8,"17:00" },
             {42,11,8,"18:55"},
             {43,11,8,"20:45"},
             {44,11,8,"23:20" },
             {45,8, 9,"11:00"},
             {46,8,9,"14:25" },
             {47,8,9,"18:00" },
             {48,8,9,"21:20" },
             {49,12,10,"10:45" },
             {50,12,10,"13:00" },
             {51,12,10,"15:25"},
             {52,12,10,"17:00"},
             {53,12,10,"19:05" },
             {54,12,10,"21:00" },
             {55,12,10,"23:20"}
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}