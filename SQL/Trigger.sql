--Trigger
----- add refund in wallet if booking is done using wallet
Create trigger AddWallet
on Booking
after update 
as 
begin
		if update(CancelBooking)
		begin
			update UserDetail set wallet += (select Amount from inserted) 
			where UserDetail.UserId in (select ud.UserId from inserted 
										join UserMapping um on um.UserMapId=inserted.UserMapId
										join UserDetail ud on ud.UserId=inserted.UserMapId
										join Payment p on p.PaymentId=inserted.PaymentId
										where p.PaymentId=3)
		end
end	

select * from Booking

select * from UserDetail

update Booking set CancelBooking=0 where BookingId =3

---------------------------------------------------------------------------------------------------------------------------

create trigger TicketStatusConfirm
on Booking
after delete 
as
begin
	update Booking set TicketStatus=1 where booking.trainId in (select TrainId from deleted)

end

delete from Booking where BookingId=3