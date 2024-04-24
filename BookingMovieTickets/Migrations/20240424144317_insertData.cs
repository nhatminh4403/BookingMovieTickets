using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingMovieTickets.Migrations
{
    /// <inheritdoc />
    public partial class insertData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FilmCategory",
                columns: new[] { "FilmCategoryId", "Description" },
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
                    {1,"InfinityCinema Quận 7","Lầu 9 Crescent Mall, 101 Đ Tôn Dật Tiên, Tân Phú, Quận 7, Thành phố Hồ Chí Minh" }
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
                columns: new[] { "SeatId", "TheatreRoomId", "IsBooked" },
                values: new object[,]
                {
                    {1,1,false}, {2,1,false},{3,1,false}, {4,1,false},{5,1,false},
                    {6,1,false},{7,1,false}, {8,1,false},{9,1,false}, {10,1,false},
                    {11,1,false}, {12,1,false}, {13,1,false}, {14,1,false},{15,1,false}, {16,1,false},
                    {17,1,false}, {18,1,false}, {19,1,false}, {20,1,false}, {21,1,false}, {22,1,false},
                    {23,1,false}, {24,1,false}, {25,1,false}, {26,1,false}, {27,1,false}, {28,1,false},
                    {29,1,false}, {30,1,false}, {31,1,false}, {32,1,false}, {33,1,false},
                    {34,1,false}, {35,1,false}, {36,1,false}, {37,2,false},{38,1,false},
                    {39,1,false },{40,1,false},{41,1,false}, {42,1,false}, {43,1,false},{44,1,false},{45,1,false},

                    {1,2,false}, {2,2,false},{3,2,false},
                    {4,2,false}, {5,2,false}, {6,2,false},
                    {7,2,false}, {8,2,false}, {9,2,false},
                    {10,2,false}, {11,2,false}, {12,2,false},
                    {13,2,false}, {14,2,false}, {15,2,false},
                    {16,2,false}, {17,2,false}, {18,2,false},
                    {19,2,false}, {20,2,false}, {21,2,false}, {22,2,false},
                    {23,2,false}, {24,2,false}, {25,2,false}, {26,2,false},
                    {27,2,false}, {28,2,false}, {29,2,false}, {30,2,false},
                    {31,2,false}, {32,2,false}, {33,2,false}, {34,2,false},
                    {35,2,false}, {36,2,false}, {37,2,false}, {38,2,false},
                    {39,2,false}, {40,2,false}, {41,2,false},
                    {42,2,false}, {43,2,false}, {44,2,false},{45,2,false},

                    {1,3,false },{2,3,false },{3,3,false },{4,3,false },{5,3,false },
                    {6,3,false },{7,3,false },{8,3,false },{9,3,false },{10,3,false },{11,3,false },{12,3,false},
                    {13,3,false },{14,3,false },{15,3,false },{16,3,false },{17,3,false },{18,3,false },{19,3,false },{20,3,false },{21,3,false },{22,3,false },{23,3,false },{24,3,false },{25,3,false },{26,3,false },{27,3,false },{28,3,false },{29,3,false },
                    {30,3,false },{31,3,false },{32,3,false },{33,3,false },{34,3,false },
                    {35,3,false },{36,3,false },{37,3,false },{38,3,false },{39,3,false },
                    {40,3,false },{41,3,false},{42,3,false },{43,3,false },{44,3,false},{45,3,false },

                     {1,4,false}, {2,4,false},{3,4,false},
                     {4,4,false}, {5,4,false}, {6,4,false},
                     {7,4,false}, {8,4,false}, {9,4,false},
                     {10,4,false}, {11,4,false}, {12,4,false},
                     {13,4,false}, {14,4,false}, {15,4,false},
                     {16,4,false}, {17,4,false}, {18,4,false},
                     {19,4,false}, {20,4,false}, {21,4,false}, {22,4,false},
                     {23,4,false}, {24,4,false}, {25,4,false}, {26,4,false},
                     {27,4,false}, {28,4,false}, {29,4,false}, {30,4,false},
                     {31,4,false}, {32,4,false}, {33,4,false}, {34,4,false},
                     {35,4,false}, {36,4,false}, {37,4,false}, {38,4,false},
                     {39,4,false}, {40,4,false}, {41,4,false},
                     {42,4,false}, {43,4,false}, {44,4,false},{45,4,false},

                     {1,5,false}, {2,5,false},{3,5,false},
                     {4,5,false}, {5,5,false}, {6,5,false},
                     {7,5,false}, {8,5,false}, {9,5,false},
                     {10,5,false}, {11,5,false}, {12,5,false},
                     {13,5,false}, {14,5,false}, {15,5,false},
                     {16,5,false}, {17,5,false}, {18,5,false},
                     {19,5,false}, {20,5,false}, {21,5,false}, {22,5,false},
                     {23,5,false}, {24,5,false}, {25,5,false}, {26,5,false},
                     {27,5,false}, {28,5,false}, {29,5,false}, {30,5,false},
                     {31,5,false}, {32,5,false}, {33,5,false}, {34,5,false},
                     {35,5,false}, {36,5,false}, {37,5,false}, {38,5,false},
                     {39,5,false}, {40,5,false}, {41,5,false},
                     {42,5,false}, {43,5,false}, {44,5,false},{45,5,false},

                      {1,6,false}, {2,6,false},{3,6,false},
                     {4,6,false}, {5,6,false}, {6,6,false},
                     {7,6,false}, {8,6,false}, {9,6,false},
                     {10,6,false}, {11,6,false}, {12,6,false},
                     {13,6,false}, {14,6,false}, {15,6,false},
                     {16,6,false}, {17,6,false}, {18,6,false},
                     {19,6,false}, {20,6,false}, {21,6,false}, {22,6,false},
                     {23,6,false}, {24,6,false}, {25,6,false}, {26,6,false},
                     {27,6,false}, {28,6,false}, {29,6,false}, {30,6,false},
                     {31,6,false}, {32,6,false}, {33,6,false}, {34,6,false},
                     {35,6,false}, {36,6,false}, {37,6,false}, {38,6,false},
                     {39,6,false}, {40,6,false}, {41,6,false},
                     {42,6,false}, {43,6,false}, {44,6,false},{45,6,false},

                      {1,7,false}, {2,7,false},{3,7,false},
                     {4,7,false}, {5,7,false}, {6,7,false},
                     {7,7,false}, {8,7,false}, {9,7,false},
                     {10,7,false}, {11,7,false}, {12,7,false},
                     {13,7,false}, {14,7,false}, {15,7,false},
                     {16,7,false}, {17,7,false}, {18,7,false},
                     {19,7,false}, {20,7,false}, {21,7,false}, {22,7,false},
                     {23,7,false}, {24,7,false}, {25,7,false}, {26,7,false},
                     {27,7,false}, {28,7,false}, {29,7,false}, {30,7,false},
                     {31,7,false}, {32,7,false}, {33,7,false}, {34,7,false},
                     {35,7,false}, {36,7,false}, {37,7,false}, {38,7,false},
                     {39,7,false}, {40,7,false}, {41,7,false},
                     {42,7,false}, {43,7,false}, {44,7,false},{45,7,false},

                      {1,8,false}, {2,8,false},{3,8,false},
                     {4,8,false}, {5,8,false}, {6,8,false},
                     {7,8,false}, {8,8,false}, {9,8,false},
                     {10,8,false}, {11,8,false}, {12,8,false},
                     {13,8,false}, {14,8,false}, {15,8,false},
                     {16,8,false}, {17,8,false}, {18,8,false},
                     {19,8,false}, {20,8,false}, {21,8,false}, {22,8,false},
                     {23,8,false}, {24,8,false}, {25,8,false}, {26,8,false},
                     {27,8,false}, {28,8,false}, {29,8,false}, {30,8,false},
                     {31,8,false}, {32,8,false}, {33,8,false}, {34,8,false},
                     {35,8,false}, {36,8,false}, {37,8,false}, {38,8,false},
                     {39,8,false}, {40,8,false}, {41,8,false},
                     {42,8,false}, {43,8,false}, {44,8,false},{45,8,false},

                      {1,9,false}, {2,9,false},{3,9,false},
                     {4,9,false}, {5,9,false}, {6,9,false},
                     {7,9,false}, {8,9,false}, {9,9,false},
                     {10,9,false}, {11,9,false}, {12,9,false},
                     {13,9,false}, {14,9,false}, {15,9,false},
                     {16,9,false}, {17,9,false}, {18,9,false},
                     {19,9,false}, {20,9,false}, {21,9,false}, {22,9,false},
                     {23,9,false}, {24,9,false}, {25,9,false}, {26,9,false},
                     {27,9,false}, {28,9,false}, {29,9,false}, {30,9,false},
                     {31,9,false}, {32,9,false}, {33,9,false}, {34,9,false},
                     {35,9,false}, {36,9,false}, {37,9,false}, {38,9,false},
                     {39,9,false}, {40,9,false}, {41,9,false},
                     {42,9,false}, {43,9,false}, {44,9,false},{45,9,false},

                      {1,10,false}, {2,10,false},{3,10,false},
                     {4,10,false}, {5,10,false}, {6,10,false},
                     {7,10,false}, {8,10,false}, {9,10,false},
                     {10,10,false}, {11,10,false}, {12,10,false},
                     {13,10,false}, {14,10,false}, {15,10,false},
                     {16,10,false}, {17,10,false}, {18,10,false},
                     {19,10,false}, {20,10,false}, {21,10,false}, {22,10,false},
                     {23,10,false}, {24,10,false}, {25,10,false}, {26,10,false},
                     {27,10,false}, {28,10,false}, {29,10,false}, {30,10,false},
                     {31,10,false}, {32,10,false}, {33,10,false}, {34,10,false},
                     {35,10,false}, {36,10,false}, {37,10,false}, {38,10,false},
                     {39,10,false}, {40,10,false}, {41,10,false},
                     {42,10,false}, {43,10,false}, {44,10,false},{45,10,false}
                });

            migrationBuilder.InsertData(
                table:"Films",
                columns: new[] { "FilmId", "NameFilm", "Description", "PosterUrl","TrailerUrl", "PremiereDate", "FilmCategoryId" },
                values: new object[,]
                {
                    {1, "LẬT MẶT 7: MỘT ĐIỀU ƯỚC",
                        "Một câu chuyện lần đầu được kể bằng tất cả tình yêu, và từ tất cả những hồi ức xao xuyến nhất của đấng sinh thành",
                        "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/l/a/lat-mat-7.jpg",
                        "https://youtu.be/d1ZHdosjNX8?si=f6_pea9cJ5HtvnJy",
                        "26/04/2024",12},

                    {2,"GODZILLA X KONG: ĐẾ CHẾ MỚI",
                    "Kong và Godzilla - hai sinh vật vĩ đại huyền thoại, hai kẻ thủ truyền kiếp sẽ cùng bắt tay thực thi một sứ mệnh chung mang tính sống còn để bảo vệ nhân loại, và trận chiến gắn kết chúng với loài người mãi mãi sẽ bắt đầu.",
                    "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/p/o/poster_payoff_godzilla_va_kong_3_1_.jpg",
                    "https://youtu.be/RXc2bs_aBuA",
                    "29/03/2024",1},

                    {3,"KUNG FU PANDA 4",
                    "Sau khi Po được chọn trở thành Thủ lĩnh tinh thần của Thung lũng Bình Yên, Po cần tìm và huấn luyện một Chiến binh Rồng mới, trong khi đó một mụ phù thủy độc ác lên kế hoạch triệu hồi lại tất cả những kẻ phản diện mà Po đã đánh bại về cõi linh hồn.",
                    "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/4/7/470x700-kungfupanda4.jpg",
                    "https://youtu.be/egkeFvm26pc",
                    "08/03/2024",7},

                    {4,"THANH XUÂN 18x2: LỮ TRÌNH HƯỚNG VỀ EM",
                    "Ký ức tình đầu ùa về khi Jimmy nhận được tấm bưu thiếp từ Ami. Cậu quyết định một mình bước lên chuyến tàu đến Nhật Bản gặp lại người con gái cậu đã bỏ lỡ 18 năm trước. Mối tình day dứt thời thanh xuân, liệu sẽ có một kết cục nào tốt đẹp khi đoàn tụ?",
                    "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/7/0/700x1000_exhuma-min.jpg",
                    "https://youtu.be/8Pq08VsVUFk",
                    "12/04/2024",9},

                    {5,"EXHUMA: QUẬT MỘ TRÙNG MA",
                    "Hai pháp sư, một thầy phong thuỷ và một chuyên gia khâm liệm cùng hợp lực khai quật ngôi mộ bị nguyền rủa của một gia đình giàu có, nhằm cứu lấy sinh mạng hậu duệ cuối cùng trong dòng tộc. Bí mật hắc ám của tổ tiên được đánh thức.",
                    "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/p/o/poster_payoff_godzilla_va_kong_3_1_.jpg",
                    "https://youtu.be/7LH-TIcPqks",
                    "15/03/2024",4},

                    {6,"KẺ TRỘM MẶT TRĂNG 4",
                    "Gru phải đối mặt với kẻ thù mới là Maxime Le Mal và Valentina đang lên kế hoạch trả thù anh, buộc gia đình anh phải lẩn trốn đi nơi khác. Bên cạnh việc đấu tranh bảo vệ gia đình, Gru đồng thời còn phải tìm ra điểm chung với thành viên mới nhất trong nhà đó là Gru Jr.",
                    "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/d/m/dm4_teaser_700x1000.jpg",
                    "https://youtu.be/GTupBD8M3yw",
                    "05/07/2024",7},

                    {7,"PHIM ĐIỆN ẢNH DORAEMON: NOBITA VÀ BẢN GIAO HƯỞNG ĐỊA CẦU",
                    "TÁC PHẨM KỶ NIỆM 90 NĂM FUJIKO F FUJIO Chuẩn bị cho buổi hòa nhạc ở trường, Nobita đang tập thổi sáo - nhạc cụ mà cậu dở tệ. Thích thú trước nốt \"No\" lạc quẻ của Nobita, Micca - cô bé bí ẩn đã mời Doraemon, Nobita cùng nhóm bạn đến \"Farre\" - Cung điện âm nhạc tọa lạc trên một hành tinh nơi âm nhạc sẽ hóa thành năng lượng. Nhằm cứu cung điện này, Micca đang tìm kiếm \"virtuoso\" - bậc thầy âm nhạc sẽ cùng mình biểu diễn! Với bảo bối thần kì \"chứng chỉ chuyên viên âm nhạc\", Doraemon và các bạn đã chọn nhạc cụ, cùng Micca hòa tấu, từng bước khôi phục cung điện. Tuy nhiên, một vật thể sống đáng sợ sẽ xóa số âm nhạc khỏi thế giới đang đến gần, Trái Đất đang rơi vào nguy hiểm... ! Liệu những người bạn nhỏ có thể cứu được \"tương lai âm nhạc\" và cả địa cầu này?",
                    "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/1800x/71252117777b696995f01934522c402d/m/a/main_poster_-_dmmovie2023_1.jpg",
                    "https://youtu.be/Yug8gbDd5EQ",
                    "29/03/2024",7},

                    {8,"TAROT 2024",
                    "Bộ phim sẽ là hành trình theo chân một nhóm bạn đại học sau khi sử dụng một bộ bài tarot bí ẩn, từng người trong nhóm đã ra đi theo những cách kì lạ và có liên quan đến lá bài mà họ bốc. Trước khi hết thời gian, họ đã cùng nhau hợp tác để khám phá ra bí ẩn đằng sau bộ bài kí bí ấy. Bạn sẽ nhìn thấy ai khi trút hơi thở cuối cùng?",
                    "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/7/0/700x1000-tarot.jpg",
                    "https://youtu.be/mqiEnk8Lrco",
                    "03/05/2024",4},

                    {9,"CÁI GIÁ CỦA HẠNH PHÚC",
                    "Bà Dương và ông Thoại luôn cố gắng để xây dựng một hình ảnh gia đình tài giỏi và danh giá trong mắt mọi người. Tuy nhiên dưới lớp vỏ bọc hào nhoáng ấy là những biến cố và lục đục gia đình đầy sóng gió. Nhìn kĩ hơn một chút bức tranh gia đình hạnh phúc ấy, rất nhiều \"khuyết điểm\" sẽ lộ ra gây bất ngờ.",
                    "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/7/0/700x1000-cghp-min.jpg",
                    "https://youtu.be/79BznZKQwIQ",
                    "19/04/2024",9},

                    {10,"MAI",
                    "\"Mai\" xoay quanh cuộc đời của một người phụ nữ đẹp tên Mai có số phận rất đặc biệt. Bởi làm nghề mát xa, Mai thường phải đối mặt với ánh nhìn soi mói, phán xét từ những người xung quanh. Và rồi Mai gặp Dương - chàng trai đào hoa lãng tử. Những tưởng bản thân không còn thiết tha yêu đương và mưu cầu hạnh phúc cho riêng mình thì khao khát được sống một cuộc đời mới trong Mai trỗi dậy khi Dương tấn công cô không khoan nhượng. Họ cho mình những khoảnh khắc tự do, say đắm và tràn đầy tiếng cười. Liệu cặp đôi ấy có nắm giữ được niềm hạnh phúc đó dài lâu khi miệng đời lắm khi cay nghiệt, bất công? \"Mai\" - một câu chuyện tâm lý, tình cảm pha lẫn nhiều tràng cười vui nhộn với sự đầu tư mạnh tay nhất trong ba phim của Trấn Thành hứa hẹn sẽ đem đến cho khán giả những phút giây thật sự ý nghĩa trong mùa Tết năm nay.",
                    "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/m/a/mai_teaser_poster_digital_1_.jpg",
                    "https://youtu.be/HXWRTGbhb4U",
                    "10/02/2024",6},

                    {11,"NGÀY TÀN CỦA ĐẾ QUỐC",
                    "Trong một tương lai gần, một nhóm các phóng viên chiến trường quả cảm phải đấu tranh với thời gian và bom đạn nguy hiểm để đến kịp Nhà Trắng giữa bối cảnh nội chiến Hoa Kỳ đang tiến đến cao trào.",
                    "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/1800x/71252117777b696995f01934522c402d/k/t/kt_facebook.jpg",
                    "https://youtu.be/QGlgPf9jGMA",
                    "12/04/2024",1},

                    {12,"MÙA HÈ CỦA LUCA",
                    "\"Mùa Hè Của Luca\" kể về chuyến hành trình của cậu bé Luca tại hòn đảo Portorosso thuộc vùng biển Địa Trung Hải ở Ý tuyệt đẹp. Ở đây cậu đã làm quen và kết thân với những người bạn nhỏ mới và tận hưởng mùa hè đầy nắng, kem Gelato và cả món mì Ý trứ danh. Tuy nhiên có một điều không ổn lắm, Luca là một THỦY QUÁI và những người dân trên hòn đảo này lại không thích điều này chút nào.",
                    "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/r/s/rsz_1200x1800_2.jpg",
                    "https://youtu.be/FzV3gRevq4Q",
                    " 18/04/2024",7}
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
