﻿namespace BookingMovieTickets.VIewModel
{
    public class VnPaymentResponseModel
    {
        public bool Success { get; set; }
        public string PaymentMethod { get; set; }
        public string OrderDescription { get; set; }
        public string OrderId { get; set; }
        public string PaymentId { get; set; }
        public string TransactionId { get; set; }
        public string Token { get; set; }
        public string VnPayResponseCode { get; set; }

    }

    public class VnPaymentRequestModel
    {
        public int ReceiptId { get; set; }
        public string FullName { get; set; }
        public string Desc { get; set; }       
        public decimal SeatPrice { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
